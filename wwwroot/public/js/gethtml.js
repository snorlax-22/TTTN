
//tính dung lượng của ảnh

var img = '';

function checkKB(img) {
    var xhr = new XMLHttpRequest();
    xhr.open('HEAD', img, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                var bytesfromimage = parseFloat(xhr.getResponseHeader('content-length')) / 1024;
                if (bytesfromimage > 300) {
                    //alert("hình này lớn hơn 300kb:" + img);
                    console.warn("hình này lớn hơn 300kb: " + img + "  ||kbyte from image: " + bytesfromimage);
                }
            } else {
                console.log('ERROR');
            }
        }
    };
    xhr.send(null);
}

$.ajax({
    url: '/GetHTML/Search',
    type: 'GET',
    dataType: 'json',
    contentType: 'application/json;charset=utf-8',
    success: function (response) {
        var data = JSON.parse(response);

        $.each(data, function (i, val) {
            checkKB(val)
        });
        
    },
    error: function () {
    }
})


