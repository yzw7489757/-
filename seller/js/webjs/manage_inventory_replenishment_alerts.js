$(function () { 
    
    if(window.sessionStorage){
        var goodsSku = sessionStorage.getItem('sku')
    }
     // 获取补货提醒设置 
     $.post(baseUrl + '/GetRemind', {
        goodsSku: goodsSku
    }, function (res) {
        console.log(res);
        // 卖家sku
        $('.sellerSku').text(decodeURIComponent(res.sellerSku));
        // 商品名称
        $('.goodsName').text(decodeURIComponent(res.goodsName));
        // 状况
        $('.condition').text(decodeURIComponent(res.condition));
        // 月销量
        $('.sales').text(decodeURIComponent(res.sales));
        // 提醒条件 （返回数字  对应下拉选项value）
        var key = res.term
        $('.selectName option[value="'+key+'"]').attr("selected","selected")
        // 提醒阀值
        $('.limitValue').val(decodeURIComponent(res.limitValue));
    }, 'json')
    // 设置补货提醒
    $('.saveBtn').click(function () { 
        var term = $('.selectName option:selected').val();
        var limitValue = $('.limitValue').val();
        $.post(baseUrl + '/SupplementRemind', {
            goodsSku: goodsSku,
            term: term,
            limitValue: limitValue
        }, function (res) {
            console.log(res);
            if(res.result == "1"){
                alert(decodeURIComponent(res.error))
            }
        }, 'json')
     })
 })