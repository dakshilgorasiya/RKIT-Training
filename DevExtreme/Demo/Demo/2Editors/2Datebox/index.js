$(() => {
  // Specifies the device-dependent default configuration properties for this component.
  DevExpress.ui.dxDateBox.defaultOptions({
    device: { deviceType: "desktop" },
    options: {
      value: new Date(2005, 2, 12),
    },
  });

  var dateBoxInstance = $("#date-box")
    .dxDateBox({
      // Specifies whether a user can type a date directly into the text field.
      // If false, the user must pick a date from the picker only.
      acceptCustomValue: true,

      // Specifies the shortcut key that sets focus on the UI component.
      // In Chrome press alt+a to focus. Behavior varies by browser.
      accessKey: "A",

      // Specifies whether the UI component changes its visual state as a result of user interaction.
      // If true, a pressed/active effect is shown when the user clicks the input field.
      activeStateEnabled: true,

      // Enables adaptive rendering on small screens.
      // When true, the digital clock face is hidden on mobile.
      adaptivityEnabled: true,

      // The text displayed on the Apply button.
      // Visible only when applyValueMode is "useButtons".
      applyButtonText: "Done",

      // Specifies how the end user applies the selected value.
      //   "instantly"  → value is applied as soon as the user picks a date (default)
      //   "useButtons" → user must click the Apply/Cancel buttons to confirm
      // NOTE: "instantly" cannot be used when pickerType is "rollers" or type is "datetime".
      applyValueMode: "useButtons",

      // Allows you to add custom buttons to the input text field.
      buttons: [
        "clear",
        "dropDown",
        {
          name: "today",
          location: "after",
          options: {
            text: "Today",
            onClick() {
              dateBoxInstance.option("value", new Date());
            },
          },
        },
      ],

      // Configures the embedded Calendar component.
      // Applies only when pickerType is "calendar".
      // Most dxCalendar options are accepted here EXCEPT:
      //   dateSerializationFormat, disabledDates, max, min,
      //   onValueChanged, selectionMode, tabIndex, value
      // (those are controlled by DateBox itself)
      calendarOptions: {
        firstDayOfWeek: 0, // 0 = Sunday, 1 = Monday
        showTodayButton: false,
        zoomLevel: "month", // "month" | "year" | "decade" | "century"
      },

      // The text displayed on the Cancel button.
      // Visible only when applyValueMode is "useButtons".
      cancelButtonText: "Cancel",

      // The message shown when the entered value is outside the [min, max] range.
      dateOutOfRangeMessage: "Value is out of range",

      // Specifies the serialization format for the date-time value.
      // Use LDML patterns. Examples:
      //   "yyyy-MM-dd"            → date only
      //   "yyyy-MM-ddTHH:mm:ss"  → local date & time
      //   "yyyy-MM-ddTHH:mm:ssZ" → UTC date & time
      // NOTE: Only applies when the initial value is NOT set.
      //       When set, the component value becomes a string, not a Date object.
      dateSerializationFormat: "yyyy-MM-dd hh:mm:ss",

      // Specifies whether the drop-down content is rendered lazily (on first open).
      // true  → rendered when first opened (default, better performance)
      // false → rendered immediately on component init
      deferRendering: true,

      // To disable the DateBox
      disabled: false,

      // Specifies dates that users cannot select in the calendar picker.
      // Accepts an array of Date objects OR a callback function.
      // Applies only when pickerType is "calendar".
      // Example (disable all Sundays):
      disabledDates: function (data) {
        return data.view === "month" && data.date.getDay() === 0;
      },
      //disabledDates: [
      //    new Date(2025, 11, 25), // Dec 25 2025
      //    new Date(2026, 0, 1),   // Jan 1 2026
      //],

      // Specifies the display format of the date value inside the text field.
      // Uses LDML or predefined DevExtreme format strings.
      // Examples: "dd/MM/yyyy", "shortDate", "longDate", "MM-dd-yyyy"
      displayFormat: "dd/MM/yyyy hh:mm:ss a",

      // Specifies a custom template for the drop-down button.
      //dropDownButtonTemplate: function () {
      //    return $("<span>").text("Select Date");
      //},

      // Configures the drop-down field which holds the content.
      dropDownOptions: {
        fullScreen: false,
      },

      // To attach custom attributes to the root container element.
      elementAttr: {
        id: "customId",
        class: "class1 class2",
      },

      // Configures the drop-down field which holds the content.

      // Specifies whether the UI component can be focused using keyboard navigation.
      // Press Tab to focus
      focusStateEnabled: true,

      // Specifies the UI component's height (container height).
      // Can be a number (px) or a string like "55px", "20vh", "80%", "inherit".
      height: 50,

      // Specifies text for a hint that appears when a user hovers over the UI component.
      hint: "Select a date",

      // Specifies whether the UI component changes its state when a user hovers over it.
      hoverStateEnabled: true,

      // Attributes to be attached to the underlying <input> HTML element.
      // Different from elementAttr, which targets the root container.
      inputAttr: {
        "aria-label": "Date picker",
        "data-testid": "date-input",
      },

      // Specifies the time interval (in minutes) between items in the time-picker drop-down.
      // This property applies only if the type property is set to "time" and the pickerType is "list".
      interval: 10,

      // The message shown when the entered string cannot be parsed as a valid date.
      invalidDateMessage: "Date value is invalid",

      // isDirty (read-only)
      // Indicates whether the current value differs from the initial value.
      // If acceptCustomValue is enabled and the entered value is not a date, the isDirty value does not change.

      // isValid
      // Indicates whether the editor's current value passes validation.
      // NOTE: When async rules are used, isValid is true while status is "pending".

      // The label text shown above / inside the input field.
      label: "Select Date",

      // Controls how the label behaves relative to the input field.
      //   "static"   → label is always above the input
      //   "floating" → label floats up when the input has focus or a value
      //   "hidden"   → label is not shown
      //   "outside"  → label is rendered outside the input container
      labelMode: "floating",

      // The maximum date/time that can be selected.
      // If this property is undefined, pickerType - "rollers", type - "date" or "datetime", the UI component renders values up to 50 years from the current date
      // Dates after this value will be disabled in the picker.
      max: new Date(2030, 11, 31),

      // Specifies the maximum number of characters a user can type into the text field.
      // maxLength: 10,

      // The minimum date/time that can be selected.
      // Dates before this value will be disabled in the picker.
      min: new Date(2000, 0, 1),

      // The value to be assigned to the name attribute of the underlying HTML element.
      // Useful when the input is inside a <form>.
      name: "dateField",

      // Fires when the user changes the input value via keyboard (not the picker).
      // Useful for detecting manual text entry.
      onChange: function (e) {
        console.log("onChange (keyboard input)");
        console.log(e);
      },

      // Fires when the drop-down picker is closed.
      onClosed: function (e) {
        console.log("onClosed");
        console.log(e);
      },

      // A function that is executed when the UI component is rendered and each time it is repainted.
      onContentReady: function (e) {
        console.log("onContentReady");
        console.log(e);
      },

      // Fires when the user copies text from the input field.
      onCopy: function (e) {
        console.log("onCopy");
        console.log(e);
      },

      // Fires when the user cuts text from the input field.
      onCut: function (e) {
        console.log("onCut");
        console.log(e);
      },

      // A function that is executed before the UI component is disposed of.
      onDisposing: function (e) {
        console.log("onDisposing");
        console.log(e);
      },

      // Fires when the user presses Enter inside the text field.
      onEnterKey: function (e) {
        console.log("onEnterKey");
        console.log(e);
      },

      // Fires when the text field receives focus.
      //onFocusIn: function (e) {
      //    console.log("onFocusIn");
      //    console.log(e);
      //},

      // Fires when the text field loses focus.
      //onFocusOut: function (e) {
      //    console.log("onFocusOut");
      //    console.log(e);
      //},

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
      onInitialized: function (e) {
        console.log("onInitialized");
        console.log(e);
      },

      // Fires on every keystroke inside the text field.
      //onInput: function (e) {
      //    console.log("onInput");
      //    console.log(e);
      //},

      // Fires on keydown inside the text field.
      //onKeyDown: function (e) {
      //    console.log("onKeyDown");
      //    console.log(e);
      //},

      // Fires on keyup inside the text field.
      //onKeyUp: function (e) {
      //    console.log("onKeyUp");
      //    console.log(e);
      //},

      // Fires when the drop-down picker is opened.
      onOpened: function (e) {
        console.log("onOpened");
        console.log(e);
      },

      // A function that is executed after a UI component property is changed.
      //onOptionChanged: function (e) {
      //    console.log("onOptionChanged");
      //    console.log(e);
      //    console.log(e.value);
      //},

      // Fires when the user pastes content into the text field.
      onPaste: function (e) {
        console.log("onPaste");
        console.log(e);
      },

      // A function that is executed after the UI component's value is changed.
      // e.previousValue → old Date (or string), e.value → new Date (or string)
      onValueChanged: function (e) {
        console.log("onValueChanged");
        console.log(e.previousValue, "->", e.value);
      },

      // Whether the drop-down picker is currently open.
      // Can be set programmatically to open/close the picker.
      opened: true,

      // If true, clicking anywhere in the text field opens the picker.
      // If false, only the drop-down button opens the picker.
      openOnFieldClick: true,

      // Specifies the type of date/time picker UI shown in the drop-down.
      //   "calendar" → calendar view (default for "date" / "datetime")
      //   "list"     → scrollable time list (default for "time")
      //   "native"   → browser-native date input
      pickerType: "calendar",

      // Placeholder text shown inside the input field when it is empty.
      placeholder: "DD/MM/YYYY",

      // Specifies whether the editor is read-only.
      // The user can see the value but cannot change it.
      readOnly: false,

      // Switches the UI component to a right-to-left representation.
      // When true, text flows right-to-left and layout is reversed.
      rtlEnabled: false,

      // Whether to show an analog clock in the datetime picker.
      // Applies when type is "datetime" and pickerType is "calendar".
      showAnalogClock: true,

      // Whether to display a clear (×) button inside the input field.
      // Clicking it resets the value to null.
      showClearButton: true,

      // Whether to display the drop-down (calendar) toggle button.
      showDropDownButton: true,

      // Whether to enable spell-checking on the text input.
      spellcheck: false,

      // Controls the visual style of the input field.
      //   "outlined"   → border around the entire field (default)
      //   "underlined" → bottom border only
      //   "filled"     → filled background
      stylingMode: "outlined",

      // Specifies the tab order of the element when Tab key navigation is used.
      tabIndex: 0,

      // text (read-only)
      // The text representation of the current value as it appears in the input field.

      // The text on the "Today" shortcut button in the calendar picker.
      // Visible when calendarOptions.showTodayButton is true OR applyValueMode is "useButtons".
      todayButtonText: "Today",

      // Specifies which part of date/time the component handles.
      //   "date"     → date only (default)
      //   "time"     → time only
      //   "datetime" → both date and time
      type: "datetime",

      // Enables a masked input so the user types into pre-formatted placeholders
      // (e.g., __/__/____) instead of a free text field.
      // Prevents malformed manual date entry.
      useMaskBehavior: false,

      // validationError
      // Information about the broken validation rule (first item from validationErrors array).

      // validationErrors
      // An array of all validation rules that failed.

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

      // The current value of the DateBox.
      // Accepts a JavaScript Date object, an ISO string, or null.
      // null → empty / no date selected
      value: new Date(2005, 2, 12),

      // The event that triggers a value change when typing directly into the field.
      //   "change" → fires on blur (default)
      //   "keyup"  → fires on every keystroke
      valueChangeEvent: "keyup",

      // Specifies whether the UI component is visible.
      visible: true,

      // Specifies the UI component's width (container width).
      // Can be a number (px) or a string like "250px", "50%", "inherit".
      width: 350,
    })
    .dxDateBox("instance");

  // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
  // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
  dateBoxInstance.beginUpdate();

  // Removes focus from the check box.
  dateBoxInstance.blur();

  // Resets the value property to the default value.
  //dateBoxInstance.clear();

  // Closes the drop-down editor.
  //dateBoxInstance.close();

  // Gets the popup window's content.
  console.log("Content", dateBoxInstance.content());

  // Disposes of all the resources allocated to the CheckBox instance.
  //dateBoxInstance.dispose();

  // Gets the root UI component element.
  // console.log(dateBoxInstance.element().focusin());

  // Refreshes the UI component after a call of the beginUpdate() method.
  dateBoxInstance.endUpdate();

  // Gets the UI component's <input> element.
  console.log("Field", dateBoxInstance.field());

  // Gets an instance of a custom action button.
  //dateBoxInstance.getButton("today").focus();

  // Sets focus on the UI component.
  //dateBoxInstance.focus();

  // Gets the instance of a UI component found using its DOM node.
  //let element = document.getElementById("customId");
  //let instance = DevExpress.ui.dxDateBox.getInstance(element);
  //console.log(instance === dateBoxInstance);

  // Gets the UI component's instance. Use it to access other methods of the UI component.
  //instance = dateBoxInstance.instance();
  //console.log(instance === dateBoxInstance);

  // Detaches all event handlers from a single event.
  //dateBoxInstance.off("valueChanged");

  // Detaches a particular event handler from a single event.
  //dateBoxInstance.off("valueChanged", cb1);

  // To attach event listener
  //dateBoxInstance.on("valueChanged", cb1);

  // To attach multiple event listener
  //dateBoxInstance.on({
  //    "valueChanged": cb2,
  //    "optionChanged": cb2
  //});

  // Opens the drop-down editor.
  //dateBoxInstance.open();

  // Gets all UI component properties.
  //console.log(dateBoxInstance.option());

  // Gets the value of a single property.
  //console.log(dateBoxInstance.option("readOnly"));

  // Updates the value of a single property.
  //dateBoxInstance.option("readOnly", false);

  // Updates the values of several properties.
  //dateBoxInstance.option({
  //    "readonly": false,
  //    value: null
  //});

  // Registers a handler to be executed when a user presses a specific key.
  // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"

  //dateBoxInstance.registerKeyHandler("w", function () {
  //    console.log("w clicked")
  //})

  // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
  // The repaint() method re - initializes the component with new settings, resetting its state and history.
  //dateBoxInstance.repaint();

  // Resets the value property to the initial value.
  // This method sets the isDirty flag to false.
  //dateBoxInstance.reset();

  // Resets the value property to the value passed as an argument.
  // This method sets the isDirty flag to false.
  dateBoxInstance.reset(new Date(2001, 0, 1));

  // Resets a property to its default value.
  //dateBoxInstance.resetOption("buttons");

  // EVENTS
  // change : Raised when the UI component loses focus after the text field's content was changed using the keyboard.
  // closed : Raised once the drop-down editor is closed.
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
