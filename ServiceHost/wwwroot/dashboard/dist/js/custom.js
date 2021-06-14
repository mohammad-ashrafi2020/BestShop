$("form").submit(
    function () {
        var isOk = $(".input-validation-error");
        if (isOk.length == 0) {
            $(".loading").fadeIn();
            $("form button[type=submit]").attr("disabled", "true");
            setTimeout(function() {
                var s = $(".input-validation-error");
                console.log(s.length);
                if (s.length > 0) {
                    $(".loading").fadeOut();
                    $("form button[type=submit]").removeAttr("disabled");
                }
            },100,1);
        }
    });
function setInputFilter(textbox, inputFilter) {
    ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    });
};

$(document).ready(function () {
    if ($(".select2")) {
        $(".select2").select2();
    }
    if ($(".dateSelect")) {
        $('.dateSelect').pDatepicker({
            format: 'YYYY/MM/D',
            initialValue: false
        });
    }
    if (document.getElementById("number_input")) {
        setInputFilter(document.getElementById("number_input"),
            function (value) {
                return /^\d*\.?\d*$/.test(value);
            });
    }
});

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