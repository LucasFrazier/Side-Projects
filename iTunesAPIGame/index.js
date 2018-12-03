$(document).ready(function () {  

    $("#btnSearch").on("click", function (event) {

        var userInput = $("#userInput").val();
        
        $.ajax({
            url: "https://dog.ceo/api/breeds/image/random/" + userInput,
            type: "GET",
            dataType: "json"
        }).done(function (data) {
            console.log(data);
            $("#apiMagic").empty();
            for(let x = 0; x < userInput; x++){
                let flipCard = $("<div>").addClass("flip-card");
                let flipCardInner = $("<div>").addClass("flip-card-inner");
                let flipCardFront = $("<div>").addClass("flip-card-front");
                let flipCardBack = $("<div>").addClass("flip-card-back");
                let albumImage = $("<img>").attr("src", data.message[x]).attr("style", "width:300px;height:auto;");
                
                flipCardFront.append(albumImage);
                flipCardInner.append(flipCardFront);
    
                flipCardBack.append("<h1>").text("Album Name");
                flipCardBack.append("<p>").text("Year");
                flipCardBack.append("<p>").text("Record Label");
                flipCardInner.append(flipCardBack);
    
                flipCard.append(flipCardInner);
                $("#apiMagic").append(flipCard);
            }
        }).fail(function (xhr, status, error) {
            console.log(error);
        });
    });
    
/* $("#btnSearch").on("click", function (event) {

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
        $("#apiMagic").empty();
        for(let x = 0; x < data.results.length; x++){
            let flipCard = $("<div>").addClass("flip-card");
            let flipCardInner = $("<div>").addClass("flip-card-inner");
            let flipCardFront = $("<div>").addClass("flip-card-front");
            let flipCardBack = $("<div>").addClass("flip-card-back");
            let albumImage = $("<img>").attr("src", data.results[x].artworkUrl100).attr("style", "width:300px;height:300px;");
            
            flipCardFront.append(albumImage);
            flipCardInner.append(flipCardFront);

            flipCardBack.append("<h1>").text("Album Name");
            flipCardBack.append("<p>").text("Year");
            flipCardBack.append("<p>").text("Record Label");
            flipCardInner.append(flipCardBack);

            flipCard.append(flipCardInner);
            $("#apiMagic").append(flipCard);
        }
    }).fail(function (xhr, status, error) {
        console.log(error);
    });
}); */



});