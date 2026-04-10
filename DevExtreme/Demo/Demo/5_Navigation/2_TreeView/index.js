import { products } from "./product.js"

$(() => {
    let treeView = $("#treeview").dxTreeView({
        collapseIcon: "minus",
        expandIcon: "plus",

        dataSource: products,

        // Accepted Values: 'plain' | 'tree'(default)
        dataStructure: "plain",
        displayExpr: "name",

        // * can be used to expand menu
        expandAllEnabled: false,

        // which property of dataSource will be used to expand
        expandedExpr: "isExpanded",

        // Accepted Values: 'dblclick' | 'click'
        expandEvent: "click",

        // if parent is not expanded and child is still is will not be shown expanded intially
        expandNodesRecursive: false,

        // item field whose value defines whether or not the corresponding node includes child nodes.
        // hasItemsExpr

        // Time period in milliseconds before the onItemHold event is raised.
        itemHoldTimeout: 750,

        // itemsExpr

        keyExpr: "ID",

        noDataText: "No data to display",

        // e has {node, itemIndex, itemElement, itemData, event, element, component}
        // node have children, parent, itemData, key,text, expanded, disabled
        onItemClick: function (e) {
            console.log("Item clicked ", e);
        },

        // e have {component, element, event, itemData, itemElement, node, itemIndex}
        onItemCollapsed: function (e) {
            console.log("onItemCollapsed", e);
        },

        // e have {node, itemIndex, itemElement, itemData, event, element, component}
        onItemContextMenu: function (e) {
            console.log("onItemContextMenu", e);
        },

        // e have {node, itemIndex, itemElement, itemData, event, element, component}
        onItemExpanded: function (e) {
            console.log("onItemExpanded", e);
        },

        // e have {node, itemIndex, itemElement, itemData, event, element, component}
        onItemHold: function (e) {
            console.log("onItemHold", e);
        },

        // onItemRendered
        onItemSelectionChanged: function (e) {
            console.log("onItemSelectionChanged", e);
        },

        //onSelectionChanged: function (e) {
        //    console.log("Selected", e);
        //},

        onSelectAllValueChanged: function (e) {
            console.log("onSelectAllValueChanged");
            console.log(e);
        },


        parentIdExpr: "categoryId",
        itemTemplate: function (item) {
            if (item.price) {
                return `<div> ${item.name} ($${item.price}) </div>`;
            } else {
                return `<div> ${item.name} </div>`;
            }
        },

        // Accepted Values: 'both' | 'horizontal' | 'vertical'(default)
        //scrollDirection: "horizontal",


        // Searching
        searchEnabled: true,
        searchEditorOptions: {
            label: "Find"
        },
        searchExpr: "name",

        searchMode: "contains",
        // searchTimeout
        // searchValue



        // Selection
        //selectAllText
        selectByClick: true,
        selectedExpr: "selected",

        // Accepted Values: 'multiple'(default) | 'single' | 'all' | 'none'
        selectionMode: "multiple",

        selectNodesRecursive: false,

        // none(default), normal, selectAll
        showCheckBoxesMode: "selectAll", 

        // useNativeScrolling

        // If this property is true, the UI component initially loads only the root nodes. Child nodes are loaded when their parent is being expanded.
        // The dataStructure property should be set to "plain".
        virtualModeEnabled: false,

        width: 400,
    }).dxTreeView("instance");

    //treeView.collapseAll();

    // it accepts itemData or itemElement or key
    //treeView.collapseItem("1_1");

    // expandAll
    // expandItem() -> it accepts itemData or itemElement or key

    console.log(treeView.getNodes());

    console.log(treeView.getScrollable()); // returns dxScroolable

    console.log(treeView.getSelectedNodeKeys());

    console.log(treeView.getSelectedNodes());

    //treeView.scrollToItem() -> it accepts itemData or itemElement or key

    //treeView.selectAll();
    //treeView.selectItem() -> it accepts itemData or itemElement or key
    //unselectAll(), unselectItem()

    treeView.updateDimensions().then(() => console.log("DOne"));
});