$(function () {
    var showText = true;
    $('.a-tabs li').click(function () {
        var index = $(this).index();
        $(".chooseText>li").eq(index).removeClass("none").siblings().addClass("none");
    })
    $('.Textdetail>li').click(function () { 
        var index = $(this).index(); 
        if(showText){
            $('.Textdetail li').eq(index).find('.a-section-expander-inner').removeClass('none')
            $('.Textdetail li').eq(index).find('.a-icon-section-collapse').css({
                'backgroundPosition':'-5px -82px'
            })
            $('.Textdetail li').eq(index).find('.editBtn').show()
            showText = false;
        }else{
            $('.Textdetail>li').eq(index).find('.a-section-expander-inner').addClass('none')
            $('.Textdetail li').eq(index).find('.a-icon-section-collapse').css({
                'backgroundPosition':'-5px -59px'
            })
            $('.Textdetail li').eq(index).find('.editBtn').hide()
            showText = true;
        }
     })
})