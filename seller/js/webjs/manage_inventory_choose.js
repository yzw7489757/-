$(function () {
    var goodId;
    var skuId;
    var goodsArr;
    var baseUrl = 'http://192.168.2.164:8096/QAMZNAPI.asmx';
    goodId = inputctr.public.getQueryString('goodsID');
    skuId = inputctr.public.getQueryString('sku_id');
    var strGoodsJson = JSON.stringify({goodsArr:[{goodId:goodId,skuId:skuId}]});
    if(window.sessionStorage){
        sessionStorage.setItem('goodId',goodId)
        sessionStorage.setItem('skuId',skuId)
    }
    // 商品信息初始化
    $.post(baseUrl+'/Transformation',{strGoodsJson:strGoodsJson}, function(res){
        console.log(res)
        var data = res.goodsInfo[0];
        $('.sellerSku').text(data.sellerSku)
        $('.goodName').text(decodeURIComponent(data.goodName))
        if(data.shippingMode =='-1'){
            $('.shippingMode').text('所有')
        }else if(data.shippingMode =='1'){
            $('.shippingMode').text('卖家')
        }
        else if(data.shippingMode =='2'){
            $('.shippingMode').text('亚马逊')
        }
        if(data.productId != ""){
            $('.productId').text(decodeURIComponent(data.productId))
        }
    },'json')
    $('.returnBtn').click(function () {
        $(window).attr('location', '/seller/manage_inventory.html')
    })
    $('.saveBtn').click(function () {
        $(window).attr('location', '/seller/manage_inventory_dangerous.html')
    })
})