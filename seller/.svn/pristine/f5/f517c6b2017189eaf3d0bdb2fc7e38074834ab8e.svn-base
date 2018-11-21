$(function(){
    // 选择一种文档类型 效果
    inputctr.public.checkLogin();
    inputctr.public.judgeBegaintask('1008');
    var radio_button_cc_individual = $('#radio-button-cc--individual');
    var radio_button_bas_individual = $('#radio-button-bas--individual');
    var container_dnd_cc_individual = $('#container-dnd-cc--individual');
    var container_dnd_bas_individual = $('#container-dnd-bas--individual');
    radio_button_cc_individual.click(function(){
        if($(this).prop('checked')){
            container_dnd_cc_individual.show(150)
            container_dnd_bas_individual.hide(150)
        }
    })
    radio_button_bas_individual.click(function(){
        if($(this).prop('checked')){
            container_dnd_bas_individual.show(150)
            container_dnd_cc_individual.hide(150)
        }
    })
    // 邮箱验证
    var E_mail = $('#myq-application-form-email-input');
    E_mail.change(function(){
        if(!inputctr.public.isemail(E_mail.val())){
            E_mail.parent().siblings('#myq-required-email-address-error').removeClass('hidden');
        }else{
            E_mail.parent().siblings('#myq-required-email-address-error').addClass('hidden');
        }
    })
    // 提交所需资质文档
    inputctr.public.initImgUploader('#file-submit','/UploadFile',inputctr.addProductUploadfileQueued,inputctr.addProductUploaduploadSuccess,'#document-upload-container-dnd-individual',1);
    var submit_button = $(".button-text");
    var doc_file_path;
    // 请从下方选择一种文档类型
     $('input[type="radio"][name="radio-documents"]').change(function(){
        inputctr.public.initImgUploader('#cc--individual-button','/UploadFile',inputctr.addProductUploadfileQueued,inputctr.addProductUploaduploadSuccess,'#document-upload-container-dnd-cc--individual',1);
        inputctr.public.initImgUploader('#bas--individual-button','/UploadFile',inputctr.addProductUploadfileQueued,inputctr.addProductUploaduploadSuccess,'#document-upload-container-dnd-bas--individual',1);
    })
    // 提交资料
    submit_button.off('click').click(function(){ 
        inputctr.public.judgeRecodertask('1008','提交店铺开通审核资料开始');
        var error_message = $('#saw-module-incomplete-message');
        var user_country = $('.myq-option-list-div').find('.country').text();
        var user_type = $('.myq-option-list-div').find('input[type="radio"][name="individual_or_business"]:checked').attr('mold');
        var doc_type = $('input[type="radio"][name="radio-documents"]:checked').attr('mold');
        var file_submit = $('#file-list-dnd-ni--individual').attr('path');
        if(doc_type == '1'){
            doc_file_path = $('#file-list-dnd-cc--individual').attr('path');
        }else{
            doc_file_path = $('#file-list-dnd-bas--individual-table').attr('path');
        }
        if(!E_mail.val()){
            E_mail.parent().siblings('#myq-required-email-address-error').removeClass('hidden');
            return;
        }else{
            E_mail.parent().siblings('#myq-required-email-address-error').addClass('hidden');
        }
        if(!file_submit || !doc_file_path){
            $('html ,body').animate({scrollTop: 0}, 300);
            error_message.removeClass('hidden');
            return;
        }else{
            error_message.addClass('hidden');
        }
        inputctr.public.SellerRegisterLoading();
        var seller_identity_verification = {
            userid:amazon_userid,
            country:user_country,
            identity:user_type,
            identity_file:file_submit,
            doc_type:doc_type,
            doc_file:doc_file_path,    
            email:E_mail.val(),
            phone:$('#myq-application-form-phone-input').val()
        }
        if($(this).attr('id') == 'button-save-draft-category'){
            seller_identity_verification.sign = '1'
        }else{
            seller_identity_verification.sign = '2'
        }
        $.post(baseUrl+'/SellerIdentityVerification',seller_identity_verification, function(data){
            if(data){
                inputctr.public.SellerRegisterLoadingRemove();
            }
            if(data.result == 1){
                inputctr.public.judgeFinishtask('1008',link);
            }
        },'json')
    })
    function link(){
        window.location.href = 'home_page.html';
    }
})