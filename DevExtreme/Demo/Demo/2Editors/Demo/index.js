import { cityState, planDetails } from "./constants.js"

$(() => {
    // Store current section which is displayed
    let currentpage = 1;

    // Store state of form
    let store = {
        email: "",
        username: "",
        password: "",
        gender: "",
        birthdate: null,
        address: "",
        pincode: "",
        state: "",
        city: "",
        selectedPlan: null,
        collegeName: "",
    };

    // Wherether to save data on sessionStorage or not
    let saveLocal = true;

    // Function that loads data from sessionStorage when page loads
    function loadDataFromSession() {
        console.log("LOad data from session");
        store.email = sessionStorage.getItem("email");
        store.username = sessionStorage.getItem("username");
        store.password = sessionStorage.getItem("password");
        store.gender = sessionStorage.getItem("gender");
        store.birthdate = sessionStorage.getItem("birthdate");
        store.address = sessionStorage.getItem("address");
        store.pincode = sessionStorage.getItem("pincode");
        store.state = sessionStorage.getItem("state");
        store.city = sessionStorage.getItem("city");
        store.selectedPlan = sessionStorage.getItem("selectedPlan");
        store.collegeName = sessionStorage.getItem("collegeName");

        // Cast selectedPlan to number as in session value is stored as string but id is number
        if (store.selectedPlan === "" || store.selectedPlan === null || store.selectedPlan === undefined || store.selectedPlan === "NaN") {
            store.selectedPlan = null;
        } else {
            store.selectedPlan = Number.parseInt(store.selectedPlan);
        }
    };
    loadDataFromSession();

    // A function that save store data to session when user click on next of save button
    function setSessionStorage() {
        if (saveLocal) {
            console.log("SetSessionStorage");
            console.log(store);
            for (let key in store) {
                sessionStorage.setItem(key, store[key] ?? "");
            }
        } else {
            removeSessionStorage();
        }
    }

    // A function to remove all data from sessionStorage
    function removeSessionStorage() {
        sessionStorage.clear();
    }


    // A function that will be called when user is on first page and click next
    function handleFirstPageSubmit() {
        const validationResult = DevExpress.validationEngine.validateGroup("first");
        if (validationResult.isValid) {
            removeSessionStorage();
            setSessionStorage();
            $("#firstpage").hide();
            $("#secondpage").show();
            currentpage = 2;
            progressbarinstance.option("value", 25);
        }
    }

    // A function that will be called when user is on second page and click next 
    function handleSecondPageSubmit() {
        const validationResult = DevExpress.validationEngine.validateGroup("second");
        if (validationResult.isValid) {
            removeSessionStorage();
            setSessionStorage();
            $("#secondpage").hide();
            $("#thirdpage").show();
            currentpage = 3;
            progressbarinstance.option("value", 50);

            if (store?.selectedPlan === 5) {
                collegeName.option("visible", true);
                collegeName.option("disabled", false);
            } else {
                collegeName.option("visible", false);
                collegeName.option("disabled", true);
                collegeNameValidator.reset();
            }
        }
    }

    // A function that will be called when user is on third page and click next
    function handleThirdPageSubmit() {
        const validationResult = DevExpress.validationEngine.validateGroup("third");
        if (validationResult.isValid) {
            removeSessionStorage();
            setSessionStorage();
            $("#thirdpage").hide();
            $("#fourthpage").show();
            currentpage = 4;
            progressbarinstance.option("value", 75);
            buttonInstance.option("text", "submit");
        }
    }

    // A function that will be called when user is on fourth page and click submit
    function handleFourthPageSubmit() {
        const validationResult = DevExpress.validationEngine.validateGroup("fourth");
        if (validationResult.isValid) {
            removeSessionStorage();
            setSessionStorage();
            currentpage = 4;
            progressbarinstance.option("value", 100);
        }
    }

    let progressbarinstance = $("#progressbar").dxProgressBar({
        max: 100,
        min: 0,
        showStatus: false,
        value: 0,
    }).dxProgressBar("instance");

    // first page
    $("#email").dxTextBox({
        label: "Email",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        value: store.email,
        onValueChanged: function (e) {
            store.email = e.value;
        }
    }).dxValidator({
        validationGroup: "first",
        validationRules: [
            {
                type: "required",
                message: "Email is required"
            },
            {
                type: "stringLength",
                max: 50,
                min: 5,
                message: "Email's length should be between 5 to 50 character"
            },
            {
                type: "email",
                message: "Invalid email format"
            },
        ]
    });

    $("#username").dxTextBox({
        label: "User name",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        value: store.username,
        onValueChanged: function (e) {
            store.username = e.value;
        }
    }).dxValidator({
        validationGroup: "first",
        validationRules: [
            {
                type: "required",
                message: "Username is required"
            },
            {
                type: "stringLength",
                max: 50,
                min: 5,
                message: "Username must be between 5 to 50 character"
            },
        ]
    });

    $("#password").dxTextBox({
        label: "Password",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        mode: "password",
        value: store.password,
        onValueChanged: function (e) {
            store.password = e.value;
        }
    }).dxValidator({
        validationGroup: "first",
        validationRules: [
            {
                type: "required",
                message: "Password is required"
            },
            {
                type: "pattern",
                pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
                message: "Password is not strong"
            }
        ]
    });

    $("#gender").dxRadioGroup({
        label: "Gender",
        items: ["male", "female", "Other", "Prefer not to say"],
        layout: "horizontal",
        hint: "Select a gender",
        value: store.gender,
        validationMessageMode: "always",
        validationMessagePosition: "right",
        onValueChanged: function (e) {
            store.gender = e.value;
        }
    }).dxValidator({
        validationGroup: "first",
        validationRules: [
            {
                type: "required",
                message: "Gender is required"
            },
        ]
    });

    $("#birthdate").dxDateBox({
        label: "Birth Date",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        value: store.birthdate !== null ? new Date(store.birthdate) : null,
        onValueChanged: function (e) {
            store.birthdate = e.value;
        },
        displayFormat: "dd/MM/yyyy",
        openOnFieldClick: true,
        useMaskBehavior: true,
        disabledDates: function (data) {
            return data.date > new Date();
        }
    }).dxValidator({
        validationGroup: "first",
        validationRules: [
            {
                type: "required",
                message: "Birthdate is required"
            },
        ]
    });


    // second page
    $("#address").dxTextArea({
        label: "Address",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        value: store.address,
        autoResizeEnabled: true,
        maxHeight: 100,
        onValueChanged: function (e) {
            console.log("Address changed");
            store.address = e.value;
        }
    }).dxValidator({
        validationGroup: "second",
        validationRules: [
            {
                type: "required",
                message: "Address is required"
            },
            {
                type: "stringLength",
                min: 10,
                max: 500,
                message: "Address should contain 10 to 500 characters"
            },
            {
                type: "pattern",
                pattern: /[a-zA-Z]+/,
                message: "Address should contains some words"
            }
        ]
    });

    $("#pincode").dxNumberBox({
        label: "Pincode",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        value: store.pincode,
        onValueChanged: function (e) {
            store.pincode = e.value;
        }
    }).dxValidator({
        validationGroup: "second",
        validationRules: [
            {
                type: "required",
                message: "Pincode is required"
            },
            {
                type: "pattern",
                pattern: /^[0-9]{6}$/,
                message: "Pincode should contain 6 digits"
            }
        ]
    });

    $("#state").dxSelectBox({
        label: "State",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        items: Object.keys(cityState),
        value: store.state,
        onValueChanged: function (e) {
            cityinstance.beginUpdate();
            cityinstance.option("disabled", false);
            cityinstance.option("items", cityState[e.value]);
            cityinstance.option("value", "");
            cityinstance.endUpdate();
            store.state = e.value;
            store.city = "";
        }
    }).dxValidator({
        validationGroup: "second",
        validationRules: [
            {
                type: "required",
                message: "State is required"
            }
        ]
    });

    let cityinstance = $("#city").dxSelectBox({
        disabled: store.state == "" ? true : false,
        validationMessageMode: "always",
        validationMessagePosition: "right",
        items: cityState[store.state],
        value: store.city,
        onValueChanged: function (e) {
            store.city = e.value;
        }
    }).dxValidator({
        validationGroup: "second",
        validationRules: [
            {
                type: "required",
                message: "City is required"
            }
        ]
    }).dxSelectBox("instance");

    // third page
    let plandetailinstance = $("#plandetails").dxDropDownBox({
        dataSource: planDetails,
        valueExpr: "id",
        displayExpr: "name",
        contentTemplate: function (e) {
            const $grid = $("<div>").dxDataGrid({
                dataSource: planDetails,
                keyExpr: "id",
                columns: [
                    "name",
                    "price",
                    "usersAllowed",
                ],
                selection: {
                    mode: "single"
                },
                selectedRowKeys: store.selectedPlan ? [store.selectedPlan] : [],
                onSelectionChanged: function (args) {
                    console.log(args.selectedRowKeys[0]);
                    e.component.option("value", args.selectedRowKeys[0]);
                    e.component.close();

                    if (args.selectedRowKeys[0] === 5) {
                        collegeName.option("visible", true);
                        collegeName.option("disabled", false);
                    } else {
                        collegeName.option("visible", false);
                        collegeName.option("disabled", true);
                        collegeName.option("value", "");
                        collegeNameValidator.reset();
                    }
                }
            });

            let gridInstance = $grid.dxDataGrid("instance");

            return $grid;
        },

        label: "Select a plan",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",

        value: store.selectedPlan,
        onValueChanged: function (e) {
            store.selectedPlan = e.value;
        }

    }).dxValidator({
        validationGroup: "third",
        validationRules: [
            {
                type: "required",
                message: "Select a plan"
            }
        ]
    }).dxDropDownBox("instance");

    let collegeName = $("#collegeName").dxTextBox({
        label: "College Name",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        mode: "text",
        value: store.collegeName,
        onValueChanged: function (e) {
            store.collegeName = e.value;
        }
    }).dxValidator({
        validationGroup: "third",
        validationRules: [
            {
                type: "required",
                message: "College name is required",
            },
            {
                type: "stringLength",
                max: 100,
                min: 10,
                message: "College name should be between 10 to 100 characters",
            }
        ]
    }).dxTextBox("instance");

    let collegeNameValidator = $("#collegeName").dxValidator("instance");

    // fourth page
    let uploadSuccess = false;

    $("#profilephoto").dxFileUploader({
        multiple: false,
        allowCanceling: true,
        uploadUrl: "http://localhost:5275/api/ImageUpload/upload",
        name: "file",
        accept: "image/*",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        onUploaded: function () {
            uploadSuccess = true;
            DevExpress.validationEngine.validateGroup("fourth");
        },
        onUploadError: function () {
            uploadSuccess = false;
        },
    }).dxValidator({
        validationGroup: "fourth",
        validationRules: [
            {
                type: "custom",
                message: "Please upload profile photo",
                validationCallback: function () {
                    return uploadSuccess;
                },
                reevaluate: true,
            }
        ]
    });

    // basic buttons
    $("#savedata").dxCheckBox({
        text: "Save data locally",
        value: saveLocal,
        onValueChanged: function (e) {
            saveLocal = e.value;
        }
    });

    let buttonInstance = $("#btn").dxButton({
        text: "Next",
        width: 100,
        onClick: function (e) {
            switch (currentpage) {
                case 1:
                    handleFirstPageSubmit();
                    break;
                case 2:
                    handleSecondPageSubmit();
                    break;
                case 3:
                    handleThirdPageSubmit();
                    break;
                case 4:
                    handleFourthPageSubmit();
                    break;
            }
        }
    }).dxButton("instance");

    // Initial page configurations
    //$("#firstpage").hide(); // show only first section
    $("#secondpage").hide();
    $("#thirdpage").hide();
    $("#fourthpage").hide();

    // By default hide college name text box
    collegeName.option("visible", false);
});
