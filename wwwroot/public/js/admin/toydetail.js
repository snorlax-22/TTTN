var listAnh = null;

$(".edit-btn").click(function (event) {
    event.preventDefault();
    window.location.href = "@Url.Action('DangNhap', 'Admin')" + "?username=" + $("#username").val() + "&password=" + $("#password").val();
});


$("#add-toy").click(function (e) {
    $.ajax({
        type: "POST",
        url: "/Admin/ThemDoChoi/",
        data: {
            manv: 4,
            tenDoChoi: $("#toyName").val(),
            password: $("#toyPrice").val(),
            listAnh: srcData,
            slAnh: 1
        },
        success: function (result) {
            if (result == 1) {
                console.log('ok');
                alert('Thêm đồ chơi thành công !');
            }
            else {
                console.log('error');
                alert('Thêm đồ chơi thất bại, vui lòng xem lại !');
            }

        },
        error: function (result) {
            console.log('error');
            alert('Thêm đồ chơi thất bại, vui lòng xem lại !');
        }
    });
});


function encodeImageFileAsURL(data, data1) {
    console.log(data);
    var a = document.getElementsByClassName(data)[0];
    console.log(a);
    var filesSelected = document.getElementsByClassName(data)[0].files;
    console.log(filesSelected);
    if (filesSelected.length > 0) {
        var fileToLoad = filesSelected[0];

        var fileReader = new FileReader();

        fileReader.onload = function (fileLoadedEvent) {
            srcData = fileLoadedEvent.target.result; // <--- data: base64

            var newImage = document.getElementsByClassName(data1)[0];
            newImage.src = srcData;

            document.getElementsByClassName("imgTest").innerHTML = newImage.outerHTML;
            /*  listAnh.add(srcData);*/
            if (!listAnh) {
                listAnh = srcData;
            }
            else {
                listAnh = listAnh + "|" + srcData;
            }
            
            console.log(listAnh);
        }
        fileReader.readAsDataURL(fileToLoad);
    }
}