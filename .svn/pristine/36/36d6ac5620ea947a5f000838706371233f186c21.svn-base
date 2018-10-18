var popover_html = '<div class="popover">'+
                        '<div class="showCloseIcon">'+
                            '<i class="a-icon a-icon-close"></i>'+
                        '</div>'+
                        '<div class="tips_content"></div>'+
                        '<div class="transparent"></div>'+
                    '</div>'
function popover_hover(h,popover,d){
    h.hover(function() {
        var l = $(this).offset().left - (popover.outerWidth(true)/2) + $(this).outerWidth(true)/2;
        var that = $(this);
        that.append(popover);
        var tip = $(this).attr('tip');
        function fade(d,N){
            popover.children('.tips_content').text(d[N]);
            var t = that.offset().top - popover.outerHeight(true) - 10;
            setTimeout(function(){
                popover.css({ top: t,left: l}).stop().fadeIn(300)
            }, 0)
        }
        fade(d,tip)
        popover.children('.showCloseIcon').click(function() {
           popover.fadeOut(300);
        })
    }, function() {
        popover.stop().fadeOut(300);
    })
}
$(function(){
    $('body').append(popover_html)
})

