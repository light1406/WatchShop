$(document).ready(function () {
    $(".load-more").click(function () {
        var npr = document.getElementsByClassName("product-item").length;
        $.ajax({
            url: "/Product/LoadMore",
            type: "GET",
            dataType: "json",
            data: { count: npr },
            contentType: "application/json; charset=utf-8",
            success: function (rp) {
                if (rp != "") {
                    $(".list-product").append(rp)
                } else {
                    $(".load-more").parent().remove()
                }
            },
            error: function (ex) {
                console.log("error")
            }
        });
    });
});