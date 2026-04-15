$(() => {
    window.jsPDF = window.jspdf.jsPDF;

    let store = new DevExpress.data.CustomStore({
        load: function (loadOptions) {
            console.log(loadOptions)
            let d = $.Deferred();
            let queryParams = $.extend({}, loadOptions);
            if (queryParams.filter) queryParams.filter = JSON.stringify(queryParams.filter);
            if (queryParams.sort) queryParams.sort = JSON.stringify(queryParams.sort);
            if (queryParams.select) queryParams.select = JSON.stringify(queryParams.select);
            if (queryParams.group) queryParams.group = JSON.stringify(queryParams.group);
            if (queryParams.groupSummary) queryParams.groupSummary = JSON.stringify(queryParams.groupSummary);
            if (queryParams.totalSummary) queryParams.totalSummary = JSON.stringify(queryParams.totalSummary);
            if (queryParams.searchExpr) queryParams.searchExpr = JSON.stringify(queryParams.searchExpr);
            if (queryParams.userData) queryParams.userData = JSON.stringify(queryParams.userData);
            $.getJSON("http://localhost:5203/api/Data/GetRecords", queryParams)
                .done(res => {
                    d.resolve({
                        data: res.data,
                        totalCount: res.totalCount,
                        summary: res.summary,
                        groupCount: res.groupCount
                    });
                })
                .fail((xhr) => {
                    d.reject("Data Load Error");
                });
            return d.promise();
        },

        //load: function (loadOptions) {
        //    return $.ajax({
        //        url: "https://localhost:7059/api/Data/GetAll",
        //        method: "GET",
        //    });
        //},

        insert: function (values) {
            values.sale_Date = new Date(values.sale_Date);

            return $.ajax({
                url: "https://localhost:7059/api/Data/Add",
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        remove: function (key) {
            return $.ajax({
                url: `https://localhost:7059/api/Data/Delete?id=${key}`,
                method: "DELETE"
            });
        },

        key: "id",
        loadMode: "processed",

        update: function (key, values) {
            const payload = {
                id: key,
                ...values,
            };

            return $.ajax({
                url: "https://localhost:7059/api/Data/Update",
                method: "PUT",
                data: JSON.stringify(payload),
                contentType: "application/json",
            })
        }
    });

    let gridInstance = $("#grid").dxDataGrid({
        dataSource: store,
        cacheEnabled: true,
        columnAutoWidth: true,
        allowColumnResizing: true,
        allowColumnReordering: true,
        wordWrapEnabled: true,

        remoteOperations: true,

        toolbar: {
            visible: true,
            items: [
                "addRowButton",
                "columnChooserButton",
                "exportButton",
                {
                    locateInMenu: "never",
                    widget: "dxButton",
                    options: {
                        text: "Toggle Selection",
                        onClick: function () {
                            const currentMode = gridInstance.option("selection.mode");

                            if (currentMode === "none") {
                                gridInstance.option("selection", {
                                    mode: "multiple",
                                });
                                gridInstance.option("export", {
                                    allowExportSelectedData: true,
                                });
                            } else {
                                gridInstance.option("selection", {
                                    mode: "none"
                                });
                                gridInstance.option("export", {
                                    allowExportSelectedData: false,
                                });
                            }
                        }
                    }
                },
                "searchPanel",
            ],
        },

        columnChooser: {
            enabled: true,
            mode: "select",
            search: {
                enabled: true,
            },
            selection: {
                allowSelectAll: true,
                recursive: true,
                selectByClick: true
            }
        },

        stateStoring: {
            enabled: true,
            savingTimeout: 2000,
            storageKey: "gridState",
            type: "localStorage"
        },

        grouping: {
            contextMenuEnabled: true,
            autoExpandAll: false,
        },

        export: {
            enabled: true,
            formats: ["xlsx", "pdf"],
            allowExportSelectedData: false,
        },

        onExporting: function (e) {



            if (e.format === 'xlsx') {
                const workbook = new ExcelJS.Workbook();
                const worksheet = workbook.addWorksheet("Orders");

                e.component.columnOption("shipping_Details", "visible", true);
                e.component.columnOption("shipping_Address.street", "visible", true);
                e.component.columnOption("shipping_Address.city", "visible", true);
                e.component.columnOption("shipping_Address.state", "visible", true);


                DevExpress.excelExporter.exportDataGrid({
                    component: e.component,
                    worksheet,
                    autoFilterEnabled: true,
                    customizeCell: function (options) {
                        const gridCell = options.gridCell;

                        if (gridCell.rowType === "totalFooter") {
                            options.excelCell.value = null;
                        }

                        if (gridCell.rowType === "groupFooter") {
                            options.excelCell.value = null;
                        }
                    }
                }).then(() => {
                    e.component.columnOption("shipping_Details", "visible", false);
                    e.component.columnOption("shipping_Address.street", "visible", false);
                    e.component.columnOption("shipping_Address.city", "visible", false);
                    e.component.columnOption("shipping_Address.state", "visible", false);

                    workbook.xlsx.writeBuffer().then((buffer) => {
                        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), "Order.xlsx")
                    });
                });
            }
            else if (e.format === 'pdf') {
                //let originalSummary = gridInstance.option("summary");
                //gridInstance.option("summary", {});
                const doc = new jsPDF({
                    orientation: "landscape"
                });

                DevExpress.pdfExporter.exportDataGrid({
                    jsPDFDocument: doc,
                    component: e.component,
                    customizeCell: function (options) {
                        const { pdfCell, gridCell } = options;

                        if (gridCell.rowType === "data" && gridCell.column.name == "total") {
                            let sale_Price = gridCell.data.sale_Price;
                            let quantity = gridCell.data.quantity;

                            pdfCell.text = (sale_Price * quantity).toFixed(2);
                        }

                        if (gridCell.rowType === "data" && gridCell.column.name == "bill") {
                            let sale_Price = gridCell.data.sale_Price;
                            let discount = gridCell.data.discount;
                            let quantity = gridCell.data.quantity;

                            pdfCell.text = ((sale_Price * quantity) - (sale_Price * quantity * discount / 100)).toFixed(2);
                        }

                        if (gridCell.rowType === "data" && gridCell.column.name == "sale_Price") {
                            let sale_Price = gridCell.data.sale_Price;

                            pdfCell.text = (sale_Price).toFixed(2);
                        }


                        pdfCell.font.size = 8;
                    }
                }).then(() => {
                    doc.save('Orders.pdf');
                });
                //gridInstance.option("summary", originalSummary);
            }

        },

        editing: {
            allowAdding: true,
            allowDeleting: true,
            allowUpdating: true,
            mode: "form",
            useIcons: true,

            form: {
                items: [
                    {
                        itemType: "group",
                        caption: "Product Details",
                        items: [
                            {
                                dataField: "product_Name"
                            },
                            {
                                dataField: "product_Category"
                            }
                        ]
                    },
                    {
                        itemType: "group",
                        caption: "Selling Details",
                        items: [
                            {
                                dataField: "sale_Date"
                            },
                            {
                                dataField: "sale_Price"
                            },
                            {
                                dataField: "discount"
                            },
                            {
                                dataField: "quantity"
                            }
                        ]
                    },
                    {
                        itemType: "group",
                        caption: "Shipping Address",
                        items: [
                            {
                                dataField: "shipping_Address.street"
                            },
                            {
                                dataField: "shipping_Address.city"
                            },
                            {
                                dataField: "shipping_Address.state"
                            }
                        ]
                    },
                    {
                        itemType: "group",
                        caption: "Other",
                        items: [
                            {
                                dataField: "payment_Method"
                            },
                            {
                                dataField: "review"
                            }
                        ]
                    }
                ],
                colCount: 2,
            },
        },

        paging: {
            enabled: true,
            pageSize: 15,
        },

        pager: {
            allowedPageSizes: [5, 10, 15, 20, 50],
            infoText: "Page {0} of {1} (Total {2} orders)",
            showPageSizeSelector: true,
            showNavigationButtons: true,
            showInfo: true,
            visible: true
        },

        headerFilter: {
            visible: true,
            search: {
                enabled: true,
            }
        },

        filterPanel: {
            visible: true,
        },

        filterRow: {
            visible: true,
        },

        filterSyncEnabled: true,

        searchPanel: {
            visible: true,
        },

        summary: {
            recalculateWhileEditing: true,
            groupItems: [
                //{
                //    column: "bill",
                //    summaryType: "avg",
                //    showInGroupFooter: true,
                //    valueFormat: {
                //        type: "fixedPoint",
                //        precision: 2
                //    },
                //},
                //{
                //    column: "bill",
                //    summaryType: "sum",
                //    showInGroupFooter: true,
                //    valueFormat: {
                //        type: "fixedPoint",
                //        precision: 2
                //    },
                //},
                {
                    column: "quantity",
                    summaryType: "sum",
                    showInGroupFooter: true,
                },
                {
                    column: "id",
                    summaryType: "count",
                    customizeText: function (value) {
                        return "Total orders : " + value.value;
                    }
                }
            ],
            totalItems: [
                //{
                //    column: "bill",
                //    summaryType: "avg",
                //    showInGroupFooter: true,
                //    valueFormat: {
                //        type: "fixedPoint",
                //        precision: 2
                //    },
                //},
                //{
                //    column: "bill",
                //    summaryType: "sum",
                //    showInGroupFooter: true,
                //    valueFormat: {
                //        type: "fixedPoint",
                //        precision: 2
                //    },
                //},
                {
                    column: "quantity",
                    summaryType: "sum",
                    showInGroupFooter: true,
                }
            ]
        },

        sorting: {
            mode: "multiple",
        },

        masterDetail: {
            enabled: true,
            template: function (container, options) {
                const data = options.data;
                const address = data.shipping_Address;

                const wrapper = $("<div>");

                $("<div>").text("Shipping address").appendTo(wrapper);
                $("<div>").text("Street : " + address.street).appendTo(wrapper);
                $("<div>").text("City : " + address.city).appendTo(wrapper);
                $("<div>").text("State : " + address.state).appendTo(wrapper);

                wrapper.appendTo(container);
            }
        },

        columns: [
            {
                dataField: "id",
                caption: "Order Id",
                alignment: "center",
                allowEditing: false,
                sortIndex: 0,
                sortOrder: "asc",
                allowHeaderFiltering: false,
            },
            {
                caption: "Product",
                alignment: "center",
                columns: [
                    {
                        dataField: "product_Name",
                        caption: "Product Name",
                        alignment: "center",
                        validationRules: [
                            {
                                type: "required",
                                message: "Product name is required",
                                trim: true,
                            }
                        ],
                    },
                    {
                        dataField: "product_Category",
                        caption: "Product Category",
                        alignment: "center",
                        validationRules: [
                            {
                                type: "required",
                                message: "Product category is required",
                                trim: true,
                            }
                        ],
                        lookup: {
                            dataSource: [
                                "Gaming",
                                "Books",
                                "Clothing",
                                "Electronics",
                                "Shoes",
                            ]
                        }
                    }
                ]
            },
            {
                caption: "Selling Details",
                alignment: "center",
                columns: [
                    {
                        dataField: "sale_Date",
                        caption: "Sale Date",
                        alignment: "center",
                        dataType: "date",
                        format: "dd-MM-yyyy",
                        editorOptions: {
                            displayFormat: "dd-MM-yyyy",
                            pickerType: "calendar",
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Sale date is required",
                                trim: true,
                            }
                        ],
                    },
                    {
                        dataField: "sale_Price",
                        caption: "Sale Price Per unit",
                        alignment: "center",
                        format: {
                            type: "currency",
                            currency: "INR"
                        },
                        setCellValue: function (newData, value) {
                            newData.sale_Price = value;
                            newData.total = value * (newData.quantity || 0);
                            newData.bill = newData.total - (newData.total * newData.discount / 100);
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Sale price is required",
                                trim: true,
                            },
                            {
                                type: "range",
                                min: 0,
                                message: "Negative value is not allowed"
                            }
                        ],
                        headerFilter: {
                            groupInterval: 50,
                        },
                    },
                    {
                        dataField: "discount",
                        caption: "Discount",
                        alignment: "center",
                        format: {
                            formatter: function (value) {
                                return value + "%";
                            }
                        },
                        setCellValue: function (newData, value) {
                            newData.discount = value;
                            newData.total = newData.sale_Price * (newData.quantity || 0);
                            newData.bill = newData.total - (newData.total * newData.discount / 100);
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Discount is required",
                                trim: true,
                            },
                            {
                                type: "range",
                                min: 0,
                                max: 100,
                                message: "Discount must be between 0 to 100"
                            }
                        ],
                        headerFilter: {
                            groupInterval: 5,
                        },
                    },
                    {
                        dataField: "quantity",
                        caption: "Quantity",
                        alignment: "center",
                        editorOptions: {
                            format: "#0"
                        },
                        setCellValue: function (newData, value) {
                            newData.quantity = value;
                            newData.total = newData.sale_Price * (value || 0);
                            newData.bill = newData.total - (newData.total * newData.discount / 100);
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Quantity is required",
                                trim: true,
                            },
                            {
                                type: "range",
                                message: "Quantity must be greater than 0",
                                min: 1,
                            }
                        ],
                    },
                    //{
                    //    dataField: "total",
                    //    caption: "Total bill price",
                    //    calculateCellValue: function (data) {
                    //        return data.sale_Price * data.quantity;
                    //    },
                    //    format: {
                    //        type: "currency",
                    //        currency: "INR",
                    //        precision: 2,
                    //    },
                    //    alignment: "center",
                    //    allowEditing: false,
                    //    headerFilter: {
                    //        groupInterval: 1000,
                    //    },
                    //},
                    //{
                    //    dataField: "bill",
                    //    caption: "Bill after discount",
                    //    calculateCellValue: function (data) {
                    //        return (data.sale_Price * data.quantity) - ((data.discount / 100) * (data.sale_Price * data.quantity));
                    //    },
                    //    format: {
                    //        type: "currency",
                    //        currency: "INR",
                    //        precision: 2,
                    //    },
                    //    alignment: "center",
                    //    allowEditing: false,
                    //    headerFilter: {
                    //        groupInterval: 1000,
                    //    },
                    //}
                ]
            },
            {
                caption: "Shipping Details",
                alignment: "center",
                showInColumnChooser: false,
                allowExporting: true,
                visible: false,
                dataField: "shipping_Details",
                columns: [
                    {
                        dataField: "shipping_Address.street",
                        visible: false,
                        showInColumnChooser: false,
                        caption: "Street",
                        validationRules: [
                            {
                                type: "required",
                                message: "Street is required",
                                trim: true,
                                allowExporting: true,
                            },
                        ],
                    },
                    {
                        dataField: "shipping_Address.city",
                        visible: false,
                        showInColumnChooser: false,
                        caption: "City",
                        validationRules: [
                            {
                                type: "required",
                                message: "City is required",
                                trim: true,
                                allowExporting: true,
                            },
                        ],
                    },
                    {
                        dataField: "shipping_Address.state",
                        visible: false,
                        showInColumnChooser: false,
                        caption: "State",
                        validationRules: [
                            {
                                type: "required",
                                message: "State is required",
                                trim: true,
                                allowExporting: true,
                            },
                        ],
                    },
                ],
            },
            {
                dataField: "payment_Method",
                caption: "Payment Method",
                alignment: "center",
                validationRules: [
                    {
                        type: "required",
                        message: "Payment method is required",
                        trim: true,
                    }
                ],
                lookup: {
                    dataSource: [
                        "apple pay",
                        "google pay",
                        "paytm",
                        "NTFS",
                        "cash"
                    ]
                }
            },
            {
                dataField: "review",
                captin: "Review",
                alignment: "center",
                validationRules: [
                    {
                        type: "required",
                        message: "Review is required",
                        trim: true,
                    },
                    {
                        type: "range",
                        message: "Review should be between 1 to 5",
                        min: 1,
                        max: 5,
                    }
                ],
            }
        ],

        onInitNewRow: function (e) {
            e.data.sale_Price = 0;
            e.data.quantity = 1;
            e.data.discount = 0;
        },
    }).dxDataGrid("instance");
});