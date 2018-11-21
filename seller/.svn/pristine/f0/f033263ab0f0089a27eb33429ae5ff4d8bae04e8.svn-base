$(function(){
    var Refund_button = $('.Refund-button');
    var list_row_refund = $('li.list-row-refund');
    Refund_button.click(function() {
        if($(this).hasClass('active')){
            return;
        }
       $(this).addClass('active').siblings('.Refund-button').removeClass('active');
       list_row_refund.eq($(this).index()).removeClass('hide').siblings('.list-row-refund').addClass('hide');
    })
})