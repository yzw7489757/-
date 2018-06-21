$(function(){
    var drop_details = $('.drop_details');
    var subscriptions_fadeIn = $('.subscriptions_fadeIn');
    var new_address_enter = $('.new_address_enter');
    var ExistingAddress = $('#ExistingAddress');
    drop_details.click(function() {
        subscriptions_fadeIn.toggleClass('hide')
    })
    ExistingAddress.find('.add_message_label').click(function() {
        new_address_enter.removeClass('hide')
    })
    ExistingAddress.find('.old_message_label').click(function() {
        new_address_enter.addClass('hide')
    })
    var ask_inform = $('.ask_inform');
    var ask_inform_box = $('.ask_inform_box');
    var answer_content = {
        quesition:'Why do we ask for your bank information?',
        content:'We need a valid bank account to disburse your Amazon sales proceeds. Make sure you enter banking information accurately. Editing this information later can result in delayed payments while we review the account for your security.'
    }
    popover_click(ask_inform,ask_inform_box,answer_content);

    var tip_hover = $('.deposit .hover_tip');
    var popover = $('.popover');
    var deposit_method = {
        Name:'Account Holder Name must match the name on your bank account. Do not include the name of your bank. Example: John Doe or Company XYZ. Match what your bank has on file using ISO basic Latin characters. This information must be accurate in order to receive your payments.',
        Routing:'(Federal ABA Number) Provide a routing number for Automated Clearing House (ACH) or electronic funds transfers instead of wire transfers. Please contact your bank for assistance.',
        Number:'Your account must be enabled to receive deposits through the Automated Clearing House (ACH). Please contact your bank for assistance. (Up to 17 digits)'
    }
    popover_hover(tip_hover,popover,deposit_method)
})