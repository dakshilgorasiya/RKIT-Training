$(() => {
    let loadIndicatorInstace = $("#loadIndicatorContainer").dxLoadIndicator({
        // elementAttr, height, hint, onContentReady, onDisposing, onInitialized, onOptionChanged, rtlEnabled, width

         //indicatorSrc // set a .gif file
        //visible: 
    }).dxLoadIndicator("instance");

    $('#btn').dxButton({
        text: 'Send',
        height: 40,
        width: 180,
        template(data, container) {
            $(`<div class='button-indicator'></div>`).appendTo(container);
            $(`<span class='dx-button-text'>${data.text}</span>`).appendTo(container);
            buttonIndicator = container.find('.button-indicator').dxLoadIndicator({
                visible: false,
            }).dxLoadIndicator('instance');
        },
        onClick(data) {
            data.component.option('text', 'Sending');
            buttonIndicator.option('visible', true);
            setTimeout(() => {
                buttonIndicator.option('visible', false);
                data.component.option('text', 'Send');
            }, 2000);
        },
    });
});