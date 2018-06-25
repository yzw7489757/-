$(function(){
    alert(1)
    var sc_sub_nav = $('.sc-sub-nav');
    var sc_hover_nav = $('.sc_hover_nav');
    sc_hover_nav.mouseover(function(){
        alert('a')
        sc_sub_nav.addClass('hide');
    })
})
