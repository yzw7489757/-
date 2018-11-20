$(function(){
    inputctr.public.checkLogin();
    var promotionID = inputctr.public.getQueryString('manage');
    $('#view-promotion').click(function(){
        window.location.href = 'view_promotion.html?view='+promotionID;
    })
    var Create_group = $('#Create-group');
    var Group_Name = $('#Group-Name');
    var Group_Quantity = $('#Group-Quantity');
    var claim_code_table = $('.claim-code-table');
    var num_group = $('.num_group');
    // Create claim code group
    Create_group.click(function() {
        if(Group_Name.val().trim() == ''){
            Group_Name.addClass('error-border');
        }else{
            Group_Name.removeClass('error-border');
        }
        if(Group_Quantity.val().trim() == '' || Group_Quantity.val().trim()>20){
            Group_Quantity.addClass('error-border');
        }else{
            Group_Quantity.removeClass('error-border');
        }
        if($('.error-border').length){
            return;
        }else{
            inputctr.public.SellerRegisterLoading();
            var CreateClaimData = {
                seller_id:amazon_userid,
                promotion_id:promotionID,
                quantity:Group_Quantity.val().trim(),
                name:Group_Name.val().trim()
            }
            inputctr.public.AjaxMethods('POST', baseUrl + '/CreateClaim', {json:JSON.stringify(CreateClaimData)}, function (data) {
                if(data.result == 1) {
                    var val = data.data;
                    var code_html = '<tr>'+
                                        '<td>'+val.name+'</td>'+
                                        '<td>'+val.quantity+'</td>'+
                                        '<td>'+val.creation_date+'</td>'+
                                        '<td>'+val.requested_by+'</td>'+
                                        '<td>'+val.status_name+'</td>'+
                                        '<td><a href="javascript:;" class="download a-link-normal" id='+val.group_id+'>Download</a></td>'+
                                    '</tr>'
                    claim_code_table.find('tbody').append(code_html);
                    num_group.children().text(claim_code_table.find('tbody').children('tr').length+' claim code group'); 
                }else{
                    alert(data.error);
                }
                inputctr.public.SellerRegisterLoadingRemove();
            }, function (error) {
                alert(error.statusText);
            })
        }
    })
    // Show claim code group
    var CodeGroupData = {
        promotion_id:promotionID,
        orderBy:'date_asc'
    }
    function CodeGroup(data){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('GET', baseUrl + '/ClaimList', {json:JSON.stringify(data)}, function (data) {
            var code_html = '';
            if(data.result == 1) {
                var val = data.data;
                num_group.children().text(val.length+' claim code group'); 
                for(var i=0;i<val.length;i++){
                    code_html += '<tr>'+
                                    '<td>'+val[i].name+'</td>'+
                                    '<td>'+val[i].quantity+'</td>'+
                                    '<td>'+val[i].creation_date+'</td>'+
                                    '<td>'+val[i].requested_by+'</td>'+
                                    '<td>'+val[i].status_name+'</td>'+
                                    '<td><a href="javascript:;" class="download a-link-normal" id='+val[i].group_id+'>Download</a></td>'+
                                '</tr>'
                }
                claim_code_table.find('tbody').html(code_html)
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            inputctr.public.SellerRegisterLoadingRemove();
            alert(error.statusText);
        })
    }CodeGroup(CodeGroupData)
    // Download claim code group
    var downloadFlag = true;
    claim_code_table.find('tbody').on('click','.download',function(){
        if(!downloadFlag){
            return;
        }
        var downloadData = {
            group_id:this.id
        }
        downloadFlag = false;
        inputctr.public.AjaxMethods('POST', baseUrl + '/ClaimCodeDown', {json:JSON.stringify(downloadData)}, function (data) {
            downloadFlag = true;
            if(data.result == 1) {
                location.href=data.file;
            }else{
                alert(data.error);
            }
        }, function (error) {
            alert(error.statusText);
        })
    })
    // Creation Date 排序
    claim_code_table.find('thead').on('click','.mt-sort-down',function(){
        $(this).toggleClass('desc');
        if($(this).hasClass('desc')){
            CodeGroupData.orderBy = 'date_desc';
            $(this).find('.desc-icon-down').addClass('desc-icon-up');
        }else{
            CodeGroupData.orderBy = 'date_asc';
            $(this).find('.desc-icon-down').removeClass('desc-icon-up');
        }
        CodeGroup(CodeGroupData);
    })
})