$(function(){
    inputctr.public.checkLogin();
    inputctr.public.SellerRegisterLoading();
    $.post(baseUrl+'/GetSellerRegister4',{userid:amazon_userid}, function(data){
        if(data){
            inputctr.public.SellerRegisterLoadingRemove();
            inputctr.public.judgeBegaintask('1006');
        }
        if(data.step < '4'){
           inputctr.public.RegisterStep(data.step)
        }
    },'json')
})