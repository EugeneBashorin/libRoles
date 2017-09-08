$(".button-saver").click(function () {
    alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/booksList.txt")
});

$(".db-saver").click(function () {
    alert("Saved to Data Base")
});

$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".viewDialog").on("click", function (e) {
        e.preventDefault();

        $("<div></div>")
            .addClass("dialog")
            .appendTo("body")
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true
            })
            .load(this.href);
    });
});