$(function () {
    const gridData = [
        { id: 1, orderDate: new Date(2023, 0, 10) },
        { id: 2, orderDate: new Date(2024, 5, 15) },
        { id: 3, orderDate: new Date(2024, 7, 20) }
    ];

    $("#grid").dxDataGrid({
        dataSource: gridData,
        keyExpr: "id",
        showBorders: true,

        headerFilter: {
            visible: true
        },

        columns: [
            {
                dataField: "orderDate",
                dataType: "date",

                headerFilter: {
                    dataSource: function (options) {
                        console.log(options);
                        // FIRST LOAD → YEARS
                        if (!options.data) {
                            console.log("Loading Years");
                            options.dataSource = {
                                load: function () {
                                    console.log("API CALL: /years");

                                    return new Promise(resolve => {
                                        setTimeout(() => {
                                            const years = [2023, 2024];

                                            console.log("Years returned:", years);

                                            const finalData = years.map(y => ({
                                                text: y.toString(),
                                                value: [
                                                    ["orderDate", ">=", new Date(y, 0, 1)],
                                                    "and",
                                                    ["orderDate", "<", new Date(y + 1, 0, 1)]
                                                ],
                                                level: "year",
                                                hasItems: true,
                                            }));

                                            resolve(finalData);
                                        }, 500);
                                    });
                                }
                            };
                        }

                        // EXPAND YEAR → MONTHS
                        else if (options.data.level === "year") {
                            const year = options.data.value;

                            console.log(`Loading Months for ${year}`);

                            options.dataSource = {
                                load: function () {
                                    console.log(`API CALL: /months?year=${year}`);

                                    return new Promise(resolve => {
                                        setTimeout(() => {

                                            const months = [
                                                { name: "Jan", index: 0 },
                                                { name: "Feb", index: 1 },
                                                { name: "Mar", index: 2 }
                                            ];

                                            console.log(`Months for ${year}:`, months);

                                            resolve(months.map(m => ({
                                                text: m.name,

                                                // FILTER EXPRESSION
                                                value: [
                                                    ["orderDate", ">=", new Date(year, m.index, 1)],
                                                    "and",
                                                    ["orderDate", "<", new Date(year, m.index + 1, 1)]
                                                ],

                                                level: "month",
                                                hasChildren: false
                                            })));
                                        }, 500);
                                    });
                                }
                            };
                        }
                    }
                }
            }
        ]
    });

});