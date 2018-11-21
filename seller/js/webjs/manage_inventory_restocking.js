$(function () {
    
    inputctr.public.checkLogin();
    var packMethod;
    var adrId;
    var goodsIds;
    var sendAdrId;
    var goodId;
    var skuId;
    var skuIds;
    
    if (window.sessionStorage) {
        goodsIds = sessionStorage.getItem('skuIds');
        adrIds = sessionStorage.getItem('adrId');
        goodId = sessionStorage.getItem('goodId');
        skuId = sessionStorage.getItem('skuId');
        skuIds = skuId + ',';
        // var goodIds = sessionStorage.setItem('goodIds', goodIds);
        sessionStorage.removeItem('adrId');
        sessionStorage.removeItem('sendAdrId');
    }
    if(inputctr.public.getQueryString('sku_id')){
        goodId = inputctr.public.getQueryString('goodsID');
        skuId = inputctr.public.getQueryString('sku_id');
        skuIds = skuId + ',';
    }
    var strGoodsJson = JSON.stringify({
        goodsArr: [{
            goodsId: skuId,
            goodsNum: 10
        }]
    });
    // 初始化转化商品信息 
    $.post(baseUrl + '/GetGoodsInfo', {
        goodsIds: skuIds
    }, function (res) {
        console.log(res);
        var data = res.goodsInfo[0];
        if (data) {
            // 卖家sku
            $('.sellerSku').text(data.sellerSku)
            // 商品名称
            $('.goodName').text(decodeURIComponent(data.goodName))
            // 配送类型：-1 所有 1卖家 2 亚马逊
            if (data.shippingMode == '-1') {
                $('.shippingMode').text('所有')
            } else if (data.shippingMode == '1') {
                $('.shippingMode').text('卖家')
            } else if (data.shippingMode == '2') {
                $('.shippingMode').text('亚马逊')
            }
        }
    }, 'json')
    // 获取地址详情
    $.post(baseUrl + '/GetAdr', {
        adrId: adrIds,
        sellerId:amazon_userid
    }, function (res) {
        console.log(res);
        console.log(adrId)
        adrId = res.adrId;
        $('.name').text(decodeURIComponent(res.name))
        $('.address').text(decodeURIComponent(res.address))
        $('.address2').text(decodeURIComponent(res.address2))
        $('.cityProvince').text(`${decodeURIComponent(res.city)} ${decodeURIComponent(res.province)}`)
        $('.zipcode').text(decodeURIComponent(res.zipcode))
        $('.country').text(decodeURIComponent(res.country))
    }, 'json')

    $("input[name=type]").click(function () {
        if ($(this).val() == 'mixing') {
            packMethod = 1;
        } else {
            packMethod = 2;
        }
    })

    $('.goBtn').click(function () {
        if (!packMethod) {
            alert('请选择包装类型!!')
        } else {
            // 选择发货地址和包裹类型
            $.post(baseUrl + '/SelectAdr', {
                sellerId:amazon_userid,
                deliveryAddressId:adrId,
                packMethod: packMethod,
                strGoodsJson: strGoodsJson
            }, function (res) {
                console.log(res);
                if (res.result == '1') {
                    if (window.sessionStorage) {
                        sessionStorage.setItem('planId', res.planId)
                    }
                    $(window).attr('location', '/seller/manage_inventory_setNumber.html')
                }
            }, 'json')
        }
    })
    // 从另一地址发货
    $('.editAddress').click(function () { 
        $(window).attr("location", "manage_inventory_editAddress.html?goodsID="+goodId+"&sku_id="+skuId)
     })
})