$('.nav-link').click(function () {

    $('.nav-link').removeClass('active');
    $(this).addClass('active');
    var matrangthai = $(this).data('id');
    //var myJsonProduct = JSON.stringify(prd);
    $.ajax({
        url: '/Admin/ChooseListOrder',
        type: 'GET',
        data: {
            matrangthai: matrangthai
        },
        success: function (html) {
            $('#cart-list').empty();
            $('#cart-list').html(html);
        },
        error: function () {
        }
    })
});

$('.approve').click(function () {

    var idCart = $(this).data('id');
    //var myJsonProduct = JSON.stringify(prd);
    $.ajax({
        url: '/Admin/duyetDonHang',
        type: 'POST',
        data: {
            maDonHang: idCart,
            maNVDuyet: $(this).data('idnvduyet'),
            maNVGiao: $('#deliver').val()
        },
        success: function () {
            location.reload();  
        },
        error: function () {
        }
    })
});

