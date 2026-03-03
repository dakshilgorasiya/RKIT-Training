$(() => {
    // Specifies the device-dependent default configuration properties for this component.
    DevExpress.ui.dxFileUploader.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            accessKey: "a"
        },
    });

    let fileUploaderInstance = $("#fileUploader").dxFileUploader({
        // A funtion that will be called when file upload is aborted
        // file: file info object
        // uploadInfo: upload session info object
        abortUpload: function (file, uploadInfo) {
            console.log(file);
            console.log(uploadInfo);
        },

        // Specifies file types users can select in the Open File dialog. The default value accepts all file types.
        // FileUploader passes the value of this property to the accept attribute of the underlying input element. Utilize MIME types or file extensions separated by commas. Examples include:
        // image/* - only image files
        // image/png, image/jpg or .png, .jpg - only PNG and JPG images
        // If you pass a value that the component's underlying input element cannot parse, the Open File dialog will accept all file types.
        // The allowedFileExtensions property prevents prohibited file types from uploading, but does not restrict them in the Open File dialog. To filter file types in the Open File dialog, you must define the accept option.
        accept: "image/*", 

        // Specifies the shortcut key that sets focus on the UI component.
        accessKey: "a",

        // Specifies whether the UI component changes its visual state as a result of user interaction.
        activeStateEnabled: true,

        // Specifies if an end user can remove a file from the selection and interrupt uploading.
        // This property applies only if the uploadMode is not set to "useForm".
        // default: true
        allowCanceling: true,

        // Restricts file extensions that can be uploaded to the server.
        // Note that the allowedFileExtensions property disables the uploading of the prohibited file types, but does not restrict these file types in the Open File dialog. To filter file types in the Open File dialog, use the accept option.
        //allowedFileExtensions: ["pdf"],

        // Specifies the chunk size in bytes. Applies only if uploadMode is "instantly" or "useButtons". Requires a server that can process file chunks.
        // Set this property to a positive value to enable chunk upload.
        // When chunk upload is enabled, the FileUploader sends several multipart/form-data requests with information about the file and chunk. The "chunkMetadata" parameter contains chunk details as a JSON object of the following structure:
        //{
        //    "FileGuid": string,
        //    "FileName": string,
        //    "FileType": string,
        //    "FileSize": long,
        //    "Index": long,        // The chunk's index
        //    "TotalCount": long,   // The file's total chunk count
        //}
        //chunkSize: 100 * 1024,

        // Specifies the HTML element which invokes the file upload dialog.
        // same as select a file
        dialogTrigger: $("#uploadBtn"),

        // Specifies whether the UI component responds to user interaction.
        //disabled: true,

        // Specifies the HTML element in which users can drag and drop files for upload.
        // create another drop zone
        dropZone: $("#dropZone"),

        // Specifies the global attributes to be attached to the UI component's container element.
        elementAttr: {
            id: "elementId"
        },

        // Specifies whether the UI component can be focused using keyboard navigation.
        focusStateEnabled: true,

        // Specifies the UI component's height.
        //height: 100,

        // Specifies text for a hint that appears when a user pauses on the UI component.
        hint: "This is hint",

        // Specifies whether the FileUploader component changes the state of all its buttons when users hover over them.
        hoverStateEnabled: true,

        // Specifies the attributes to be passed on to the underlying <input> element of the file type.
        inputAttr: {
            id: "inputId"
        }, 

        // The text displayed when the extension of the file being uploaded is not an allowed file extension.
        invalidFileExtensionMessage: "Not allowed file",

        // The text displayed when the size of the file being uploaded is greater than the maxFileSize.
        invalidMaxFileSizeMessage: "file is large",

        // The text displayed when the size of the file being uploaded is less than the minFileSize.
        invalidMinFileSizeMessage: "file is small",

        // Specifies or indicates whether the editor's value is valid.
        // isValid

        // Specifies the text displayed on the area to which an end user can drop a file.
        labelText: "Upload a file",

        // Specifies the maximum file size (in bytes) allowed for uploading. Applies only if uploadMode is "instantly" or "useButtons".
        //maxFileSize: 100*1024,

        // Specifies the minimum file size (in bytes) allowed for uploading. Applies only if uploadMode is "instantly" or "useButtons".
        //minFileSize: 100,

        // Specifies whether the UI component enables an end user to select a single file or multiple files.
        multiple: true,

        // Specifies the value passed to the name attribute of the underlying input element. Required to access uploaded files on the server.
        // This property's value should end with square brackets if the uploadMode is "useForm". 
        name: "file",

        // A function that allows you to customize the request before it is sent to the server.
        // e has {component, element, file, request, uploadInfo}
        onBeforeSend: function (e) {
            console.log("onBeforeSend");
            console.log(e);
        },

        // A function that is executed when the UI component is rendered and each time the component is repainted.
        // e has {element, component}
        onContentReady: function (e) {
            console.log("onContentReady");
            console.log(e);
        },

        // A function that is executed before the UI component is disposed of.
        // e has {element, component}
        onDisposing: function (e) {
            console.log("onDisposing");
            console.log(e);
        },

        // A function that is executed when the mouse enters a drop zone while dragging a file.
        // e has {component, dropZoneElement, element, event}
        onDropZoneEnter: function (e) {
            console.log("onDropZoneEnter");
            console.log(e);
        },

        // A function that is executed when the mouse leaves a drop zone as it drags a file.
        // e has {component, dropZoneElement, element, event}
        onDropZoneLeave: function (e) {
            console.log("onDropZoneLeave");
            console.log(e);
        },

        // A function that is executed when the file upload process is complete.
        // e has {component, element}
        onFilesUploaded: function (e) {
            console.log("onFilesUploaded");
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

        // A function that is executed when a file segment is uploaded.
        // in case of chunk upload called for every segment upload
        // e has {bytesLoaded, bytesTotal, component, element, event, file, request, segmentSize}
        //onProgress: function (e) {
        //    console.log("onProgress");
        //    console.log(e);
        //},

        // A function that is executed when the file upload is aborted.
        // e has {component, element, event, file, message, request}
        onUploadAborted: function (e) {
            console.log("onUploadAborted");
            console.log(e);
        },

        // A function that is executed when a file is successfully uploaded.
        // e has {component, element, event, file, message, request}
        onUploaded: function (e) {
            console.log("onUploaded");
            console.log(e);
        },

        // A function that is executed when an error occurs during the file upload.
        // e has {component, element, error, event, file, message, request}
        onUploadError: function (e) {
            console.log("onUploadeError");
            console.log(e);
        },

        // A function that is executed when the file upload is started.
        // e has {component, element, event, file, request}
        onUploadStarted: function (e) {
            console.log("onUploadStarted");
            console.log(e);
        },

        // A function that is executed after the UI component's value is changed.
        // e.previousValue → old Date (or string), e.value → new Date (or string)
        // e has {value, previousValue, event, element, component}
        onValueChanged: function (e) {
            console.log("onValueChanged");
            console.log(e.previousValue, "->", e.value);
        },

        // Gets the current progress in percentages.
        // progress

        // Specifies whether the editor is read-only.
        // Note that already selected files are available for upload in readOnly mode.
        //readOnly: true,

        // The message displayed by the UI component when it is ready to upload the specified files.
        readyToUploadMessage: "File is ready to save",

        // Switches the UI component to a right-to-left representation.
        //rtlEnabled: false,

        // The text displayed on the button that opens the file browser.
        selectButtonText: "Open file explorer",

        // Specifies whether or not the UI component displays the list of selected files.
        showFileList: true,

        // Specifies the number of the element when the Tab key is used for navigating.
        tabIndex: 1,

        // The message displayed by the UI component when the file upload is cancelled.
        // This property is only available if the uploadMode property is set to "instantly".
        uploadAbortedMessage: "Upload stopped",

        // The text displayed on the button that starts uploading.
        // The property makes sense only if the uploadMode property is set to "useButtons" or "instantly".
        uploadButtonText: "start uploads",

        // A function that uploads a file in chunks.
        //uploadChunk: function (file, uploadInfo) {
        //    console.log("Custom data : ", uploadInfo.customData);
        //    const formData = new FormData();

        //    formData.append("file", uploadInfo.chunkBlob);

        //    formData.append("chunkMetadata", JSON.stringify({
        //        fileName: file.name,
        //        fileGuid: uploadInfo.fileGuid,
        //        Index: uploadInfo.chunkIndex,
        //        totalCount: uploadInfo.chunkCount
        //    }));

        //    return $.ajax({
        //        url: "http://localhost:5275/api/ImageUpload/chunk-upload",
        //        method: "POST",
        //        data: formData,
        //        processData: false,
        //        contentType: false
        //    });
        //},

        // Specifies custom data for the upload request.
        uploadCustomData: {
            photoType: "jpeg",
        },

        // The message displayed by the UI component when uploading is finished.
        uploadedMessage: "Saved succefully",

        // The message displayed by the UI component on uploading failure.
        uploadFailedMessage: "Saving failed",

        // A function that uploads a file.
        //uploadFile: async function (file, processCallback) {
        //    console.log("Upload file called");

        //    // it expects bytes uploaded not percentage
        //    processCallback(100000);
        //    processCallback(200000);

        //},

        // Specifies headers for the upload request.
        uploadHeaders: {
            "X-Custom": "123",
        },

        // Specifies the method for the upload request.
        // Accepted Values: 'POST' | 'PUT'
        // Default Value: 'POST'
        uploadMethod: "POST",

        // Specifies how the UI component uploads files.
        // Accepted Values: 'instantly' | 'useButtons' | 'useForm'
        // Default Value: 'instantly'
        uploadMode: "useButtons",

        // Specifies a target Url for the upload request.
        //uploadUrl: "http://localhost:5275/api/ImageUpload/chunk-upload"
        uploadUrl: "http://localhost:5275/api/ImageUpload/upload",

        // Information about the broken validation rule (first item from validationErrors array).
        // validationError

        // An array of all validation rules that failed.
        // validationErrors

        // Indicates the current validation status.
        //   "valid"   → value passes all rules
        //   "invalid" → value fails at least one rule
        //   "pending" → async validation is in progress
        validationStatus: "valid",

        // Specifies a File instance representing the selected file. Read-only when uploadMode is "useForm".
        //value

        // Specifies whether the UI component is visible.
        visible: true,

        // Specifies the UI component's width.
        //width: 100,
        
    }).dxFileUploader("instance");


    // Cancels the file upload. (In case multiple allowed all upload will stop)
    //The abortUpload method works differently in the following upload modes:
    //useForm: The method is not supported in this mode.
    //useButtons: Cancels the file upload and makes the file available for upload.
    //instantly: Cancels the file upload.
    $("#abortUpload").click(() => {
        fileUploaderInstance.abortUpload();
    });

    // Cancels the file upload.
    $("#abortUploadfile").click(() => {
        fileUploaderInstance.abortUpload(fileUploaderInstance.option("value[0]"));
    });

    // Cancels the file upload.
    $("#abortUploadIndex").click(() => {
        fileUploaderInstance.abortUpload(0);
    });

    // Postpones rendering that can negatively affect performance until the endUpdate() method is called.
    // The beginUpdate() and endUpdate() methods reduce the number of renders in cases where extra rendering can negatively affect performance.
    //fileUploaderInstance.beginUpdate();

    // Resets the value property to the default value.
    //fileUploaderInstance.clear();


    // Disposes of all the resources allocated to the CheckBox instance.
    //fileUploaderInstance.dispose();

    // Gets the root UI component element.
    //fileUploaderInstance.element().focusin();

    // Refreshes the UI component after a call of the beginUpdate() method.
    //fileUploaderInstance.endUpdate();

    // Sets focus on the UI component.
    //fileUploaderInstance.focus();

    // Gets the instance of a UI component found using its DOM node.
    let element = document.getElementById("elementId");
    let instance = DevExpress.ui.dxFileUploader.getInstance(element);
    //console.log(instance === fileUploaderInstance);

    // Gets the UI component's instance. Use it to access other methods of the UI component.
    instance = fileUploaderInstance.instance();
    //console.log(instance === fileUploaderInstance);

    // Detaches all event handlers from a single event.
    //fileUploaderInstance.off("valueChanged");

    // Detaches a particular event handler from a single event.
    //fileUploaderInstance.off("valueChanged", cb1);

    // To attach event listener
    //fileUploaderInstance.on("valueChanged", cb1);

    // To attach multiple event listener
    //fileUploaderInstance.on({
    //    "valueChanged": cb2,
    //    "optionChanged": cb2
    //});
    // Gets all UI component properties.
    //console.log(fileUploaderInstance.option());

    // Gets the value of a single property.
    //console.log(fileUploaderInstance.option("readOnly"));

    // Updates the value of a single property.
    //fileUploaderInstance.option("readOnly", false);

    // Updates the values of several properties.
    //fileUploaderInstance.option({
    //    "readonly": false,
    //    value: null
    //});

    // Registers a handler to be executed when a user presses a specific key.
    // "backspace","tab","enter","escape","pageUp","pageDown","end","home","leftArrow","upArrow","rightArrow","downArrow","del","space","F","A","asterisk","minus"
    //fileUploaderInstance.registerKeyHandler("w", function () {
    //    console.log("w clicked")
    //});

    // Removes a file.
    // The removeFile method is not supported in useForm upload mode.
    $("#removeFileFile").click(() => {
        fileUploaderInstance.removeFile(fileUploaderInstance.option("value[0]"));
    });

    // The removeFile method is not supported in useForm upload mode.
    // The removeFile method is not supported in useForm upload mode.
    $("#removeFileIndex").click(() => {
        fileUploaderInstance.removeFile(0);
    });

    // Renders the component again without reloading data. Use the method to update the component's markup and appearance dynamically.
    // The repaint() method re - initializes the component with new settings, resetting its state and history.
    //fileUploaderInstance.repaint();

    // Resets the value property to the value passed as an argument.
    // This method sets the isDirty flag to false.
    //fileUploaderInstance.reset();

    // Resets a property to its default value.
    //fileUploaderInstance.resetOption("value");

    // Uploads all the selected files.
    // The upload method is not supported in useForm upload mode. In instantly upload mode, the upload method is useful if you use the value property to select a file(s) you want to upload.
    $("#upload").click(() => {
        fileUploaderInstance.upload();
    });

    // Uploads the specified file.
    $("#uploadFile").click(() => {
        fileUploaderInstance.upload(fileUploaderInstance.option("value[0]"));
    });

    // Uploads a file with the specified index.
    $("#uploadIndex").click(() => {
        fileUploaderInstance.upload(0);
    });

    // EVENTS
    // beforeSend : Raised before the request is sent to the server and allows you to customize this request.
    // contentReady : Raised when the UI component is rendered and each time the component is repainted.
    // disposing : Raised before the UI component is disposed of.
    // dropZoneEnter : Raised when the mouse enters a drop zone as it drags a file.
    // dropZoneLeave : Raised when the mouse leaves a drop zone as it drags a file.
    // filesUploaded : Raised when the file upload process is complete.
    // initialized : Raised only once, after the UI component is initialized.
    // optionChanged : Raised after a UI component property is changed.
    // progress : Raised when a file segment is uploaded.
    // uploadAborted : Raised when the file upload is aborted.
    // uploaded : Raised when a file is successfully uploaded.
    // uploadError : Raised when an error occurs during the file upload.
    // uploadStarted : Raised when the file upload is started.
    // valueChanged : Raised after the UI component's value is changed.
});