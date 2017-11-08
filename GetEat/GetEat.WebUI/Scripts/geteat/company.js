//alert(1)
$(document).ready(function () {

    //Background height

    $(window).on("load resize", function () {
        $(".companibkgr", ".screen-bgr").css("height", window.innerHeight);
    });
});
