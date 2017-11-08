
$(document).ready(function () {

    //Background height

    $(window).on("load resize", function () {
        $(".screen-bgr").css("height", window.innerHeight);
    });



    // autocompelete
    var availableTags;

    $.ajax(
        {
            url: '/Home/GetKitchens',
            method: 'GET'
        })
        .done(function (data) {
            var availableTags;
            $("#cuisine").autocomplete({
                source: availableTags,
                classes: {
                    "ui-autocomplete": "highlight"
                }
            });
        })
        .fail(function (data) {
            aler('fail');
        });

    $("#cuisine").autocomplete({
        source: availableTags,
        classes: {
            "ui-autocomplete": "highlight"
        }
    });

    var availableCities = [
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
        source: availableCities,
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



