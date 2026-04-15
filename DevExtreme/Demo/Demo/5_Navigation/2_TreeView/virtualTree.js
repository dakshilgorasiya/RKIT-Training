$(() => {
    $("#tree").dxTreeView({
        dataStructure: "plain",
        keyExpr: "id",
        parentIdExpr: "parentId",

        virtualModeEnabled: false,

        // parentNode have {children, disabled, expanded, itemData, items, key, parent, selected, text}
        // for root node parentNode will be null which will be called when treeView is rendered
        // it can also return promise
        createChildren: function (parentNode) {
            if (!parentNode) {
                return [{ id: 1, text: "Electronics", hasItems: true }];
            }
            if (parentNode.key === 1) {
                return [
                    { id: 2, parentId: 1, text: "Mobile", hasItems: true },
                    { id: 3, parentId: 1, text: "Laptop", hasItems: false }
                ];
            }
            if (parentNode.key === 2) {
                return [
                    { id: 4, parentId: 2, text: "Android", hasItems: false },
                    { id: 5, parentId: 2, text: "iOS", hasItems: false }
                ];
            }
        }
    });
});