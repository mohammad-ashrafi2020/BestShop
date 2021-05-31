////$("form").submit(
////    function () {
////        var isOk = $(".input-validation-error");
////        if (isOk.length == 0) {
////            $(".loading").fadeIn();
////            $("form button[type=submit]").attr("disabled", "true");
////            setTimeout(function () {
////                var s = $(".input-validation-error");
////                console.log(s.length);
////                if (s.length > 0) {
////                    $(".loading").fadeOut();
////                    $("form button[type=submit]").removeAttr("disabled");
////                }
////            }, 100, 1);
////        } else {
////        }
////    });
function changePage(id) {
    $("#pageId").val(id);
    $("#filter").submit();
}
function AddFooterRow() {
    var count = $("#rowCount").val();

    for (var i = 0; i < count; i++) {
        $("#table-body").append(
            "<tr>" +
            "<td><input type='text' autocomplete='off' name='title' class='form-control'/></td>" +
            "<td><input type='text' autocomplete='off' name='url' class='form-control'/></td></tr>"
        );
    }
}
function AddRow() {
    var count = $("#rowCount").val();

    for (var i = 0; i < count; i++) {
        $("#table-body").append(
            "<tr>" +
            "<td><input type='text' autocomplete='off' name='ProductModel.Keys' class='form-control'/></td>" +
            "<td><input type='text' autocomplete='off' name='ProductModel.Values' class='form-control'/></td></tr>"
        );
    }
}
$("#RegisterDto_IsAcceptRules").change(function () {
    if (this.checked) {
        $(".btn-submit").prop("disabled", false);;
    } else {
        $(".btn-submit").prop("disabled", true);;
    }
});
