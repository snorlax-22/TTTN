$(document).on("click", ".jsTitle", function (e) {
    if ($("#preloader").is(":visible") == true) {
        return;
    }
    e.preventDefault();

    $('.nutrival').click(function () {
        $(this).addClass('active');
        $('.nutrival').removeClass('acct');

        var a = $(this).data('id')
        $(`.nutrival[data-id=${a}]`).addClass('acct');
    });

    $('html, body').animate({
        scrollTop: $(".box-filter").offset().top
    }, 500);
    $(".filter-item").removeClass("isShowing");
    if (!$('body').hasClass('bg-black')) {
        $(this).addClass("active");
        $('.breadcrumb').addClass('heighter');
        $(this).addClass("showing");
        $(this).parents(".filter-item").addClass("isShowing");
        $('body').addClass('bg-black');

        if ($(this).parent().hasClass("filter-total")) {
            $("body.bg-black").addClass("overlay-filter");
        } else
            $("body.bg-black").removeClass("overlay-filter");
        $(this).next('.filter-show').fadeIn(300, function () {
            //if ($(".filter-item .filter-list--hang").hasScrollBarDoc()) {
            //    $(".block-manu .filter-show").addClass("has-scroll");
            //}
        });
        $(".sort-select-main").fadeOut(0);
        $(".info__content").hide();
        if ($(".bsc-block .breadcrumb.hide").length > 0) {
            $(".bg-black .bsc-block").addClass("fix-padding");
        } else
            $(".bg-black .bsc-block").removeClass("fix-padding");
    } else {
        if (!$(this).hasClass('showing')) {//check nếu ko co class showing thì có nghĩa là đang click cai khác nên sẽ hiện block khác lên -- hack não nhẹ
            $(".filter-item__title.active").removeClass("active");
            $(".jsTitle.showing").removeClass("showing");
            $(".filter-show").fadeOut();
            activeOrUnActiveBlock();
            $(this).next('.filter-show').fadeIn(300);
            $(this).addClass("active").addClass("showing");
            $(this).parents(".filter-item").addClass("isShowing");
        } else {
            $('body').removeClass('bg-black');
            $(".jsTitle").removeClass("showing");
            activeOrUnActiveBlock();
            $(".filter-show").fadeOut(300);
            $('.breadcrumb').removeClass('heighter');
        }
    }
});

$(document).on('click', ".click-sort", function () {
    $(".sort-select-main").fadeToggle(300);
    $(".jsTitle.showing").trigger('click');
});

// Filter sắp xếp
$(document).on("click", ".sort-select-main p", function () {
    if ($(this).hasClass('active')) return;

    $(".sort-select-main p.active").removeClass('active');
    $(this).addClass('active');

    query.OrderType = $(this).data('id');
    query.PageIndex = 0;
    filterProduct(false, true);
    replaceTextFilterSort($(this));
});

$(document).on('click', ".layout-nh2__item", function (event) {
    event.preventDefault();
    $(this).toggleClass('border-add');
});

$(document).on("click", ".close-filtertotal", function () {
    $(".show-total").removeClass("active");
    $(".filter-total .jsTitle").trigger('click');
    if ($(".filter-button-total").is(":visible") === true) {
        //$(".show-total .btn-filter-readmore").trigger('click');
        filterProduct();
    }
});

//Bấm xem trong filter bên ngoài
$(document).on("click", ".btn-filter-readmore", function () {
    if ($(this).hasClass('prevent')) {
        return;
    }

    query.PageIndex = 0;
    /*LoadCheckAjax();*/
    
    filterProduct(false, true);
    
});

// Hàm đóng popup filter
function closePopUpFilter() {
    $(".filter-show").fadeOut(300);
    $(".jsTitle").removeClass("showing");
    if ($(".sort-select-main").css('display') == 'block') {
        $(".click-sort").trigger("click");
    }
    $(".bgFilter-total").hide();
    $('body').removeClass('bg-black');
}

// Hàm lọc lại những giá trị bị trùng trong mảng
function unique(value, index, self) {
    return self.indexOf(value) === index;
}

