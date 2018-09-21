$(function () {
    var baseUrl = 'http://192.168.2.164:8096/QAMZNAPI.asmx';
    var packMethod;
    if (window.sessionStorage) {
        var goodsIds = sessionStorage.getItem('skuIds');
        goodId = sessionStorage.getItem('goodId')
        skuId = sessionStorage.getItem('skuId')
    }
    if (window.sessionStorage) {
        goodIds = goodId + ',';
        sessionStorage.setItem('goodIds', goodIds)
    }
    var strGoodsJson = JSON.stringify({
        goodsArr: [{
            goodsId: goodId,
            goodsNum: 10
        }]
    });
    // 初始化转化商品信息
    $.post(baseUrl + '/GetGoodsInfo', {
        goodsIds: goodIds
    }, function (res) {
        console.log(res);
        var data = res.goodsInfo[0];
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
    }, 'json')

    $("input[name=type]").click(function () {
        if ($(this).val() == 'mixing') {
            packMethod = 1;
        } else {
            packMethod = 2;
        }
    })

    $('.goBtn').click(function () {
        // 选择发货地址和包裹类型
        $.post(baseUrl + '/SelectAdr', {
            sellerId: 1,
            deliveryAddressId: 1,
            packMethod: packMethod,
            strGoodsJson: strGoodsJson
        }, function (res) {
            console.log(res);
            if (res.result == '1') {
                if(window.sessionStorage){
                    sessionStorage.setItem('planId',res.planId)
                }
                $(window).attr('location', '/seller/manage_inventory_setNumber.html')
            }
        }, 'json')
    })
})