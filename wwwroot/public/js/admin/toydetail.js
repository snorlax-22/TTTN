
$(".edit-btn").click(function (event) {
    event.preventDefault();
    window.location.href = "@Url.Action('DangNhap', 'Admin')" + "?username=" + $("#username").val() + "&password=" + $("#password").val();
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


function encodeImageFileAsURLAdd(maHinhAnh) {

    var a = document.getElementsByClassName(data)[0];
    var filesSelected = document.getElementsByClassName(data)[0].files;
    if (filesSelected.length > 0) {
        var fileToLoad = filesSelected[0];
        var fileReader = new FileReader();
        fileReader.onload = function (fileLoadedEvent) {
            srcData = fileLoadedEvent.target.result; // <--- data: base64
            var newImage = document.getElementsByClassName()[0];
            newImage.src = srcData;
            document.getElementsByClassName("imgTest").innerHTML = newImage.outerHTML;
            $.ajax({
                type: "POST",
                url: "/Admin/ThemAnh/",
                data: {
                    maHinhAnh: maHinhAnh,
                    anh: srcData
                },
                success: function (result) {
                    if (result == 1) {
                        alert('Thêm ảnh thành công !');
                        location.reload();
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
//$("#savetoy").click(function (e) {
    
//});