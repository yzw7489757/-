$(function(){
    inputctr.public.checkLogin();
    var checkbox = $('input.valid_checkbox');
    var button_submit = $('button.button-submit');
    var legal_name = $("#ln_legal_name");
    // 初始化
    inputctr.public.SellerRegisterLoading();
    $.post(baseUrl+'/GetSellerRegister1',{userid:userid}, function(data){
        if(data){
            inputctr.public.SellerRegisterLoadingRemove();
        }
        if(data.result == 1){
            legal_name.val(data.legal_name)
        }else{
            console.log(decodeURIComponent(data.error))
        }
    },'json')
    
    checkbox.click(function() {
        var legal_name_val = legal_name.val();
        if($(this).prop('checked')&&legal_name_val){
            button_submit.prop('disabled',false)
        }else{
            button_submit.prop('disabled',true)
        }
    })
    legal_name.change(function() {
       if(checkbox.prop('checked') && $(this).val()){
            button_submit.prop('disabled',false)
        }else{
            button_submit.prop('disabled',true)
        }
    })
    var send_flag = false;
    button_submit.click(function(){
        inputctr.public.SellerRegisterLoading();
        if(send_flag){
            return;
        }
        send_flag = true;
        var legal_inform = {
            userid:userid,
            legalname:legal_name.val().trim()
        }
        $.post(baseUrl+'/SellerRegister1',legal_inform, function(data){
            if(data){
                send_flag = false;
                 inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                window.location.href='seller_information.html'
            }else{
                alert(decodeURIComponent(data.error))
            }
        },'json')
    })
})