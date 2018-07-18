$(function(){
    var register = $("#continue");
    var send_flag = false;
    register.click(function(){
        var name = $("#ap_customer_name").val();
        var email = $("#ap_email").val();
        var password = $("#ap_password").val();
        var sure_password = $("#ap_password_check").val();
        var stuid = inputctr.public.getCookie('studentID');
        var trainingmode = inputctr.public.getCookie('traintype');
        var stuaccount = inputctr.public.getCookie('account');
        var language = inputctr.public.getCookie('lang');
        if(!name){
            $("#auth-customerName-missing-alert").removeClass('auth-inlined-error-message');
            return;
        }else{
            $("#auth-customerName-missing-alert").addClass('auth-inlined-error-message');
        }
        if(!inputctr.public.isemail(email)){
            $("#auth-email-missing-alert").removeClass('auth-inlined-error-message');
            return;
        }else{
            $("#auth-email-missing-alert").addClass('auth-inlined-error-message');
        }
        if(password.length < 6){
            $("#ap_password").siblings('.a-alert-inline-info').find('.a-alert-content').css({color: '#c40000'})
            return;
        }else{
            $("#ap_password").siblings('.a-alert-inline-info').find('.a-alert-content').css({color: '#2b2b2b'})
        }
        if(sure_password != password){
            $("#auth-passwordCheck-missing-alert").removeClass('auth-inlined-error-message');
            return; 
        }else{
            $("#auth-passwordCheck-missing-alert").addClass('auth-inlined-error-message');
        }
        var sellerMessage = {
            name:name,
            email:email,
            pwd:password,
            stuid:stuid,
            stuaccount:stuaccount,
            trainingmode:trainingmode
        }
        if(send_flag){
            return;
        }
        send_flag = true;
        $.post(baseUrl+'/SellerRegister', sellerMessage, function(data) {
            if(data){
               send_flag = false; 
            }
            if(data.result == 1){
                $("#auth-error-message-box").addClass('hide');
                inputctr.public.setCookie('token',data.token);
                window.location.href='seller_agreement.html';
            }else{
                $("#auth-error-message-box").removeClass('hide').find("span.a-list-item").text(decodeURIComponent(data.error));
            }
        },'json')  
    })
})