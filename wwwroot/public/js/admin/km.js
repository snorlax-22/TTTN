
$('#add-km').click(function (event) {
    //event.preventDefault();
    $.ajax({
        url: "/Admin/DiscountVoice",
        type: 'GET',
        success: function (html) {
            $('.section-add-item-km').append(html);
        },
        error: function (res) {
            console.log('error DiscountVoice')
        }
    });
    
});



$('.save').click(function (event) {
    //event.preventDefault();
    
    var arrPtGiamGia = [];
    var arrMaDoChoi = [];
    $('.ptgiamgia').each(function (i, obj) {
        arrPtGiamGia.push($(obj).val());
    });

    $('.toys :selected').each(function (i, obj) {
        arrMaDoChoi.push($(obj).val());
    });

    var manv = $('#empid').data('id');
    var timefrom = $('#timefrom').val();
    var timeto = $('#timeto').val();
    var tenkm = $('#kmname').val();
    var lydokm = $('#lydokm').val();

    $.ajax({
        url: "/Admin/TaoKhuyenMai",
        data: {
            arrPtGiamGia: JSON.stringify(arrPtGiamGia),
            arrMaDoChoi: JSON.stringify(arrMaDoChoi),
            manv: manv,
            timefrom: timefrom,
            timeto: timeto,
            tenkm: tenkm,
            lydokm: lydokm
        },
        type: 'GET',
        success: function (html) {
            alert('Thêm đợt khuyến mãi thành công');
            location.reload();
        },
        error: function (res) {
            console.log('error DiscountVoice');
        }
    });
});
