

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




