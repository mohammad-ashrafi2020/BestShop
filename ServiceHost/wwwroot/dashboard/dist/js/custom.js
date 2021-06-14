$("form").submit(
    function () {
        var isOk = $(".input-validation-error");
        if (isOk.length == 0) {
            $(".loading").fadeIn();
            $("form button[type=submit]").attr("disabled", "true");
            setTimeout(function () {
                var s = $(".input-validation-error");
                console.log(s.length);
                if (s.length > 0) {
                    $(".loading").fadeOut();
                    $("form button[type=submit]").removeAttr("disabled");
                }
            }, 100, 1);
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

function LoadChildrenGroups(wraperId, thisId) {
    var groupId = $(`#${thisId}`).val();
    $.ajax({
        url: "/admin/BlogManagement/Groups/LoadChildGroups?parentId=" + groupId,
        type: "get"
    }).done(function (data) {
        $(`#${wraperId}`).html('');

        $(`#${wraperId}`).append('<option>انتخاب کنید</option>');
        for (var item in data) {
           
            var group = data[item].value;
            console.log(group);

            $(`#${wraperId}`).append(`<option value='${group.value}'>${group.title}</option>`)
        }
    });
}
