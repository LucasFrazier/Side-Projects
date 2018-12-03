$(document).ready(function () {  

$("#btnSearch").on("click", function (event) {

    var artist = $("#artist").val();
    
    $.ajax({
        url: "https://itunes.apple.com/search",
        type: "GET",
        dataType: "json",
        data: {
            term: artist,
            country: 'US',
            entity: 'album'

        }
    }).done(function (data) {
        console.log(data);
                    
    }).fail(function (xhr, status, error) {
        console.log(error);
    });
});

});