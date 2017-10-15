
$(document).ready(function () {

    // autocompelete
    var availableTags = [
      "ActionScript",
      "AppleScript",
      "Asp",
      "BASIC",
      "C",
      "C++",
      "Clojure",
      "COBOL",
      "ColdFusion",
      "Erlang",
      "Fortran",
      "Groovy",
      "Haskell",
      "Java",
      "JavaScript",
      "Lisp",
      "Perl",
      "PHP",
      "Python",
      "Ruby",
      "Scala",
      "Scheme"
    ];
    $("#tags").autocomplete({
        source: availableTags
    });

    // date picker intialization 

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