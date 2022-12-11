
//sửa hảng đồ chơi
$(".edit-btn").on('click', function (e) {
    var idRow = '#'+$(this).data('id').toString();
    console.log(idRow);
    $.ajax({
        type: "POST",
        url: "/Admin/CrudDoTuoi/",
        data: {
            idDoTuoi: $(this).data("id"),
            doTuoi: $(idRow).val(),
            type: 2
        },
        success: function (rs) {
            if (rs) {
                alert('Lưu độ tuổi thành công');
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
        type: "POST",
        url: "/Admin/CrudDoTuoi/",
        data: {
            idDoTuoi: $(this).data("id"),
            type: 3
        },
        success: function (rs) {
            if (rs) {
                alert('Xóa độ tuổi thành công');
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
        alert('Vui lòng nhập độ tuổi !');
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Admin/CrudDoTuoi/",
            data: {
                doTuoi: $('.add-brand').val(),
                type: 1
            },
            success: function (rs) {
                if (rs) {
                    alert('Thêm độ tuổi thành công');
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









