$(function(){
    inputctr.public.checkLogin();
    var pruduct_question_select = $('.billing').find('.select_answer').children('input[type="radio"]');
    var product_next = $(".product_next");
    var product_information = {
        is_product_upc:"",
        is_product_brand:"",
        product_list:""
    }
    var send_flag = false;
    product_next.click(function(){
        if(send_flag){
            return;
        }
        send_flag = true;
        // 筛选 选中的input
        var pruduct_question_checked = pruduct_question_select.filter(function(index) {
                return $(this).is(':checked');
            })
        if(!pruduct_question_checked.length){
            $('.billing').siblings('.a-alert-inline-error').removeClass('hide');
            return;
        }else{
            $('.billing').siblings('.a-alert-inline-error').addClass('hide');
        }
        inputctr.public.SellerRegisterLoading();
        //product_information 赋值
        var answer = [];
        for(var i=0;i<pruduct_question_checked.length;i++){
            answer.push($(pruduct_question_checked[i]).attr('choice'))
        }
        var j=0;
        for(var i in product_information){
            product_information[i] = answer[j];
            j++;
        }
        product_information.userid = userid;
        // 提交问题答案 验证
        $.post(baseUrl+'/SellerRegister5',product_information, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
                send_flag = false;
            }
            if(data.result == 1){
                window.location.href='product_category.html'
            }else{
                alert(decodeURIComponent(data.error)) 
            }
        },'json')
    })
})