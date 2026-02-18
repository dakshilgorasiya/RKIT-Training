$(() => {
    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxCheckBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            value: true,
        }
    });

    var checkBoxInstance = $("#check-box").dxCheckBox({

        // Specifies the shortcut key that sets focus on the UI component.
        // In chorme press alt+a to foucs and toggle while in some browser it only focus than by clicking space trigger click hanlder
        accessKey: "A",


        // Specifies whether the UI component changes its visual state as a result of user interaction.
        // if set to true and user hold click on checkbox effect will be shown if false no effect will be shown
        activeStateEnabled: true,


        // To disable checkbox
        disabled: false,


        // To attach attribute to element
        elementAttr: {
            id: "customId",
            class: "class1 class2"
        },


        // Specifies whether users can set the CheckBox state to indeterminate.
        // if true cycle of state will be Indeterminate → Checked → Unchecked → Indeterminate → ...
        // if false initialstate can be indeterminate so state cycle is Indeterminate → Checked → Unchecked → Checked → Unchecked → ...
        enableThreeStateBehavior: true,


        // Specifies whether the UI component can be focused using keyboard navigation.
        // To test try pressing tab and then space to trigger
        focusStateEnabled: true,


        // Specifies the UI component's height.(container's height')
        // can be number in pixal or in string like "55px", "20vh", "80%", "inherit"
        // NOTE: The property affects only the size of the UI component container. Use the iconSize property to specify the size of a check box icon.
        height: 100,


        // Specifies text for a hint that appears when a user pauses(hover) on the UI component.
        hint: "this is hint",


        // Specifies whether the UI component changes its state when a user pauses on it.
        // enable it to give hover effect
        hoverStateEnabled: true,


        // Specifies the check box icon's width and height.
        iconSize: 30,

        // isDirty
        // Specifies whether the component's current value differs from the initial value.

        // isValid
        // Specifies or indicates whether the editor's value is valid.
        // NOTE: When you use async rules, isValid is true if the status is "pending" or "valid".


        // The value to be assigned to the name attribute of the underlying HTML element.
        name: "fieldName",


        // A function that is executed when the UI component is rendered and each time the component is repainted.
        onContentReady: function (e) {
            console.log("onContentReady");
            console.log(e);
        },


        // A function that is executed before the UI component is disposed of.
        onDisposing: function (e) {
            console.log("onDisposing");
            console.log(e);
        },


        // A function used in JavaScript frameworks to save the UI component instance.
        // dxCheckBox() called
        //   ↓
        // instance created
        //   ↓
        // onInitialized ← fires here
        //   ↓
        // DOM rendered
        //   ↓
        // onContentReady
        onInitialized: function (e) {
            console.log("onInitialized");
            console.log(e);
        },


        // A function that is executed after a UI component property is changed.
        onOptionChanged: function (e) {
            console.log("onOptionChanged");
            console.log(e);
            console.log(e.value);
        },


        // A function that is executed after the UI component's value is changed.
        onValueChanged: function (e) {
            console.log("onValueChanged");
            console.log(e.previousValue, "->", e.value);
        },


        // Specifies whether the editor is read-only.
        readOnly: false,


        // Switches the UI component to a right-to-left representation.
        // When this property is set to true, the UI component text flows from right to left, and the layout of elements is reversed. 
        rtlEnabled: false,


        // Specifies the number of the element when the Tab key is used for navigating.
        tabIndex: 0,


        // Specifies the text displayed by the check box.
        text: "this is text",


        // Information on the broken validation rule. Contains the first item from the validationErrors array.
        // validationError


        // An array of the validation rules that failed.
        // validationErrors


        // Specifies how the message about the validation rules that are not satisfied by this editor's value is displayed.
        // validationMessageMode
        //Accepted Values: 'always' | 'auto'
        // auto: The tooltip with the message is displayed when the editor is in focus.
        // always: The tooltip with the message is not hidden when the editor loses focus.


        // Indicates or specifies the current validation status.
        // validationStatus
        // Accepted Values: 'valid' | 'invalid' | 'pending'


        // Specifies the UI component state.
        // true -> checked
        // false -> unchecked
        // undefined or null -> undetermined
        value: null,


        // Specifies whether the UI component is visible.
        visible: true,


        // Specifies the UI component's width.
        // can be number in pixal or in string like "55px", "20vh", "80%", "inherit"
        // NOTE: The property affects only the size of the UI component container. Use the iconSize property to specify the size of a check box icon.
        width: 100,

    }).dxCheckBox("instance");

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    checkBoxInstance.beginUpdate();

    // Removes focus from the check box.
    checkBoxInstance.blur();


    // Resets the value property to the default value.
    // checkBoxInstance.clear();



    // Disposes of all the resources allocated to the CheckBox instance.
    //checkBoxInstance.dispose();


    // Gets the root UI component element.
    console.log(checkBoxInstance.element().focusin());

    // Refreshes the UI component after a call of the beginUpdate() method.
    checkBoxInstance.endUpdate();

    // Sets focus on the UI component.
    checkBoxInstance.focus();

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("customId");
    let instance = DevExpress.ui.dxCheckBox.getInstance(element);
    console.log(instance === checkBoxInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = checkBoxInstance.instance();
    console.log(instance === checkBoxInstance);


    // Detaches all event handlers from a single event.
    checkBoxInstance.off("valueChanged");


    // Detaches a particular event handler from a single event.
    checkBoxInstance.off("valueChanged", cb1);


    // To attach event listener
    checkBoxInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    checkBoxInstance.on({
        "valueChanged": cb2,
        "optionChanged": cb2
    });

    // Gets all UI component properties.
    console.log(checkBoxInstance.option());

    // Gets the value of a single property.
    console.log(checkBoxInstance.option("readOnly"));

    // Updates the value of a single property.
    checkBoxInstance.option("readOnly", false);

    // Updates the values of several properties.
    checkBoxInstance.option({
        "readOnly": false,
        value: null
    });

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    checkBoxInstance.registerKeyHandler("w", function () {
        console.log("w clicked")
    })


    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    checkBoxInstance.repaint();

    // Resets the value property to the initial value.
    // This method sets the isDirty flag to false.
    checkBoxInstance.reset();


    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    checkBoxInstance.reset(true);

    // Resets a property to its default value.
    checkBoxInstance.resetOption("onValueChanged");



    // EVENTS
    // contentReady : Raised when the UI component is rendered and each time the component is repainted.
    // disposing : Raised before the UI component is disposed of.
    // initialized : Raised only once, after the UI component is initialized.
    // optionChanged : Raised after a UI component property is changed.
    // valueChanged : Raised after the UI component's value is changed.
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