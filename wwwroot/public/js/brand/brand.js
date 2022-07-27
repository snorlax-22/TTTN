
$(".edit-btn").on('click', function (e) {

    var idRow = '#'+$(this).data('id').toString();

    console.log(idRow);

    $.ajax({
        type: "POST",
        url: "/Admin/SuaHang/",
        data: {
            idHang: $(this).data("id"),
            tenHang: $(idRow).val(),
        },
        success: function () {
            alert('Lưu đồ chơi thành công');
        },
        error: function () {
            alert('Đã có lỗi xảy ra');
        },
        failure: function () {
            alert('Đã có lỗi xảy ra');
        }
    });
});

