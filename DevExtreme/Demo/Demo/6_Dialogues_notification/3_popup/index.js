$(() => {
    const popupText = `<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
    Penatibus et magnis dis parturient. Eget dolor morbi non arcu risus. Tristique magna sit amet purus gravida quis blandit.
    Auctor urna nunc id cursus metus aliquam eleifend mi in. Tellus orci ac auctor augue mauris augue neque gravida. Nullam vehicula ipsum a arcu.
    Nullam ac tortor vitae purus faucibus ornare suspendisse sed nisi. Cursus in hac habitasse platea dictumst. Egestas dui id ornare arcu.
    Dictumst vestibulum rhoncus est pellentesque elit ullamcorper dignissim.</p>
 
    <p>Mauris rhoncus aenean vel elit scelerisque mauris pellentesque pulvinar. Neque volutpat ac tincidunt vitae semper quis lectus.
    Sed sed risus pretium quam vulputate dignissim suspendisse in. Urna nec tincidunt praesent semper feugiat nibh sed pulvinar.
    Ultricies lacus sed turpis tincidunt id aliquet risus feugiat. Amet cursus sit amet dictum sit amet justo donec enim.
    Vestibulum rhoncus est pellentesque elit ullamcorper. Id aliquet risus feugiat in ante metus dictum at.</p>`;

    let popupInstance = $("#popup").dxPopup({
        //container: ""
        contentTemplate: () => {
            const content = $("<div />");
            content.append(
                $("<img />").attr("src", "data:image/jpeg;base64,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"),
                $(popupText)
            );
            return content;
        },
        deferRendering: true,
        title: "Information",
        resizeEnabled: false,


        // Drag and Drop
        //dragAndResizeArea: $("body"),
        dragEnabled: true,
        dragOutsideBoundary: false,

        enableBodyScroll: true,
        fullScreen: false,

        // height, width, maxHeight, maxWidth, minHeight, minWidth

        // onHidden, onHiding, onShowing, onShown

        // e have { component, element, event, height, width }
        onResize: function (e) {
            console.log("onResize");
            console.log(e);
        },

        onResizeEnd: function (e) {
            console.log("onResizeEnd");
            console.log(e);
        },

        onResizeStart: function (e) {
            console.log("onResizeStart");
            console.log(e);
        },

        // e have { component, element, titleElement }
        onTitleRendered: function (e) {
            //console.log("onTitleRendered");
            //console.log(e);
        },

        //position: {

        //},

        // Specifies whether to display the Popup at the initial position when users reopen it.
        restorePosition: true,

        hideOnOutsideClick: false,
        hideOnParentScrollL: false,

        shading: true,
        shadingColor: "rgba(0,0,0,0.4)",
        showTitle: true,
        //titleTemplate: "<h1>title</h1>",

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

                // Accepted Values: 'always' | 'inMenu'
                showText: "inMenu",
                //menuItemTemplate: function (data, index) {
                //    return $("<div>").text(data.options.text + "Click");
                //},
                //template:
                // text
                toolbar: "bottom",
            }],

        wrapperAttr: {
            id: "custom",
        },
        position: "center",
        visible: true,


    }).dxPopup("instance");

    // return jquery element
    console.log(popupInstance.content());

    //popupInstance.hide();
    //popupInstance.show();

    popupInstance.toggle(true);
});