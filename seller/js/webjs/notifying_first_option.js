$(function () {
    var showText = true;
    $('.a-tabs li').click(function () {
        var index = $(this).index();
        $(".chooseText>li").eq(index).removeClass("none").siblings().addClass("none");
    })
    $('.Textdetail>li').click(function (e) { 
        var index = $(this).index(); 
        var TextdetailLi = $('.Textdetail li').eq(index) 
        console.log(e.target.className)
        if(e.target.className.indexOf('edit') != '-1'){
            // 点击编辑
            TextdetailLi.find('.save_cancel_Btn').show()
            TextdetailLi.find('.editBtn').hide()
            TextdetailLi.find('.check-icon').addClass('editImg')
            TextdetailLi.find('.originalInfo').hide()
        }else if(e.target.className.indexOf('cancel') != '-1'){
            //点击取消
            TextdetailLi.find('.originalInfo').show()
            TextdetailLi.find('.save_cancel_Btn').hide()
            TextdetailLi.find('.editBtn').show()
            TextdetailLi.find('.check-icon').removeClass('editImg')
        }else{
            if(showText){
                TextdetailLi.find('.a-section-expander-inner').removeClass('none')
                TextdetailLi.find('.a-icon-section-collapse').css({
                    'backgroundPosition':'-5px -82px'
                })
                TextdetailLi.find('.editBtn').show()
                showText = false;
            }else{
                TextdetailLi.find('.save_cancel_Btn').hide()
                TextdetailLi.find('.editBtn').hide()
                TextdetailLi.find('.a-section-expander-inner').addClass('none')
                TextdetailLi.find('.a-icon-section-collapse').css({
                    'backgroundPosition':'-5px -59px'
                })
                TextdetailLi.find('.editBtn').hide()
                showText = true;
            }
        }
        
    })

})