$(document).ready(function () {
    $(".txt").click(function () {
        $.ajax({
            url: "/Cart/ThemVaoGio",
            type: 'POST',
            data: {
                id: $(this).data("id"),
                qty: 1
            },
            success: function (res) {
                console.log('thêm vào giỏ thành công')
            },
            error: function (res) {
                console.log('thêm vào giỏ thất bại')
            }
        });
    });

    $('.txt').click(function (event) {
        tempAlert('Đã thêm sản phẩm vào giỏ', 2000);
    });
});

function tempAlert(msg, duration) {
    var el = document.createElement("div");
    el.setAttribute("style", "padding:15px;border-radius:8px;position:absolute;top:48px;right:319px;background-color:white;");
    el.innerHTML = msg;
    setTimeout(function () {
        el.parentNode.removeChild(el);
    }, duration);
    document.body.appendChild(el);
}







