function UploadImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            //'userAvatar' img
            $('#image_target').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$(".color-select").click(function () {
    var value = $(this).attr("color-for");
    $(this).addClass("selected");
    $(`#${value}`).prop("checked", true);
    var otherSelector = "[color-for!=" + value + "]";
    $(otherSelector).removeClass("selected");
});
$(".submit-discount").click(function () {
    var title = $("#DiscountCode_CodeTitle").val();
    $.ajax({
        url: `/Admin/DiscountCodes/IsCodeExist?code=${title}`,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        if (data == "No") {
            $("#discount_form").submit();
        } else {
            Error("عنوان کد تکراری است", "عنوان دیگری انتخاب کنید");
        }
    });
});

$(document).ready(function () {
    if (window.location.href.toLowerCase().includes("/tickets/show")) {
        $('.ticket-Body').animate({
            scrollTop: $('.ticket-Body .chat:last-child').position().top
        }, 'slow');
    }
    $.ajax({
        url: "/Admin/Notifications",
        type: "get"
    }).done(function (data) {
        //item1=messageCount
        //item2=notificationsCount
        //item3=MessageContents
        //item4=NotificationContent
        if (data.item2 > 0) {
            $(".notifications-menu .dropdown-toggle span").html(data.item2);
            $(".notifications-menu .dropdown-menu .header").html(`
            <li class="header text-center">شما ${data.item2} اعلان جدید دارید</li>`);

            $(".notifications-menu .dropdown-menu .menu").append(data.item4);
        }
        if (data.item1 > 0) {
            $(".messages-menu .dropdown-toggle span").html(data.item1);

            $(".messages-menu .dropdown-menu .header").html(`
            <li class="header text-center"> ${data.item1} پیام جدید ثبت شده است</li>`);
            $(".messages-menu .dropdown-menu .menu").append(data.item3);

            $(".notifications-menu .dropdown-menu").append(`
            <li class="footer"><a href="/Admin/ContactUs">نمایش تمام پیام ها</a></li>`);
        }
    });
});
$("#image_selector").change(function () {
    UploadImage(this);
});

