$(async function () {

    // ================================
    //              Data
    // ================================

    const postStore = new DevExpress.data.CustomStore({
        load: function () {
            return $.ajax({
                url: "https://localhost:7051/api/Data/GetAllPost",
            })
        },
        insert: function (values) {
            return $.ajax({
                url: "https://localhost:7051/api/Data/AddRow",
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },
        remove: function (key) {
            return $.ajax({
                url: `https://localhost:7051/api/Data/DeleteRow?id=${key}`,
                method: "DELETE"
            });
        },

        update: function (key, values) {
            const payload = {
                id: key,
                ...values,
            };

            return $.ajax({
                url: "https://localhost:7051/api/Data/UpdateRow",
                method: "PUT",
                data: JSON.stringify(payload),
                contentType: "application/json",
            })
        },
        byKey: function (key) {
            return $.ajax({
                url: `https://localhost:7051/api/Data/GetPostById?id=${key}`
            })
        },
        loadMode: "raw",
        key: "id",
    });

    const commentStore = new DevExpress.data.CustomStore({
        load: function () {
            if (getSelectedPostId() === undefined || getSelectedPostId() === null) {
                return Promise.resolve([]);
            }
            return $.ajax({
                url: `https://jsonplaceholder.typicode.com/posts/${getSelectedPostId()}/comments`,
            })
        },
        key: "id",
        loadMode: "raw",
    });


    // ===============================
    //             Helpers
    // =============================== 

    function getSelectedPostId() {
        return postBoxInstance.option("value");
    }

    async function getSelectedPostTitle() {
        const id = getSelectedPostId();
        const res = await postStore.byKey(id);
        return res.title;
    }

    function makeTextBox(label, initialValue = "") {
        const $wrapper = $("<div>");

        const $textBox = $("<div>").dxTextBox({ label, value: initialValue });
        $textBox.appendTo($wrapper);

        return {
            $wrapper,
            getValue: () => $textBox.dxTextBox("option", "value"),
        };
    }


    /// #####################################
    ///              Datagrid
    /// #####################################

    // Comment datagrid
    function buildCommentGrid(e) {
        return $("<div>").dxDataGrid({
            dataSource: commentStore,
            columns: [{ dataField: "body" }],
            selection: { mode: "single" },
            onSelectionChanged(args) {
                e.component.option("value", args.selectedRowKeys[0]);
                e.component.close();
            },
        });
    }


    // Post content
    function buildPostGridContent(e) {
        const $wrapper = $("<div>");


        // datagrid
        $("<div>").dxDataGrid({
            keyExpr: "id",
            dataSource: e.component.getDataSource(),
            paging: { enabled: true, pageSize: 10 },
            selection: { mode: "single" },
            columns: [
                { dataField: "title" },
            ],
            onSelectionChanged: async function (args) {
                const postId = args.selectedRowKeys[0];
                console.log("Selected post:", postId);

                e.component.option("value", postId);
                e.component.close();

                localStorage.setItem("lastSelectedPost", postId);

                await commentStore.load();
                commentBoxInstance.getDataSource().reload();
                commentBoxInstance.repaint();
            },
        }).appendTo($wrapper);

        // Action Buttons
        const $actions = $("<div>");

        let inputTextBox = null;

        function removeInputTextBox() {
            if (inputTextBox) {
                inputTextBox.remove();
                inputTextBox = null;
            }
        }

        function attachSaveButton(getValue, onSave) {
            $("<div>").dxButton({
                text: "Save",
                onClick: async function () {
                    await onSave(getValue());
                    removeInputTextBox();
                    postBoxInstance.getDataSource().reload();
                },
            }).appendTo(inputTextBox);
        }

        // Add
        $("<div>").dxButton({
            text: "Add",
            onClick: function () {
                removeInputTextBox();
                const { $wrapper, getValue } = makeTextBox("Title");
                inputTextBox = $wrapper; 
                $wrapper.appendTo($actions);

                attachSaveButton(getValue, async (title) => {
                    await postStore.insert({ title });
                });
            },
        }).appendTo($actions);

        // Update
        $("<div>").dxButton({
            text: "Update",
            onClick: async function () {
                removeInputTextBox();
                const { $wrapper, getValue } = makeTextBox("Title", await getSelectedPostTitle());
                inputTextBox = $wrapper;  
                $wrapper.appendTo($actions);

                attachSaveButton(getValue, async (title) => {
                    await postStore.update(getSelectedPostId(), { title });
                    postBoxInstance.repaint();
                });
            },
        }).appendTo($actions);

        // Delete
        $("<div>").dxButton({
            text: "Delete",
            onClick: async function () {
                await postStore.remove(getSelectedPostId());
                postBoxInstance.option("value", undefined);
                localStorage.removeItem("lastSelectedPost");
                postBoxInstance.repaint();
                commentBoxInstance.getDataSource().reload();
                commentBoxInstance.repaint();
            },
        }).appendTo($actions);

        $actions.appendTo($wrapper);
        return $wrapper;
    }

    // ######################
    //      dropdownbox
    // ######################

    const postBoxInstance = $("#posts")
        .dxDropDownBox({
            dataSource: postStore,
            keyExpr: "id",
            displayExpr: "title",
            deferRendering: true,
            contentTemplate: buildPostGridContent,
            onContentReady: async function (e) {
                const raw = localStorage.getItem("lastSelectedPost");
                if (raw == null) return;

                const postId = parseInt(raw);
                e.component.option("value", postId);
            },
        })
        .dxDropDownBox("instance");

    const commentBoxInstance = $("#postsComments")
        .dxDropDownBox({
            dataSource: commentStore,
            displayExpr: "body",
            deferRendering: false,
            contentTemplate: buildCommentGrid,
        })
        .dxDropDownBox("instance");

});