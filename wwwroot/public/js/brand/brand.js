
//sửa hảng đồ chơi
$(".edit-btn").on('click', function (e) {
    var idRow = '#'+$(this).data('id').toString();
    console.log(idRow);
    $.ajax({
        type: "PUT",
        url: "/Admin/SuaHang/",
        data: {
            idHang: $(this).data("id"),
            tenHang: $(idRow).val(),
        },
        success: function (rs) {
            if (rs) {
                alert('Lưu đồ chơi thành công');
            }
            else {
                alert('Đã có lỗi xảy ra');
            }
        },
        error: function (rs) {
            alert('Đã có lỗi xảy ra');
        },
        failure: function (rs) {
            alert('Đã có lỗi xảy ra');
        }
    });
});

//xóa hãng
$(".delete-btn").on('click', function (e) {
    var idRow = '#'+$(this).data('id').toString();
    console.log(idRow);
    $.ajax({
        type: "PUT",
        url: "/Admin/XoaHang/",
        data: {
            idHang: $(this).data("id"),
        },
        success: function (rs) {
            if (rs) {
                alert('Xóa đồ chơi thành công');
                location.reload();
            }
            else {
                alert('Đã có lỗi xảy ra');
            }
        },
        error: function (rs) {
            alert('Đã có lỗi xảy ra');
        },
        failure: function (rs) {
            alert('Đã có lỗi xảy ra');
        }
    });
});

//thêm hãng
$(".add-btn").on('click', function (e) {
    if ($('.add-brand').val() == '') {
        alert('Vui lòng nhập tên hãng !');
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Admin/ThemHang/",
            data: {
                tenHang: $('.add-brand').val()
            },
            success: function (rs) {
                if (rs) {
                    alert('Thêm đồ chơi thành công');
                    location.reload();
                }
                else {
                    alert('Đã có lỗi xảy ra');
                }
            },
            error: function (rs) {
                alert('Đã có lỗi xảy ra');
            },
            failure: function (rs) {
                alert('Đã có lỗi xảy ra');
            }
        });
    }
});









