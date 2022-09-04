//thêm nhà CC
$(".add-btn").on('click', function (e) {

    if ($('.sname').val() = '' || $('.snumber').val() == '' || $('.smail').val() == '', $('.saddress').val()) {
        alert('Vui lòng nhập đủ thông tin của nhà cung cấp');
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Admin/themNhaCC/",
            data: {
                tenNhaCC: $('.sname').val(),
                sdtNhaCC: $('.snumber').val(),
                emailNhaCC: $('.smail').val(),
                diaChiNhaCC: $('.saddress').val()
            },
            success: function (rs) {
                if (rs) {
                    alert('Thêm nhà cung cấp thành công');
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









