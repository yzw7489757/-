var popover_html = '<div class="popover">'+
                        '<div class="showCloseIcon">'+
                            '<i class="a-icon a-icon-close"></i>'+
                        '</div>'+
                        '<div class="tips_content"></div>'+
                        '<div class="transparent"></div>'+
                    '</div>'
$(function(){
    $('body').append(popover_html)
})
//h 鼠标划过的元素； popover 提示框本身； dir 提示框相对于 鼠标划过的元素 的方向； 提示内容写在 鼠标划过的元素 行内 并命名为tip
//默认方向为top 方向参数为'top','right','bottom','left'
//配合popover_hover.css   注意：不要改动该文件
//使用时需手动CSS设置 popover 宽度 
//例如：var tip_hover = $('.deposit .hover_tip');
//      var popover = $('.popover');
//      popover_hover(tip_hover,popover);
function popover_hover(h,popover,dir){ 
    dir = dir || 'top';
    h.hover(function() {
        $(this).append(popover);
        var tip = $(this).attr('tip');
        popover.children('.tips_content').html(tip);
        var _this_left = $(this).offset().left;
        var _this_top = $(this).offset().top;
        var _this_width = $(this).outerWidth(true);
        var _this_height = $(this).outerHeight(true);
        if(dir == 'top'){
            popover.addClass('top');
            var l = _this_left - (popover.outerWidth(true)/2) + _this_width/2;
            var t = _this_top - popover.outerHeight(true) - 10;
        }
        if(dir == 'right'){
            popover.addClass('right');
            popover.children('.transparent').css({ height:'100%'});
            var l = _this_left + _this_width + 10;
            var t = _this_top - (popover.outerHeight(true)/2) + _this_height/2;
        }
        if(dir == 'bottom'){
            popover.addClass('bottom');
            var l = _this_left - (popover.outerWidth(true)/2) + _this_width/2;
            var t = _this_top + _this_height + 10;
        }
        if(dir == 'left'){
            popover.addClass('left');
            popover.children('.transparent').css({ height:'100%'});
            var l = _this_left - popover.outerWidth(true) - 10;
            var t = _this_top - (popover.outerHeight(true)/2) + _this_height/2;
        }
        setTimeout(function(){
            popover.css({ top: t,left: l}).stop().fadeIn(300)
        }, 0)
        popover.children('.showCloseIcon').click(function() {
           popover.fadeOut(300);
        })
    }, function() {
        popover.stop().fadeOut(300);
    })
}


