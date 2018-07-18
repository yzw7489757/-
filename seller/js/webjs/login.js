$(function () {
    // 验证是否保持登录状态
    if(inputctr.public.getCookie('login_state')){
        $('#ap_email').val(Base64.decode(inputctr.public.getCookie('user_email')));
        $('#ap_password').val(Base64.decode(inputctr.public.getCookie('pwd')));
        $('input[type="checkbox"][name="rememberMe"]').prop("checked",true);
    }else{
        $('#ap_password').val("");
        $('input[type="checkbox"][name="rememberMe"]').prop("checked",false);
    }
    var signInSubmit = $('#signInSubmit');
    var send_flag = false;
    function resgister_step(step){
        switch (step){
            case '1': window.location.href='seller_agreement.html';
              break;
            case '2': window.location.href='seller_information.html';
              break;
            case '3': window.location.href='billing_deposit.html';
              break;
            case '4': window.location.href='tax_information.html';
              break;
            case '5': window.location.href='product_information.html';
              break;
        }
    }
    // 提交登录信息
    signInSubmit.click(function () {
        if(send_flag){
            return;
        }
        send_flag = true;
        var ap_email = $('#ap_email');
        var ap_password = $('#ap_password');
        var email_missing_alert = $('#auth-email-missing-alert');
        var password_missing_alert = $('#auth-password-missing-alert');
        if(!ap_email.val()){
            email_missing_alert.removeClass('auth-inlined-error-message');
            return;
        }else if (!inputctr.public.isemail(ap_email.val()) && !inputctr.public.ismobile(ap_email.val())) {
            email_missing_alert.removeClass('auth-inlined-error-message');
            return;
        } else {
            email_missing_alert.addClass('auth-inlined-error-message')
        }
        if (!ap_password.val() || ap_password.val().length<6) {
            password_missing_alert.removeClass('auth-inlined-error-message');
            return;
        } else {
            password_missing_alert.addClass('auth-inlined-error-message')
        }
        inputctr.public.SellerRegisterLoading();
        var sellerMessage = {
            account:ap_email.val(),
            pwd:ap_password.val(),
            stu_account:inputctr.public.getCookie('account'),
            trainingmode:inputctr.public.getCookie('traintype'),
            stuid:inputctr.public.getCookie('studentID'),
        }
        $.post(baseUrl+'/SellerLogin', sellerMessage, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
                send_flag = false; 
            }
            if(data.result == 1){
                $("#auth-error-message-box").addClass('hide');
                if($('input[type="checkbox"][name="rememberMe"]').prop("checked")){
                    inputctr.public.setCookie('login_state',data.userid,7);
                    inputctr.public.setCookie('user_email',Base64.encode(sellerMessage.account),7);
                    inputctr.public.setCookie('pwd',Base64.encode(sellerMessage.pwd),7);
                }else{
                    inputctr.public.clearCookie('login_state');
                    inputctr.public.clearCookie('user_email');
                    inputctr.public.clearCookie('pwd');
                }
                resgister_step(data.step); 
            }else{
                $("#auth-error-message-box").removeClass('hide').find("span.a-list-item").text(decodeURIComponent(data.error));
            }
        },'json')
    })
})