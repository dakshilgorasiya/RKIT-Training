$(() => {
    const fruits = ["Apples", "Oranges", "Lemons", "Pears", "Pineapples"];
    const dataSource = fruits;
    let list;


    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxDropDownBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            value: "defaultValue",
        },
    });

    let dropDownBoxInstance = $("#dropdown-box").dxDropDownBox({
        // Specifies whether the UI component allows a user to enter a custom value.
        acceptCustomValue: true,

        // Specifies the shortcut key that sets focus on the UI component.
        accessKey: "a",

        // Specifies whether the UI component changes its visual state as a result of user interaction.
        activeStateEnabled: false,

        // Allows you to add custom buttons to the input text field.
        buttons: [
            "dropDown",
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
            }
        ],

        // Specifies a custom template for the drop-down content.
        contentTemplate: function (e) {
            const $list = $("<div>").dxList({
                //dataSource: dropDownBoxInstance.option("items"),
                dataSource: e.component.getDataSource(),

                selectionMode: "single",

                onItemClick: function (args) {
                    e.component.option("value", args.itemData); // set value
                    e.component.close(); // close dropdown
                },

                allowItemDeleting: true,
                onItemDeleting: function (args) {
                    if (dataSource.length === 1) {
                        args.cancel = true;
                    }
                }
            });

            list = $list.dxList("instance");
            return $list;
        },

        // Binds the UI component to data.
        dataSource: dataSource,

        // Specifies whether to render the drop-down field's content when it is displayed. If false, the content is rendered immediately.
        deferRendering: true,

        // Specifies whether the UI component responds to user interaction.
        disabled: false,

        // Specifies the data field whose values should be displayed.
        displayExpr: function (item) {
            return "#" + item;
        },

        // Customizes text before it is displayed in the input field.
        // This function receives values from the data field set in the displayExpr property and should return a string that contains text for the input field. If the displayExpr is not set, the function receives full data objects.
        displayValueFormatter: function (value) {
            if (!value || (Array.isArray(value) && value.length === 0)) {
                return "";
            }

            return value + "#";
        },


        // Specifies a custom template for the drop-down button.
        //dropDownButtonTemplate: function () {
        //    return $("<span>").text("Select Date");
        //},

        // Configures the drop-down field which holds the content.
        dropDownOptions: {
            fullScreen: false,
        },

        // Specifies the global attributes to be attached to the UI component's container element.
        elementAttr: {
            id: "CustomID"
        },

        //Specifies DropDownBox input field addons.
        //fieldAddons: {
        //    beforeTemplate(data, element) {
        //        element.append(
        //            $('<span>').text('₹').css({ marginRight: '4px' })
        //        );
        //    }
        //},

        // Specifies a custom template for the text field. Must contain the TextBox UI component.
        //fieldTemplate: function (value, fieldElement) {
        //    const result = $("<div class='custom-item'>");
        //    result
        //        .dxTextBox({
        //            value: value,
        //            readOnly: false
        //        });
        //    fieldElement.append(result);
        //},

        // Specifies whether the UI component can be focused using keyboard navigation.
        focusStateEnabled: true,

        // Specifies the UI component's height.
        //height: 100,

        // Specifies text for a hint that appears when a user pauses on the UI component.
        hint: "This is hint",

        // Specifies whether the UI component changes its state when a user pauses on it.
        hoverStateEnabled: true,

        // Specifies the attributes to be passed on to the underlying HTML element.
        //inputAttr: {
        //    "aria-label": "Date picker",
        //},

        // Specifies whether the component's current value differs from the initial value.
        // isDirty

        // Specifies or indicates whether the editor's value is valid.
        // isValid

        // An array of items used to synchronize the DropDownBox with an embedded UI component.
        // Do not use the items property if you use dataSource (and vice versa).
        //items: [1,2,3,4],

        // Specifies a text string used to annotate the editor's value.
        label: "Choose food",

        // Specifies the label's display mode.
        // static(default), floating, hidden, outside
        labelMode: "floating",

        // Specifies the maximum number of characters you can enter into the textbox.
        maxLength: 10,

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

        // A function that is executed once the drop-down editor is closed.
        // e has {element, component}
        onClosed: function (e) {
            console.log("onclosed");
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

        // Fires when the drop-down picker is opened.
        // e has {element, component}
        onOpened: function (e) {
            console.log("onOpened");
            console.log(e);
        },

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

        // Specifies whether or not the drop-down editor is displayed.
        opened: false,

        // Specifies whether a user can open the drop-down list by clicking a text field.
        // default is true
        openOnFieldClick: true,

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

        // Specifies whether the drop-down button is visible.
        showDropDownButton: true,

        // Specifies how the UI component's text field is styled.
        // options : outlined, underlined, filled
        //stylingMode: "underlined",

        // Specifies the number of the element when the Tab key is used for navigating.
        // if two have same value accoding to DOM order will be select
        // make it -1 to disable tab focus, make it 0 to follow natural DOM order
        tabIndex: 1,

        // The read-only property that holds the text displayed by the UI component input element.
        // text

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

        // Specifies which data field provides unique values to the UI component's value.
        valueExpr: function (item) {
            return item;
        },

        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        width: 400
    }).dxDropDownBox("instance"); 

    //dropDownBoxInstance = null;

    let a = $("#CustomID").dxDropDownBox("instance");
    a.blur();

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //dropDownBoxInstance.beginUpdate();

    // Removes focus from the check box.
    dropDownBoxInstance.blur();

    // Resets the value property to the default value.
    //dropDownBoxInstance.clear();

    // Closes the drop-down editor.
    //dropDownBoxInstance.close();

    // Gets the popup window's content.
    console.log("Content", dropDownBoxInstance.content());

    // Disposes of all the resources allocated to the CheckBox instance.
    //dropDownBoxInstance.dispose();

    // Gets the root UI component element.
    //console.log(dropDownBoxInstance.element().focusin());

    // Refreshes the UI component after a call of the beginUpdate() method.
    //dropDownBoxInstance.endUpdate();

    // Gets the UI component's <input> element.
    console.log("Field", dropDownBoxInstance.field());

    // Gets an instance of a custom action button.
    //dropDownBoxInstance.getButton("myBtn").focus();

    // Sets focus on the UI component.
    dropDownBoxInstance.focus();

    // Gets the DataSource instance.
    // This method returns the DataSource instance even if the UI component's dataSource property was given a simple array.
    console.log("Data source : ", dropDownBoxInstance.getDataSource())

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomID");
    let instance = DevExpress.ui.dxDropDownBox.getInstance(element);
    //console.log(instance === dropDownBoxInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    //instance = dropDownBoxInstance.instance();
    //console.log(instance === dropDownBoxInstance);

    // Detaches all event handlers from a single event.
    //dropDownBoxInstance.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //dropDownBoxInstance.off("valueChanged", cb1);

    // To attach event listener
    //dropDownBoxInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    //dropDownBoxInstance.on({
    //    "valueChanged": cb2,
    //    "optionChanged": cb2
    //});

    // Opens the drop-down editor.
    //dropDownBoxInstance.open();

    // Gets all UI component properties.
    console.log(dropDownBoxInstance.option());

    // Gets the value of a single property.
    //console.log(dropDownBoxInstance.option("readOnly"));

    // Updates the value of a single property.
    //dropDownBoxInstance.option("readOnly", false);

    // Updates the values of several properties.
    //dropDownBoxInstance.option({
    //    "readonly": false,
    //    value: null
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    //dropDownBoxInstance.registerKeyHandler("w", function () {
    //    console.log("w clicked")
    //})

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //dropDownBoxInstance.repaint();

    // Resets the value property to the initial value.
    // This method sets the isDirty flag to false.
    //dropDownBoxInstance.reset();

    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    //dropDownBoxInstance.reset("reset");

    // Resets a property to its default value.
    dropDownBoxInstance.resetOption("buttons");

    // EVENTS
    // change : Raised when the UI component loses focus after the text field's content was changed using the keyboard.
    // closed : Raised once the drop-down editor is closed.
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
    // opened: Raised once the drop - down editor is opened.
    // optionChanged : Raised after a UI component property is changed.
    // pasted : Raised when the UI component's input has been pasted.
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