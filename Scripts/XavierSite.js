//add comment ajax
$(document).ready(function () {
    $('#commentForm').submit(function (event) {
        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr('action');

        $.post(url, data, function (response) {
            alert(response);
        });
    });

});






$(document).ready(function () {
    //do something
});