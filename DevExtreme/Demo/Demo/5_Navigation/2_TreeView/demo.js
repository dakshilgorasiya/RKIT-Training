$(() => {
    $("#treeHierarchical").dxTreeView({
        items: [
            {
                id: 1,
                text: "Electronics",
                expanded: true,
                items: [
                    {
                        id: 2,
                        text: "Mobile",
                        items: [
                            { id: 3, text: "Android" },
                            { id: 4, text: "iOS" }
                        ]
                    },
                    {
                        id: 5,
                        text: "Laptop"
                    }
                ]
            }
        ],
        displayExpr: "text",
        showCheckBoxesMode: "normal",
    });

    $("#treePlain").dxTreeView({
        items: [
            { id: 1, text: "Electronics", parentId: 0 },
            { id: 2, text: "Mobile", parentId: 1 },
            { id: 3, text: "Android", parentId: 2 },
            { id: 4, text: "iOS", parentId: 2 },
            { id: 5, text: "Laptop", parentId: 1 }
        ],

        dataStructure: "plain",
        keyExpr: "id",
        parentIdExpr: "parentId",
        displayExpr: "text",

        // the items who have parentId == rootValue will be
        rootValue: 0,
        showCheckBoxesMode: "normal",
    });

});