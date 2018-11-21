$(function(){
    // 轮播左右按钮
    var product_hover = $('.feed-carousel');
    product_hover.hover(function() {
        $(this).children('.slide-button').removeClass('opacity')
        $(this).find('.swiper-scrollbar-drag').stop().fadeIn(500);
    }, function() {
        $(this).children('.slide-button').addClass('opacity')
        $(this).find('.swiper-scrollbar-drag').stop().fadeOut(500);
    });
    //查看历史记录
    var remove_history = $('.nav-timeline-data .nav-timeline-remove-container .nav-timeline-icon');
    remove_history.on('click',function(event) {
        event.stopPropagation(); 
        var i = $(this).parents('.swiper-slide').index();
        Historial.removeSlide(i);
        if(Historial.slides.length == 1){
            $('#nav-flyout-timeline').slideUp("100");
        }
    });
    // 商品简介弹框
    var product_details = $('.feed-carousel .swiper-wrapper .product-details');
    var mask_popover_brief = $('.mask-popover-brief');
    var same_section = mask_popover_brief.find('#same-section');
    var popover_close = mask_popover_brief.find('#gw-popover-close');
    product_details.click(function(){
        $('body').css({overflow: 'hidden'});
        mask_popover_brief.fadeIn(300).queue(function(next){
            same_section.animate({height:"30%"},500);
            next();
        })
    })
    popover_close.click(function(){
        mask_popover_brief.fadeOut(300);
        $('body').css({overflow: 'auto'});
        same_section.css({height: '3px'});
    })
    var same_link = same_section.find('.same-link');
    same_link.click(function(){
        $(this).addClass('selected').siblings().removeClass('selected');
    })
    // 返回顶部
    var navFooterBackToTop = $('.navFooterBackToTop');
    navFooterBackToTop.click(function(){
        $('html,body').animate({scrollTop: 0},'200');
    })
    // 头部下拉列表
    var departments = $('#nav-link-shopall');
    var historial = $('#nav-recently-viewed');
    var accountList = $('#nav-link-accountList');
    var try_prime = $('#nav-link-prime');
    var nav_flyout_accountList = $('#nav-flyout-accountList');
    var nav_flyout_timeline = $('#nav-flyout-timeline');
    var nav_flyout_shopAll = $('#nav-flyout-shopAll');
    var nav_flyout_prime = $('#nav-flyout-prime');
    function ListHover(target,flyout){
        target.hover(function(){
            flyout.fadeIn(0);
        }, function() {
            flyout.fadeOut(0);
        });
        flyout.hover(function(){
            flyout.fadeIn(0);
        },function() {
            flyout.fadeOut(0);
        })
    }
    ListHover(departments,nav_flyout_shopAll);
    ListHover(accountList,nav_flyout_accountList);
    ListHover(try_prime,nav_flyout_prime);
    ListHover(historial,nav_flyout_timeline);
})