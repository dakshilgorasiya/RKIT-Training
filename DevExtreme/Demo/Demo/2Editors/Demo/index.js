let cityState = {
    "Gujarat": [
        "Ahmedabad",
        "Surat",
        "Vadodara",
        "Rajkot"
    ],
    "Maharashtra": [
        "Mumbai",
        "Pune",
        "Nagpur",
        "Nashik"
    ],
    "Rajasthan": [
        "Jaipur",
        "Udaipur",
        "Jodhpur",
        "Kota"
    ],
    "Karnataka": [
        "Bengaluru",
        "Mysuru",
        "Mangaluru",
        "Hubballi"
    ],
    "Tamil Nadu": [
        "Chennai",
        "Coimbatore",
        "Madurai",
        "Tiruchirappalli"
    ]
};

let planDetails = [
    {
        id: 1,
        name: "Basic",
        price: 199,
        usersAllowed: 1,
    },
    {
        id: 2,
        name: "Standard",
        price: 499,
        usersAllowed: 3,
    },
    {
        id: 3,
        name: "Premium",
        price: 999,
        usersAllowed: 5,
    },
    {
        id: 4,
        name: "Enterprise",
        price: 1999,
        usersAllowed: 20,
    },
    {
        id: 5,
        name: "Student",
        price: 99,
        usersAllowed: 1,
    }
];


$(() => {
    let currentpage = 1;
    //let store = {
    //    email: "abc@example.com",
    //    username: "abc",
    //    password: "Miracle@123",
    //    gender: "male",
    //    birthdate: "03/12/2005",
    //    address: "ganesh merian",
    //    pincode: "340053",
    //    state: "Gujarat",
    //    city: "Ahmedabad",
    //    selectedPlan: "Student"
    //};

    let store = {
        email: "",
        username: "",
        password: "",
        gender: "",
        birthdate: "",
        address: "",
        pincode: "",
        state: "",
        city: "",
        selectedPlan: ""
    };

    function loadDataFromSession() {
        store.email = sessionStorage.getItem("email");
        store.username = sessionStorage.getItem("username");
        store.password = sessionStorage.getItem("password");
        store.gender = sessionStorage.getItem("gender");
        store.birthdate = sessionStorage.getItem("birthdate");
        store.address = sessionStorage.getItem("address");
        store.pincode = sessionStorage.getItem("pincode");
        store.state = sessionStorage.getItem("state");
        store.selectedPlan = sessionStorage.getItem("selectedPlan");

    };
    loadDataFromSession();

    function setSessionStorage() {
        for (let key in store) {
            sessionStorage.setItem(key, store[key]);
        }
    }

    function removeSessionStorage() {
        sessionStorage.clear();
    }



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

    function handleSecondPageSubmit() {
        const validationResult = DevExpress.validationEngine.validateGroup("second");
        if (validationResult.isValid) {
            removeSessionStorage();
            setSessionStorage();
            $("#secondpage").hide();
            $("#thirdpage").show();
            currentpage = 3;
            progressbarinstance.option("value", 50);
        }
    }

    function handleThirdPageSubmit() {
        const validationResult = DevExpress.validationEngine.validateGroup("third");
        if (validationResult.isValid) {
            removeSessionStorage();
            setSessionStorage();
            $("#thirdpage").hide();
            $("#fourthpage").show();
            currentpage = 4;
            progressbarinstance.option("value", 75);
        }
    }

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
                type: "email",
                message: "Invalid email format"
            }
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
        ]
    });

    $("#password").dxTextBox({
        label: "Password",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
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
        value: store.birthdate !== "" ? new Date(store.birthdate) : null,
        onValueChanged: function (e) {
            store.birthdate = e.value;
        },
        displayFormat: "dd/MM/yyyy",
        openOnFieldClick: true,
        useMaskBehavior: true,
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
    $("#address").dxTextBox({
        label: "Address",
        labelMode: "floating",
        validationMessageMode: "always",
        validationMessagePosition: "right",
        value: store.address,
        onValueChanged: function (e) {
            store.address = e.value;
        }
    }).dxValidator({
        validationGroup: "second",
        validationRules: [
            {
                type: "required",
                message: "Address is required"
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
            cityinstance.option("disabled", false);
            cityinstance.option("items", cityState[e.value]);
            store.state = e.value;
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
        //disabled: true,
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
    plandetailinstance = $("#plandetails").dxDropDownBox({
        dataSource: planDetails,
        valueExpr: "id",
        displayExpr: "name",
        contentTemplate: function (e) {
            const $grid = $("<div>").dxDataGrid({
                dataSource: plandetailinstance.getDataSource(),
                keyExpr: "id",
                columns: [
                    "id",
                    "name",
                    "price",
                    "usersAllowed",
                ],
                selection: {
                    mode: "single"
                },
                onSelectionChanged: function (args) {
                    console.log(args.selectedRowKeys[0]["id"]);
                    e.component.option("value", args.selectedRowKeys[0]["id"]);
                }
            });

            gridInstance = $grid.dxDataGrid("instance");

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

    // fourth page
    $("#profilephoto").dxFileUploader({
        multiple: false,
        allowCanceling: true,
        uploadUrl: "http://localhost:5275/api/ImageUpload/upload",
        name: "file",
        accept: "image/*",
        validationMessageMode: "always",
        validationMessagePosition: "right",
    }).dxValidator({
        validationGroup: "fourth",
        validationRules: [
            {
                type: "required",
                message: "Add a profile photo"
            }
        ]
    });

    // basic buttons
    $("#savedata").dxCheckBox({
        text: "Save data locally"
    });

    $("#btn").dxButton({
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
    });


    //$("#firstpage").hide();
    $("#secondpage").hide();
    $("#thirdpage").hide();
    $("#fourthpage").hide();
});
