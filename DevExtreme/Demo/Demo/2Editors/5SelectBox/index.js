$(() => {
    const fruits = ["Apples", "Oranges", "Lemons", "Pears", "Pineapples"];
    const dataSource = fruits;

    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxSelectBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            value: "defaultValue",
        },
    });

    let selectBoxInstance = $("#selectBox").dxSelectBox({
        // Specifies whether the UI component allows a user to enter a custom value. 
        // Requires the onCustomItemCreating handler implementation.
        acceptCustomValue: true,

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
            "dropDown",
        ],

        // Specifies the DOM event after which the custom item should be created. Applies only if acceptCustomValue is enabled.
        // The recommended events are "blur", "change", and "focusout", but you can use other events as well. The default value of this property is "change", and items are created when the component loses focus.
        // Besides the event passed to this property, the item can also be created when users press the Enter key. To allow users to create items only when they press the Enter key, pass an empty string to this property.
        customItemCreateEvent: "focusout",

        // Binds the UI component to data.
        // Do not specify the items property if you specified the dataSource, and vice versa.
        // Field names cannot be equal to this and should not contain the following characters: ., :, [, and ].
        dataSource: dataSource,

        // Specifies whether to render the drop-down field's content when it is displayed. If false, the content is rendered immediately.
        deferRendering: true,

        // Specifies whether the UI component responds to user interaction.
        disabled: false,

        // Specifies the data field whose values should be displayed.
        displayExpr: function (item) {
            return item;
        },

        // Returns the value currently displayed by the UI component.
        // Read-only

        // Returns the value currently displayed by the UI component.
        // displayValue


        // Specifies a custom template for the drop-down button.
        //dropDownButtonTemplate: function () {
        //    return $("<span>").text("Select one");
        //},

        // Configures the drop-down field which holds the content.
        dropDownOptions: {
            fullScreen: false,
        },

        // Specifies the global attributes to be attached to the UI component's container element.
        elementAttr: {
            id: "CustomID"
        },


        // Specifies a custom template for the text field. Must contain the TextBox UI component.
        // If you define a fieldTemplate, the component does not render the underlying HTML. In this case, you should render hidden input with the corresponding name attribute to submit values through a HTML form.
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

        // Specifies whether data items should be grouped.
        // If you enable both this property and DataSource.paginate, the pagination works only on the group level.
        // grouped

        // Specifies a custom template for group captions.
        // groupTemplate

        // Specifies the UI component's height.
        //height: 100,

        // Specifies text for a hint that appears when a user pauses on the UI component.
        //hint: "This is hint",

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
        //items: [1,2,3,4],

        // Specifies a custom template for items.
        itemTemplate: function (data) {
            return `
            <div class='custom-item'>
                <h3>Natural </h3>
                <div class='product-name'>${data}</div>
            </div>`;
        },

        // Specifies a text string used to annotate the editor's value.
        label: "Choose food",

        // Specifies the label's display mode.
        // static(default), floating, hidden, outside
        labelMode: "outside",

        // Specifies the maximum number of characters you can enter into the textbox.
        maxLength: 10,

        // The minimum number of characters that must be entered into the text box to begin a search. Applies only if searchEnabled is true.
        // When the SelectBox input field contains text (an item is selected), the component ignores minSearchLength and starts searching after users enter one character.
        minSearchLength: 2,

        // Specifies the text or HTML markup displayed by the UI component if the item collection is empty.
        // The SelectBox component evaluates the noDataText property's value. This evaluation, however, makes the SelectBox potentially vulnerable to XSS attacks. To guard against these attacks, encode the HTML markup before you assign it to the noDataText property.
        // default: 'No data to display'
        noDataText: "no item to show",

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

        // A function that is executed when the UI component is rendered and each time the component is repainted.
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

        // A function that is executed when a user adds a custom item. Requires acceptCustomValue to be set to true.
        // You can specify DOM events after which the component calls this function. Use the customItemCreateEvent property for this purpose. Besides the event passed to this property, the item can also be created when users press the Enter key.
        // e gets {component, customItem, element, text }
        // set customItem to null to cancel custom item creation
        onCustomItemCreating: function (e) {
            dataSource.push(e.text.trim());
            e.component.option("dataSource", dataSource);
            e.customItem = e.text.trim();
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

        // A function that is executed when a list item is clicked or tapped.
        // e has {itemIndex, itemElement, itemData, event, element, component}
        onItemClick: function (e) {
            console.log("onItemClick");
            console.log(e);
        },

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

        // A function that is executed when a list item is selected or selection is canceled.
        // e has {selectedItem, element, component}
        onSelectionChanged: function (e) {
            console.log("onSelectionChanged");
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
        opened: true,

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

        // Specifies whether to allow search operations.
        // Searching works with source data of plain structure only. Subsequently, data can be transformed to hierarchical structure using the DataSource's group property.
        searchEnabled: true,

        // Specifies the name of a data source item field or an expression whose value is compared to the search criterion.
        // In most cases, you should pass the name of a field by whose value data items are searched.If you need to search elements by several field values, assign an array of field names to this property.
        //searchExpr:

        // Specifies a comparison operation used to search UI component items.
        // Default Value: 'contains'
        // This property changes how users search SelectBox items and controls the component's auto-fill functionality. The following values are available for searchMode:
        // 'contains' -> Searches items that contain the typed text.SelectBox does not activate autofill. (default)
        // 'startswith' -> Searches items that start with the typed text.SelectBox autofills the input with the first matched item if acceptCustomValue is false(default ).If acceptCustomValue is true, the component does not activate autofill.
        searchMode: "contains",

        // Specifies the time delay, in milliseconds, after the last character has been typed in, before a search is executed.
        // Default Value: 500
        searchTimeout: 200,

        // Gets the currently selected item.
        // read only
        // selectedItem

        // Specifies whether to display the Clear button in the UI component.
        showClearButton: true,

        // Specifies whether or not the UI component displays unfiltered values until a user types a number of characters exceeding the minSearchLength property value
        // default: false
        showDataBeforeSearch: true,

        // Specifies whether the drop-down button is visible.
        showDropDownButton: true,

        // Specifies whether or not to display selection controls.
        // default: false
        showSelectionControls: true,

        // Specifies whether or not the UI component checks the inner text for spelling mistakes.
        // Default: false
        spellcheck: true,

        // Specifies how the UI component's text field is styled.
        // options : outlined, underlined, filled
        //stylingMode: "underlined",

        // Specifies the number of the element when the Tab key is used for navigating.
        // if two have same value accoding to DOM order will be select
        // make it -1 to disable tab focus, make it 0 to follow natural DOM order
        tabIndex: 1,

        // The read-only property that holds the text displayed by the UI component input element.
        // displayValue define what is selected text is diffrent when user is typing
        // text

        // Specifies whether the SelectBox uses item's text a title attribute.
        // If the property is set to true, the text that items within the SelectBox contain is passed to the title attribute of the respective item.
        // Only add title but behaviour is handled by browser
        useItemTextAsTitle: true,

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
        //value: "Apples",

        // deprecated
        // Use the customItemCreateEvent property instead.
        // Specifies the DOM events after which the UI component's value should be updated. Applies only if acceptCustomValue is set to true.
        // This property accepts a single event name or several names separated by spaces.
        // The recommended events are "keyup", "blur", "change", "input", and "focusout", but you can use other events as well.
        //valueChangeEvent: "blur, keyup",

        // Specifies which data field provides unique values to the UI component's value.
        valueExpr: function (item) {
            return item;
        },

        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        width: 400,

        // Specifies whether text that exceeds the drop-down list width should be wrapped.
        // default: false
        wrapItemText: true,
    }).dxSelectBox("instance");

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //selectBoxInstance.beginUpdate();

    // Removes focus from the check box.
    //selectBoxInstance.blur();

    // Resets the value property to the default value.
    //selectBoxInstance.clear();

    // Closes the drop-down editor.
    //selectBoxInstance.close();

    // Gets the popup window's content.
    console.log("Content", selectBoxInstance.content());

    // Disposes of all the resources allocated to the CheckBox instance.
    //selectBoxInstance.dispose();

    // Gets the root UI component element.
    //console.log(selectBoxInstance.element().focusin());

    // Refreshes the UI component after a call of the beginUpdate() method.
    //selectBoxInstance.endUpdate();

    // Gets the UI component's <input> element.
    console.log("Field", selectBoxInstance.field());


    // Sets focus on the UI component.
    //selectBoxInstance.focus();

    // Gets an instance of a custom action button.
    //selectBoxInstance.getButton("myBtn").focus();

    // Gets the DataSource instance.
    // This method returns the DataSource instance even if the UI component's dataSource property was given a simple array.
    //console.log("Data source : ", selectBoxInstance.getDataSource())

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomID");
    let instance = DevExpress.ui.dxSelectBox.getInstance(element);
    //console.log(instance === selectBoxInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    //instance = selectBoxInstance.instance();
    //console.log(instance === selectBoxInstance);

    // Detaches all event handlers from a single event.
    //selectBoxInstance.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //selectBoxInstance.off("valueChanged", cb1);

    // To attach event listener
    //selectBoxInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    //selectBoxInstance.on({
    //    "valueChanged": cb2,
    //    "optionChanged": cb2
    //});

    // Opens the drop-down editor.
    //selectBoxInstance.open();

    // Gets all UI component properties.
    //console.log(selectBoxInstance.option());

    // Gets the value of a single property.
    //console.log(selectBoxInstance.option("readOnly"));

    // Updates the value of a single property.
    //selectBoxInstance.option("readOnly", false);

    // Updates the values of several properties.
    //selectBoxInstance.option({
    //    "readonly": false,
    //    value: null
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

    //selectBoxInstance.registerKeyHandler("w", function () {
    //    console.log("w clicked")
    //})

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //selectBoxInstance.repaint();

    // Resets the value property to the initial value.
    // This method sets the isDirty flag to false.
    //selectBoxInstance.reset();

    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    //selectBoxInstance.reset("reset");

    // Resets a property to its default value.
    //selectBoxInstance.resetOption("buttons");

    // EVENTS
    // change : Raised when the UI component loses focus after the text field's content was changed using the keyboard.
    // closed : Raised once the drop-down editor is closed.
    // conentReady : Raised when the UI component is rendered and each time the component is repainted.
    // copy : Raised when the UI component's input has been copied.
    // customItemCreating : Raised when a user adds a custom item.
    // cut : Raised when the UI component's input has been cut.
    // disposing : Raised before the UI component is disposed of.
    // enterKey : Raised when the Enter key has been pressed while the UI component is focused.
    // focusIn : Raised when the UI component gets focus.
    // focusOut : Raised when the UI component loses focus.
    // initialized : Raised only once, after the UI component is initialized.
    // input : Raised each time the UI component's input is changed while the UI component is focused.
    // itemClick : Raised when a list item is clicked or tapped.
    // keyDown : Raised when a user is pressing a key on the keyboard.
    // keyUp : Raised when a user releases a key on the keyboard.
    // opened: Raised once the drop - down editor is opened.
    // optionChanged : Raised after a UI component property is changed.
    // paste : Raised when the UI component's input has been pasted.
    // selectionChanged : Raised when a list item is selected or selection is canceled.
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