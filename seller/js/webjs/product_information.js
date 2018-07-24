$(function(){
    inputctr.public.checkLogin();
    var pruduct_question_select = $('.billing').find('.select_answer').children('input[type="radio"]');
    var billing_length = $('.billing').children('div.a-section').length;
    var product_next = $(".product_next");
    var product_information = {
        is_product_upc:"",
        is_product_brand:"",
        product_list:""
    }
    // 初始化
    inputctr.public.SellerRegisterLoading();
    $.post(baseUrl+'/GetSellerRegister5',{userid:amazon_userid}, function(data){
        if(data){
            inputctr.public.SellerRegisterLoadingRemove();
            inputctr.public.judgeBegaintask('1007');
        }
        if(data.step != '4'){
            inputctr.public.RegisterStep(data.step)
        }
    },'json')
    product_next.click(function(){
        // 筛选 选中的input
        inputctr.public.judgeRecodertask('1007','提供店铺销售产品信息开始');
        var pruduct_question_checked = pruduct_question_select.filter(function(index) {
                return $(this).is(':checked');
            })
        if(pruduct_question_checked.length < billing_length){
            $('.billing').siblings('.a-alert-inline-error').removeClass('hide');
            return;
        }else{
            $('.billing').siblings('.a-alert-inline-error').addClass('hide');
        }
        inputctr.public.SellerRegisterLoading();
        var answer = [];
        for(var i=0;i<pruduct_question_checked.length;i++){
            answer.push($(pruduct_question_checked[i]).attr('choice'))
        }
        var j=0;
        for(var i in product_information){
            product_information[i] = answer[j];
            j++;
        }
        product_information.userid = amazon_userid;
        // 提交问题答案 验证
        $.post(baseUrl+'/SellerRegister5',product_information, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                inputctr.public.judgeFinishtask('1007',link);
                
            }else{
                alert(decodeURIComponent(data.error)) 
            }
        },'json')
    })
    function link(){
        window.location.href='product_category.html'
    }
})