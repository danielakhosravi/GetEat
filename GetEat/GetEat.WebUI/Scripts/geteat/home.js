
$(document).ready(function () {
    
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

    $('ul li').each(function (i) {
        $(this).addClass('linksaccount'); 
    });

 
    //$('#datetimepicker1').datetimepicker();
    ////
    //$('#timepicker2').timepicker({
    //    minuteStep: 1,
    //    template: 'modal',
    //    appendWidgetTo: 'body',
    //    showSeconds: true,
    //    showMeridian: false,
    //    defaultTime: false
    //});

});