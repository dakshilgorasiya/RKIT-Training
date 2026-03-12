$(() => {
    let products = [
        { Id: 1, Name: "Laptop", Price: 70000, Category: "Electronics" },
        { Id: 2, Name: "Phone", Price: 30000, Category: "Electronics" },
        { Id: 3, Name: "Table", Price: 5000, Category: "Furniture" },
        { Id: 4, Name: "Chair", Price: 2000, Category: "Furniture" },
        { Id: 5, Name: "Headphones", Price: 3000, Category: "Electronics" },
        { Id: 6, Name: "Pen", Price: 50, Category: "Stationary" },
        { Id: 7, Name: "Notebook", Price: 100, Category: "Stationary" }
    ];

    let store = new DevExpress.data.LocalStore({
        key: "Id",
        data: products,
        name: "productData"
    });

    $("#grid").dxDataGrid({
        dataSource: store,

        // Specifies a delay in milliseconds between when data changes and the moment these changes are saved in the local storage
        // Applies only if immediate is false.
        flushInterval: 2000,

        // Specifies whether the LocalStore saves changes in the local storage immediately.
        immediate: false,
    });
});