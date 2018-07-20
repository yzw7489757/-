$(function(){
    var options = {
        id: 'auth-captcha-image-container',
        type: "number"
    }
    var getCode = inputctr.public.verifyCode(options);
    $('#auth-captcha-refresh-link').click(function(){
        getCode.refresh()
    })
    var code_submit = $("#continue");
    var send_flag = false;
    code_submit.click(function(){
        var email = $("#ap_email").val();
        var password_missing_alert = $("#auth-password-missing-alert");
        var guess_missing_alert = $("#auth-guess-missing-alert");
        var res = getCode.validate($("#auth-captcha-guess").val());
        if(!email){
            password_missing_alert.removeClass('auth-inlined-error-message');
            return;
        }else if(!inputctr.public.isemail(email) && !inputctr.public.ismobile(email)){
            password_missing_alert.removeClass('auth-inlined-error-message');
            return;
        }else{
            password_missing_alert.addClass('auth-inlined-error-message');
        }
        if(!res){
            guess_missing_alert.removeClass('auth-inlined-error-message');
            return;
        }else{
            guess_missing_alert.addClass('auth-inlined-error-message');
        }
        inputctr.public.SellerRegisterLoading();
        var sellerMessage = {
            account:email,
            stuid:inputctr.public.getCookie('studentID'),
            trainingmode:inputctr.public.getCookie('traintype')
        }
        if(send_flag){
            return;
        }
        send_flag = true;
        $.post(baseUrl+'/SellerForgotPassword1', sellerMessage, function(data){
            if(data){
                send_flag = false; 
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                $("#auth-error-message-box").addClass('hide');
                window.location.href='check_eamil.html'
            }else{
                $("#auth-error-message-box").removeClass('hide').find("span.a-list-item").text(decodeURIComponent(data.error));
            }
        },'json')
    })
})