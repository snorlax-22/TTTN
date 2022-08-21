$(document).ready(function () {
    $(".txt").click(function () {
        $.ajax({
            url: "/Cart/ThemVaoGio",
            type: 'POST',
            data: {
                id: $(this).data("id"),
                qty: 1
            },
            success: function (res) {
                console.log('thêm vào giỏ thành công')
            },
            error: function (res) {
                console.log('thêm vào giỏ thất bại')
            }
        });
    });

    $('.txt').click(function (event) {
        tempAlert('Đã thêm sản phẩm vào giỏ', 2000);
    });

    $('.plus').click(function (event) {
        var a = $(this).data("id");
        $.ajax({
            url: "/Cart/plusminusCart",
            type: 'POST',
            data: {
                id: $(this).data("id"),
                qty: 1,
                key: '+'
            },
            success: function (res) {
                $("#" + a).attr('value', res).trigger('change');
            },
            error: function (res) {
                console.log('+1 error')
            }
        });
    });

    $('.minus').click(function (event) {
        var a = $(this).data("id");
        $.ajax({
            url: "/Cart/plusminusCart",
            type: 'POST',
            data: {
                id: $(this).data("id"),
                qty: 1,
                key: '-'
            },
            success: function (res) {
                //$('input.text').val(res);
                $("#" + a).attr('value', res).trigger('change');
            },
            error: function (res) {
                console.log('-1 error')
            }
        });
    });

    $('#pay').click(function (event) {
        $.ajax({
            url: "/Paypal/checkIsLoginCustomer",
            type: 'GET',
            success: function (res) {

                if (res === "1") {
                    //showConfirm();
                    aler('sai tk mk')
                }
                else if (res === "0") {
                    showPopup();
                }                 
                else {
                    alert(res);
                }
                
            },
            error: function (res) {
                console.log('-1 error')
            }
        });
    });

});

function tempAlert(msg, duration) {
    var el = document.createElement("div");
    el.setAttribute("style", "padding:15px;border-radius:8px;position:absolute;top:48px;right:319px;background-color:white;");
    el.innerHTML = msg;
    setTimeout(function () {
        el.parentNode.removeChild(el);
    }, duration);
    document.body.appendChild(el);
}

function closePopup() {
    var a = document.getElementsByClassName('bg-promo')[0];
    a.classList.add('hide');
    var b = document.getElementsByClassName('alert-promo')[0];
    b.classList.add('hide');

}

function showPopup() {
    var a = document.getElementsByClassName('bg-promo')[0];
    a.classList.remove('hide');
    var b = document.getElementsByClassName('alert-promo')[0];
    b.classList.remove('hide');
}









