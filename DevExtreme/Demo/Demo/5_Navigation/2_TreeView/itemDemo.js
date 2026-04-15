$(() => {
    const items = [
        {
            text: "Fruits",
            expanded: true,
            //parentId: "",

            // This field is used when the virtual mode is enabled. 
            hasItems: true,
            items: [
                {
                    text: "Apple",
                    disabled: true,
                },
                {
                    text: "Banana",
                    html: "<h2>banana</h2>",
                },
                {
                    text: "Mango",
                    icon: "coffee",
                    selected: true,
                }
            ]
        },
        {
            text: "Vegetables",
            items: [
                {
                    text: "Carrot",
                    visible: false,
                },
                {
                    text: "Potato",
                    template: "<h2>Potato</h2>"
                },
                {
                    text: "Leafy",
                    items: [
                        { text: "Spinach" },
                        { text: "Lettuce" }
                    ]
                }
            ]
        },
        {
            text: "Drinks",
            items: [
                { text: "Water" },
                { text: "Juice" }
            ]
        }
    ];

    $("#treeview").dxTreeView({
        items: items,

        displayExpr: "text",
        expandEvent: "click",
        selectionMode: "single",
        showCheckBoxesMode: "none"
    });
});