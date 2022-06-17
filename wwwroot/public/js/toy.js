
var filtersBrand = [];
var filtersKind = [];
var sortSelected = "";
var prd = {
    brand: [],
    kind: [],
    orderType:""
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

//check nếu có brand hoặc loại trong 
$(document).ready(function () {
    $('.c-btnbox').click(function () {
        if ($(this).hasClass('act')) {
            
            if (filtersBrand.includes($(this).attr('data-brand'))) {
                filtersBrand.pop($(this).attr('data-brand'));
            }
            if (filtersKind.includes($(this).attr('data-name'))) {
                filtersKind.pop($(this).attr('data-name'));
            }
            $(this).removeClass('act');
            console.log("removed " + filtersBrand);
            console.log("removed " + filtersKind);
        }
        else {
            if ($(this).attr('data-brand') != undefined && !filtersBrand.includes($(this).attr('data-brand'))) {
                filtersBrand.push($(this).attr('data-brand'));
            }
            if ($(this).attr('data-name') != undefined && !filtersKind.includes($(this).attr('data-name'))) {
                filtersKind.push($(this).attr('data-name'));
            }
            $(this).addClass('act');
            console.log("added " + filtersBrand);
            console.log("added " + filtersKind);
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



