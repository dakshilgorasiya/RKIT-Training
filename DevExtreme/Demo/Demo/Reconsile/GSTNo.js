$(() => {
    let gstValidator = $("#gstNum").dxTextBox({
        label: "gstNum",
        validationMessageMode: "always",
        validationMessagePosition: "bottom"
    }).dxValidator({
        validationRules: [
            {
                type: "custom",
                reevaluate: true,
                validationCallback: function (e) {
                    let pan = $("#pan").dxTextBox("option", "value");
                    let state = $("#state").dxTextBox("option", "value");
                    const gst = e.value;

                    if (!gst) {
                        return true;
                    }

                    if (gst.length !== 15) {
                        e.rule.message = "Length of GST number must be 15";
                        return false;
                    }
                    if (!gst.startsWith(state)) {
                        e.rule.message = "State code not matched";
                        return false;
                    }
                    if (gst.substr(2, 10) !== pan) {
                        e.rule.message = "PAN number not matched";
                        return false;
                    }
                    if (gst[13] !== "Z") {
                        e.rule.message = "14th digit must be 'Z'";
                        return false;
                    }
                    return true;
                }
            },
            //{
            //    type: "compare",
            //    ignoreEmptyValue: false,
            //    message: "GST is invalid",
            //    comparisonTarget: function () {
            //        let internalRule = gstValidator.option("validationRules")[0];

            //        let pan = $("#pan").dxTextBox("option", "value");
            //        let state = $("#state").dxTextBox("option", "value");
            //        let gst = $("#gstNum").dxTextBox("option", "value");

            //        if (gst.length !== 15) {
            //            internalRule.message = "Length of GST number must be 15";
            //            return false;
            //        }
            //        if (!gst.startsWith(state)) {
            //            internalRule.message = "State code not matched";
            //            return false;
            //        }
            //        if (gst.substr(2, 10) !== pan) {
            //            internalRule.message = "PAN number not matched";
            //            return false;
            //        }
            //        if (gst[13] !== "Z") {
            //            internalRule.message = "14th digit must be 'Z'";
            //            return false;
            //        }

            //        return state + pan + gst[12] + "Z" + gst[14];
            //    }
            //}
        ]
    }).dxValidator("instance");

    $("#pan").dxTextBox({
        label: "pan",
        onValueChanged: function (e) {
            gstValidator.validate();
        }
    });
    $("#state").dxTextBox({
        label: "state",
        onValueChanged: function (e) {
            gstValidator.validate();
        }
    });
});