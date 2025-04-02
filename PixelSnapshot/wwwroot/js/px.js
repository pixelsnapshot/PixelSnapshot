$(document).ready(function () {

    $("#searchBox").on("keyup", function () {
           let filter = $(this).val().trim();
                    window.location.href = "/Home/Gallery?search=" + encodeURIComponent(filter);
                });


});