$(function(){
    inputctr.public.checkLogin();
    var type = inputctr.public.getQueryString('type');
    var ListArr = ['高级商品列表','SKU 列表','ASIN 列表','浏览分类节点编号列表','品牌名称列表','供应商部门代码列表','商品组列表','商品类型名称列表','供货商编码列表'];
    $('.selection-type').text(ListArr[type]);
    var submit_button = $('.submit_button');
    var createData = {
        seller_id:amazon_userid,
        type:++type,
        tracking_id:'',
        description:'',
        ASIN:''
    }
    var Selection_ID = $('#Selection_ID');
    var Internal_Description = $('#Internal_Description');
    var ASIN_List = $('#ASIN_List');
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
        createData.tracking_id = Selection_ID.val().trim();
        createData.description = Internal_Description.val().trim();
        createData.ASIN = ASIN_List.val().trim().replace(/[\r\n]/g,',');
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/CreateProductSelection', {json:JSON.stringify(createData)}, function (data) {
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