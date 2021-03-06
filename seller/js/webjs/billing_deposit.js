$(function(){
    inputctr.public.selectCountry(function () {
        $(".address_country").val("中国");
        $(".bank_country").val("美国");
        $("select[name=country]").attr("disabled", "disabled");
    });
    inputctr.public.checkLogin();
    var drop_details = $('.drop_details');
    var subscriptions_fadeIn = $('.subscriptions_fadeIn');
    var new_address_enter = $('.new_address_enter');
    var ExistingAddress = $('#ExistingAddress');
    var date = new Date();
    var yy = date.getFullYear();
    var mm = date.getMonth()+1;
    var Today = yy;
    // 收款
    var Collect_Card = $('.Card_Number');
    var Cardholder_Name = $('.Cardholder_Name');
    var Card_Year = $('.yyDropdownSelect');
    var Card_Month = $('.ccDropdownSelect');
    // 存款
    var Holder_Name = $(".Holder_Name");
    var Routing_Number = $(".Routing_Number");
    var Bank_Number = $(".Bank_Number");
    var Re_type_Number = $(".Re-type_Number");
    for(var y=0;y<21;y++){
        Card_Year.append('<option value='+Today+'>'+Today+'</option>');
        Today++;
    }
    // 初始化
    var UpdateBill;
    var address_id;
    var addressid;
    var old_address_show = {
        address:'',
        city:'',
        province:'',
        country:'',
        zipcode:''
    }
    inputctr.public.SellerRegisterLoading();
    $.post(baseUrl+'/GetSellerRegister3',{userid:amazon_userid}, function(data){
        if(data){
            inputctr.public.SellerRegisterLoadingRemove();
            inputctr.public.judgeBegaintask('1005');
        }
        if(data.data.step < '3'){
           inputctr.public.RegisterStep(data.data.step)
        }
        if(data.result == 1){
            UpdateBill = 1;
            var billing = data.data;
            var charge = billing.charge;
            var AddressDetails = billing.address;
            var BankAccount = billing.deposit;
            addressid = AddressDetails.address_id;
            Collect_Card.val(charge.card_number);
            Cardholder_Name.val(decodeURIComponent(charge.card_holder_name));
            Card_Month.children('option[value='+charge.valid_through_month+']').prop("selected","selected");
            Card_Year.children('option[value='+charge.valid_through_year+']').prop("selected","selected");
            ExistingAddress.find('.old_message_label').children('.existing-address-width').text(decodeURIComponent(AddressDetails.address)+','+decodeURIComponent(AddressDetails.city)+','+decodeURIComponent(AddressDetails.province)+','+AddressDetails.zipcode+','+decodeURIComponent(AddressDetails.country))
            old_address_show = {
               address:decodeURIComponent(AddressDetails.address),
               city:decodeURIComponent(AddressDetails.city),
               province:decodeURIComponent(AddressDetails.province),
               country:decodeURIComponent(AddressDetails.country),
               zipcode:AddressDetails.zipcode 
            }
            $('.bank_country').children('option[value='+decodeURIComponent(BankAccount.bank_location)+']').prop("selected","selected");
            Holder_Name.val(decodeURIComponent(BankAccount.account_name));
            Routing_Number.val(BankAccount.routing_number);
            Bank_Number.val(BankAccount.account_number);
            Re_type_Number.val(BankAccount.account_number);
        }else{
            var billing = data.data;
            var AddressDetails = billing.address;
            ExistingAddress.find('.old_message_label').children('.existing-address-width').text(decodeURIComponent(AddressDetails.address)+','+decodeURIComponent(AddressDetails.city)+','+decodeURIComponent(AddressDetails.province)+','+AddressDetails.zipcode+','+decodeURIComponent(AddressDetails.country))
            old_address_show = {
               address:decodeURIComponent(AddressDetails.address),
               city:decodeURIComponent(AddressDetails.city),
               province:decodeURIComponent(AddressDetails.province),
               country:decodeURIComponent(AddressDetails.country),
               zipcode:AddressDetails.zipcode 
            }
            UpdateBill = 0;
            addressid = 0;
        }
    },'json')
    // 查看计划详情
    drop_details.click(function() {
        subscriptions_fadeIn.toggleClass('hide')
    })
    // 添加不同的账单地址
    ExistingAddress.find('.add_message_label').click(function() {
        new_address_enter.removeClass('hide')
    })
    ExistingAddress.find('.old_message_label').click(function() {
        new_address_enter.addClass('hide')
    })
    // 银行信息click提示框
    var ask_inform = $('.ask_inform');
    var ask_inform_box = $('.ask_inform_box');
    popover_click(ask_inform,ask_inform_box);
    // 存款方式hover提示框
    var tip_hover = $('.deposit .hover_tip');
    var popover = $('.popover');
    popover_hover(tip_hover,popover);
    
    // 表单验证
    var regNum = /^\d{13,19}$/;
    var regRout = /^\d{9}$/;
    $('.card').change(function() {
        if(!$(this).val()){
            $(this).addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
        }else{
            if($(this).hasClass('Card_Number') || $(this).hasClass('Bank_Number')){
                if(!regNum.test($(this).val())){
                    $(this).addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
                }else{
                    $(this).removeClass('red_warning').siblings('.a-alert-inline-error').addClass('hide');
                }
            }else if($(this).hasClass('Routing_Number')){
                if(!regRout.test($(this).val())){
                    $(this).addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
                }else{
                    $(this).removeClass('red_warning').siblings('.a-alert-inline-error').addClass('hide');
                }
            }else{
                $(this).removeClass('red_warning').siblings('.a-alert-inline-error').addClass('hide');
            }
        }
    })
    // 添加不同的账单地址验证
    $(".address-textbox").change(function(){
        if(!$(this).val()){
            $(this).addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
        }else{
            if($(this).hasClass('Postal_code')){
                if(!inputctr.public.ispostcode($(this).val())){
                     $(this).addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
                 }else{
                    $(this).removeClass('red_warning').siblings('.a-alert-inline-error').addClass('hide');
                 }
            }else{
                $(this).removeClass('red_warning').siblings('.a-alert-inline-error').addClass('hide');
            }
        }
    })
    // 重新输入银行账号验证
    Re_type_Number.change(function() {
        if(Bank_Number.val()){
            if($(this).val() != Bank_Number.val()){
                $(this).siblings('.a-alert-inline-error').removeClass('hide').find('.a-alert-content').text('请输入相同的账号！');
            }else{
                $(this).siblings('.a-alert-inline-error').addClass('hide').find('.a-alert-content').text('必填字段！')
            }
        }
    })
    // 有效期验证
    Card_Month.change(function() {
        if(Card_Year.val() == yy){
            if($(this).val() < mm){
                $(this).parents(".b-span5").siblings('.a-alert-inline-error').removeClass('hide')
            }else{
                $(this).parents(".b-span5").siblings('.a-alert-inline-error').addClass('hide')
            }
        }else{
            $(this).parents(".b-span5").siblings('.a-alert-inline-error').addClass('hide')
        }
    })
    Card_Year.change(function(){
        if($(this).val() > yy){
            $(this).parents(".ws-span6").siblings('.a-alert-inline-error').addClass('hide');
        }
        if($(this).val() == yy){
            if(Card_Month.val() < mm){
                $(this).parents(".ws-span6").siblings('.a-alert-inline-error').removeClass('hide')
            }
        }
    })
    // 提交验证
    var deposit_next = $(".deposit_next");
    var Card_Year_flag = false;
    var card_flag = false;
    var Address_flag = false;
    deposit_next.click(function(){
        var card = $('.card').filter(function(index) {
            return $(this).val() == '';
        })
        if(Card_Year.val() == yy){
            if(Card_Month.val() < mm){
                Card_Year_flag = true;
                Card_Month.parents(".b-span5").siblings('.a-alert-inline-error').removeClass('hide');
            }else{
                Card_Year_flag = false;
                Card_Month.parents(".b-span5").siblings('.a-alert-inline-error').addClass('hide')
            }
        }
        if(card.length){
            card_flag = true;
            card.addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
        }else{
            card_flag = false;
        }
        var add_message = $("#add_message");
        if(add_message.is(':checked')){
            var AddressChange = 0;
            var address_box = $(".address-textbox").filter(function(index) {
                return $(this).val() == '';
            })
            if(address_box.length){
                Address_flag = true;
                address_box.addClass('red_warning').siblings('.a-alert-inline-error').removeClass('hide');
            }else{
                Address_flag = false;
            }
            if(Card_Year_flag || card_flag || Address_flag){
                return;
            }  
        }else{
            AddressChange = 1;
            if(Card_Year_flag || card_flag){
                return;
            }  
        }
        if(Re_type_Number.val()){
            if(Re_type_Number.val() != Bank_Number.val()){
                Re_type_Number.siblings('.a-alert-inline-error').removeClass('hide');
                return;
            }else{
                Re_type_Number.siblings('.a-alert-inline-error').addClass('hide');
            }
        }
        inputctr.public.judgeRecodertask('1005','提供付款和收款账户信息开始');
        inputctr.public.SellerRegisterLoading();
        if(AddressChange == 0){
            var Bill_deposit = {
                userid:amazon_userid,
                card_number:Collect_Card.val(),
                card_month:Card_Month.val(),
                card_year:Card_Year.val(),
                card_holder:Cardholder_Name.val(),
                addressid:addressid,
                address:$('.Street_address').val(),
                city:$('.City_Town').val(),
                province:$('.Province').val(),
                country:$('.address_country').val(),
                zipcode:$('.Postal_code').val(),
                bank_location:$('.bank_country').val(),
                account_holder:Holder_Name.val(),
                routing_number:Routing_Number.val(),
                account_number:Bank_Number.val(),
                id:UpdateBill
            }    
        }else{
           var Bill_deposit = {
               userid:amazon_userid,
               card_number:Collect_Card.val(),
               card_month:Card_Month.val(),
               card_year:Card_Year.val(),
               card_holder:Cardholder_Name.val(),
               addressid:addressid,
               address:old_address_show.address,
               city:old_address_show.city,
               province:old_address_show.province,
               country:old_address_show.country,
               zipcode:old_address_show.zipcode,
               bank_location:$('.bank_country').val(),
               account_holder:Holder_Name.val(),
               routing_number:Routing_Number.val(),
               account_number:Bank_Number.val(),
               id:UpdateBill
           }     
        }
        $.post(baseUrl+'/SellerRegister3',Bill_deposit, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                inputctr.public.judgeFinishtask('1005',link);
               
            }else{
                alert(decodeURIComponent(data.error)) 
            }
        },'json')
    })
    function link(){
        window.location.href='tax_information.html';
    }
})