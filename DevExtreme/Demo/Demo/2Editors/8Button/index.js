$(() => {
    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxButton.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            accessKey: "a",
        },
    });

    let buttonInstance = $("#buttonDiv").dxButton({
        // Specifies the shortcut key that sets focus on the UI component.
        accessKey: "a",

        // Specifies whether the UI component changes its visual state as a result of user interaction.
        activeStateEnabled: true,

        // Specifies whether the UI component responds to user interaction.
        disabled: false,

        // Specifies the global attributes to be attached to the UI component's container element.
        elementAttr: {
            id: "CustomID"
        },

        // Specifies whether the UI component can be focused using keyboard navigation.
        focusStateEnabled: true,

        // Specifies the UI component's height.
        // The TextArea can have a fixed or resizable height. Components with a fixed height displays a native scroll bar if the entered text exceeds the text area.
        //height: 100,

        // Specifies text for a hint that appears when a user pauses on the UI component.
        hint: "This is hint",

        // Specifies whether the UI component changes its state when a user pauses on it.
        hoverStateEnabled: true,

        // Specifies the icon to be displayed on the button.
        // The icon's URL
        // The icon's name if the icon is from the DevExtreme icon library
        // The icon's CSS class if the icon is from an external icon library
        // The icon in the Base64 format
        // The icon in the SVG format.Ensure that the source is reliable.
         icon: "search",
        //icon: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRtRs_rWILOMx5-v3aXwJu7LWUhnPceiKvvDg&s",
        //icon: "./home.svg",
        //icon: "data: image / png; base64, iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAACXBIWXMAAAsTAAALEwEAmpwYAAACG0lEQVR4nO2Zy0ocQRSGv8SoEF1klywiJogLkUTILo76AGaCir6AC92LiAsjWSi+ Q3bZ + wxqsgpJIDuzUhAFL + AFZtyIl5JKTkOl6Z6pFp0 + TuqHQ1f / VdV1Pqq6KLohKCjopnoPrAGngMk5ToFVoJgVYklB8iYlFrPMhFEeRR + QNQWJmiqx4gNSVpCoqRIlH5BaJtQL9Hl4JiFUgSSNGSmARKrFcsqiPq0ghYwg / VpB6mZpmQCCLpDwsqMMpG6WlqlHkELC0ilUWE5qQW5jNlOVd4ImgMT034CcAbtyvZcg28Ao0CjtmoAxYMdj0Ik7mPGqSup0CLyQegvyzAF6CRxXGHDZ4 / k1A5l2zj374u0Bb8WfSem3BTzRBNIldd9j / jfxuxP6nDvnqhEtIE1SdwEcAb + AA0l2FphP6PNB + rRJHxUgkYaBB1K218GUl91 + 5GuQ + Bp7hgoQq1bgDdDy5 + 7vJnDotLXl51L3MeEZKkAGgBPxjuVwZzXltB0Sr1 + WokqQ3zF / Xfx2ub9y2s4Bn5yIZMtf8gJ5BDwELmP + pfjNCSCVNJ4XSIfU / Yz5P8TvdEAmUyKSLX / OC2RO6l4Dm + JtAK / En88wcK7vSMlJ2m6pT + Vq1eP5e04FiJFdyh7 + Hku7Flkm0S6mDqR8D47xJR + Q1RwTNLf5662oIFFTJd7hqUUFyZqUWPCFcGdmRcnP0bLk4j0TQUFB / KNrsG7v3AVOiD0AAAAASUVORK5CYII=",

        // A function that is executed when the Button is clicked or tapped.
        // e has {component, element, event, validationGroup(The validation group to which the button is related.)}
        onClick: function (e) {
            console.log("onClick");
            console.log(e);
        },

        // A function that is executed when the UI component is rendered and each time it is repainted.
        // e has {element, component}
        onContentReady: function (e) {
            console.log("onContentReady");
            console.log(e);
        },

        // A function that is executed before the UI component is disposed of.
        // e has {element, component}
        onDisposing: function (e) {
            console.log("onDisposing");
            console.log(e);
        },

        // A function used in JavaScript frameworks to save the UI component instance.
        // Lifecycle order:
        //   dxDateBox() called
        //     ↓
        //   instance created
        //     ↓
        //   onInitialized  ← fires here
        //     ↓
        //   DOM rendered
        //     ↓
        //   onContentReady
        // e has {element, component}
        onInitialized: function (e) {
            console.log("onInitialized");
            console.log(e);
        },

        // A function that is executed after a UI component property is changed.
        // e has {value, previousValue, name, fullName, element, component}
        //onOptionChanged: function (e) {
        //    console.log("onOptionChanged");
        //    console.log(e);
        //    console.log(e.value);
        //},

        // Switches the UI component to a right-to-left representation.
        rtlEnabled: false,

        // Specifies how the button is styled.
        // Accepted Values: 'text' | 'outlined' | 'contained'
        // Default Value: 'contained'
        stylingMode: "outlined",

        // Specifies the number of the element when the Tab key is used for navigating.
        // if two have same value accoding to DOM order will be select
        // make it -1 to disable tab focus, make it 0 to follow natural DOM order
        tabIndex: 1,

        // Specifies a custom template for the Button UI component.
        //template: function ({ icon, text }) {
        //    return `<h1>${text} ${icon}</h1>`;
        //},

        // The text displayed on the button.
         text: "click me",

         // Specifies the button type.
         // Accepted Values: 'danger' | 'default' | 'normal' | 'success'
         // Default Value: 'normal'
         // https://js.devexpress.com/jQuery/Demos/WidgetsGallery/Demo/Button/PredefinedTypes/FluentBlueLight/
         type: "default",

         // Specifies whether the button submits an HTML form.
         // default: false
        // If this property is set to true, users can click the button to validate the validation group and submit the HTML form. If the group contains async rules, the form is not submitted until they are checked.
        // If the onClick event handler is specified, it is executed before validation and form submission.
        // If you need to cancel form submission, handle a form's submit event.
         //useSubmitBehavior: true,

        // Specifies the name of the validation group to be accessed in the click event handler.
        // When using a button to validate several editors on a page, the button must "know" in which validation group these editors are located.
        // Specify the validationGroup configuration property for the button. Assign the validation group name specified for the validationGroup property of the validators that extend the editors to be validated.
        // validationGroup
    
        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        width: 400
    }).dxButton("instance");

    // to programatically click button
    buttonInstance.element().trigger("dxclick");

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //buttonInstance.beginUpdate();

    // Disposes of all the resources allocated to the CheckBox instance.
    //buttonInstance.dispose();

    // Gets the root UI component element.
    //buttonInstance.element().focusin();

    // Refreshes the UI component after a call of the beginUpdate() method.
    //buttonInstance.endUpdate();

    // Sets focus on the UI component.
    //buttonInstance.focus();

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomID");
    let instance = DevExpress.ui.dxTextBox.getInstance(element);
    //console.log(instance === buttonInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = buttonInstance.instance();
    //console.log(instance === buttonInstance);

    // Detaches all event handlers from a single event.
    //buttonInstance.off("optionChanged");

    // Detaches a particular event handler from a single event.
    //buttonInstance.off("optionChanged", cb1);

    // To attach event listener
    //buttonInstance.on("optionChanged", cb1);

    // To attach multiple event listener
    //buttonInstance.on({
    //    "optionChanged": cb2,
    //});
    // Gets all UI component properties.
    //console.log(buttonInstance.option());

    // Gets the value of a single property.
    //console.log(buttonInstance.option("hint"));

    // Updates the value of a single property.
    //buttonInstance.option("hint", "click me");

    // Updates the values of several properties.
    //buttonInstance.option({
        //"hint": "click me"
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    //buttonInstance.registerKeyHandler("w", function () {
    //    console.log("w clicked")
    //});

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //buttonInstance.repaint();

    // Resets a property to its default value.
    //buttonInstance.resetOption("value");

    // EVENTS
    // click : Raised when the Button is clicked or tapped.
    // contentReady : Raised when the UI component is rendered and each time the component is repainted.
    // disposing : Raised before the UI component is disposed of.
    // initialized : Raised only once, after the UI component is initialized.
    // optionChanged : Raised after a UI component property is changed.
});



function cb1() {
    console.log("cb1");
}

function cb2() {
    console.log("cb2");
}

function cb3() {
    console.log("cb3");
}

function cb4() {
    console.log("cb4");
}