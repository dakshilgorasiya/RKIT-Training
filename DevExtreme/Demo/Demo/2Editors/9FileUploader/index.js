$(() => {
    $("#fileUploader").dxFileUploader({
        multiple: false,
        uploadMode: 'useButtons',
        allowCanceling: true,
        uploadUrl: "http://localhost:5275/api/ImageUpload/upload",
        name: "file",
    });

    $("#fileUploaderMultiple").dxFileUploader({
        multiple: true,
        uploadMode: 'useButtons',
        allowCanceling: true,
        uploadUrl: "http://localhost:5275/api/ImageUpload/upload",
        name: "file"
    });

    $("#chunkUpload").dxFileUploader({
        multiple: false,
        uploadMode: "instantly",
        uploadUrl: "http://localhost:5275/api/ImageUpload/chunk-upload",
        name: "file",

        chunkSize: 100000, // 200 KB per chunk
    });

    $("#chunkMultiple").dxFileUploader({
        multiple: true,
        uploadMode: "useButtons",
        uploadUrl: "http://localhost:5275/api/ImageUpload/chunk-upload",
        name: "file",

        chunkSize: 100000, // 200 KB per chunk
    });

    $("#formUpload").dxFileUploader({
        multiple: true,
        uploadMode: "useForm",
        name: "file",

    });
});