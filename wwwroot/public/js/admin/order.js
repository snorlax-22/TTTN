﻿$('.nav-link').click(function () {

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

$('.submit').click(function (event) {

    var datefrom = $('#input_from').val();
    var dateto = $('#input_to').val();

    $.ajax({
        url: "/Admin/thongKeDoanhThu",
        type: 'GET',
        data: {
            datefrom: datefrom,
            dateto: dateto
        },
        success: function (res) {
            console.log(res);
            $('#chart').html(res);
        },
        error: function (res) {
            
        }
    });
});


$('.gotoprint').click(function (event) {
    //event.preventDefault();
    alert("Okeeee");
});

