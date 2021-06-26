function LoadBlogChildrenGroups(wraperId, thisId) {
    var groupId = $(`#${thisId}`).val();
    $.ajax({
        url: "/BlogManagement/Groups/LoadChildGroups?parentId=" + groupId,
        type: "get"
    }).done(function (data) {
        $(`#${wraperId}`).html('');

        $(`#${wraperId}`).append('<option>انتخاب کنید</option>');
        for (var item in data) {

            var group = data[item].value;
            console.log(group);

            $(`#${wraperId}`).append(`<option value='${group.value}'>${group.title}</option>`);
            $(`#${wraperId}`).selectpicker('refresh');
        }
    });
}
$(document).ready(function () {
    var inputs = $(".form-control");
    for (var i = 0; i <= inputs.length - 1; i++) {
        var current = inputs[i].value;
        var cureentid = inputs[i].getAttribute("id");
        if (current) {
            $(`#${cureentid}`).parent().addClass('focused');
        }
    }
});
function changePage(pageId) {
    var url = new URL(window.location.href);
    var search_params = url.searchParams;

    // Change PageId
    search_params.set('pageId', pageId);
    url.search = search_params.toString();

    // the new url string
    var new_url = url.toString();

    window.location.replace(new_url);
}
function updateQueryStringParameter(uri, key, value) {
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";
    if (uri.match(re)) {
        return uri.replace(re, '$1' + key + "=" + value + '$2');
    }
    else {
        return uri + separator + key + "=" + value;
    }
}