// Hàm collect tất cả param gán vô biến query 
function collectParam() {

    var $ctype = $('.nutrival.acct');
    if ($ctype.length > 0) {
        query.compareType = $ctype.data('id');
        query.Protein = $('input[name=protein]').val();
        query.TotalFat = $('input[name=totalfat]').val();
        query.TotalCarbon = $('input[name=totalcarbon]').val();
        query.Calcium = $('input[name=calcium]').val();
        query.Sodium = $('input[name=sodium]').val();
        query.Magnesium = $('input[name=magnesium]').val();
        query.Iron = $('input[name=iron]').val();
        query.Copper = $('input[name=copper]').val();
        query.Potassium = $('input[name=potassium]').val();
        query.VitaminD3 = $('input[name=vitamind3]').val();
        query.VitaminB1 = $('input[name=vitaminb1]').val();
        query.VitaminB2 = $('input[name=vitaminb2]').val();
        query.Iodine = $('input[name=iodine]').val();
        query.Zinc = $('input[name=zinc]').val();
    }
    
    var $manu = $('.manu a.active');
    if ($manu.length > 0) {
        var numberArray = new Array();
        $manu.each(function () {
            
            numberArray.push($(this).data('id'));
        });
        numberArray = numberArray.filter(unique);
        query.StrListManuId = numberArray.join();
    } else {
        if (query.IsBuffePage && query.PageId > 0 && query.IsManufacturePage) {
            query.StrListManuId = query.PageId.toString();
        } else {
            query.StrListManuId = '';
        }
    }

    var $origins = $('.origin a.active');
    if ($origins.length > 0) {
        var numberArray = new Array();
        $origins.each(function () {
            console.log($(this).data('id'));
            numberArray.push($(this).data('id'));
        });
        numberArray = numberArray.filter(unique);
        query.StrOrigin = numberArray.join();
    } else {
        query.StrOrigin = '';
    }


    var $specs = $('.specs a.active');
    if ($specs.length > 0) {
        var numberArray = new Array();
        var specsArray = new Array();
        $specs.each(function () {
            numberArray.push($(this).data('id'));
            specsArray.push($(this).data('name'));
        });
        numberArray = numberArray.filter(unique);
        specsArray = specsArray.filter(unique);
        query.StrListSpecs = numberArray.join();
        query.ListSpecs = specsArray;
    } else {
        query.StrListSpecs = '';
    }



    var $price = $('.price a.active');
    if ($price.length > 0) {
        var numberArray = new Array();
        $price.each(function () {
            numberArray.push($(this).data('id'));
        });
        numberArray = numberArray.filter(unique);
        query.StrListRangeId = numberArray.join();
        query.StrRangePriceMinMax = '';
    } else {
        query.StrListRangeId = '';
    }

    
    var $cls = $('.colors a.active');
    if ($cls.length > 0) {
        let numberArray = new Array();
        $cls.each(function () {
            numberArray.push($(this).data('id'));
        });
        numberArray = numberArray.filter(unique);
        query.StrColorID = numberArray.join();
    } else {
        query.StrColorID = '';
    }
    var $ext = $('.extend a.active');
    if ($ext.length > 0) {
        var numberArray = new Array();
        $ext.each(function () {
            numberArray.push($(this).data('id'));
        });
        numberArray = numberArray.filter(unique);
        query.ExtendFilter = numberArray.join();
    } else {
        query.ExtendFilter = '';
    }
    var $category = $('.category a.active');
    if ($category.length > 0) {
        var numberArray = new Array();
        $category.each(function () {
            numberArray.push($(this).data('id'));
        });
        numberArray = numberArray.filter(unique);
        query.StrListCategory = numberArray.join();
    } else {
        query.StrListCategory = '';
    }
    var $oder = $('.sort-select-main p.active');
    if ($oder.length > 0) {
        query.OrderType = $('.sort-select-main p.active').data('id');
    } else {
        query.OrderType = 0;
    }
}

