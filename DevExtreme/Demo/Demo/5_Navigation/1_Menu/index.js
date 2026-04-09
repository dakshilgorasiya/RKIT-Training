$(() => {
    const menu = $("#menu").dxMenu({
        // This property is in effect only if the orientation is "horizontal".
        adaptivityEnabled: false,
        width: 50,

        // when set to false sub menu will stay if mouse leave and when click it will hide (default: true)
        hideSubmenuOnMouseLeave: true,

        items: [
            {
                icon: 'home'
            },
            {
                text: 'About',
            },
            {
                text: 'Products',
                items: [
                    {
                        // to control where or not programatically menu can be seleced or not
                        selectable: true,
                        selected: true,
                        text: 'Product 1',
                        template: $("<h5>").text("Product 1")
                    },
                    {
                        text: 'Category',
                        items: [
                            {
                                text: 'Product 2',

                                // will close menu on click or not
                                closeMenuOnClick: false,
                            },
                            {
                                // have a horizontal line between product 2 and product 3
                                beginGroup: true,
                                selectable: true,
                                text: 'Product 3'
                            },
                            {
                                text: 'Product 4',
                                disabled: true,
                                visible: false,
                            },
                            {
                                text: "Product 5",
                                url: "https://www.google.com",
                                linkAttr: {
                                    target: "_blank"
                                }
                            }
                        ]
                    },
                    {
                        disabled: true,
                        text: 'Product 5'
                    }
                ]
            },
            {
                icon: 'cart'
            }
        ],

        // which data field contains nested items.
        //itemsExpr: "items"

        //itemTemplate: function (data, index, element) {
        //    // if data is objet containing icon or text or items
        //    return $("<div>").text("menu");
        //},

        // e has {itemIndex, itemElement, itemData, event, element, component}
        onItemClick: function (e) {
            if (e.itemData.text) {
                console.log(e.itemData.text + ' has been clicked!');
            }
            else if (e.itemData.icon) {
                console.log(e.itemData.icon + ' has been clicked!');
            }
        },

        // e has {itemIndex, itemElement, itemData, event, element, component}
        onItemContextMenu: function (e) {
            console.log("onItemContextMenu");
            console.log(e);
        },

        // e has {itemIndex, itemElement, itemData, element, component}
        // called for every render but once rendered it will not render again just hide
        onItemRendered: function (e) {
            //console.log("onItemRendered");
            //console.log(e);
        },

        // e has {removedItems, addedItems, element, component}
        onSelectionChanged: function (e) {
            console.log("onSelectionChanged");
            console.log(e);
        },

        // after submenuhidden
        // e has {component, element, rootItem, itemData, submenuContainer}
        onSubmenuHidden: function (e) {
            //console.log("onSubmenuHidden");
        },

        // before submenu hidden set e.cancel = true to cancel hiding
        // e has {component, element, rootItem, itemData, submenuContainer, cancel}
        onSubmenuHiding: function (e) {
            //console.log("onSubmenuHiding");
        },

        // e has {component, element, rootItem, itemData, submenuContainer}
        onSubmenuShowing: function (e) {
            //console.log("onSubmenuShowing");
        },

        // e has {component, element, rootItem, itemData, submenuContainer, cancel}
        onSubmenuShown: function (e) {
            //console.log("onSubmenuShown");
        },

        // horizontal(default), verticle
        //orientation: "verticle",

        selectByClick: true,

        // to programatically select item
        // selectedItem

        // selectedExpr : name of the data source item field whose value defines whether or not the corresponding UI component items is selected.

        //Accepted Values: 'multiple' | 'single' | 'all' | 'none'(default)
        selectionMode: "single",


        // Accepted Values: 'onClick' | 'onHover'
        //showFirstSubmenuMode: "onHover",
        showFirstSubmenuMode: {
            name: "onHover",
            delay: {
                show: 2000,
                hide: 1000,
            }
        },

        showSubmenuMode: {
            name: "onHover",
            delay: 500,
        },

        // Accepted Values: 'auto'(default) | 'leftOrTop' | 'rightOrBottom'
        submenuDirection: "rightOrBottom",
    }).dxMenu("instance");

    // it accepts items dom node
    // menu.selectItem();
    // menu.unselectItem()
});