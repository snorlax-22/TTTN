$('#signup').click(function () {

    var option = $('input[name="inlineRadioOptions"]:checked').val();
    var gioitinh = "";
    if (option == "option1") {
        gioitinh = "Nam";
    }
    else {
        gioitinh = "Nữ";
    }

    console.log(gioitinh);
    var tenKh = $('#cusName').val();
    var mk = $('#cusPass').val();
    var acc = $('#cusAccount').val();
    var mst = $('#cusMST').val();
    var add = $('#cusAdd').val();
    var email = $('#cusEmail').val();
    var phone = $('#cusPhone').val();
    var cmnd = $('#cusID').val();

    console.log(cmnd);

    if ((tenKh) == '') {
        alert('Tên KH không được để trống !');
    }
    else if ((mk) == '') {
        alert('MK không được để trống !');
    }
    else if ((acc) == '') {
        alert('Tên TK không được để trống !');
    }
    else {
        $.ajax({
            url: '/Home/ThemKhachHang',
            type: 'POST',
            data: {
                tenKh: tenKh,
                mk: mk,
                acc: acc,
                mst: mst,
                add: add,
                email: email,
                phone: phone,
                gioitinh: gioitinh,
                cmnd: cmnd
            },
            success: function (res) {
                if (res == 1) {
                    alert('Đăng ký thành công !');
                    document.location.href = "/";
                }
                else {
                    alert('Đã xảy ra lỗi vui lòng thử lại');
                }

            },
            error: function () {
            }
        })
    }

});

$('#signin').click(function () {
    document.location.href = "/Home/SignIn", true;
});

$('.profile').click(function () {

    var username = $(this).data('kh');

    $.ajax({
        url: '/Home/GetProfile',
        type: 'POST',
        data: {
            username: username,
        },
        success: function (res) {
                document.location.href = "/Home/Profile", true;
        },
        error: function () {
        }
    });
});

$('#dangnhap').click(function () {

    var pw = $('#pw-pay').val();
    var username = $('#id-pay').val();

    $.ajax({
        url: '/Home/Login',
        type: 'POST',
        data: {
            pw: pw,
            username: username,       
        },
        success: function (res) {
            if (res == 1) {
                document.location.href = "/", true;
            }
            else {
                alert('Sai tên đăng nhập hoặc mật khẩu');
            }
        },
        error: function () {
        }
    });
});

$('#update').click(function () {

    var tenKh = $('#cusName').val();
    var mk = $('#cusPass').val();
    var mst = $('#cusMST').val();
    var add = $('#cusAdd').val();
    var email = $('#cusEmail').val();
    var phone = $('#cusPhone').val();
    var cmnd = $('#cusID').val();
    var username = $('#cusAccount').val();

    console.log(cmnd);

    if ((tenKh) == '') {
        alert('Tên KH không được để trống !');
    }
    else if ((mk) == '') {
        alert('MK không được để trống !');
    }
    else {
        $.ajax({
            url: '/Home/SuaKhachHang',
            type: 'POST',
            data: {
                username: username,
                tenKh: tenKh,
                mk: mk,
                mst: mst,
                add: add,
                email: email,
                phone: phone,
                cmnd: cmnd
            },
            success: function (res) {
                if (res == 1) {
                    alert('Sửa tài khoản thành công !');
                    document.location.href = "/";
                }
                else {
                    alert('Đã xảy ra lỗi vui lòng thử lại');
                }

            },
            error: function () {
            }
        })
    }

});