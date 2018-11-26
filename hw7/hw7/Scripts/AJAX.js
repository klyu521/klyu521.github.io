var boringWords = ["I", "his", "my", "him", "go", "to", "and", "but", "it",
                   "me", "we", "of", "those","he", "that",
                   "this", "an", "so", "us"];

$("#InputBox").bind("keypress", function (e) {

    if (e.key === ' ') {
        var value = $("#InputBox").val();
        var valueSpace = value.split(" ");
        var data = valueSpace[valueSpace.length - 1];
        var flag = false;
        for (var i = 0; i < boringWords.length; i++) {

            if (boringWords[i].toUpperCase() === data.toUpperCase()) {
                flag = true;
            }
        }
        if (flag) {
            $("#Image").append("<label>" + data + "&nbsp;</label></div>");
        }
        else {
            ajaxFuc(data);
        }
    }
});


function ajaxFuc(data) {

    var source = "/Translator/Sticker/" + data;
    console.log(source);


    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData,
        error: errorOnAjax
    });
}


function displayData(giphyData) {

    var imageUrl = giphyData.data.images.original_still.url;

    $("#Image").append("<img src='" + imageUrl + "' style='width:80px;height:80px; margin:15px;'/>");
}

function errorOnAjax() {
    console.log("error");
}

function clear() {
    $("InputBox").empty();
}