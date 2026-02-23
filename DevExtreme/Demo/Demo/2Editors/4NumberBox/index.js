$(() => {
    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxNumberBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            // if min max is set but value is not between them still number box will get default value when user first focus out than value will bound to min, max
            value: 220,
        },
    });

    let numberBoxInstance = $("#numberBox").dxNumberBox({
        // Specifies the shortcut key that sets focus on the UI component.
        accessKey: "a",

        // Specifies whether the UI component changes its visual state as a result of user interaction.
        activeStateEnabled: true,

        // Allows you to add custom buttons to the input text field.
        buttons: [
            "clear",
            {
                name: "myBtn",
                location: "after",
                options: {
                    icon: "search",
                    onClick: function (e) {
                        console.log("myBtn clicked");
                    }
                }
            },
            "spins"
        ],

        // Specifies whether the UI component responds to user interaction.
        disabled: false,

        // Specifies the global attributes to be attached to the UI component's container element.
        elementAttr: {
            id: "CustomID"
        },

        // Specifies whether the UI component can be focused using keyboard navigation.
        focusStateEnabled: true,

        // Specifies the value's display format and controls user input accordingly.
        // When this property is specified, a press on the minus sign (-) inverts the current value instead of entering "-".
        //format: {
        //    //type: "currency",
        //    //currency: "INR",
        //    //useCurrencyAccountingStyle: true // use () for negative number instead of "-"

        //    type: "percent", // Multiplies the input value by 100. if not wanted use custom format

        //    //type: "exponential", // error on console

        //    //type: "largeNumber", // wrong number

        //    //type: "fixedPoint",
        //    //precision: 2

        //    // If you allow users to edit the formatted value, implement the parser function to convert the value back to a number.
        //    //formatter: function (value) {
        //    //    return "₹ " + value.toFixed(2);
        //    //},
        //    //parser: function (text) {
        //    //    return Number(text.replace("₹", ""));
        //    //},
        //},
        // or
        //format: "percent",
        // Custom Format
        // Rules
        // 0 -> A digit.Displays '0' if the formatted number does not have a digit in that position.
        // # -> Up to 15 of leading digits, a single digit, or nothing.If this character goes first in the format string, it can match multiple leading digits(before the decimal point).Subsequent characters match a single digit.If the formatted number does not have a digit in the corresponding position, it displays nothing.
        // For example, if you apply format "#0.#" to "123.45", the result is "123.4".
        // . -> A decimal separator.(Actual character depends on locale).
        // , -> A group separator. (Actual character depends on locale).
        // % -> The percent sign.Multiplies the input value by 100.
        // ; -> Separates positive and negative format patterns.
        // For example, the "#0.##;(#0.##)" format displays a positive number according to the pattern before the semicolon(";"), and a negative number according to the pattern after the semicolon(";").
        // If you do not use this character and the additional pattern, negative numbers display a minus("-") prefix.
        // Escape characters You can display the special characters above as literals if you enclose them in single quotation marks.
        // For example, '%'.
        // Other characters	You can add any literal characters to the beginning or end of the format string.

        //format: "##0.00;<>##0.00",

        // Specifies the UI component's height.
        //height: 10,

        // Specifies text for a hint that appears when a user pauses on the UI component.
        hint: "This is hint",

        // Specifies whether the UI component changes its state when a user pauses on it.
        hoverStateEnabled: true,

        // Specifies the attributes to be passed on to the underlying HTML element.
        inputAttr: {
            id: "inputId"
        },

        // Specifies the text of the message displayed if the specified value is not a number.
        invalidValueMessage: "Invalid number",

        // Specifies or indicates whether the editor's value is valid.
        // When you use async rules, isValid is true if the status is "pending" or "valid".
        // isValid

        // Specifies a text string used to annotate the editor's value.
        label: "Choose number",

        // Specifies the label's display mode.
        // static(default), floating, hidden, outside
        labelMode: "floating",

        // The maximum value accepted by the number box.
        //max: 100,

        // The minimum value accepted by the number box.
        //min: 10,


        // Specifies the value to be passed to the type attribute of the underlying <input> element.
        // If you set the format property, the mode for mobile devices is changed to "tel"; "number" is not available.
        // Default Value: 'text', 'number' (mobile devices)
         mode: "text",

        // The value to be assigned to the name attribute of the underlying HTML element.
        // Will affect name of hidden input tag where actual value is stored not to input box
        name: "number",

        // A function that is executed when the UI component loses focus after the text field's content was changed using the keyboard.
        // e has {event(jQuery), element(UI's container), component(UI component's instance)}
        // to get value we can use e.event.target.value
        onChange: function (e) {
            console.log("onchange");
            console.log(e);
        },

        // onContentReady
        // Fires when the user copies text from the input field.
        // e has {event, element, component}
        onCopy: function (e) {
            console.log("onCopy");
            console.log(e);
        },

        // Fires when the user cuts text from the input field.
        // e has {event, element, component}
        onCut: function (e) {
            console.log("onCut");
            console.log(e);
        },

        // A function that is executed before the UI component is disposed of.
        // e has {element, component}
        onDisposing: function (e) {
            console.log("onDisposing");
            console.log(e);
        },

        // Fires when the user presses Enter inside the text field.
        // This function is executed after the onKeyUp and onKeyDown functions.
        // e has {event, element, component}
        onEnterKey: function (e) {
            console.log("onEnterKey");
            console.log(e);
        },

        // Fires when the text field receives focus.
        // e has {event, element, component}
        onFocusIn: function (e) {
            console.log("onFocusIn");
            console.log(e);
        },

        // Fires when the text field loses focus.
        // e has {event, element, component}
        onFocusOut: function (e) {
            console.log("onFocusOut");
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

        // Fires on every keystroke inside the text field.
        // e has {event, element, component}
        //onInput: function (e) {
        //    console.log("onInput");
        //    console.log(e);
        //},

        // Fires on keydown inside the text field.
        // e has {event, element, component}
        //onKeyDown: function (e) {
        //    console.log("onKeyDown");
        //    console.log(e);
        //},

        // Fires on keyup inside the text field.
        // e has {event, element, component}
        //onKeyUp: function (e) {
        //    console.log("onKeyUp");
        //    console.log(e);
        //},

        // A function that is executed after a UI component property is changed.
        // e has {value, previousValue, name, fullName, element, component}
        //onOptionChanged: function (e) {
        //    console.log("onOptionChanged");
        //    console.log(e);
        //    console.log(e.value);
        //},

        // Fires when the user pastes content into the text field.
        // e has {event, element, component}
        onPaste: function (e) {
            console.log("onPaste");
            console.log(e);
        },

        // A function that is executed after the UI component's value is changed.
        // e.previousValue → old Date (or string), e.value → new Date (or string)
        // e has {value, previousValue, event, element, component}
        onValueChanged: function (e) {
            console.log("onValueChanged");
            console.log(e.previousValue, "->", e.value);
        },

        // Specifies a text string displayed when the editor's value is empty.
        // will be overridden by label if set to floating mode
        placeholder: "Pick a number",

        // Specifies whether the editor is read-only.
        // Built-in action buttons are invisible.
        //Custom action buttons are visible but disabled.If a button should not be disabled, set its disabled property to false:
        readOnly: false,

        // Switches the UI component to a right-to-left representation.
        rtlEnabled: false,

        // Specifies whether to display the Clear button in the UI component.
        showClearButton: true,

        // Specifies whether to show the buttons that change the value by a step.
        showSpinButtons: true,

        // Specifies how much the UI component's value changes when using the spin buttons, Up/Down arrow keys, or mouse wheel.
        step: 5,

        // Specifies how the UI component's text field is styled.
        // options : outlined, underlined, filled
        stylingMode: "underlined",

        // Specifies the number of the element when the Tab key is used for navigating.
        // if two have same value accoding to DOM order will be select
        // make it -1 to disable tab focus, make it 0 to follow natural DOM order
        tabIndex: 1,

        // A property that holds the UI component's value with applied format.
        // read-only
        // text

        // Specifies whether to use touch friendly spin buttons. Applies only if showSpinButtons is true.
        // Default Value: true, false (desktop)
        useLargeSpinButtons: true,

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

        // The current number box value.
        value: 10,

        // Specifies the DOM events after which the UI component's value should be updated.
        // This property accepts a single event name or several names separated by spaces.
        // The recommended events are "keyup", "blur", "change", "input", and "focusout", but you can use other events as well.
        valueChangeEvent: "focusout",

        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        width: 400
    }).dxNumberBox("instance");

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //numberBoxInstance.beginUpdate();

    // Removes focus from the check box.
    numberBoxInstance.blur();

    // Resets the value property to the default value.
    //numberBoxInstance.clear();

    // Disposes of all the resources allocated to the CheckBox instance.
    //numberBoxInstance.dispose();

    // Gets the root UI component element.
    //numberBoxInstance.element().focusin();

    // Refreshes the UI component after a call of the beginUpdate() method.
    //numberBoxInstance.endUpdate();

    // Sets focus on the UI component.
    numberBoxInstance.focus();

    // Gets an instance of a custom action button.
    numberBoxInstance.getButton("myBtn").focus();


    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomID");
    let instance = DevExpress.ui.dxNumberBox.getInstance(element);
    //console.log(instance === numberBoxInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = numberBoxInstance.instance();
    //console.log(instance === numberBoxInstance);

    // Detaches all event handlers from a single event.
    //numberBoxInstance.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //numberBoxInstance.off("valueChanged", cb1);

    // To attach event listener
    //numberBoxInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    //numberBoxInstance.on({
    //    "valueChanged": cb2,
    //    "optionChanged": cb2
    //});

    // Gets all UI component properties.
    //console.log(numberBoxInstance.option());

    // Gets the value of a single property.
    //console.log(numberBoxInstance.option("readOnly"));

    // Updates the value of a single property.
    //numberBoxInstance.option("readOnly", false);

    // Updates the values of several properties.
    //numberBoxInstance.option({
    //    "readonly": false,
    //    value: null
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    numberBoxInstance.registerKeyHandler("w", function () {
        console.log("w clicked")
    })

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //numberBoxInstance.repaint();

    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    //numberBoxInstance.reset(19);

    // Resets a property to its default value.
    //numberBoxInstance.resetOption("buttons");

    // EVENTS
    // change : Raised when the UI component loses focus after the text field's content was changed using the keyboard.
    // contentReady : Raised when the UI component is rendered and each time the component is repainted.
    // copy : Raised when the UI component's input has been copied.
    // cut : Raised when the UI component's input has been cut.
    // disposing : Raised before the UI component is disposed of.
    // enterKey : Raised when the Enter key has been pressed while the UI component is focused.
    // focusIn : Raised when the UI component gets focus.
    // focusOut : Raised when the UI component loses focus.
    // initialized : Raised only once, after the UI component is initialized.
    // input : Raised each time the UI component's input is changed while the UI component is focused.
    // keyDown : Raised when a user is pressing a key on the keyboard.
    // keyUp : Raised when a user releases a key on the keyboard.
    // optionChanged : Raised after a UI component property is changed.
    // paste : Raised when the UI component's input has been pasted.
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