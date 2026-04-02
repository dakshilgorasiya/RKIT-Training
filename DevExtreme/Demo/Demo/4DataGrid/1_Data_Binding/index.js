$(() => {
    let data = [
        { Id: 1, Name: "Laptop", Price: 70000, Category: "Electronics" },
        { Id: 2, Name: "Phone", Price: 30000, Category: "Electronics" },
        { Id: 3, Name: "Table", Price: 5000, Category: "Furniture" },
        { Id: 4, Name: "Chair", Price: 2000, Category: "Furniture" },
        { Id: 5, Name: "Headphones", Price: 3000, Category: "Electronics" },
        { Id: 6, Name: "Pen", Price: 50, Category: "Stationary" },
        { Id: 7, Name: "Notebook", Price: 100, Category: "Stationary" }
    ]

    $("#grid1").dxDataGrid({
        dataSource: data,

        columns: [
            { dataField: "Id", caption: "ID no." },
            { dataField: "Name", caption: "Name" },
            { dataField: "Price", caption: "MRP" },
            { dataField: "Category", caption: "Category" }
        ]
    });


    let customStore = new DevExpress.data.CustomStore({
        load: function (loadOptions) {
            return $.ajax({
                url: "https://localhost:7051/api/Data/GetAllPost",
                method: "GET"
            })
        }
    });

    $("#grid2").dxDataGrid({
        dataSource: customStore,
    })
});