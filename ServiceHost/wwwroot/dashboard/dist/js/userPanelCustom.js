$("#delete-noti").click(function () {
    deleteItem("/UserPanel/Notifications/DeleteNotifications");
});
$(".box-tools button").click(function () {
    var id = $(this).attr("data-id");
    if (id != "null") {
        $(`[data-new=${id}]`).remove();

        $.ajax({
            url: "/UserPanel/Notifications/SeenNotification?id=" + id,
            type: "get"
        }).done(function (data) {
            if (data == "success") {
                $(`[data-id=${id}]`).attr("data-id", "null");
            }
        });
    }
});
function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    // add a zero in front of numbers<10
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('time').innerHTML = h + ":" + m + ":" + s;
    t = setTimeout(function () {
            startTime();
        },
        500);
}

function TrainingConf(id) {
    swal({
        title: "آیا از انجام عملیات اطمینان دارید ؟",
        text: "لطفا در صورتی که تمام دوره را تماشا کرده اید درخواست دهید",
        icon: "info",
        buttons: ["لغو", "بله"]
    }).then((isOk) => {
        if (isOk) {
            $.ajax({
                url: "/UserPanel/MyCourses/TrainingConfirmation?courseId=" + id,
                type: "get",
                beforeSend: function () {
                    $(".loading").show();
                },
                complete: function () {
                    $(".loading").hide();
                }
            }).done(function (data) {
                if (data === "Success") {
                    swal({
                        title: "عملیات با موفقیت انجام شد",
                        icon: "success",
                        button: "باشه"
                    }).then((isOk) => {
                        location.reload();
                    });
                }
                if (data === "Error") {
                    swal({
                        title: "مشکلی پیش آمده !",
                        text: "لطفا در زمان دیگری امتحان کنید",
                        icon: "error",
                        button: "باشه"
                    });
                }
                if (data === "Warning") {
                    swal({
                        title: "درخواست شما در حال برسی است",
                        text: "لطفا منتظر بمانید تا درخواست شما تایید شود",
                        icon: "error",
                        button: "باشه"
                    });
                }
            });
        }
    });
}
function received(orderId, sellerId) {
    Question(`/UserPanel/Orders/Show/${orderId}/ReceivedProducts?param=${sellerId}`, "آیا از انجام عملیات اطمینان دارید ؟", "");
};
function deleteCard(id) {
    deleteItem(`/UserPanel/Cards/DeleteCard?cardId=${id}`, "امکان حذف کارت وجود ندارد");
}


