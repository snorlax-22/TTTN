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