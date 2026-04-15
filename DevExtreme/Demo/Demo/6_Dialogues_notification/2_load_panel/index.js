$(() => {
    $("#panel").dxLoadPanel({
        visible: true,

        // time after which loader will be displayed
        delay: 1000,

        //height: 100,
        // width
        hideOnOutsideClick: true,
        hideOnParentScroll: false,
        indicatorSrc: "https://js.devexpress.com/Content/data/loadingIcons/rolling.svg",
        //maxHeight
        // maxWidth

        container: $("#container"),

        message: "Fetching records just for you ...",

        // e have {model, element, component}
        onHidden: function (e) {
            console.log("onHidden", e);
        },

        // e have {model, element, component, cancel}
        onHiding: function (e) {
            console.log("onHiding", e);
        },

        // e have {model, element, component, cancel}
        onShowing: function (e) {
            console.log("onShowing", e);
        },

        // e have {model, element, component}
        onShown: function (e) {
            console.log("onShown", e);
        },

        position: {
            // Accepted Values: 'bottom' | 'center' | 'left' | 'left bottom' | 'left top' | 'right' | 'right bottom' | 'right top' | 'top

            // Specifies the overlay element's side or corner to align with a target element.
            // if set to center at will be implemented from center point
            my: 'right',

            // Specifies the target element's side or corner where the overlay element should be positioned.
            at: 'left',
            of: "#container",
        },

        // If this property is set to true, the LoadPanel is displayed in modal mode, and users cannot interact with other UI components.
        shading: true,

        shadingColor: "rgba(0,0,0,0.4)",

        showIndicator: true,

        showPane: true,

        wrapperAttr: {
            id: "check",
        }
    });
});