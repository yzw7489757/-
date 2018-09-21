$(function () {
    var baseUrl = 'http://192.168.2.164:8096/QAMZNAPI.asmx';
    inputctr.public.checkLogin();
    if (window.sessionStorage) {
        var planId = sessionStorage.getItem('planId')
    }

    $('.goBtn').click(function () {
        // 检查货件
        $.post(baseUrl + '/CreateCargo', {
            planId: planId,
            sellerId: amazon_userid
        }, function (res) {
            if(res.result == '1'){
                $(location).attr('href', '/seller/manage_inventory_checking_hide.html');
            }
        }, 'json')

        
    })
    // 返回
    $('.returnBtn').click(function () {
        $(location).attr('href', '/seller/manage_inventory_labeling_goods.html');
    })
})