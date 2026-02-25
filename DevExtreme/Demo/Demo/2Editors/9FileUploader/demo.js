$(() => {
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
        onProgress: function (e) {
            console.log("onProgress");
            console.log(e);
        },

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

        uploadMode: "useButtons",
        uploadUrl: "http://localhost:5275/api/ImageUpload/upload"
    }).dxFileUploader("instance");
});