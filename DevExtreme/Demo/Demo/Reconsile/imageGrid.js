$(async () => {
    const data = await $.getJSON(`https://picsum.photos/v2/list`);
    const store = new DevExpress.data.ArrayStore({
        data
    });
    const grid = function (e) {
        const $wrapper = $("<div>");

        const $grid = $("<div>").dxDataGrid({
            dataSource: e.component.getDataSource(),
            paging: {
                enabled: true,
                pageSize: 10,
            },
            columns: [
                {
                    dataField: "download_url",
                    cellTemplate: function (container, options) {
                        $("<img>")
                            .attr("src", options.value)
                            .css({
                                width: "50px"
                            })
                            .appendTo(container);
                    },
                },
                "author",
            ]
        }).appendTo($wrapper);

        return $wrapper;
    }

    const dropDown = $("#dropDown").dxDropDownBox({
        contentTemplate: grid,
        dataSource: store,
    });
});