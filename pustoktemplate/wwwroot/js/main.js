$(document).ready(function () {
    $(document).on("click", "show-book-modal", function (e) {
        e.preventDefaut();

        var url = $(this).attr("href")

        fetch(url)
            .then(response => response.text())
            .then(data => $(".product-details-modal").html(data))
    })
})