if ($(window).width() < 767) {
    $(window).scroll(function() {

        scroll = $(window).scrollTop();

        if (scroll >= 70) {
            $('.fixed_header').addClass("header_show");

        } else {
            $('.fixed_header').removeClass("header_show");
        }

    });
}

$(".mobile_menu").click(function() {
    $(".fh_nave").slideToggle();
    $(this).find('i').toggleClass('fa-times');
});
$(document).ready(function() {
    $(".btn1").click(function() {
        if ($(this).hasClass('active')) {
            $("[name=Gender]").attr('checked', true);
        } else if ($(this).hasClass('active') !== false) {
            $("[name=Gender]").attr('checked', false);
        }
        $(".btn1").removeClass("active");
        $(this).addClass("active");
    });


});
$(document).ready(function() {
    $(".btn2").click(function() {
        if ($(this).hasClass('active')) {
            $("[name=Gender]").attr('checked', true);
        } else if ($(this).hasClass('active') !== false) {
            $("[name=Gender]").attr('checked', false);
        }
        $(".btn2").removeClass("active");
        $(this).addClass("active");
    });


});
$(document).ready(function() {

    $(".form-group-select").click(function() {
        $(".form-group-select").addClass("selectintro");
    });


});