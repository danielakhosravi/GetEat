
$(document).ready(function () {

    //Background height

   



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


    $(".raiting-star").on("click", function () {
        $(this).addClass('active');
        $(this).prevAll().addClass('active');

        $(this).nextAll().removeClass('active');
        $("#score").val($(this).index() + 1);
    });
  
    $("[data-toggle=tooltip]").tooltip();

});

$(window).on("load resize", function () {
    $(".screen-bgr", ".logbackground", ".contactbackgr").css("height", window.innerHeight);
});

$(function () {
    $('#datetimepicker1').datetimepicker();
});

$('#timepicker2').timepicker({
    minuteStep: 1,
                               template: 'modal',
                               appendWidgetTo: 'body',
                               showSeconds: true,
                               showMeridian: false,
                               defaultTime: false
                           });







