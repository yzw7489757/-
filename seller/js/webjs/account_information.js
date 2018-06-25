$(function(){
    var sc_sub_nav = $('.sc-sub-nav');
    var sc_hover_nav = $('.sc-hover-nav');
    console.log(sc_hover_nav)
   
    for(let i=0;i<sc_hover_nav.length;i++){
         $('.sc-hover-nav').eq([i]).attr('data-list',i)
         sc_hover_nav[i].addEventListener('mouseover',function(){
            $('.sc-hover-nav').eq([this.dataset.list])
            .find('.sc-nav-arrow').eq(0).css({opacity:1,visibility:'visible'});
            $('.sc-hover-nav').eq([this.dataset.list])
            .find('.sc-sub-nav').eq(0).css({display:'block'});
         })
         sc_hover_nav[i].addEventListener('mouseout',function(){
            $('.sc-hover-nav').eq([this.dataset.list])
            .find('.sc-nav-arrow').eq(0).css({opacity:0,visibility:'hidden'});
            $('.sc-hover-nav').eq([this.dataset.list])
            .find('.sc-sub-nav').eq(0).css({display:'none'});
         })
    }
})
