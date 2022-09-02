$(document).ready(function () {
    $("#log").click(function (event) {
        $.ajax({
            type: "GET",
            url: "/Admin/DangNhap/",
            data: {
                username: $('.username').val(),
                password: $('.password').val()
            },
            success: function (result) {
                if (result == 1) {
                    document.location.href = '/Admin/Admin', true;
                }
                else if (result == 1002) {
                    document.location.href = '/Admin/Order', true;
                }
                else {
                    alert("Sai mật khẩu hoặc tên đăng nhập");
                }

            },
            error: function (result) {
                alert('login failed');
            }
        });

    });
});

