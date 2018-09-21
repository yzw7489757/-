$(function () {
    var baseUrl = 'http://192.168.2.164:8096/QAMZNAPI.asmx';
    if (window.sessionStorage) {
        var planId = sessionStorage.getItem('planId')
    }
    $('.look_goods').click(function () {
        $('.model-wrapper').show()
    })

    $.post(baseUrl + '/GetCargoGoods', {
        planId: planId
    }, function (res) {
        console.log(res)
        var data = res.goodsLable[0];
        // 卖家sku
        $('.sellerId').text(data.sellerId)
        // 商品名称
        $('.goodsName').text(decodeURIComponent(data.goodsName))
        // 配送类型：-1 所有 1卖家 2 亚马逊
        if (data.packModel == '-1') {
            $('.shippingMode').text('所有')
        } else if (data.packModel == '1') {
            $('.shippingMode').text('卖家')
        } else if (data.packModel == '2') {
            $('.shippingMode').text('亚马逊')
        }
        // 发货（1是 0否）
        if (data.deliveried == '1') {
            $('.deliveried').text('是')
        } else {
            $('.deliveried').text('否')
        }
        // 收货（1是 0否）
        if (data.Collected == '1') {
            $('.Collected').text('是')
        } else {
            $('.Collected').text('否')
        }

    }, 'json')

    $('.goBtn').click(function () {
        $(location).attr('href', '/seller/manage_inventory_pretreatment_cargo.html');
    })
})