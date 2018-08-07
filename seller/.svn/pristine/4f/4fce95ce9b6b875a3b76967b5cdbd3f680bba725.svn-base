$(function () {
    var showText = true;
    var email = $('.email').text()
    $('.a-tabs li').click(function () {
        var index = $(this).index();
        $(".chooseText>li").eq(index).removeClass("none").siblings().addClass("none");
    })
    $('.title').each(function (index, item) {
        $('.title').eq(index).click(function (e) {
            var TextdetailLi = $('.title').eq(index)
            if (e.target.className.indexOf('edit') != '-1') {
                // 点击编辑
                TextdetailLi.find('.save_cancel_Btn').show()
                TextdetailLi.find('.editBtn').hide()
                TextdetailLi.parents('.parentNode').find('.check-icon').addClass('editImg')
                TextdetailLi.parents('.parentNode').find('.originalInfo').hide()

            } else if (e.target.className.indexOf('cancel') != '-1') {
                //点击取消
                TextdetailLi.parents('.parentNode').find('.originalInfo').show()
                TextdetailLi.find('.save_cancel_Btn').hide()
                TextdetailLi.find('.editBtn').show()
                TextdetailLi.parents('.parentNode').find('.check-icon').removeClass('editImg')
            }else if(e.target.className.indexOf('save') != '-1'){
                
            }else {
                if (showText) {
                    TextdetailLi.parents('.parentNode').find('.a-section-expander-inner').show()
                    TextdetailLi.find('.a-icon-section-collapse').css({
                        'backgroundPosition': '-5px -82px'
                    })
                    TextdetailLi.find('.editBtn').show()
                    showText = false;
                } else {
                    TextdetailLi.find('.save_cancel_Btn').hide()
                    TextdetailLi.find('.editBtn').hide()
                    TextdetailLi.parents('.parentNode').find('.a-section-expander-inner').hide()
                    TextdetailLi.find('.a-icon-section-collapse').css({
                        'backgroundPosition': '-5px -59px'
                    })
                    TextdetailLi.find('.editBtn').hide()
                    showText = true;
                }
            }

        })
    })
    // 通知首选项页面中编辑按钮
    function addInput(target) {
        let $addinputUl = target;
        let $addinputLi = $(`
            <li>
                <input type="email" class="box-sizing a-input-text onfocusInput a-row inputText" style="width: 82.948%;">
                <img src="./img/close.png" alt="" class="closeBtn" style="display: inline-block;">
                <br>
            </li>           
            `);
        $addinputUl.append($addinputLi)
    }
    // 编辑按钮出现input 
    $('.editBtn').each(function (index, item) {
        $('.editBtn').eq(index).click(function () {
            addInput($(this).parents('.parentNode').find('.addInput'))
            $('.editBtn').eq(index)
        })  
    })
    
    // 保存
    $('.saveBtn').each(function (index,item) { 
        $('.saveBtn').eq(index).click(function () { 
            console.log($('.addInput li input').val())
        })
    })
    
    
})