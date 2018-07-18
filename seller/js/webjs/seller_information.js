$(function () {
    inputctr.public.selectCountry();
    inputctr.public.selectLang();
    var business_name = $('.business_name');
    var ask_inform_box = $('.ask_inform_box');
    var ask_why = $('.ask_why');
    var business_name_content = {
        quesition: business_name.attr("quesition"),
        content: business_name.attr("content")
    }
    var ask_why_content = {
        quesition: ask_why.attr("quesition"),
        content: ask_why.attr("content")
    }
    // 点击弹出提示框
    popover_click(business_name, ask_inform_box, business_name_content)
    popover_click(ask_why, ask_inform_box, ask_why_content)
    // Call / SMS
    var call_label = $('.pv_radioButtonCall label[for="call"]');
    var sms_label = $('.pv_radioButtonCall label[for="SMS"]');
    var call_down = $('.call_down');
    var SMS_down = $('.SMS_down');
    call_label.click(function () {
        call_down.removeClass('hide');
        SMS_down.addClass('hide');
    })
    sms_label.click(function () {
        call_down.addClass('hide');
        SMS_down.removeClass('hide');
    })
    // 国家号码操作
    var country_phone_select = $("#country-phone-input");
    var verify_now = $("#verify_now");
    country_phone_select.focus(function () {
        if(!$(this).val()){
            $(this).val('+86')
        }
    })
    country_phone_select.blur(function(){
        if(!inputctr.public.isChinaphone($(this).val().trim())){
            $(this).addClass('red_warning').parents('.ws-span6').siblings('.a-alert-inline-error').removeClass('hide');
            verify_now.attr('disabled',true);
        }else{
            $(this).removeClass('red_warning').parents('.ws-span6').siblings('.a-alert-inline-error').addClass('hide');
            verify_now.attr('disabled',false);
        }
    })
    // 图形验证码
    var options = {
        id: 'seller-image-container',
        type: "number"
    }
    var getCode = inputctr.public.verifyCode(options);
    //页面信息
    var business_submit = $("#a-autoid-2-announce");
    var address_textbox = $(".address-textbox");
    //页面信息验证
    $(".address-textbox").change(function() { 
        if(!$(this).val()){
            if($(this).hasClass('store_name')){
                $(this).addClass('red_warning').attr('verify','false').parent().siblings('.a-alert-inline-error').removeClass('hide').find('.fail').removeClass('hide');
                $(this).parent().siblings('.a-alert-inline-error').find('.success').addClass('hide');
            }
            $(this).addClass('red_warning').attr('verify','false').siblings('.a-alert-inline-error').removeClass('hide')
        }else{
            if($(this).hasClass('address-zip')){
                if(!inputctr.public.ispostcode($(this).val().trim())){
                    $(this).addClass('red_warning').attr('verify','false').siblings('.a-alert-inline-error').removeClass('hide')
                }else{
                    $(this).removeClass('red_warning').attr('verify','true').siblings('.a-alert-inline-error').addClass('hide');
                }
            }else{
                if($(this).hasClass('store_name')){
                    return;
                }
                $(this).removeClass('red_warning').attr('verify','true').siblings('.a-alert-inline-error').addClass('hide');
            }
        }
    })
    // 验证唯一的公司显示名称
    var send_name = false;
    var store_name = $("#store_name");
    store_name.change(function(){
        if(!$(this).val()){
            return;
        }
        if(send_name){
            return;
        }
        send_name = true;
        var shopName = $(this).val().trim();
        var that = $(this);
        $.post(baseUrl+'/GetShopName',{shopname:shopName}, function(data){
            if(data){
                send_name = false; 
            }
            if(data.result == 1){
                that.removeClass('red_warning').attr('verify','true').parent().siblings('.a-alert-inline-error').removeClass('hide').find('.success').removeClass('hide').find('.a-alert-content').text(decodeURIComponent(data.error));
                that.parent().siblings('.a-alert-inline-error').find('.fail').addClass('hide');
            }else{
                that.addClass('red_warning').attr('verify','false').parent().siblings('.a-alert-inline-error').removeClass('hide').find('.fail').removeClass('hide').find('.a-alert-content').text(decodeURIComponent(data.error));
                that.parent().siblings('.a-alert-inline-error').find('.success').addClass('hide');
            }
        },'json')
    })
    // 手机验证码
    verify_now.click(function(){
        inputctr.public.SellerRegisterLoading();
        var ValidPhone = {
            type:'1',
            mobile:country_phone_select.val().trim()
        }
        $.post(baseUrl+'/SMSSend',ValidPhone, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                var code_overlay = $(".code_overlay");
                code_overlay.removeClass('hide');
                $(".cancle_code_screen").click(function(){
                    code_overlay.addClass('hide');
                })
                code_overlay.find("#pin_enter").val(data.vcode);
                var verifyOTPButton = code_overlay.find("#verifyOTPButton");
                verifyOTPButton.off('click').click(function(event){
                    event.stopPropagation();
                    if(!code_overlay.find("#pin_enter").val()){
                        return;
                    }
                    code_overlay.addClass('hide');
                    inputctr.public.SellerRegisterLoading();
                    var verifyCoed = {
                        type:ValidPhone.type,
                        mobile:country_phone_select.val().trim(),
                        vcode:code_overlay.find("#pin_enter").val()
                    }
                    $.post(baseUrl+'/SMSVerify',verifyCoed, function(verify){
                        if(verify){
                            inputctr.public.SellerRegisterLoadingRemove();
                        }
                        if(verify.result == 1){
                            verify_now.addClass('hide')
                            $('.a-verify-inline').addClass('a-alert-verify-success').removeClass('hide').find('.a-alert-content').text(decodeURIComponent(verify.error));
                            $("#a-autoid-2-announce").attr('disabled',false);
                        }else{
                           $('.a-verify-inline').addClass('a-alert-verify-error').removeClass('hide').find('.a-alert-content').text(decodeURIComponent(verify.error)); 
                        }
                    },'json')
                })
            }else{
                alert(decodeURIComponent(data.error));
            }
        },'json')
    })
    
    business_submit.click(function(){
        var address_true = $(".address-textbox").filter(function(index) {
            return $(this).attr('verify') != 'true';
        })
        if(address_true.length){
            address_true.addClass('red_warning');
            return;
        }
        inputctr.public.SellerRegisterLoading();
        var address_street = $('.address-street').val().trim();
        var address_city = $('.address-city').val().trim();
        var address_state = $('.address-state').val().trim();
        var address_country = $('.address-dropdown-select[name="country"]').val();
        var address_zip = $('.address-zip').val().trim();
        var business_name = store_name.val().trim();
        var websiteUrl = $('.websiteurl-textbox[name="websiteUrl"]').val().trim();
        var cuoutry_phone = country_phone_select.val().trim();
        var seller_information = {
            userid:inputctr.public.getCookie('login_state'),
            address:address_street,
            city:address_city,
            province:address_state,
            country:address_country,
            zipcode:address_zip,
            storename:business_name,
            website:websiteUrl,
            mobile:cuoutry_phone
        }
        $.post(baseUrl+'/SellerRegister2',seller_information, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                window.location.href='billing_deposit.html';
            }else{
                alert(decodeURIComponent(data.error))
            }
        },'json')
    })
})