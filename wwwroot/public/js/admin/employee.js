
////xóa hãng
$(".delete-btn").on('click', function (e) {
    
    $.ajax({
        type: "PUT",
        url: "/Admin/XoaNV/",
        data: {
            manv: $(this).data("id"),
        },
        success: function (rs) {
            if (rs) {
                alert('Xóa nhân viên thành công');
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

////thêm hãng
//$(".add-btn").on('click', function (e) {
//    if ($('.add-brand').val() == '') {
//        alert('Vui lòng nhập tên hãng !');
//    }
//    else {
//        $.ajax({
//            type: "POST",
//            url: "/Admin/ThemLoaiDoChoi/",
//            data: {
//                tenLoai: $('.add-brand').val()
//            },
//            success: function (rs) {
//                if (rs) {
//                    alert('Thêm loại đồ chơi thành công');
//                    location.reload();
//                }
//                else {
//                    alert('Đã có lỗi xảy ra');
//                }
//            },
//            error: function (rs) {
//                alert('Đã có lỗi xảy ra');
//            },
//            failure: function (rs) {
//                alert('Đã có lỗi xảy ra');
//            }
//        });
//    }
//});


//sửa hảng đồ chơi
$(".save").on('click', function (e) {

    var tenNV = $('#tennv').val();
    var email = $('#emailnv').val();
    var diachi = $('#diachinv').val();
    var sdt = $('#sdtnv').val();
    var mst = $('#sdtnv').val();
    var username = $('#usnv').val();
    var password = $('#pwnv').val();
    var gioitinh = $('#gioitinhnv :selected').val();
    var maquyen = $('#quyennv :selected').val();

    if (tenNV == '' || email == '' || diachi == '' || sdt == '' || mst == '' || username == ''
        || password == '' || gioitinh == '' || maquyen == '') {
        alert('Vui lòng nhập đầy đủ thông tin');
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Admin/themNhanVien/",
            data: {
                tenNV: tenNV,
                email: email,
                diachi: diachi,
                gioitinh: gioitinh,
                sdt: sdt,
                mst: mst,
                username: username,
                maquyen: maquyen,
                password: password
            },
            success: function (rs) {
                if (rs) {
                    alert('Thêm nhân viên thành công');
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









