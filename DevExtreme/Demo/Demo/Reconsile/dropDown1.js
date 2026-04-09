$(async function () {

    // ================================
    //              Data
    // ================================

    const posts = await $.getJSON(`https://jsonplaceholder.typicode.com/posts`);

    const postStore = new DevExpress.data.ArrayStore({
        data: posts,
        key: "id",
    });

    const commentStore = new DevExpress.data.ArrayStore({
        data: [],
        key: "id",
    });


    // ===============================
    //             Helpers
    // =============================== 

    async function loadComments(postId) {
        const tempComments = await $.getJSON(
            `https://jsonplaceholder.typicode.com/posts/${postId}/comments`
        );

        await commentStore.clear();

        for (const comment of tempComments) {
            await commentStore.insert(comment);
        }
        commentBoxInstance.repaint();
    }

    function getSelectedPostId() {
        return postBoxInstance.option("value");
    }

    function getSelectedPostTitle() {
        const id = getSelectedPostId();
        return posts.find((p) => p.id === id)?.title ?? "";
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
            columns: [
                {
                    dataField: "body",
                    headerCellTemplate: function () {

                    }
                }
            ],
            selection: { mode: "single" },
            onSelectionChanged(args) {
                e.component.option("value", args.selectedRowKeys[0]);
                e.component.close();

                localStorage.setItem("lastSelectedComment", args.selectedRowKeys[0]);
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
                {
                    dataField: "title",
                    headerCellTemplate: function () {

                    }
                },
            ],
            onSelectionChanged: async function (args) {
                const postId = args.selectedRowKeys[0];
                console.log("Selected post:", postId);

                e.component.option("value", postId);
                e.component.close();

                localStorage.setItem("lastSelectedPost", postId);
                localStorage.removeItem("lastSelectedComment");

                await loadComments(postId);
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
                    await fetch("https://jsonplaceholder.typicode.com/posts", {
                        method: "POST",
                        body: JSON.stringify({ title })
                    });

                    await postStore.insert({ title });
                });
            },
        }).appendTo($actions);

        // Update
        $("<div>").dxButton({
            text: "Update",
            onClick: function () {
                removeInputTextBox();
                const { $wrapper, getValue } = makeTextBox("Title", getSelectedPostTitle());
                inputTextBox = $wrapper;
                $wrapper.appendTo($actions);

                attachSaveButton(getValue, async (title) => {
                    await fetch(`https://jsonplaceholder.typicode.com/posts/${getSelectedPostId()}`, {
                        method: "PUT",
                        body: JSON.stringify({ title })
                    });

                    await postStore.update(getSelectedPostId(), { title });
                    postBoxInstance.repaint();
                });
            },
        }).appendTo($actions);

        // Delete
        $("<div>").dxButton({
            text: "Delete",
            onClick: async function () {
                await fetch(`https://jsonplaceholder.typicode.com/posts/${getSelectedPostId()}`, {
                    method: "DELETE"
                });
                localStorage.removeItem("lastSelectedPost");
                localStorage.removeItem("lastSelectedComment");
                await postStore.remove(getSelectedPostId());
                postBoxInstance.repaint();
                await commentStore.clear();
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
            contentTemplate: buildPostGridContent,
            onContentReady: async function (e) {
                const raw = localStorage.getItem("lastSelectedPost");
                if (raw == null) return;

                const postId = parseInt(raw);
                e.component.option("value", postId);

                await loadComments(postId);
            },
        })
        .dxDropDownBox("instance");

    const commentBoxInstance = $("#postsComments")
        .dxDropDownBox({
            dataSource: commentStore,
            displayExpr: "body",
            contentTemplate: buildCommentGrid,
            onContentReady: async function (e) {
                const raw = localStorage.getItem("lastSelectedComment");
                if (raw == null) return;

                const commentId = parseInt(raw);
                e.component.option("value", commentId);
            }
        })
        .dxDropDownBox("instance");

});