$(function(){
    var business_name = $('.business_name');
    var ask_inform_box = $('.ask_inform_box');
    var ask_why = $('.ask_why');
    var business_name_content = {
        quesition:'What is a Business Display Name?',
        content:'Your Business Display Name is displayed with your Amazon listings and on your Seller Profile. You can change this name any time by clicking on the "Account Info" in Seller Central Settings.'
    }
    var ask_why_content = {
        quesition:'Why do we ask for this?',
        content:"By providing a web address, you authorize Amazon to visit that site, and to use information and content from the site to help you create your listings and to better use Amazon's tools and services."
    }
    // 点击弹出提示框
    popover_click(business_name,ask_inform_box,business_name_content)
    popover_click(ask_why,ask_inform_box,ask_why_content)
    // Call / SMS
    var call_label = $('.pv_radioButtonCall label[for="call"]');
    var sms_label = $('.pv_radioButtonCall label[for="SMS"]');
    var call_down = $('.call_down');
    var SMS_down = $('.SMS_down');
    call_label.click(function() {
        call_down.removeClass('hide');
        SMS_down.addClass('hide');
    })
    sms_label.click(function() {
        call_down.addClass('hide');
        SMS_down.removeClass('hide');
    })
    // 国家号码操作
    var cuoutry_phone_select = $("#country-phone-input");
    cuoutry_phone_select.focus(function() {
        $(this).val('+86')
    })
    cuoutry_phone_select.blur(function() {
        console.log($(this).val())
    })
})