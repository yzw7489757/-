$(function(){
    inputctr.public.judgeBegaintask('1001');
    $('.cta-button').click(function(){
        inputctr.public.judgeRecodertask('1001','了解销售计划开始');
        inputctr.public.judgeFinishtask('1001',link);
    })
    function link(){
        if(!inputctr.public.getCookie('amazon_userid')){
            window.location.href='create_account.html'
        }else{
            window.location.href='login.html'
        }
    }
})