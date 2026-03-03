$(() => {
    const data = [
        { text: "Low", color: "grey" },
        { text: "Normal", color: "green" },
        { text: "Urgent", color: "yellow" },
        { text: "High", color: "red" }
    ];

    const itemData = [
        {
            // Specifies text displayed for the UI component item.
            // If you use both this property and a template, the template overrides the text.
            text: "apple",

            // Specifies whether the UI component item responds to user interaction.
            disabled: true,

            // Specifies the HTML markup to be inserted into the item element.
            // The SelectBox component evaluates the html property's value. This evaluation, however, makes the SelectBox potentially vulnerable to XSS attacks. 
            html: `<h1>Apple</h1>`,

            // Specifies a template that should be used to render this item only.
            // template will override html
            template: function (data, index, element) {
                return $("<h2>").text(data.text);
            },

            // Specifies whether or not a UI component item must be displayed.
            visible: true,
        },
        {
            text: "banana",
            disabled: false,
            template: function (data, index, element) {
                return $("<h2>").text(data.text);
            }
        },
        {
            text: "orange",
            disabled: false,
        },
        {
            text: "pinapple",
            disabled: false,
            visible: true
        }
    ];

    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxRadioGroup.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            value: "yellow",
        },
    });

    let radioGroupInstance = $("#radioGroup").dxRadioGroup({

        // Specifies the shortcut key that sets focus on the UI component.
        accessKey: "a",

        // Specifies whether the UI component changes its visual state as a result of user interaction.
        activeStateEnabled: true,

        // Binds the UI component to data.
        // Do not specify the items property if you specified the dataSource, and vice versa.
        dataSource: data,

        // Specifies whether the UI component responds to user interaction.
        disabled: false,

        // Specifies the data field whose values should be displayed.
        displayExpr: "text",

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

        // Specifies the attributes to be passed on to the underlying HTML element.
        inputAttr: {
            id: "inputId"
        },

        // Specifies whether the component's current value differs from the initial value.
        // isDirty

        // Specifies or indicates whether the editor's value is valid.
        // isValid

        // An array of items used to synchronize the DropDownBox with an embedded UI component.
        // Do not use the items property if you use dataSource (and vice versa).
        //items: itemData,

        // Specifies a custom template for items.
        itemTemplate: function (data) {
            return $("<p>").text(data.text);
        },

        // Specifies the radio group layout.
        // Default Value: 'vertical', 'horizontal' (tablets)
        layout: "horizontal",

        // The value to be assigned to the name attribute of the underlying HTML element.
        // Will affect name of hidden input tag where actual value is stored not to input box
        name: "radioResponse",

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

        // A function that is executed after the UI component's value is changed.
        // e.previousValue → old Date (or string), e.value → new Date (or string)
        // e has {value, previousValue, event, element, component}
        onValueChanged: function (e) {
            console.log("onValueChanged");
            console.log(e.previousValue, "->", e.value);
        },

        // Specifies whether the editor is read-only.
        // Built-in action buttons are invisible.
        //Custom action buttons are visible but disabled.If a button should not be disabled, set its disabled property to false:
        readOnly: false,

        // Switches the UI component to a right-to-left representation.
        rtlEnabled: false,

        // Information about the broken validation rule (first item from validationErrors array).
        // validationError

        // An array of all validation rules that failed.
        // validationErrors

        // Specifies how the validation error tooltip is displayed.
        //   "auto"   → tooltip appears only when the editor has focus
        //   "always" → tooltip stays visible even when the editor loses focus
        validationMessageMode: "always",

        // Specifies where the validation message is displayed relative to the component.
        //   "bottom" (default) | "top" | "left" | "right"
        validationMessagePosition: "right",

        // Indicates the current validation status.
        //   "valid"   → value passes all rules
        //   "invalid" → value fails at least one rule
        //   "pending" → async validation is in progress
        validationStatus: "valid",

        // Specifies the currently selected value. May be an object if dataSource contains objects, the store key is specified, and valueExpr is not set.
        // When dataSource contains objects, you should define valueExpr to correctly identify data items. If valueExpr is not specified, the component compares object references to display an item, not object values. For instance, if you define the value property as an object containing identical values to dataSource to select all items, the component displays nothing.
        value: "red",

        // Specifies which data field provides unique values to the UI component's value.
        // When dataSource contains objects, you should define valueExpr to correctly identify data items. Otherwise, the component uses referential equality to compare objects, which may result in unexpected behavior.
        valueExpr: "color",

        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        width: 400
    }).dxRadioGroup("instance");

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //radioGroupInstance.beginUpdate();

    // Resets the value property to the default value.
    //radioGroupInstance.clear();


    // Disposes of all the resources allocated to the CheckBox instance.
    //radioGroupInstance.dispose();

    // Gets the root UI component element.
    //radioGroupInstance.element().focusin();

    // Refreshes the UI component after a call of the beginUpdate() method.
    //radioGroupInstance.endUpdate();

    // Sets focus on the UI component.
    //radioGroupInstance.focus();

    // Gets the DataSource instance.
    console.log("Data Source : ", radioGroupInstance.getDataSource());

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomID");
    let instance = DevExpress.ui.dxRadioGroup.getInstance(element);
    //console.log(instance === radioGroupInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = radioGroupInstance.instance();
    //console.log(instance === radioGroupInstance);

    // Detaches all event handlers from a single event.
    //radioGroupInstance.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //radioGroupInstance.off("valueChanged", cb1);

    // To attach event listener
    //radioGroupInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    //radioGroupInstance.on({
    //    "valueChanged": cb2,
    //    "optionChanged": cb2
    //});
    // Gets all UI component properties.
    //console.log(radioGroupInstance.option());

    // Gets the value of a single property.
    //console.log(radioGroupInstance.option("readOnly"));

    // Updates the value of a single property.
    //radioGroupInstance.option("readOnly", false);

    // Updates the values of several properties.
    //radioGroupInstance.option({
    //    "readonly": false,
    //    value: null
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    //radioGroupInstance.registerKeyHandler("w", function () {
    //    console.log("w clicked")
    //});

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //radioGroupInstance.repaint();

    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    //radioGroupInstance.reset("red");

    // Resets a property to its default value.
    //radioGroupInstance.resetOption("value");

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