$(function(){
    inputctr.public.checkLogin();
    var editID = inputctr.public.getQueryString('edit');
    $('#manage_product').click(function(){
        window.location.href = 'promotion.html?step=3'
    })
    var ListArr = ['高级商品列表','SKU 列表','ASIN 列表','浏览分类节点编号列表','品牌名称列表','供应商部门代码列表','商品组列表','商品类型名称列表','供货商编码列表'];
    var submit_button = $('.submit_button');
    var editData = {
        id:editID,
        seller_id:amazon_userid,
        type:'',
        tracking_id:'',
        description:'',
        ASIN:''
    }
    var Selection_ID = $('#Selection_ID');
    var Internal_Description = $('#Internal_Description');
    var ASIN_List = $('#ASIN_List');
    //初始化
    var SelectionData = {
        id:editID
    }
    function SelectionInit(){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/ProductSelectionInfo', {json:JSON.stringify(SelectionData)}, function (data) {
            if(data.result == 1) {
               $('.selection-type').text(ListArr[data.data.choose_type-1]);
               editData.type = data.data.choose_type;
               Selection_ID.val(data.data.tracking_id);
               Internal_Description.val(data.data.description);
               ASIN_List.val(data.data.skulist.replace(/,/g,'\r\n'));
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            inputctr.public.SellerRegisterLoadingRemove();
            alert(error.statusText);
        })
    }SelectionInit();
    // 编辑
    submit_button.click(function(){
        if(Selection_ID.val().trim() == ''){
            Selection_ID.addClass('error-border');
        }else{
            Selection_ID.removeClass('error-border');
        }
        if(Internal_Description.val().trim() == ''){
            Internal_Description.addClass('error-border');
        }else{
            Internal_Description.removeClass('error-border');
        }
        if(ASIN_List.val().trim() == ''){
            ASIN_List.addClass('error-border');
        }else{
            ASIN_List.removeClass('error-border');
        }
        if($('.error-border').length){
            return;
        }
        editData.tracking_id = Selection_ID.val().trim();
        editData.description = Internal_Description.val().trim();
        editData.ASIN = ASIN_List.val().trim().replace(/[\r\n]/g,',');
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/EditProductSelection', {json:JSON.stringify(editData)}, function (data) {
            if(data.result == 1) {
                window.location.href = 'promotion.html?step=3'
            }else{
                $('#auth-error-message-box').fadeIn(200).find('.a-alert-heading').text(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            alert(error.statusText);
        })
    })
})