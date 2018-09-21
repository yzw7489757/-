$(function(){
    inputctr.public.checkLogin();
    var verity_phone = $('#verity-phone');
    var send_code_sms = $('#send-code-sms');
    var verify_phone_code_input = $('#verify-phone-code-input');
    var verify_phone_submit_button = $('#verify-phone-submit-button');
    function isChinaphone(num){
        var reNum = /^1[3|4|5|7|8][0-9]{9}$/
        return(reNum.test(num))
    }
    inputctr.public.judgeBegaintask('1105');
    var send_flag1 = true;
    var send_flag2 = true;
    send_code_sms.click(function(){
        if(!isChinaphone(verity_phone.val())){
            $(this).siblings('.error-alert').removeClass('hide');
            return;
        }else{
            if(!send_flag1){
                return;
            }
            send_flag1 = false;
            $(this).siblings('.error-alert').addClass('hide').siblings('.loading-img').removeClass('hide');
            $.post(baseUrl+'/SMSSend', {type:1, mobile:verity_phone.val().trim()}, function(data) {
                if(data){
                    send_flag1 = true;
                }
                if(data.result == 1){
                    send_code_sms.siblings('.loading-img').addClass('hide');
                    verify_phone_code_input.val(data.vcode);
                    verify_phone_submit_button.prop('disabled',false);
                }else{
                    send_code_sms.siblings('.loading-img').addClass('hide');
                    verify_phone_submit_button.prop('disabled',true);
                    alert(decodeURIComponent(data.error));
                }
            },'json')  
        }
    })
    verify_phone_submit_button.click(function(){
        if(verify_phone_code_input.val().trim().length < 6){
            $(this).siblings('.error-alert').removeClass('hide');
            return;
        }else{
            if(!send_flag2){
                return;
            }
            inputctr.public.judgeRecodertask('1105','开通账户两步验证设置增强账户安全性开始');
            send_flag2 = false;
            $(this).siblings('.error-alert').addClass('hide').siblings('.loading-img').removeClass('hide');
            $.post(baseUrl+'/SMSVerify', {type:1, mobile:verity_phone.val().trim(), vcode:verify_phone_code_input.val()}, function(data) {
                if(data){
                    send_flag2 = true;
                }
                if(data.result == 1){
                    inputctr.public.judgeFinishtask('1105',veritySuccess);
                }else{
                    verify_phone_submit_button.siblings('.loading-img').addClass('hide').siblings('.verity-error-alert').removeClass('hide').children('span').text(decodeURIComponent(data.error));
                }
            },'json')  
        }
    })
    function veritySuccess(){
        verify_phone_submit_button.siblings('.loading-img').addClass('hide').siblings('.verity-error-alert').addClass('hide');
        window.location.href = 'landing_settings.html';
    }
})