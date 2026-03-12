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

    let store = new DevExpress.data.ArrayStore({
        data: products,
        key: "Id"
    });

    let dataSource = new DevExpress.data.DataSource({
        // If We specify load function and other function of store it will override store's function
        //load: function () { },

        // Specifies data filtering conditions.
        //filter: ["!", ["Category", "=", "Electronics"]],

        // Specifies data grouping properties.
        //group: "Category",
        //group: {
        //    selector: "Category",
        //    desc: true, // which group to display first
        //},
        //group: ["Category"], // also possible to give array of object
        //group: function (e) {
        //    return e.Price > 10000 ? "Costly" : "Cheap";
        //},

        // Use this property to include language-specific parameters in sorting and filtering operations performed on a client. For example, you can use langParams to make DataSource ignore letters with diacritic symbols.
        langParams: {
            // Specifies the locale whose features affect sorting and filtering.
            locale: 'fr',

            // Specifies Intl.Collator options.
            collatorOptions: {
                sensitivity: 'accent',
                caseFirst: 'upper'
            }
        },

        // Specifies an item mapping function.
        // Can add extra column and derive it from other column
        // DataGrid and TreeList features like export, selection, and grouping work incorrectly with mapped data objects. If you need these features, use calculated columns instead of mapped objects.
        //map: function (item) {
        //    return {
        //        Id: item.Id,
        //        Name: item.Name,
        //        Price: item.Price,
        //        PriceAfterTax: item.Price * 1.1,
        //        Category: item.Category,
        //    }
        //},

        // A function that is executed after data is loaded.
        // e has Array of changed but Appears only when the push(changes) method is called and the reshapeOnPush property is false.
        //onChanged: function (e) {
        //    console.log("onChanged");
        //    console.log(e);
        //},

        // A function that is executed when data loading fails.
        // e has {message:string}
        onLoadError: function (e) {
            console.log("onLoadError");
            console.log(e.message);
        },

        // A function that is executed when the data loading status changes.
        //onLoadingChanged: function (isLoading) {
        //    console.log("onLoadingChanged", isLoading);
        //},

        // Specifies the maximum number of data items per page. Applies only if paginate is true.
        pageSize: 5,

        // Specifies whether the DataSource loads data items by pages or all at once. Defaults to false if group is set; otherwise, true.
        paginate: true,

        // Specifies a post processing function.
        //postProcess: function (data) {
        //    console.log("PostProcess");
        //},

        // Specifies the period (in milliseconds) when changes are aggregated before pushing them to the DataSource.
        // When this property is undefined, the aggregation period is calculated automatically based on the rendering speed's measurements.
        pushAggregationTimeout: 100,

        // Specifies whether the DataSource requests the total count of data items in the storage.
        // If this property is set to true, the Promise that the load() method returns is resolved with a second argument that contains the totalCount field:
        requireTotalCount: true,

        // Specifies whether to reapply sorting, filtering, grouping, and other data processing operations after receiving a push.
        reshapeOnPush: false,

        // Specifies the fields to search.
        // In most cases, you should pass the name of a field by whose value data items are searched. Assign an array of field names to this property if you need to search elements by several field values.
        //searchExpr: ["Id", "Name", "Category"],

        // Specifies the comparison operation used in searching.
        //searchOperation: "contains",

        // Specifies the value to which the search expression is compared.
        //searchValue: "Ele",

        // Specifies data sorting properties.
        //sort: "Price",
        //sort: {
        //    selector: "Price",
        //    desc: true,
        //},
        //sort: ["Price", "Id"],

        // Specifies the fields to select from data objects.
        //select: ["Id", "Price"],

        // Configures the store underlying the DataSource.
        store: store,
        //store: products, // Assigning an array to the store property automatically creates an ArrayStore in the DataSource.
    });

    dataSource.load().done(function (data, extra) {
        console.log(data);
        console.log(extra);
    });

    // METHODS

    // Cancels the load operation with a specific identifier.
    // Calling this method does not interrupt the HTTP request.
    //let loadPromise = dataSource.load().done(function (result) {
    //    console.log("Load promise resolved");
    //    console.log(result);
    //});
    //dataSource.cancel(loadPromise.operationId);

    // Disposes of all the resources allocated to the DataSource instance.
    //dataSource.dispose();

    // Gets the filter property's value.
    //console.log("Filter: ", dataSource.filter());

    // Sets the filter property's value.
    //dataSource.filter(["Category", "contains", "Ele"]);

    // Gets the group property's value.
    //console.log("Group: ", dataSource.group());

    // Sets the group property's value.
    //dataSource.group("Category");

    // Checks whether the count of items on the current page is less than the pageSize. Takes effect only with enabled paging.
    console.log("isLastPage: ", dataSource.isLastPage());

    // Checks whether data is loaded in the DataSource.
    console.log("isLoaded: ", dataSource.isLoaded());

    // Checks whether data is being loaded in the DataSource.
    console.log("isLoading: ", dataSource.isLoading());

    // Gets an array of data items on the current page.
    console.log("items: ", dataSource.items());

    // Gets the value of the underlying store's key property.
    console.log("key: ", dataSource.key());

    // Starts loading data.
    //dataSource.load().done((data, extra) => {
    //    console.log("Loaded");
    //    console.log(data);
    //    console.log(extra);
    //});

    // Gets an object with current data processing settings.
    console.log("loadOptions: ", dataSource.loadOptions());

    // off, on for event handling

    // Gets the current page index.
    console.log("pageIndex: ", dataSource.pageIndex());

    // Sets the index of the page that should be loaded on the next load() method call.
    // Call the load() method to update the UI component bound to the DataSource:
    //dataSource.pageIndex(1);

    // Gets the page size.
    console.log("pageSize: ", dataSource.pageSize());

    // Sets the page size.
    dataSource.pageSize(4);

    // Gets the paginate property's value.
    console.log("paginate: ", dataSource.paginate());

    // Sets the paginate property's value
    dataSource.paginate(false);
    dataSource.load();

    // Clears currently loaded DataSource items and calls the load() method.
    // DataSource reloads data starting from the current page index. To reload all data, set pageIndex to 0 before you call reload().
    // The Promise returned from this method is extended with the operationId field which you can use to cancel the invoked operation.
    dataSource.reload().done((data) => {
        console.log("Reload", data);
    });

    // Other methods
    // requireTotalCount(), requireTotalCount(value)
    // searchExpr(), searchExpr(expr)
    // searchOperation(), searchOperation(op)
    // searchValue(), searchValue(value)
    // select(), select(expr)
    // sort(), sort(sortExpr)

    // Gets the instance of the store underlying the DataSource.
    //let store = dataSource.store();

    // Gets the number of data items in the store after the last load() operation without paging. Takes effect only if requireTotalCount is true
    console.log("totalCount: ", dataSource.totalCount());
        

    // EVENTS
    // changed: Raised after data is loaded.
    // loadError: Raised when data loading fails.
    // loadingChanged: Raised when the data loading status is changed.

    store.push([
        {
            type: "insert",
            data: {
                Id: 1,
                Name: "Laptop",
                Price: 70000,
                Category: "Electronics"
            }
        }
    ]);

    $("#grid").dxDataGrid({
        dataSource: dataSource,
    });
});