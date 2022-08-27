

$('.print').click(function () {
    window.print();
});

$('.topdf').click(function () {
    var doc = new jsPDF();
    var elementHandler = {
        '#ignorePDF': function (element, renderer) {
            return true;
        }
    };
    var source = window.document.getElementsByTagName("page")[0];
    doc.fromHTML(
        source,
        55,
        55,
        {
            'width': 280, 'elementHandlers': elementHandler
        });

    doc.save("hoadon.pdf");
});
