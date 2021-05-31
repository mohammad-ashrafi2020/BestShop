$(document).ready(function () {
    var result = $("#requestResult").val();
    result = JSON.parse(result);
    console.log(result);
    if (result.Status === 200) {
        Success(result.Title, result.Message,result.isReloadPage);
    } else if (result.Status === 10) {
        ErrorAlert(result.Title, result.Message);
    }else if (result.Status === 404) {
        Warning(result.Title, result.Message);
    }
});