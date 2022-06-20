
var filtersBrand = [];
var filtersKind = [];
var sortSelected = "";
var prd = {
    brand: [],
    kind: [],
    orderType: "",
    CurrentPageIndex: 1
};

//show và unshow các class dưới đây
function showFilter(obj) {
    var c = document.getElementsByClassName("sort-select-main");
    for (var i = 0; i < c.length; i++) {
        if (c[i].style.display == "block") {
            c[i].style.display = "none";
        }
        else {
            c[i].style.display = "block";
        }

    }
}

//show và unshow các class dưới đây
function showFilteritem(obj) {
    var c = document.getElementsByClassName("filter-show");

    if (c[0].style.display == "block") {
        c[0].style.display = "none";
    }
    else {
        c[0].style.display = "block";
    }
}

//show và unshow các class dưới đây
function showFilteritem1(obj) {
    var c = document.getElementsByClassName("filter-show");

    if (c[1].style.display == "block") {
        c[1].style.display = "none";
    }
    else {
        c[1].style.display = "block";
    }
}


//sad
//trạng thái nút bấm filter
$(document).ready(function () {
    $('.sort').click(function () {
        prd.orderType = $(this).attr('data-name');
        console.log(prd.orderType)
        var myJsonProduct = JSON.stringify(prd);

        $.ajax({
            url: '/ProductCate/SearchFilter',
            type: 'GET',
            data: {
                jsonprd: myJsonProduct
            },
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                var data = JSON.parse(response);
                $('#toy-grid').load('ProductCate/LoadToyBoxes', {
                    aPList: data,
                });
            },
            error: function () {
            }
        })
    })
});


//phân trang
$(document).ready(function () {
    $('.pagination.button-pagbreak.button-pagbreak-prev').click(function () {
        console.log($(this).attr('data-page'))
        prd.CurrentPageIndex = $(this).attr('data-page');

        $('.pagination.button-pagbreak.button-pagbreak-prev').removeClass("active");
        $(this).toggleClass("active");

        var myJsonProduct = JSON.stringify(prd);

        $.ajax({
            url: '/ProductCate/SearchFilter',
            type: 'GET',
            data: {
                jsonprd: myJsonProduct
            },
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                var data = JSON.parse(response);
                $('#toy-grid').load('ProductCate/LoadToyBoxes', {
                    aPList: data
                });
            },
            error: function () {
            }
        })
    }),
    $('#_pgNextPage').click(function () {
        console.log($(this).attr('data-page'))
        prd.CurrentPageIndex = $(this).attr('data-page');

        var buttonPage = document.getElementsByClassName('pagination button-pagbreak button-pagbreak-prev');

        $('.pagination').removeClass("active");
        buttonPage[buttonPage.length - 1].classList.add("active");

        var myJsonProduct = JSON.stringify(prd);

        $.ajax({
            url: '/ProductCate/SearchFilter',
            type: 'GET',
            data: {
                jsonprd: myJsonProduct
            },
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                var data = JSON.parse(response);
                $('#toy-grid').load('ProductCate/LoadToyBoxes', {
                    aPList: data
                });
            },
            error: function () {
            }
        })
    }),
        $('#_pgPreviousPage').click(function () {
            console.log($(this).attr('data-page'))
            prd.CurrentPageIndex = $(this).attr('data-page');

            var buttonPage = document.getElementsByClassName('pagination button-pagbreak button-pagbreak-prev');

            $('.pagination').removeClass("active");
            buttonPage[0].classList.add("active");

            var myJsonProduct = JSON.stringify(prd);

            $.ajax({
                url: '/ProductCate/SearchFilter',
                type: 'GET',
                data: {
                    jsonprd: myJsonProduct
                },
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                success: function (response) {
                    var data = JSON.parse(response);
                    $('#toy-grid').load('ProductCate/LoadToyBoxes', {
                        aPList: data
                    });
                },
                error: function () {
                }
            })
        })
});

//check nếu có brand hoặc loại trong 
$(document).ready(function () {
    //var y = [1, 2, 2, 3, 2]
    //var removeItem = 2;

    //y = jQuery.grep(y, function (value) {
    //    return value != removeItem;
    //});
    $('.c-btnbox').click(function () {
        if ($(this).hasClass('act')) {
            
            if (filtersBrand.includes($(this).attr('data-brand'))) {
                //filtersBrand.pop($(this).attr('data-brand'));
                filtersBrand.splice($.inArray($(this).attr('data-brand'), filtersBrand), 1);
               
            }
            if (filtersKind.includes($(this).attr('data-name'))) {
                //filtersKind.pop($(this).attr('data-name'));
                filtersKind.splice($.inArray($(this).attr('data-name'), filtersKind), 1);
               
            }
            $(this).removeClass('act');
            console.log(filtersBrand);
            console.log(filtersKind);
        }
        else {
            if ($(this).attr('data-brand') != undefined && !filtersBrand.includes($(this).attr('data-brand'))) {
                filtersBrand.push($(this).attr('data-brand'));
            }
            if ($(this).attr('data-name') != undefined && !filtersKind.includes($(this).attr('data-name'))) {
                filtersKind.push($(this).attr('data-name'));
            }
            $(this).addClass('act');

            console.log(filtersBrand);
            console.log(filtersKind);
        }
    })
});

//lấy dữ liệu data-brand và data-name của class ".c-btnbox"
$(document).ready(function () {
    $('.filter-button').click(function () {
        prd.brand = filtersBrand;
        prd.kind = filtersKind;
        console.log(prd);

        var myJsonProduct = JSON.stringify(prd);

        $.ajax({
            url: '/ProductCate/SearchFilter',
            type: 'GET',
            data: {
                jsonprd: myJsonProduct
            },
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                var data = JSON.parse(response);
                $('#toy-grid').load('ProductCate/LoadToyBoxes', {
                    aPList: data,
                });
            },
            error: function () {
            }
        })
    })
});



