
$(".edit-btn").click(function (event) {
    event.preventDefault();
    window.location.href = "@Url.Action('DangNhap', 'Admin')" + "?username=" + $("#username").val() + "&password=" + $("#password").val();
});

$("#save-toy").click(function (event) {
    $.ajax({
        type: "POST",
        url: "/Admin/suaDoChoiInfo/",
        data: {
            madochoi: $('#emppName').data('toyid'),
            manv: $('#emppName').data('id'),
            gia: $('#toyPrice').val(),
            tendochoi: $('#toyName').val(),
            mota: $('.description').val()
        },
        success: function (result) {
            if (result == 1) {
                isSuccess = 1;
                alert('Xóa ảnh thành công !');
                location.reload();
            }
            else {
                console.log('error');
                alert('Xóa ảnh thất bại, vui lòng xem lại !');
            }

        },
        error: function (result) {
            console.log('error');
            alert('Xóa ảnh thất bại, vui lòng xem lại !');
        }
    });
});

function encodeImageFileAsURL(data, data1, id) {
    var a = document.getElementsByClassName(data)[0];
    var filesSelected = document.getElementsByClassName(data)[0].files;
    if (filesSelected.length > 0) {
        var fileToLoad = filesSelected[0];
        var fileReader = new FileReader();
        fileReader.onload = function (fileLoadedEvent) {
            srcData = fileLoadedEvent.target.result; // <--- data: base64
            var newImage = document.getElementsByClassName(data1)[0];
            newImage.src = srcData;
            document.getElementsByClassName("imgTest").innerHTML = newImage.outerHTML;
            $.ajax({
                type: "PUT",
                url: "/Admin/SuaAnh/",
                data: {
                    idAnh: id,
                    anh: srcData
                },
                success: function (result) {
                    if (result == 1) {
                        alert('Sửa ảnh thành công !');
                    }
                    else {
                        console.log('error');
                        alert('Sửa ảnh thất bại, vui lòng xem lại !');
                    }

                },
                error: function (result) {
                    console.log('error');
                    alert('Sửa ảnh thất bại, vui lòng xem lại !');
                }
            });
        }
        fileReader.readAsDataURL(fileToLoad);
    }
}


function encodeImageFileAsURLAdd(maDoChoi) {
    var filesSelected = document.getElementById('inputFileToLoad').files;
    if (filesSelected.length > 0) {
        var fileToLoad = filesSelected[0];
        var fileReader = new FileReader();
        fileReader.onload = function (fileLoadedEvent) {
            srcData = fileLoadedEvent.target.result; // <--- data: base64
            var newImage = document.createElement('img');
            newImage.src = srcData;
            document.getElementsByClassName("imgTest").innerHTML = newImage.outerHTML;
            $.ajax({
                type: "POST",
                url: "/Admin/ThemAnh/",
                data: {
                    maDoChoi: maDoChoi,
                    anh: srcData
                },
                success: function (result) {
                    if (result == 1) {
                        isSuccess = 1;
                        alert('Cập nhật thành công !');
                        location.reload();
                    }
                    else {
                        console.log('error');
                        alert('Cập nhật thất bại, vui lòng xem lại !');
                    }

                },
                error: function (result) {
                    console.log('error');
                    alert('Cập nhật thất bại, vui lòng xem lại !');
                }
            });
        }
        fileReader.readAsDataURL(fileToLoad); 
    }
}

function xoaAnh(data) {
    $.ajax({
        type: "POST",
        url: "/Admin/xoaAnh/",
        data: {
            idAnh: data,
        },
        success: function (result) {
            if (result == 1) {
                isSuccess = 1;
                alert('Xóa ảnh thành công !');
                location.reload();
            }
            else {
                console.log('error');
                alert('Xóa ảnh thất bại, vui lòng xem lại !');
            }

        },
        error: function (result) {
            console.log('error');
            alert('Xóa ảnh thất bại, vui lòng xem lại !');
        }
    });
}
