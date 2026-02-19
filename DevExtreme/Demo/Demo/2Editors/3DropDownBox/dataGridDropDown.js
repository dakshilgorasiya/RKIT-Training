$(async () => {
    let jsonData = await $.getJSON("data.json");

    $("#dropDownBox").dxDropDownBox({

        dataSource: jsonData,
        value: [],
        valueExpr: "ID",
        displayExpr: "ID",

        displayValueFormatter: function (value) {
            //if (!value || value.length === 0) return "";
            const items = jsonData.filter(item => value.includes(item.ID));
            return items.map(item => item.CompanyName).join(", ");
        },

        contentTemplate: function (e) {

            const $grid = $("<div>").dxDataGrid({
                dataSource: jsonData,
                keyExpr: "ID",

                columns: ["ID", "CompanyName", "City", "State", "Zipcode", "Phone", "Fax", "Website"],

                selection: {
                    mode: "multiple"
                },

                onSelectionChanged: function (args) {
                    e.component.option("value", args.selectedRowKeys);
                }
            });

            gridInstance = $grid.dxDataGrid("instance");

            return $grid;
        },

        onValueChanged: function (e) {
            //if (gridInstance) {
            //    gridInstance.selectRows(e.value, false
        },

        opened: true

    }).dxDropDownBox("instance");
});
