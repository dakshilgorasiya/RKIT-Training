$(() => {
    $("#btn").dxButton({
        text: "Click me!",
        onClick: function () {
            console.log("Buttton clicked");
        }
    });

    //! To get instance

    // If component is not instanitated yet it will throw error
    var buttonInstance = $("#btn").dxButton("instance");

    // another way to get instance
    var element = document.getElementById("btn");
    var chartInstance = DevExpress.ui.dxButton.getInstance(element);
    if (chartInstance) {
        console.log(chartInstance);
    } else {
        console.log("Intance not exists")
    }


    //! Get Property
    // 1. To get property from instancee
    console.log(buttonInstance.option("text"));

    // 2. Another way to get property
    console.log($("#btn").dxButton("option", "text"));

    // 3. To get all property
    console.log(buttonInstance.option());
    console.log($("#btn").dxButton("option"));





    //! To set property

    // To set single property

    // 1. By using instacnce
    buttonInstance.option("text", "update1");

    // 2. By using plugin method
    $("#btn").dxButton("option", "text", "update2");

    // NOTE : If you perform several property changes, wrap them with the beginUpdate() and endUpdate() method calls. This prevents the UI component from being unnecessarily refreshed and from events being raised. Use an object instead if you need to change several properties at once.


    // To set multiple property

    // 1. By using insrtace
    buttonInstance.option({
        text: "update3",
        onClick: function () {
            console.log("update3");
        }
    });

    // 2. By using plugin method
    $("#btn").dxButton({
        text: "update4",
        onClick: function () {
            console.log("update4");
        }
    })

    // By batching updates
    buttonInstance.beginUpdate();
    buttonInstance.option("text", "update5");
    buttonInstance.option("onClick", function () {
        console.log("update5");
    });
    buttonInstance.endUpdate();





    //! To call a method

    // 1. By plugin method
    //$("#btn").dxButton("focus");
    // If method need to send param $("#btn").dxButton("focus", "param1", "param2");

    // 2. By instace
    buttonInstance.focus();




    //! Event handling
    function cb1() {
        console.log("cb1");
    }
    function cb2() {
        console.log("cb2");
    }
    function cb3(e) {
        console.log("cb3");
        e.cancel = true;
    }
    function cb4() {
        console.log("cb4");
    }

    // Attaching event
    // 1. attach multiple type of events
    buttonInstance.on({
        "click": cb1,
        "click": cb2   // only cb2 will be called
    });

    // 2. To attach multiple event handler
    buttonInstance
        .on("click", cb3)
        .on("click", cb4);


    // Detaching event
    // 1. To detach an event
    //buttonInstance.off("click", cb2);

    // 2. To detach all events
    //buttonInstance.off("click");

    // 3. To unsubscribe event attached by onEventName
    //buttonInstance.option("onClick", undefined);


    // Dispose control
    // $("#btn").dxButton("dispose");
});