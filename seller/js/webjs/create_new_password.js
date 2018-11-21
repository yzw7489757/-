$(function(){
    var save_changes = $('#save_changes');
    var send_flag = false;
    save_changes.click(function(){
        var new_password = $("#ap_fpp_password").val();
        var sure_password = $('#ap_fpp_password_check').val();
        if(!new_password || new_password.length<6){
            $("#ap_fpp_password").siblings('.a-alert-inline-info').find('.a-alert-content').css({color: '#c40000'});
            return;
        }else{
            $("#ap_fpp_password").siblings('.a-alert-inline-info').find('.a-alert-content').css({color: '#2b2b2b'})
        }
        if(!sure_password){
            $('#auth-passwordCheck-missing-alert').removeClass('auth-inlined-error-message');
            return;
        }else{
            $('#auth-passwordCheck-missing-alert').addClass('auth-inlined-error-message');
        }
        if(sure_password!=new_password){
            $('#auth-password-mismatch-alert').removeClass('auth-inlined-error-message');
            return;
        }else{
            $('#auth-password-mismatch-alert').addClass('auth-inlined-error-message');
        }
        inputctr.public.SellerRegisterLoading();
        var token = inputctr.public.getQueryString('token');
        var change_password = {
            pwd:new_password,
            token:token
        }
        if(send_flag){
            return;
        }
        send_flag = true;
        $.post(baseUrl+'/SellerForgotPassword2',change_password, function(data) {
            if(data){
                send_flag = false; 
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                window.location.href='login.html'
            }else{
                alert(decodeURIComponent(data.error))
            }
        },'json')
    })
})