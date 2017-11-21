
$(document).ready(function () {

    InitialiseScore();

    InitialiseKitchen();

    InitialiseCity();
    
});

function InitialiseKitchen()
{
    var availableCuisine;

    $.ajax(
        {
            url: '/Home/GetKitchens',
            method: 'GET'
        })
        .done(function (data) {
            
            availableCuisine = data;
            $("#cuisine").autocomplete({
                source: availableCuisine,
                classes: {
                    "ui-autocomplete": "highlight"
                },
                position: { my: "right top", at: "right bottom" }
            });
        })
        .fail(function (data) {
            aler('please reload page');
        });


    
}




function InitialiseScore()
{
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
}
   


$(window).on("load resize", function () {
    $(".screen-bgr", ".logbackground", ".contactbackgr").css("height", window.innerHeight);
});

//$(function () {
//    $('#datetimepicker1').datetimepicker();
//});

//$('#timepicker2').timepicker({
//    minuteStep: 1,
//                               template: 'modal',
//                               appendWidgetTo: 'body',
//                               showSeconds: true,
//                               showMeridian: false,
//                               defaultTime: false
//                           });




function InitialiseCity()
{
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
        source: function (req, responseFn) {
            addMessage("search on: '" + req.term + "'<br/>");
            var re = $.ui.autocomplete.escapeRegex(req.term);
            var matcher = new RegExp("^" + re, "i");
            var a = $.grep(availableCities, function (item, index) {
                //addMessage("&nbsp;&nbsp;sniffing: '" + item + "'<br/>");
                return matcher.test(item);
            });
            addMessage("Result: " + a.length + " items<br/>");
            responseFn(a);
        },

        select: function (value, data) {
            if (typeof data === "undefined") {
                addMessage('You selected: ' + value + "<br/>");
            } else {
                addMessage('You selected: ' + data.item.value + "<br/>");
            }
        },
        classes:
        {
            "ui-autocomplete": "highlight"
        },
        autoFocus: true
    });

    monkeyPatchAutocomplete();
    availableCities.sort();
}

function monkeyPatchAutocomplete() {

    // Don't really need to save the old fn, 
    // but I could chain if I wanted to
    var oldFn = $.ui.autocomplete.prototype._renderItem;

    $.ui.autocomplete.prototype._renderItem = function (ul, item) {
        var re = new RegExp("^" + this.term, "i");
        var t = item.label.replace(re, "<span style='font-weight:bold;color:#6284B4'>" + this.term.toUpperCase() + "</span>");
        return $("<li></li>")
            .data("item.autocomplete", item)
            .append("<a style='color:#080808'>" + t + "</a>")
            .appendTo(ul);
    };
}
function addMessage(msg) {
    $('#msgs').append(msg);
}




