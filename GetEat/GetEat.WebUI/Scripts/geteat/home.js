
$(document).ready(function () {

    //Background height

    $(window).on("load resize",function(){
        $(".screen-bgr").css("height", window.innerHeight);
    });
    


    // autocompelete
    var availableTags = [
      "Indonesian",
      "Mexican",
      "Italian",
      "French",
      "Chinese",
      "Spanish",
      "Japanese",
      "Turkey",
      "Indian",
      "Iranian",
      "Bulgarian",
      "Sushi",
      "Seafood",
      "Fastfood",
      "Fish",
      "take away ",
      "Burger",
      "Pizza",
      "Steaks and Grill",
      "Seafood and Grill",
      "Meditarranean",
        ];
    $("#cuisine").autocomplete({
        source: availableTags,
        classes: {
            "ui-autocomplete": "highlight"
        }
    });
    var availableTags = [
      "Sofia",
      "Bourgas",
      "Varna",
      "Rousse",
      "Plovdiv",
      "Stara Zagora",
      "Pleven",
      "Pazardzhik",
      "Velingrad",
      "Veliko Tarnovo",
      "Asenovgrad",
      "Balchik",
      "Bansko",
      "Bankia",
      "Blagoevgrad",
      "Vidin",
      "Devnq",
      "Dobrich",
      "Kazanluk",
      "Karlovo",
      "Kalofer",
      "Sopot"
    ];
    $("#city").autocomplete({
        source: availableTags,
        classes: {
            "ui-autocomplete": "highlight"
        }
    });

    
    $("a#registrate").on('click', function () {
        $('input[type = checkbox]').prop('checked', true)
        $(this).css('color', '#DC8DC9');
        $("a#logIn").css('color', '#FE9D00');
    });
    $("a#logIn").on('click', function () {
        $('input[type = checkbox]').prop('checked', false)
        $(this).css('color', '#DC8DC9');
        $("a#registrate").css('color', '#FE9D00');

    });

   
});



