$(() => {

    const menuData = [
        {
            id: 1,
            text: "File",
            icon: "folder",
            isMainMenu: true,
            items: [
                {
                    id: 11,
                    text: "New",
                    items: [
                        { id: 111, text: "Project" },
                        { id: 112, text: "File" }
                    ]
                },
                {
                    id: 12,
                    text: "Open",
                    items: [
                        { id: 121, text: "Recent" },
                        { id: 122, text: "Browse" }
                    ]
                }
            ]
        },
        {
            id: 2,
            text: "Edit",
            icon: "edit",
            isMainMenu: true,
            items: [
                {
                    id: 21,
                    text: "Undo"
                },
                {
                    id: 22,
                    text: "Redo"
                },
                {
                    id: 23,
                    text: "Find",
                    items: [
                        { id: 231, text: "Find..." },
                        { id: 232, text: "Replace" }
                    ]
                }
            ]
        },
        {
            id: 3,
            text: "View",
            icon: "eyeopen",
            isMainMenu: true,
            items: [
                {
                    id: 31,
                    text: "Zoom",
                    items: [
                        { id: 311, text: "Zoom In" },
                        { id: 312, text: "Zoom Out" }
                    ]
                },
                {
                    id: 32,
                    text: "Layout",
                    items: [
                        {
                            id: 321,
                            text: "Grid",
                            items: [
                                { id: 3211, text: "Show Grid" },
                                { id: 3212, text: "Hide Grid" }
                            ]
                        }
                    ]
                }
            ]
        }
    ];

    $("#menu").dxMenu({
        dataSource: menuData,
        displayExpr: "text",
        itemsExpr: "items",
        itemTemplate: function (itemData, itemIndex, itemElement) {
            if (itemData.isMainMenu) {
                itemElement.css({
                    display: "flex",
                    alignItems: "center",
                    justifyContent: "center",
                    padding: "15px"
                });
                return $("<div>")
                    .addClass(`dx-icon dx-icon-${itemData.icon}`)
                    .css({ fontSize: "28px" });
            } else {
                const $container = $("<div>").addClass("dx-menu-item-content");

                $container.append(
                    $("<p>").addClass("dx-menu-item-text").text(itemData.text).css({
                        display: "inline",
                    })
                );

                if (itemData.items && itemData.items.length) {
                    $container.append(
                        $("<p>").addClass("dx-menu-item-popout").css({
                            display: "inline",
                            "margin-left": "35px",
                        })
                    );
                }

                return $container;
            }
        },
        orientation: "verticle",
        showFirstSubmenuMode: "onHover",
        onItemClick: function (e) {
            console.log("Clicked:", e.itemData.text);
        }
    });

});