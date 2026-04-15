$(function () {
    const toast = $("#toast").dxToast({
        displayTime: 2000,
        width: 300,
        position: {
            my: "bottom center",
            at: "bottom center",
            of: window
        },

        // height, maxHeight, maxWidth, minHeight, minWidth, width
        //contentTemplate
        deferRendering: true,

        closeOnClick: true,
        closeOnSwipe: true,

        hideOnOutsideClick: false, 
        hideOnParentScroll: true,

        shading: false,
        shadingColor: "rgba(0,0,0,0.4)",

        // Accepted Values: 'custom' | 'error' | 'info' | 'success' | 'warning'
        // If you assign "custom" to the type property, the dx-toast-custom class is applied to the UI component element. Use CSS styles to customize the appearance of the toast.
        // type


        wrapperAttr: {

        },

        // onHidden, onHiding, onShowing, onShown
    }).dxToast("instance");

    console.log(toast.content());
    toast.toggle(true);

    $("#successBtn").dxButton({
        text: "Show Success",
        type: "success",
        onClick: function () {
            toast.option({
                message: "Operation successful!",
                type: "success"
            });
            toast.show();
        }
    });

    $("#errorBtn").dxButton({
        text: "Show Error",
        type: "danger",
        onClick: function () {
            toast.option({
                message: "Something went wrong!",
                type: "error"
            });
            toast.show();
        }
    });

    $("#infoBtn").dxButton({
        text: "Show Info",
        onClick: function () {
            toast.option({
                message: "This is an info message.",
                type: "info"
            });
            toast.show();
        }
    });
});