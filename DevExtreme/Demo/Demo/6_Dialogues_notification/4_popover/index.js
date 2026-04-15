$(function () {

    $("#button").dxButton({
        text: "Click me",
        type: "success"
    });

    $("#button2").dxButton({
        text: "Click me",
    });

    let popover = $("#popover").dxPopover({

        deferRendering: true,
        disabled: false,
        enableBodyScroll: true,
        // height, maxHeight, maxWidth, minHeight, minWidth, width
        hideEvent: {
            delay: 300,
            name: "dxdblclick",
        },
        showEvent: {
            delay: 300,
            name: "mouseenter"
        },

        hideOnOutsideClick: true,
        hideOnParentScroll: true,

        // without target popover will not be displayed
        target: "#button",
        width: 250,

        title: "HELP",
        contentTemplate: function () {
            return $("<div>")
                .append("<b>Hello</b>")
                .append("<p>This is a DevExtreme Popover.</p>")
                .append("<p>It is attached to the button.</p>");
        },

        position: {

        },

        //shading: true,
        //shadingColor: "rgba(0,0,0,0.4)",

        // will only work if showTitle is true
        showCloseButton: true,
        showTitle: true,

        //titleTemplate: "<h1>HELP</h1>",

        toolbarItems: [
            {
                disabled: false,
                //html: "",
                locateInMenu: "always",

                // Accepted Values: 'dxAutocomplete' | 'dxButton' | 'dxButtonGroup' | 'dxCheckBox' | 'dxDateBox' | 'dxDropDownButton' | 'dxMenu' | 'dxSelectBox' | 'dxSwitch' | 'dxTabs' | 'dxTextBox'
                widget: "dxButton",

                // Accepted Values: 'after' | 'before' | 'center'
                location: "after",
                options: {
                    text: "Refresh",
                    onClick: function (e) {
                        console.log("refresh");
                    }
                },
                showText: "inMenu",
                //menuItemTemplate: function (data, index) {
                //    return $("<div>").text(data.options.text + "Click");
                //},
                //template:
                // text
                toolbar: "bottom",
            }],

        wrapperAttr: {

        },
        // onHidden, onHiding, onShowing, onShown
    }).dxPopover("instance");


    // return jquery element
    console.log(popover.content());

    //popover.show();
    //popover.hide();


    // to show popover for other target
    popover.show($("#button"))

    //popover.toggle(false);
});