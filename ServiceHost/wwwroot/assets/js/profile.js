var addressClicked;
$("input[name=addressRadio]").click(function (e) {
    e.preventDefault();
    var id = $(this).val();
    var selected = $(this).attr("checked");
    if (typeof selected == 'undefined') {
        addressClicked = id;
        Question("/Profile/Addresses/ActiveAddress?addressId=" + id, null, null, null, checkStatus);
    }
});
function checkStatus(status) {
    if (status === 200) {
        $(`input[value=${addressClicked}]`).prop("checked", true);
        $(`input[value=${addressClicked}]`).attr("checked", true);
        var inputs = $(`input[name=addressRadio]`);
        if (inputs.length > 1) {
            for (var i in inputs) {
                if (i =='length')
                    return;

                var current = $(inputs[i]);
                if ($(current).val() !== addressClicked)
                    $(current).attr("checked", null);
            }
        }
    }
}
function ShowInsertModal() {
    OpenModal('/Profile/Addresses/ShowInsertPartial', "modalAddress", "آدرس جدید", "lg",null);
}
function ShowEditModal(addressId) {
    OpenModal('/Profile/Addresses/ShowEditPartial?addressId=' + addressId, "modalAddress", "ویرایش جدید", "lg", null);
}
function DeleteAddress(id) {
    deleteItem(`/Profile/Addresses/DeleteAddress?addressId=${id}`);
}