$(() => {
    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxTextBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            value: "defaultValue",
        },
    });

    let textBoxInstance = $("#textBox").dxTextBox({
        // Specifies the shortcut key that sets focus on the UI component.
        accessKey: "a",

        // Specifies whether the UI component changes its visual state as a result of user interaction.
        activeStateEnabled: true,

        // Allows you to add custom buttons to the input text field.
        buttons: [
            "clear",
            {
                location: "after",
                name: "search",
                options: {
                    icon: "search",
                    onClick: function (e) {
                        console.log("Custom button clicked");
                    }
                }
            }
        ],

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

        // Specifies the attributes to be passed on to the underlying HTML element.
        inputAttr: {
            id: "inputId"
        },

        // Specifies whether the component's current value differs from the initial value.
        // isDirty

        // Specifies or indicates whether the editor's value is valid.
        // isValid

        // Specifies a text string used to annotate the editor's value.
        label: "Enter details",

        // Specifies the label's display mode.
        // static(default), floating, hidden, outside
        labelMode: "floating",

        // The editor mask that specifies a custom input format.
        // The component supports the following masking elements:
        // 0	A digit.
        // 9	A digit or a space.
        // #	A digit, a space, "+" or "-" sign.
        // L	A literal.
        // C	Any character except space.
        // c	Any character.
        // A	An alphanumeric.
        // a	An alphanumeric or a space.
        // To escape a masking element, use two backslash characters (\\). For instance, \\0 allows users to input only 0.
        mask: "00/00/0000", // mask for date
        //mask: "shnf", // using custom mask rules

        // Specifies a mask placeholder. A single character is recommended.
        // default: "_"
        maskChar: "-",

        // A message displayed when the entered text does not match the specified pattern.
        maskInvalidMessage: "Invalid value",

        // Specifies custom mask rules.
        maskRules: {
            's': '$', // a single character
            'h': /[0-9A-F]/, // a regular expression
            'n': ["$", "%", "&", "@"], // an array of characters
            'f': function (char, index, string) { // a function
                const allowedChars = ['a', 'b', 'c', '$', '_', '.'];
                return allowedChars.includes(char);
            }
        },

        // Specifies the maximum number of characters you can enter into the textbox.
        //maxLength: 10,

        // The "mode" attribute value of the actual HTML input element representing the text box.
        // The value of this property affects the set of keyboard buttons shown on the mobile device when the UI component gets focus. In addition, the following mode values add visual features to the UI component:
        // "search" - the text box contains the "X" button, which clears the text box contents
        // "password" - the text box shows a password character instead of the actual characters typed
        // Accepted Values: 'email' | 'password' | 'search' | 'tel' | 'text' | 'url'
         mode: "text",

        // The value to be assigned to the name attribute of the underlying HTML element.
        // Will affect name of hidden input tag where actual value is stored not to input box
        name: "fruit",

        // A function that is executed when the UI component loses focus after the text field's content was changed using the keyboard.
        // e has {event(jQuery), element(UI's container), component(UI component's instance)}
        // to get value we can use e.event.target.value
        onChange: function (e) {
            console.log("onchange");
            console.log(e);
        },

        // A function that is executed when the UI component is rendered and each time it is repainted.
        // e has {element, component}
        onContentReady: function (e) {
            console.log("onContentReady");
            console.log(e);
        },


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
        placeholder: "Select on",

        // Specifies whether the editor is read-only.
        // Built-in action buttons are invisible.
        //Custom action buttons are visible but disabled.If a button should not be disabled, set its disabled property to false:
        readOnly: false,

        // Switches the UI component to a right-to-left representation.
        rtlEnabled: false,

        // Specifies whether to display the Clear button in the UI component.
         showClearButton: true,

         // Specifies when the UI component shows the mask. Applies only if useMaskedValue is true.
         // Accepted Values: 'always'(default) | 'onFocus'
         showMaskMode: "onFocus",

        // Specifies whether or not the UI component checks the inner text for spelling mistakes.
        // default: true
        spellcheck: true,

        // Specifies how the UI component's text field is styled.
        // options : outlined, underlined, filled
        //stylingMode: "underlined",

        // Specifies the number of the element when the Tab key is used for navigating.
        // if two have same value accoding to DOM order will be select
        // make it -1 to disable tab focus, make it 0 to follow natural DOM order
        tabIndex: 1,

        // The read-only property that holds the text displayed by the UI component input element.
        // text

        // Specifies whether the value should contain mask characters or not.
         useMaskedValue: false,

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
        value: "select",

        // Specifies the DOM events after which the UI component's value should be updated.
        // The recommended events are "keyup", "blur", "change", "input", and "focusout", but you can use other events as well.
        valueChangeEvent: "blur",

        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        width: 400
    }).dxTextBox("instance");

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //textBoxInstance.beginUpdate();

    // Removes focus from the check box.
    //textBoxInstance.blur();

    // Resets the value property to the default value.
    //textBoxInstance.clear();


    // Disposes of all the resources allocated to the CheckBox instance.
    //textBoxInstance.dispose();

    // Gets the root UI component element.
    //textBoxInstance.element().focusin();

    // Refreshes the UI component after a call of the beginUpdate() method.
    //textBoxInstance.endUpdate();

    // Sets focus on the UI component.
    //textBoxInstance.focus();

    // Gets an instance of a custom action button.
    textBoxInstance.getButton("search").focus();


    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomID");
    let instance = DevExpress.ui.dxTextBox.getInstance(element);
    //console.log(instance === textBoxInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = textBoxInstance.instance();
    //console.log(instance === textBoxInstance);

    // Detaches all event handlers from a single event.
    //textBoxInstance.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //textBoxInstance.off("valueChanged", cb1);

    // To attach event listener
    //textBoxInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    //textBoxInstance.on({
    //    "valueChanged": cb2,
    //    "optionChanged": cb2
    //});
    // Gets all UI component properties.
    //console.log(textBoxInstance.option());

    // Gets the value of a single property.
    //console.log(textBoxInstance.option("readOnly"));

    // Updates the value of a single property.
    //textBoxInstance.option("readOnly", false);

    // Updates the values of several properties.
    //textBoxInstance.option({
    //    "readonly": false,
    //    value: null
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    //textBoxInstance.registerKeyHandler("w", function () {
    //    console.log("w clicked")
    //});

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //textBoxInstance.repaint();

    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    //textBoxInstance.reset("reset");

    // Resets a property to its default value.
    //textBoxInstance.resetOption("value");

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