$('#keyword').keyup(function () {
    var searchField = $('#keyword').val();
    var expression = RegExp(searchField, "i");

    //$('.search-result').remove();
    $('.search-result>ul').remove();
    $.ajax({
        url: '/Product/Search',
        type: 'GET',
        data: {
            searchText: searchField
        },
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (!response.length) {
                $(".search-result").css("display", "none");
                $(".search-show").css("display", "none");
                $(".header-search").css("border-radius", "20px");
            }
            var data = JSON.parse(response);
            console.log(data);
            if (searchField != "") {
                var html_Body = `<ul>
                            
                        </ul> `;
            } $('.search-result').append(html_Body);
            $.each(data, function (key, item) {
                if (item.TenDoChoi.search(expression) && searchField != "") {
                    var html_Search = `<li>
                                <a href="/">
                                    <div class="img">
                                        <img src="${item.DSHINHANH[0].HinhAnh}" class="ls-is-cached lazyloaded" alt="">
                                    </div>
                                    <div class="ct">
                                        <h3>${item.TenDoChoi}</h3>
                                        <div class="price">
                                            <strong class="price-current">${item.ThayDoiGia.Gia}₫</strong>
                                            <span class="price-old">629.000₫</span>
                                            <span class="price-percent">10%</span>
                                        </div>
                                    </div>
                                </a>
                            </li>`;
                    $('.search-result ul').append(html_Search);
                }
                if (item.TenDoChoi.search(expression) == -1 || searchField == "" || !searchField.length || searchField == null) {
                    $(".search-result").css("display", "none");
                    $(".search-show").css("display", "none");
                    $(".header-search").css("border-radius", "20px");
                }

                else if (item.TenDoChoi.search(expression) != -1 && searchField != "") {
                    $(".search-result").css("display", "block");
                    $(".search-show").css("display", "block");
                    $(".header-search").css("border-radius", "20px 20px 0px 0px");

                }
            })
        },
        error: function(){
            $(".search-result").css("display", "none");
            $(".search-show").css("display", "none");
            $(".header-search").css("border-radius", "20px");
        }
    })
})



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
            
//            }
//            var data = JSON.parse(response);
//            console.log(data);
//            if (searchField != "") {
//                var html_Body = `<ul></ul> `;
//            } $('.search-result').append(html_Body);
//            $.each(data, function (key, item) {
//                if (item.Name.search(expression) != -1 && searchField != "") {
//                    var html_Search = `<li>
//                                <a href="/">
//                                    <div class="img">
//                                        <img src="${item.Image[0]}" class="ls-is-cached lazyloaded" alt="">
//                                    </div>
//                                    <div class="ct">
//                                        <h3>${item.Name}</h3>
//                                        <div class="price">
//                                            <strong class="price-current">${item.Price}₫</strong>
//                                            <span class="price-old">629.000₫</span>
//                                            <span class="price-percent">10%</span>
//                                        </div>
//                                    </div>
//                                </a>
//                            </li>`;
//                    $('.search-result ul').append(html_Search);
//                }
//                if (item.Name.search(expression) == -1 || searchField == "" || !searchField.length || searchField == null) {
//                    $(".search-result").css("display", "none");
//                    $(".search-show").css("display", "none");
//                    $(".header-search").css("border-radius", "20px");
//                }

//                else if (item.Name.search(expression) != -1 && searchField != "") {
//                    $(".search-result").css("display", "block");
//                    $(".search-show").css("display", "block");
//                    $(".header-search").css("border-radius", "20px 20px 0px 0px");

//                }
//            })
//        },
//        error: function () {
//            $(".search-result").css("display", "none");
//            $(".search-show").css("display", "none");
//            $(".header-search").css("border-radius", "20px");
//        }
//    })
//})

