$('.approve').click(function () {

    var idCart = $(this).data('id');
    var idx = $(this).data('idx');
    //var myJsonProduct = JSON.stringify(prd);
    var clsName = '.deliver.'+idx+' :selected'
    $.ajax({
        url: '/Admin/duyetDonHang',
        type: 'POST',
        data: {
            maDonHang: idCart,
            maNVDuyet: $(this).data('idnvduyet'),
            maNVGiao: $(clsName).val()
        },
        success: function () {
            location.reload();  
        },
        error: function () {
        }
    })
});

$('.complete').click(function () {

    var idCart = $(this).data('id');
    //var myJsonProduct = JSON.stringify(prd);
    $.ajax({
        url: '/Admin/hoanthanhDonHang',
        type: 'POST',
        data: {
            maDonHang: idCart
        },
        success: function () {
            location.reload();
        },
        error: function () {
        }
    })
});

$('.ctgh').click(function (event) {
    $.ajax({
        url: "/Admin/LayChiTietGioHang",
        type: 'GET',
        data: {
            maGH: $(this).data('id')
        },
        success: function (res) {
            $('#content').html(res);
        },
        error: function (res) {
            console.log('error')
        }
    });
});

function closePopup() {
    var a = document.getElementsByClassName('bg-promo')[0];
    a.classList.add('hide');
    var b = document.getElementsByClassName('alert-promo')[0];
    b.classList.add('hide');

}

function showPopup() {
    var a = document.getElementsByClassName('bg-promo')[0];
    a.classList.remove('hide');
    var b = document.getElementsByClassName('alert-promo')[0];
    b.classList.remove('hide');
}

$('.gotoprint').click(function (event) {

    var magh = $(this).data('magh');
    var nvtao = $(this).data('nvtao');
    var cmndkh = $(this).data('cmndkh');

    $.ajax({
        url: "/Admin/InHoaDon",
        type: 'GET',
        data: {
            cmnd: cmndkh,
            manvtaohd: nvtao,
            magh: magh
        },
        success: function (res) {
            location.reload();
            document.location.href = '/Admin/GoToPrint', true;
        },
        error: function (res) {

        }
    });
});

$('.invoice').click(function (event) {

    var magh = $(this).data('magh');
    var mahd = $(this).data('mahd');

    $.ajax({
        url: "/Admin/XemHoaDon",
        type: 'GET',
        data: {
            mahd: mahd,
            magh: magh
        },
        success: function (res) {
            document.location.href = '/Admin/GoToPrint', true;
        },
        error: function (res) {

        }
    });
});

