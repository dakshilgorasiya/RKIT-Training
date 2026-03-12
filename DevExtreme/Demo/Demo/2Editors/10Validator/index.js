$(() => {
    let callbacks = [];

    let validatorDemo = $("#textBox").dxTextBox({

        // for demo of adapter
        //onValueChanged: function () {
        //    // to use adapter
        //    callbacks.forEach((callback) => {
        //        callback();
        //    });
        //},
        //disabled: true,
        elementAttr: {
            id: "CID"
        }, 

        validationMessageMode: "always"
    }).dxValidator({
        // Specifies the global attributes to be attached to the UI component's container element.
        // It will override textBox's id
        elementAttr: {
            id: "CustomId"
        },

        //Specifies the UI component's height.
        //height: 100,

        // Specifies the editor name to be used in the validation default messages.
        name: "name",

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

        // A function that is executed after a value is validated.
        // e has {}
        onValidated: function (e) {
            console.log("onValidated");
            console.log(e);
        },

        // Specifies the validation group the editor will be related to.
        // Generally, the editors that are associated with dxValidator objects are validated on each value change. But you can combine several editors into a group so that they are validated together (e.g., on a button click).
        // The validationGroup property should be specified for the associated dxValidator object to indicate the validation group within which the editor will be validated. Assign the same validation group name for those editors that should be validated together.
        validationGroup: "myForm",

        // An array of validation rules to be checked for the editor with which the dxValidator object is associated.
        validationRules: [
            // Async
            // A custom validation rule that is checked asynchronously. Use async rules for server-side validation.
            // Validation rules are checked in the following order: All the synchronous rules are checked in the same order as in the validationRules array. Then, all the async rules are checked simultaneously.
            //{
            //    type: "async",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Invalid value",

            //    // Indicates whether the rule should always be checked for the target value or only when the value changes.
            //    reevaluate: true,

            //    // A function that validates the target value.
            //    // params has {column, data, formItem, rule, validator, value}
            //    validationCallback: function (param) {
            //        return new Promise((resolve, reject) => {
            //            setTimeout(() => {
            //                // default value will be
            //                //reject();

            //                // This message will be displayed
            //                // reject("HI");
            //            }, 1000)
            //        });
            //    }
            //}

            // Compare
            // A validation rule that requires validated values to match a specified expression.
            //{
            //    type: "compare",

            //    // To specify a comparison expression, define the comparisonTarget function. Validator compares values to this function's return value. To configure which comparison operator Validator compares values to, specify the comparisonType property.
            //    comparisonTarget: function () {
            //        return "HI";
            //    },

            //    // Specifies the operator to be used for comparing the validated value with the target.
            //    // Accepted Values: '!=' | '!==' | '<' | '<=' | '==' | '===' | '>' | '>='
            //    // Default Value: '=='
            //    comparisonType: "==",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Invalid value"
            //},


            // custom
            // A rule with custom validation logic.
            //{
            //    type: "custom",

            //    // If true, the validationCallback is not executed for null, undefined, false, and empty strings.
            //    ignoreEmptyValue: false,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Invalid value",

            //    // Indicates whether the rule should be always checked for the target value or only when the target value changes.
            //    // If you set this property to false, the rule is checked only when you change an editor's value. If you enter a value and validate the editor's value twice, the validation callback is executed only once.
            //    // If you set this property to false, the rule is checked only when you change an editor's value. If you enter a value and validate the editor's value twice, the validation callback is executed only once.
            //    reevaluate: false,

            //    // A function that validates the target value.
            //    // Return Value: Boolean
            //    // true if the value is valid; otherwise, false.
            //    // e has {column, data, formItem, rule, validator, value}
            //    validationCallback: function (e) {
            //        if (e.value == "HI") {
            //            return true;
            //        } else {
            //            return false;
            //        }
            //    }
            //},

            // Email
            // A validation rule that requires that the validated field match the Email pattern.
            // It use pattern: /^[\d\w._-]+@[\d\w._-]+\.[\w]+$/i
            //{
            //    type: "email",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Invalid email"
            //},

            // Numeric
            // A validation rule that demands that the validated field has a numeric value.
            //{
            //    type: "numeric",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Invalid number",
            //},

            // Pattern
            // A validation rule that requires that the validated field match a specified pattern.
            //{
            //    type: "pattern",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Invalid value",

            //    // Specifies the regular expression that the validated value must match.
            //    pattern: /^[\d\w._-]+@[\d\w._-]+\.[\w]+$/
            //},

            // Range
            // A validation rule that demands the target value be within the specified value range (including the range's end points).
            //{
            //    type: "range",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the maximum value allowed for the validated value.
            //    max: 5,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Value must be in range",

            //    // Specifies the minimum value allowed for the validated value.
            //    min: 1,

            //    // Indicates whether the rule should be always checked for the target value or only when the target value changes.
            //    reevaluate: false,
            //},

             //Required
             //A validation rule that rejects empty and invalid values.
            {
                type: "required",

                // Specifies the message that is shown if the rule is broken.
                message: "Value is required",

                // Indicates whether to remove the Space characters from the validated value.
                trim: false
            },

            // StringLength
            // A validation rule that demands the target value length be within the specified value range (including the range's end points).
            //{
            //    type: "stringLength",

            //    // If set to true, empty values are valid.
            //    ignoreEmptyValue: false,

            //    // Specifies the maximum length allowed for the validated value.
            //    max: 5,

            //    // Specifies the message that is shown if the rule is broken.
            //    message: "Value must be in range",

            //    // Specifies the minimum length allowed for the validated value.
            //    min: 1,

            //    // Indicates whether or not to remove the Space characters from the validated value.
            //    trim: false,
            //}
        ]

        // Specifies the UI component's width.
        //width: 100,
    }).dxValidator("instance");

     $("#adapterDemo").dxValidator({
        validationRules: [{
            type: "required",
            message: "This custom field is required!"
        }],

        // An object that specifies what and when to validate, and how to apply the validation result.
        // This property should be specified when you cannot associate the Validator UI component with an editor, for instance, when you use custom editors or a validated value is a sequence of several DevExtreme editor values.
        adapter: {
            // A function that the Validator UI component calls after validating a specified value.
            // This function should apply the validation result that the validator passes as a parameter. The validation result is an object. 
            applyValidationResults: function (e) {
                if (e.isValid) {
                    $("#textBox").css("border", "1px solid green");
                } else {
                    $("#textBox").css("border", "2px solid red");
                }
            },

            // A function that returns a Boolean value specifying whether or not to bypass validation.
            // If the function returns true, validation is bypassed, otherwise validation is performed.
            bypass: function () {

                // skip validation if input is disabled
                return validatorDemo.option("disabled");
            },

            // A function that sets focus to a validated editor when the corresponding ValidationSummary item is focused.
            focus: function () {
                // Handle focus requests from a ValidationSummary
                validatorDemo.focus();
            },

            // A function that returns the value to be validated.
            getValue: function () {
                return validatorDemo.option("value");
            },

            // A function that resets the validated values.
            // The function resets the values so that end users can then specify other values. This function is called by the reset method of the Validator UI component.
            reset: function (e) {
                validatorDemo.reset();
                $("#textBox").css("border", "");
            },

            // Callbacks to be executed on the value validation.
            validationRequestsCallbacks: callbacks
        }
    });

    $("#btn").dxButton({
        text: "Validate",
        onClick: function (e) {
            e.validationGroup.validate();
        }
    });

    $("#validationSummary").dxValidationSummary({

    }); 

    // Methods
    // Disposes of all the resources allocated to the CheckBox instance.
    //validatorDemo.dispose();

    // Gets the root UI component element.
     //console.log(validatorDemo.element().focusin());

    // Sets focus on the UI component.
    //validatorDemo.focus();

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("CustomId");
    let instance = DevExpress.ui.dxValidator.getInstance(element);
    //console.log(instance === validatorDemo);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = validatorDemo.instance();
    //console.log(instance === validatorDemo);

    // Detaches all event handlers from a single event.
    //validatorDemo.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //validatorDemo.off("valueChanged", cb1);

    // To attach event listener
    //validatorDemo.on("valueChanged", cb1);

    // To attach multiple event listener
    validatorDemo.on({
        "valueChanged": cb1,
        "optionChanged": cb2
    });

    // Gets all UI component properties.
    //console.log(validatorDemo.option());

    // Gets the value of a single property.
    //console.log(validatorDemo.option("readOnly"));

    // Updates the value of a single property.
    //validatorDemo.option("readOnly", false);

    // Updates the values of several properties.
    //validatorDemo.option({
    //    "readonly": false,
    //    value: null
    //});

    // Resets the value property to the initial value.
    // This method sets the isDirty flag to false.
    //validatorDemo.reset();

  // Resets a property to its default value.
  //validatorDemo.resetOption("value");

    // Validates the value of the editor that is controlled by the current Validator object against the list of the specified validation rules.
    validatorDemo.validate();

  // EVENTS
  // disposing : Raised before the UI component is disposed of.
  // initialized : Raised only once, after the UI component is initialized.
  // optionChanged : Raised after a UI component property is changed.
  // validated : Raised after a value is validated.
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