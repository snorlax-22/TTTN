//$('#keyword').keyup(function () {
//    var searchField = $('#keyword').val();
//    var expression = RegExp(searchField, "i");

//    //$('.search-result').remove();
//    $('.search-result>ul').remove();
//    $.ajax({
//        url: '/Product/Search',
//        type: 'GET',
//        data: {
//            searchText: searchField
//        },
//        dataType: 'json',
//        contentType: 'application/json;charset=utf-8',
//        success: function (response) {
//            if (!response.length) {
//                $(".search-result").css("display", "none");
//                $(".search-show").css("display", "none");
//                $(".header-search").css("border-radius", "20px");
//            }
//            var data = JSON.parse(response);
//            console.log(data);
//            if (searchField != "") {
//                var html_Body = `<ul>

//                        </ul> `;
//            } $('.search-result').append(html_Body);
//            $.each(data, function (key, item) {
//                if (item.TenDoChoi.search(expression) && searchField != "") {
//                    var html_Search = `<li>
//                                <a href="/">
//                                    <div class="img">
//                                        <img src="${item.DSHINHANH[0].HinhAnh}" class="ls-is-cached lazyloaded" alt="">
//                                    </div>
//                                    <div class="ct">
//                                        <h3>${item.TenDoChoi}</h3>
//                                        <div class="price">
//                                            <strong class="price-current">${item.ThayDoiGia.Gia}₫</strong>
//                                            <span class="price-old">629.000₫</span>
//                                            <span class="price-percent">10%</span>
//                                        </div>
//                                    </div>
//                                </a>
//                            </li>`;
//                    $('.search-result ul').append(html_Search);
//                }
//                if (item.TenDoChoi.search(expression) == -1 || searchField == "" || !searchField.length || searchField == null) {
//                    $(".search-result").css("display", "none");
//                    $(".search-show").css("display", "none");
//                    $(".header-search").css("border-radius", "20px");
//                }

//                else if (item.TenDoChoi.search(expression) != -1 && searchField != "") {
//                    $(".search-result").css("display", "block");
//                    $(".search-show").css("display", "block");
//                    $(".header-search").css("border-radius", "20px 20px 0px 0px");

//                }
//            })
//        },
//        error: function(){
//            $(".search-result").css("display", "none");
//            $(".search-show").css("display", "none");
//            $(".header-search").css("border-radius", "20px");
//        }
//    })
//})

$('.submit-search').click(function () {

    $('.search-result').empty();

    var searchField = $('#keyword').val();
    $.ajax({
        url: '/Product/Search',
        type: 'GET',
        data: {
            searchText: searchField
        },
        success: function (html) {
            $(".search-result").css("display", "block");
            $(".search-show").css("display", "block");
            $(".search-show").css("box-shadow", " 0 24px 80px rgb(0 0 0 / 7%), 0 10.0266px 33.4221px rgb(0 0 0 / 5%), 0 5.36071px 17.869px rgb(0 0 0 / 4%), 0 3.00517px 10.0172px rgb(0 0 0 / 4%), 0 1.59602px 5.32008px rgb(0 0 0 / 3%), 0 0.664142px 2.21381px rgb(0 0 0 / 2%)");
            $(".header-search").css("border-radius", "20px 20px 0px 0px");
            $('.search-result').append(html);
        },
        error: function () {
        }
    });
})

$(document).mouseup(function (e) {
    var container = $('.search-show');

    // if the target of the click isn't the container nor a descendant of the container
    if (!container.is(e.target) && container.has(e.target).length === 0) {
        container.hide();
        $(".header-search").css("border-radius", "20px");
        
    }
});

