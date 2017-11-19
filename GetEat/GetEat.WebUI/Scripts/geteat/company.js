//alert(1)
$(document).ready(function () {

    //Background height

    $(window).on("load resize", function () {
        $(".companibkgr", ".screen-bgr").css("height", window.innerHeight);


       
    });
    
    $("li.raiting-star").on("click", function () {
        $("li.raiting-star").removeClass(".active");
        $("li.raiting-star").removeClass(".secondary-activ");
        $("this").addClass(".active");
        $("this").prevAll().addClass(".secondary-active");
    });

    $("#maxChars").keypress(function () {
      
        if ($(this).val().length >= 24) {
            //$(this).val($(this).val().slice(0, 24));
            alert("This field can take a maximum of 24 characters");
        }
    
    });
 
//    $('.carousel').carousel({
//        interval: 6000
//    })

//Rating stars

 
  //#rating span = star= raiting-circle
  //reiting-hover=.hover
    //reiting-chousen =.ratingclick

   

//    var stars;
//    var vouted;
//    $(".raiting-star").click(function () {
//        $(".raiting-star").removeClass(".reiting-hover");
//        $(".raiting-star").removeClass(".ratingclick");

//        $(this).addClass(".ratingclick");
//        $(this).prevAll().addClass(".ratingclick");

//        stars = $(this).index();
//        vouted = $($("raiting-star").get(stars));

//        $(vouted).data("vouted", true);

//    });

//    $(".raiting-star").hover(function () {
//        $(".raiting-star").removeClass(".reiting-hover");
//        $(".raiting-star").removeClass(".ratingclick");

//        $(this).addClass(".reiting-hover");
//        $(this).prevAll().addClass(".reiting-hover");
//    });

//    $(".raiting-star").mouseout(function ()   {

//        $(".raiting-star").removeClass(".reiting-hover")
//        {
//            if ($(vouted).data("vouted")) {
//                $(vouted).addClass("ratingcliked");
//                $(vouted).prevAll().addClass("ratingcliked");
//            }

//        }

//    });
//});




//    function reSetActive() {
//  $('.set').removeClass('set');
//  $('.active').addClass('set');
//  $('.active').removeClass('active');
//}

//$('path').on('click',
//  function() {
//    // setActive()
//    reSetActive()
//    alert(currentVal)
//  }
//)

});