function deleteShortCourse(id) {
    deleteItem(`/UserPanel/Teacher/ShortCourse/DeleteCourse?id=${id}`);
}
function sendProduct(id) {
    Question(``, "محصولات را برای خریدار ارسال کرده اید؟", "", "");
    swal({
        text: 'کد رهگیری  سفارش را وارد کنید',
        content: {
            element: "input",
            attributes: {
                placeholder: "کد رهگیری  مرسومه را وارد کنید",
                type: "number",
                required: "true"
            },
        },
        button: {
            text: "ثبت",
            closeModal: false,
        },
    })
        .then(name => {
            if (!name) throw null;

            $.ajax({
                url: `/UserPanel/Seller/Orders/Show/${id}/SendProduct?trackingCode=${name}`,
                type: 'get',
                beforeSend: function () {
                    $(".loading").show();
                },
                complete: function () {
                    $(".loading").hide();
                }
            }).done(function (data) {
                if (data === "Success") {
                    swal({
                        title: "عملیات با موفقیت انجام شد",
                        text: "بعد از تحویل گرفتن محصول و تایید مشتری کیف پول شما شارژ میشود ",
                        icon: "success",
                        button: "باشه"
                    }).then((isOk) => {
                        location.reload();
                    });
                } else {
                    swal({
                        title: "عملیات ناموفق",
                        text: "مشکلی در عملیات پیش آمده",
                        icon: "error",
                        button: "باشه"
                    });
                }
            });
        })
        .catch(err => {
            if (err) {
                swal("Oh noes!", "The AJAX request failed!", "error");
            } else {
                swal.stopLoading();
                swal.close();
            }
        });
}
function deleteProduct(id) {
    swal({
        title: "هشدار !!",
        text: "آیا از حذف اطمینان دارید ؟",
        icon: "warning",
        buttons: ["لغو", "بله"]
    }).then((isOk) => {
        if (isOk) {
            $.ajax({
                url: `/UserPanel/Seller/Products/DeleteProduct?productId=${id}`,
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
                        text: "اما وضعیت محصول شما در فروشگاه به 'ناموجود' تغییر یافت",
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
function ActiveAddress(id) {
    var url = `/UserPanel/Addresses/ActiveAddress?addressId=${id}`;
    $.ajax({
        url: url,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        if (data === "Success") {
            swal({
                title: "عملیات با موفقیت انجام شد",
                icon: "success",
                button: "باشه"
            }).then((isOk) => {
                location.reload();
            });
        } else {
            Error();
        }
    });
}
$(document).ready(function () {
    if (window.location.href.toLowerCase().includes("/tickets/show")) {
        $('.ticket-Body').animate({
            scrollTop: $('.ticket-Body .chat:last-child').position().top
        }, 'slow');
    }
});

function showGalleryModal() {
    $("#modal").modal({
        fadeDuration: 100,
        closeClass: 'icon-remove',
        closeText: 'X'
    });
}
function showModal() {
    $("#modal").modal({
        fadeDuration: 100,
        closeClass: 'icon-remove',
        closeText: 'X'
    });
}
$("#RequestModel_IsAcceptRules").change(function () {
    if (this.checked) {
        $(".btn-submit").prop("disabled", false);;
    } else {
        $(".btn-submit").prop("disabled", true);;
    }
});
function UploadFilteredImage(input) {

    if (input.files && input.files[0]) {
        var img = input.files[0].size;
        var imageSize = img / 1024;
        if (imageSize > 1000.000000000) {
            Error("حخم فایل بالا می باشد", "فایل وارد شده باید کمتر از 1 مگابایت باشد");
            input.files[0] = null;
            $("#image_selector").val(null);
            return;
        }
        var reader = new FileReader();
        reader.onload = function (e) {
            //'userAvatar' img
            $('#image_target').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
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
//'profile' Input
$("#image_selector").change(function () {
    UploadFilteredImage(this);
});
$("#image_selector2").change(function () {
    UploadImage(this);
});
$(document).ready(function () {
    $.ajax({
        url: "/UserPanel/HeaderValues",
        type: "get"
    }).done(function (data) {
        if (typeof data === 'object' && data !== null) {
            $(".messages-menu a .label-danger").html(data.newMessagesCount);
            $(".notifications-menu a .label-warning").html(data.newNotificationsCount);
            if (data.newNotificationsCount === 0) {
            } else {
                $(".notifications-menu .dropdown-menu .header").html(`شما ${data.newNotificationsCount} اعلان جدید دارید`);
                $("#notification_menu a").append(`
            <span class="pull-left-container">
                <span class="label label-warning pull-left">${data.newNotificationsCount}</span>
              </span>
            `);
                for (var item in data.newNotifications) {
                    var notification = data.newNotifications[item]
                    $(".notifications-menu .dropdown-menu .menu").append(`
                    <li><a href="/UserPanel/notifications"><i class="fa fa-bell-o text-warning"></i> ${notification.notificationTitle}</a></li>`);
                }
            }
            if (data.newMessagesCount === 0) {

            } else {
                $(".messages-menu .dropdown-menu .header").html(`شما ${data.newMessagesCount} پیام جدید دارید`);
                $("#messages_menu a").append(`
            <span class="pull-left-container">
                <span class="label label-danger pull-left">${data.newMessagesCount}</span>
              </span>
            `);
                for (var item in data.newMessages) {
                    var message = data.newMessages[item].messageContents[data.newMessages[item].messageContents.length - 1];
                    $(".messages-menu .dropdown-menu .menu").append(`
                        <li>
                         <a href="/UserPanel/Messages/Show/${data.newMessages[item].id}">
                             <div class="pull-right">
                                <img src="/assets/img/UserAvatars/${message.user.imageName}" class="img-circle" alt="User Image">
                             </div>
                        <h4>
                         ${message.user.name}
                        </h4>
                        <p>${message.text}</p>
                      </a>
                    </li>
                    `);
                }
            }
        }
    });


    function setColor(color) {
        if (!color.id) { return color.text; }
        var $currency = $('<span style=display:inline-block;color:black>' + color.text + '</span>    <span style="background:' + color.title + ';width:15px;height:15px;display:inline-block;box-shadow:0 0 5px 0' + color.title + ';position:relative;top:3px;"></span>');
        return $currency;
    };
    $("#select_color").select2({
        templateResult: setColor,
        templateSelection: setColor
    });

    $("#ProductModel_Product_SubParentGroupId").select2();
    $("#CourseModel_ParentGroupId").select2();
    $("#CourseModel_GroupId").select2();
    $("#ProductModel_Product_ParentGroupId").select2();
    $("#ProductModel_Product_GroupId").select2();



    $("#CourseModel_GroupId").change(function () {
        var id = $(this).val();
        $.ajax({
            url: "/UserPanel/Teacher/Courses/Add/CourseGroupOptions?parentId=" + id,
            type: "get",
            beforeSend: function () {
                $(".loading").show();
            },
            complete: function () {
                $(".loading").hide();
            }
        }).done(function (data) {
            $("#CourseModel_ParentGroupId").html(data);
        });
    });

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
});
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
$('#show_order').click(function (event) {
    event.preventDefault();
    this.blur(); // Manually remove focus from clicked link.
    $.ajax({
        url: "/UserPanel/Orders/Courses/OrderById?orderId=" + this.title,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (html) {

        $(html).appendTo('body').modal({
            fadeDuration: 100,
            closeClass: 'icon-remove',
            closeText: 'X'
        });

    });

});

function DeleteRequest(id) {
    deleteItem("/UserPanel/Teacher/StudentsRequest/DeleteRequest?id=" + id);
}

function deleteImage(id) {
    deleteItem("/UserPanel/Teacher/galleries/DeleteGallery?id=" + id);
}
function deleteInvitationCard(id) {
    deleteItem("/UserPanel/InvitationCards/Delete?id=" + id);
}

function showImage(imageName) {
    $(".show-gallery").fadeIn();
    $(".show-gallery img").attr("src", "/Assets/Images/Teachers/Galleries/" + imageName);
}

$(".show-gallery i").click(function () {
    $('.show-gallery').fadeOut();
    $(".show-gallery img").removeAttr("src");
});
function AcceptRequest(id) {
    Question("/UserPanel/Teacher/StudentsRequest/AcceptRequest?id=" + id);
}
function sendMessage(id) {
    $.ajax({
        url: "/UserPanel/Teacher/StudentsRequest/ShowPage?userId=" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#content_form").html(data);
    });
}
function shareLink(id) {
    $.ajax({
        url: "/UserPanel/InvitationCards/Share?id=" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#sendModal #content").html(data);
    });
}

function showEmailForm() {
    $("#emailForm").show();
}

function sendEmail(event) {
    event.preventDefault();
    var email = $("#emailForm #email").val();
    var id = $("#cardId").val();

    $.ajax({
        url: `/UserPanel/InvitationCards/SendEmail?email=${email}&cardId=${id}`,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        if (data === "Success") {
            Success();
            $("#emailForm").hide();
            $("#emailForm #email").val('');
        }
    });
}