function filterProduct(isClickPaging = false, isCheckPaging = false) {
    collectParam();
    $.ajax({
        url: '/Home/GetProductList',
        type: 'POST',
        data: query,
        success: function (e) {

            if (e == null || e == '') {
            }
            else {
                $(".listproduct").html(e);
            }
        },
        error: function () {
            console.log("Lỗi gọi action");
        }
    });
}

// Click các element filter trong các mục filter
$(document).on('click', ".c-btnbox", function (e) {
    e.preventDefault();
    $(this).toggleClass('active');
    if ($(this).hasClass('only')) {
        query.PageIndex = 0;
        collectParam();
        LoadCheckAjax();
        if (isLoadAjax) {
            filterProduct();
        }
    }
    else {
        var id = $(this).data('id');
        //var value = $(this).data('value');

        var isThisActive = $(this).hasClass('active') ? true : false;

        var iSight = $(this).parent().data('sight');

        if ($(this).parent().hasClass('manu')) {
            $(".manu a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        } else if ($(this).parent().hasClass('specs')) {
            $(".specs a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        } else if ($(this).parent().hasClass('price')) {
            $(".price-slider .container").slideUp();
            $(".price-slider .range-toggle span").removeClass("down");
            removeFilterActivedByType(4);
            $(".price a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        } else if ($(this).parent().hasClass('props')) {
            if ($(this).parent().hasClass('props-child')) {
                collectParam();
                query.PageIndex = 0;
                LoadCheckAjax();
                if (isLoadAjax) {
                    filterProduct();
                }
                return false;
            }
            $(".props a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        } else if ($(this).parent().hasClass('category')) {
            $(".category a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        } else if ($(this).parent().hasClass('origin')) {
            $(".origin a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        } else if ($(this).parent().hasClass('colors')) {
            $(".colors a").each(function () {
                var checkBreakloop = activeOrUnActiveFilterInsightAndOutSight($(this), id, isThisActive, iSight);
                if (checkBreakloop == 1) {
                    return false;
                }
            });
        }

        if (isThisActive) {
            insertFilterChoosed($(this));
        } else {
            removeFilterActive($(this), true);
        }

        //replaceTextTotalProduct();
        //getNumberTotalFilter();
        //replaceTextItemHasFilterIntoTitleItem();
    }
});

$(".bgFilter-total").click(function () {
    $(".filter-total .jsTitle").trigger('click');
});

$(document).on("click", ".filter-total .jsTitle", function (e) {
    if ($("#preloader").is(":visible") == true) {
        return;
    }
    $(".bgFilter-total").toggle();
});

function activeOrUnActiveBlock() {
    $(".jsTitle").removeClass("choosed");
    if ($(".c-btnbox.active").length > 0) {
        //thêm class xử lý (filter size giới hạn 3 hàng)
        $('.filter-item.filter-specs .filter-show').addClass('has-button');
        $(".filter-button").show();
        $(".filter-button-total").show();
    }

    $(".c-btnbox.active").each(function () {
        if ($(this).parents(".filter-item").length > 0 && $(this).parents(".filter-total").length == 0) {
            $(this).parents(".filter-item").find(".jsTitle").addClass("choosed");
        }
    });

    //activeOrUnActiveBlockPriceHasRangePriceValue();
}

function activeOrUnActiveFilterInsightAndOutSight($e, id, isThisActive, iSight) {
    if (isThisActive) {
        if ($e.data('id') == id && $e.not('.active') && $e.parent().data('sight') != iSight) {
            $e.addClass('active');
            return 1;
        }
    } else {
        if ($e.data('id') == id && $e.hasClass('active') && $e.parent().data('sight') != iSight) {
            $e.removeClass('active');
            return 1;
        }
    }
    return 0;
}

// Hàm insert những item đã chọn vào vùng tiêu chí đã chọn
function insertFilterChoosed(e, isRangePrice = false, isRemove = false) {
    if ($('.warpper-selected').length > 0) {
        if (e !== undefined && e.data('name') !== undefined && e.data('name') != null && e.data('name') != '') {
            var type = 0;
            if (e.data('type') !== undefined) {
                type = e.data('type');
            }
            var id = 0;
            if (e.data('type') !== undefined) {
                id = e.data('id');
            }
            if (isRemove) {
                $(".filter-selected .item[data-id=" + id + "]").remove();
                return;
            }
            var data = "<div class=\"item\" onclick=\"removeFilterActive(this,false)\" data-type=\"Loai filter\" data-id=\"ValueId\">Content<a href=\"javascript: void (0)\" class=\"clear-selected\"><i class=\"icon-clear-selected\"></i></a></div>";
            data = data.replace("Content", e.data('name')).replace("Loai filter", type).replace("ValueId", id);
            
            $(".appendItem").append(data);
            hideOrShowAreaLabelChoosed();
        } else if (isRangePrice) {
            $(".filter-selected .item[data-type=4]").remove();
            var textRange = getTextLabelRangePrice();
            if (textRange != '') {
                var data = "<div class=\"item\" onclick=\"removeFilterActive(this,false)\" data-type=\"4\" data-id=\"0\">Content<a href=\"javascript: void (0)\" class=\"clear-selected\"><i class=\"icon-clear-selected\"></i></a></div>";
                data = data.replace("Content", textRange);
                $(".appendItem").append(data);
                hideOrShowAreaLabelChoosed();
            }
        }
        console.log(e.data('name'));
        console.log(e.data('id'));
    }
    
}

//Hàm remove filter đã active
function removeFilterActive(e, isClickAgain) {
    var type = parseInt($(e).data("type"));
    if (type > 0) {
        if (!isClickAgain) {
            $(e).remove();
        } else if ($(".filter-selected .item").length > 0) {
            insertFilterChoosed($(e), false, true);
        }
    } else
        return;

    hideOrShowAreaLabelChoosed();

    switch (type) {
        case 1://manu
            if ($(".show-total-item .manu a[data-id=" + $(e).data("id") + "]").hasClass("active"))
                $(".show-total-item .manu a[data-id=" + $(e).data("id") + "]").trigger("click");
            break;
        case 2://price
            if ($(".show-total-item .price a[data-id=" + $(e).data("id") + "]").hasClass("active"))
                $(".show-total-item .price a[data-id=" + $(e).data("id") + "]").trigger("click");
            break;
        case 3://prop
            if ($(".show-total-item .props a[data-id=" + $(e).data("id") + "]").hasClass("active"))
                $(".show-total-item .props a[data-id=" + $(e).data("id") + "]").trigger("click");
            break;
        case 4://rangePrice
            if (query.StrRangePriceMinMax !== undefined && query.StrRangePriceMinMax != '') {
                if ($(".filter-list.price").length > 0) {
                    $(".price-slider .container").slideUp();
                    $(".price-slider .range-toggle span").removeClass("down");
                } else {
                    resetPriceRange();
                    $(".filter-item__title.price-title.active").removeClass('active');
                }
                callFilterRangeSlider(true);
            }
            break;
        case 6://originCountry
            if ($(".show-total-item .origin a[data-id=" + $(e).data("id") + "]").hasClass("active"))
                $(".show-total-item .origin a[data-id=" + $(e).data("id") + "]").trigger("click");
            break;
        case 8://size
            if ($(".show-total-item .specs a[data-id=" + $(e).data("id") + "]").hasClass("active"))
                $(".show-total-item .specs a[data-id=" + $(e).data("id") + "]").trigger("click");
            break;
        case 9://Color
            if ($(".show-total-item .colors a[data-id=" + $(e).data("id") + "]").hasClass("active"))
                $(".show-total-item .colors a[data-id=" + $(e).data("id") + "]").trigger("click");
            break;
        default:
    }
}

// Hàm ẩn hoặc hiện tiêu chí đã lọc
function hideOrShowAreaLabelChoosed() {
    if ($(".filter-selected .item").length == 0) {
        $(".filter-selected").hide();
    } else {
        $(".filter-selected").show();
    }
}
