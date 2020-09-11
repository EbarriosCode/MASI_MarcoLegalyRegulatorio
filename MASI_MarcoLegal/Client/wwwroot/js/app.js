$(document).ready(function () {
    let imageUpload = document.getElementById('adjunto');

    $('#adjunto').on('change',function () {
        alert("changed ")
    });
});

window.UploadFile = function () {
    
    var formData = new FormData();
    var files = $("#adjunto")[0].files[0];

    formData.append('file', files);

    $.ajax({
        url: "api/UploadFile/Upload",
        type: "post",
        dataType: "html",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: successCallBack        
    });
}

function successCallBack(returnData) {
    console.log("Calback: " + returnData);

    return returnData;
}