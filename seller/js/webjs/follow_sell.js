$(function(){
    inputctr.public.checkLogin();
    inputctr.public.SellerRegisterLoading();
    var goodsID = inputctr.public.getQueryString('goodsID');
    var skuID = inputctr.public.getQueryString('skuID');
    var reconciledDetailsAttributes = $('.reconciledDetailsAttributes');
    var reconciledImage = $('#reconciledImage');
    pageInit();
    function pageInit(){
        $.post(baseUrl+'/GetProductInfoWishSell',{goodsID:goodsID,skuID:skuID}, function(data){
            inputctr.public.SellerRegisterLoadingRemove();
            if(data.result == 1){
                if(data.data.goods_info.product_image){
                    reconciledImage.attr('src',decodeURIComponent(data.data.goods_info.product_image));
                }
                productView(data.data.sku[0],data.data.goods_info);
                offerInit(data.data.sku[0]);
            }else{
                alert(decodeURIComponent(data.error));
            }
        },'json')
        lowPrice();
    }
    // SKU最低价
    function lowPrice(){
        inputctr.public.AjaxMethods('POST', baseUrl + '/GetLowestPrice', {sku_id:skuID}, function (data) {
            inputctr.public.SellerRegisterLoadingRemove();
            if(data.result == 1) {
                $('#ship-price').children('span.a-color-price').text('$'+data.money);
            }else{
                alert(decodeURIComponent(data.error));
            }
        }, function (error) {
            alert(error.statusText);
        })
    }
    // 商品详情展示 初始化
    function productView(view1,view2){
        var view_html = '<strong>Cate Path:&nbsp;</strong>'+view2.catePath+' <br />'+
                        '<strong>'+view1.product_id_type+':&nbsp;</strong>'+view1.product_id+' <br />'+
                        '<strong>Product Name:&nbsp;</strong>'+decodeURIComponent(view2.product_name)+'<br />'+
                        '<strong>Brand Name:&nbsp;</strong>'+view2.brand_name+' <br />'+
                        '<strong>Manufacturer:&nbsp;</strong>'+view2.manufacturer+' <br />'+
                        '<strong>Category (item-type):&nbsp;</strong>'+view2.category+' <br /><br />'+
                        '<strong>Marketplace:&nbsp;</strong>'+view2.marketplace+' <br /><br />'+
                        '<strong>List Price:&nbsp;</strong><span class="smallnegative">$'+view1.your_price+'</span> <br /><br />'+
                        '<strong>Amazon Sales Rank:&nbsp;</strong>'+view2.sales_rank+'';
        reconciledDetailsAttributes.html(view_html);
    }
    var shipping_template = $('#merchant_shipping_group_name');
    var your_price = $('#list_price');
    var Seller_SKU = $('.Seller-SKU');
    var Condition_statement_select = $('.Condition_statement_select');
    var Quantity = $('.Quantity');
    // Offer 初始化
    function offerInit(data){
        your_price.val(data.your_price);
        Seller_SKU.val(data.seller_sku);
        Condition_statement_select.children('option[value="'+data.condition+'"]').prop("selected","selected");
        Quantity.val(data.quantity);
        shipping_template.children('option[value="'+data.shipping_template_id+'"]').prop("selected","selected");
    }
    var Math_Low_Price = $('#Math-Low-Price');
    Math_Low_Price.click(function() {
        inputctr.public.SellerRegisterLoading();
        lowPrice();
    })
    var main_submit_button = $('#main_submit_button');
    main_submit_button.click(function() {
        var vain = $('.verity-submit').filter(function() {
           return $(this).val().trim() == '';
        })
        var Evain = $('.verity-submit').filter(function() {
           return $(this).val().trim() != '' ;
        })
        if(shipping_template.val() == 0){
            shipping_template.addClass('error-border')
        }else{
            shipping_template.removeClass('error-border')
        }
        vain.addClass('error-border');
        Evain.removeClass('error-border')
        if($('.error-border').length){
            return;
        }
        inputctr.public.SellerRegisterLoading();
        var SellGoodsVariation = {
            sku_id:skuID,
            your_price:your_price.val().trim(),
            seller_sku:Seller_SKU.val().trim(),
            condition:Condition_statement_select.val(),
            quantity:Quantity.val().trim(),
            shipping_template_id:shipping_template.val(),
            shipping_template:shipping_template.children('option[selected=selected]').text()
        }
        inputctr.public.AjaxMethods('POST', baseUrl + '/UpdateWishSellGoodsVariation', {json:JSON.stringify(SellGoodsVariation)}, function (data) {
            inputctr.public.SellerRegisterLoadingRemove();
            if(data.result == 1) {
                window.location.href = 'manage_inventory.html';
            }else{
                alert(decodeURIComponent(data.error));
            }
        }, function (error) {
            alert(error.statusText);
        })
    })
})