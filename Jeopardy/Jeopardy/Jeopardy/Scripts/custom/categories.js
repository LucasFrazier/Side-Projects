$(document).ready(function () {

        $.ajax({
            url: "http://jservice.io/api/categories",
            type: "GET",
            dataType: "json",
            data: {
                count: "20"
            }
        }).done(function (data) {
            console.log(data);
            $("#CategorySelect1").empty();
            $("#CategorySelect2").empty();
            $("#CategorySelect3").empty();
            for (let x = 0; x < 20; x++) {
                let category1 = $("<option>").text(data[x].title).attr("data", data[x].id);
                let category2 = $("<option>").text(data[x].title).attr("data", data[x].id);
                let category3 = $("<option>").text(data[x].title).attr("data", data[x].id);
                $("#CategorySelect1").append(category1);
                $("#CategorySelect2").append(category2);
                $("#CategorySelect3").append(category3);
            }

            
        }).fail(function (xhr, status, error) {
            console.log(error);
        });

    $("#submitCategories").on("click", function (event) {

        let userInput = $("#submitCategories").data();

        $.ajax({
            url: "https://dog.ceo/api/breeds/image/random/" + userInput,
            type: "GET",
            dataType: "json"
        }).done(function (data) {
            console.log(data);
            $("#apiMagic").empty();
            for (let x = 0; x < userInput; x++) {
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
    
});