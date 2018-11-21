$(function(){
    var product_hover = $('.feed-carousel');
    product_hover.hover(function() {
        $(this).children('.slide-button').removeClass('opacity')
        $(this).find('.swiper-scrollbar-drag').stop().fadeIn(500);
    }, function() {
        $(this).children('.slide-button').addClass('opacity')
        $(this).find('.swiper-scrollbar-drag').stop().fadeOut(500);
    });
    var remove_history = $('.nav-timeline-data .nav-timeline-remove-container .nav-timeline-icon');
    remove_history.on('click',function(event) {
        event.preventDefault();
        var i = $(this).parents('.swiper-slide').index();
        Historial.removeSlide(i);
        if(Historial.slides.length == 1){
            $('#nav-flyout-timeline').slideUp("100");
        }
    });
})