function DeleteBlogGroup(id) {
    Question("/Admin/BlogManagement/groups/DeleteGroup?id=" + id, "آیا از حذف اطمینان دارید ؟");
}
$("#ArticleModel_GroupId").select2();
$("#ArticleModel_GroupId").change(function () {
    $.ajax({
        url: "/Admin/Articles/Add/GroupsByParent?parentId=" + $(this).val(),
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#select_").html(data);
    });
});
$("#meta_des").keydown(function () {
    var length = $(this).val().length;
    $(".counter").html(length);
});
$("#meta_des").change(function () {
    var length = $(this).val().length;
    $(".counter").html(length);
});
$("#meta_des1").keydown(function () {
    var length = $(this).val().length;
    $(".counter1").html(length);
});
$("#meta_des1").change(function () {
    var length = $(this).val().length;
    $(".counter1").html(length);
});
$("#meta_des2").keydown(function () {
    var length = $(this).val().length;
    $(".counter2").html(length);
});
$("#meta_des2").change(function () {
    var length = $(this).val().length;
    $(".counter2").html(length);
});
$("#ProductModel_Product_SubParentGroupId").select2();
$("#ProductModel_Product_ParentGroupId").select2();
$("#ProductModel_Product_GroupId").select2();
$("#ProductModel_Product_ParentGroupId").change(function () {
    var id = $(this).val();
    $.ajax({
        url: "/UserPanel/Seller/Products/Add/ProductGroupOptions?parentId=" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#ProductModel_Product_SubParentGroupId").html(data);
    });
});
$("#ProductModel_Product_GroupId").change(function () {
    var id = $(this).val();
    $.ajax({
        url: "/UserPanel/Seller/Products/Add/ProductGroupOptions?parentId=" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#ProductModel_Product_ParentGroupId").html(data);
    });
});
function setColor(currency) {
    if (!currency.id) { return currency.text; }
    var $currency = $('<span style=display:inline-block;color:black>' + currency.text + '</span>    <span style="background:' + currency.title + ';width:15px;height:15px;display:inline-block;box-shadow:0 0 5px 0' + currency.title + ';position:relative;top:3px;"></span>');
    return $currency;
};
$("#select_color").select2({
    templateResult: setColor,
    templateSelection: setColor
});
function deleteProducts(id) {
    swal({
        title: "هشدار !!",
        text: "آیا از حذف اطمینان دارید ؟",
        icon: "warning",
        buttons: ["لغو", "بله"]
    }).then((isOk) => {
        if (isOk) {
            $.ajax({
                url: `/Admin/Products/DeleteProduct?productId=${id}`,
                type: "get",
                beforeSend: function () {
                    $(".loading").show();
                },
                complete: function () {
                    $(".loading").hide();
                }
            }).done(function (data) {
                if (data === "Deleted") {
                    swal({
                        title: "عملیات با موفقیت انجام شد",
                        icon: "success",
                        button: "باشه"
                    }).then((isOk) => {
                        location.reload();
                    });
                } else if (data === "SoftDeleted") {
                    swal({
                        title: "امکان حذف کامل محصول وجود ندارد",
                        text: "اما وضعیت محصول در فروشگاه به 'ناموجود' تغییر یافت",
                        icon: "success",
                        button: "باشه"
                    }).then((isOk) => {
                        location.reload();
                    });
                }
                else {
                    swal({
                        title: "عملیات ناموفق",
                        icon: "error",
                        button: "باشه"
                    });
                }
            });
        }
    });
}
if (document.getElementById('salesChart')) {
    var registerChartRoot = document.getElementById('salesChart').getContext('2d');
    var registerLabels = JSON.parse($("#sales-chart-label").val());
    var registerValues = JSON.parse($("#sales-chart-value").val());
    var registerChart = new Chart(registerChartRoot, {
        type: 'line',
        data: {
            labels: registerLabels.reverse(),
            datasets: [
                {
                    label: 'آمار فروش هفت روز گذشته',
                    data: registerValues.reverse(),

                }
            ]
        },
        options: {
            showScale: false,
            responsive: true,
            legend: {
                display: false,

            },

            tooltips: {
                enabled: false,
                custom: function (tooltipModel) {
                    // Tooltip Element
                    var tooltipEl = document.getElementById('chartjs-tooltip');

                    // Create element on first render
                    if (!tooltipEl) {
                        tooltipEl = document.createElement('div');
                        tooltipEl.id = 'chartjs-tooltip';
                        tooltipEl.innerHTML = '<table></table>';
                        document.body.appendChild(tooltipEl);
                    }

                    // Hide if no tooltip
                    if (tooltipModel.opacity === 0) {
                        tooltipEl.style.opacity = 0;
                        return;
                    }

                    // Set caret Position
                    tooltipEl.classList.remove('above', 'below', 'no-transform');
                    if (tooltipModel.yAlign) {
                        tooltipEl.classList.add(tooltipModel.yAlign);
                    } else {
                        tooltipEl.classList.add('no-transform');
                    }

                    function getBody(bodyItem) {
                        return bodyItem.lines;
                    }

                    // Set Text
                    if (tooltipModel.body) {
                        var titleLines = tooltipModel.title || [];
                        var bodyLines = tooltipModel.body.map(getBody);

                        var innerHtml = '<thead style="background:transparent">';

                        titleLines.forEach(function (title) {
                            innerHtml += '<tr><th style="text-align:center">' + title + '</th></tr>';
                        });
                        innerHtml += '</thead><tbody>';

                        bodyLines.forEach(function (body, i) {
                            var visit = body[0].split(":")[1];
                            var colors = tooltipModel.labelColors[i];
                            var style = 'background:' + colors.backgroundColor;
                            style += '; border-color:' + colors.borderColor;
                            style += '; border-width: 2px';
                            var span = '<span style="' + style + '"></span>';
                            innerHtml += '<tr><td>' + span + "تعداد فروش  : " + visit + '</td></tr>';
                        });
                        innerHtml += '</tbody>';

                        var tableRoot = tooltipEl.querySelector('table');
                        tableRoot.innerHTML = innerHtml;
                    }

                    // `this` will be the overall tooltip
                    var position = this._chart.canvas.getBoundingClientRect();

                    // Display, position, and set styles for font
                    tooltipEl.style.opacity = .8;
                    tooltipEl.style.position = 'absolute';
                    tooltipEl.style.background = 'black';
                    tooltipEl.style.color = 'white';
                    tooltipEl.style.borderRadius = '10px';
                    tooltipEl.style.left = position.left + window.pageXOffset + tooltipModel.caretX + 'px';
                    tooltipEl.style.top = position.top + window.pageYOffset + tooltipModel.caretY + 'px';
                    tooltipEl.style.fontFamily = 'iranyekan';
                    tooltipEl.style.fontSize = tooltipModel.bodyFontSize + 'px';
                    tooltipEl.style.fontStyle = tooltipModel._bodyFontStyle;
                    tooltipEl.style.padding = tooltipModel.yPadding + 'px ' + tooltipModel.xPadding + 'px';
                    tooltipEl.style.pointerEvents = 'none';
                }
            }
        }
    });
}
if (document.getElementById('registerChart')) {
    var registerChartRoot = document.getElementById('registerChart').getContext('2d');
    var registerLabels = JSON.parse($("#sales-chart-label").val());
    var registerValues = JSON.parse($("#register-chart-value").val());
    var registerChart = new Chart(registerChartRoot, {
        type: 'line',
        data: {
            labels: registerLabels.reverse(),
            datasets: [
                {
                    label: 'آمار فروش هفت روز گذشته',
                    data: registerValues.reverse(),

                }
            ]
        },
        options: {
            showScale: false,
            responsive: true,
            legend: {
                display: false,

            },

            tooltips: {
                enabled: false,
                custom: function (tooltipModel) {
                    // Tooltip Element
                    var tooltipEl = document.getElementById('chartjs-tooltip');

                    // Create element on first render
                    if (!tooltipEl) {
                        tooltipEl = document.createElement('div');
                        tooltipEl.id = 'chartjs-tooltip';
                        tooltipEl.innerHTML = '<table></table>';
                        document.body.appendChild(tooltipEl);
                    }

                    // Hide if no tooltip
                    if (tooltipModel.opacity === 0) {
                        tooltipEl.style.opacity = 0;
                        return;
                    }

                    // Set caret Position
                    tooltipEl.classList.remove('above', 'below', 'no-transform');
                    if (tooltipModel.yAlign) {
                        tooltipEl.classList.add(tooltipModel.yAlign);
                    } else {
                        tooltipEl.classList.add('no-transform');
                    }

                    function getBody(bodyItem) {
                        return bodyItem.lines;
                    }

                    // Set Text
                    if (tooltipModel.body) {
                        var titleLines = tooltipModel.title || [];
                        var bodyLines = tooltipModel.body.map(getBody);

                        var innerHtml = '<thead style="background:transparent">';

                        titleLines.forEach(function (title) {
                            innerHtml += '<tr><th style="text-align:center">' + title + '</th></tr>';
                        });
                        innerHtml += '</thead><tbody>';

                        bodyLines.forEach(function (body, i) {
                            var visit = body[0].split(":")[1];
                            var colors = tooltipModel.labelColors[i];
                            var style = 'background:' + colors.backgroundColor;
                            style += '; border-color:' + colors.borderColor;
                            style += '; border-width: 2px';
                            var span = '<span style="' + style + '"></span>';
                            innerHtml += '<tr><td>' + span + "تعداد ثبت نام  : " + visit + '</td></tr>';
                        });
                        innerHtml += '</tbody>';

                        var tableRoot = tooltipEl.querySelector('table');
                        tableRoot.innerHTML = innerHtml;
                    }

                    // `this` will be the overall tooltip
                    var position = this._chart.canvas.getBoundingClientRect();

                    // Display, position, and set styles for font
                    tooltipEl.style.opacity = .8;
                    tooltipEl.style.position = 'absolute';
                    tooltipEl.style.background = 'black';
                    tooltipEl.style.color = 'white';
                    tooltipEl.style.borderRadius = '10px';
                    tooltipEl.style.left = position.left + window.pageXOffset + tooltipModel.caretX + 'px';
                    tooltipEl.style.top = position.top + window.pageYOffset + tooltipModel.caretY + 'px';
                    tooltipEl.style.fontFamily = 'iranyekan';
                    tooltipEl.style.fontSize = tooltipModel.bodyFontSize + 'px';
                    tooltipEl.style.fontStyle = tooltipModel._bodyFontStyle;
                    tooltipEl.style.padding = tooltipModel.yPadding + 'px ' + tooltipModel.xPadding + 'px';
                    tooltipEl.style.pointerEvents = 'none';
                }
            }
        }
    });
}
function showColorPage(id) {
    $.ajax({
        url: "/Admin/Colors/ShowPage?colorId=" + id,
        type: "get"
    }).done(function (data) {
        $(".modal-content #content").html(data);
    });
}

function showNewslettersPage(id) {
    $.ajax({
        url: "/Admin/NewsLetters/ShowPage?Id=" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $(".modal-content #content").html(data);
    });
}
function showWithdrawalPage(id) {
    $.ajax({
        url: "/Admin/Withdrawals/ShowPage?Id=" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $(".modal-content #content").html(data);
    });
}

function DeleteWithdrawal() {
    var rejectText = $("#description").val();

    var id = $("#id").val();
    if (!rejectText) {
        Error("لطفا دلیل حذف را بیان کنید");
    } else {
        deleteItem(`/Admin/Withdrawals/RejectRequest?id=${id}&text=${rejectText}`);
    }
}
function getExtension(path) {
    var basename = path.split(/[\\/]/).pop(),  // extract file name from full path ...
        // (supports `\\` and `/` separators)
        pos = basename.lastIndexOf(".");       // get last position of `.`

    if (basename === "" || pos < 1)            // if file name is empty or ...
        return "";                             //  `.` not found (-1) or comes first (0)

    return basename.slice(pos + 1);            // extract extension ignoring `.`
}
