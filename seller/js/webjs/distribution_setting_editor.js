$(function () {
    var show = true ; 
    $('.titleHeader').click(function () { 
        if(show){
            $('.a-icon-img').removeClass('a-icon-section-expand');
            $('.a-section-expander-inner').show();
            show = false ;
        }else{
            $('.a-icon-img').addClass('a-icon-section-expand');
            $('.a-section-expander-inner').hide();
            show = true ;
        }
     })
 })