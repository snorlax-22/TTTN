

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

function showFilteritem(obj) {
    var c = document.getElementsByClassName("filter-show");

    if (c[0].style.display == "block") {
        c[0].style.display = "none";
    }
    else {
        c[0].style.display = "block";
    }
}

$(document).ready(function () {
    $('.c-btnbox').click(function () {
        var searchBrand = $(this).attr('data-brand');
        console.log(searchBrand)
        $.ajax({
            url: '/Product/SearchFilter',
            type: 'GET',
            data: {
                searchBrand: searchBrand
            },
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                var data = JSON.parse(response);
                console.log(data)
                
                $('#toy-grid').load('Product/LoadToyBoxes', {
                    aPList: data
                    });
                
            },
            error: function () {

            }
        })
    })
});



