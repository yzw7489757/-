$(function () {
    
    var planGoodsId;
    var labelQuantity = $('.labelQuantity').val();
    var strGoodsLableJson;
    var printlabel = false;
    var goodsLable ;
    var planId;
    var cargoNo;
    if (window.sessionStorage) {
        planId = sessionStorage.getItem('planId')
    }
    
    // 商品信息初始化
    $.post(baseUrl + '/GetLableInfo', {
        planId: planId
    }, function (res) {
        console.log(res)
        detail = res.goodsLable;
        let detailTmpl = doT.template($('#showArray').text());
        $('#showTmpl').html(detailTmpl(detail));
        $('.packagesNum').text(detail.length)
        // 配送类型：-1 所有 1卖家 2 亚马逊
        if (detail.packModel == '-1') {
            labelOwner = 0;
        } else if (detail.packModel == '1') {  
            labelOwner = 1;
        } else {
            labelOwner = 2;
        }
        // 贴标方（1 卖家 2 亚马逊）
        if (detail.labelOwner == '1') {
            labelOwner = 1;
        } else if (detail.labelOwner == '2') {
            labelOwner = 2;
        } else {
            labelOwner = 0;  
        }
        // 标签总数
        function labelQuantitySpan() { 
            var labelQuantitySpan = 0;
            $('#showTmpl .adds').each(function (index, item, array) {
                labelQuantitySpan += parseInt($(this).find('.labelQuantity').val())
                $('.labelQuantitySpan').text(labelQuantitySpan)
            })
         }
        labelQuantitySpan();
        // 标签总数
        $('.labelQuantity').change(function () {
            labelQuantitySpan()
        })
        // 要打印的标签数量
        $('.labelQuantitySpan').text(detail.labelQuantity);
        // 适用于全部   select 
        $('#select').change(function () {
            $("select[name=childSelect]").find('option').attr('selected', false)
            if ($(this).val() == '适用于全部') {
                $("select[name=childSelect]").find('option[value="适用于全部"]').attr('selected', true)
            }
        })
        $('select[name="childSelect"]').change(function () {
            if ($(this).val() == '卖家') {
                labelOwner = 1;
            } else if ($(this).val() == '亚马逊') {
                labelOwner = 2;
            } else {
                labelOwner = 0;
            }
        })
        if (window.sessionStorage) {
            planGoodsId = sessionStorage.getItem('planGoodsId', $('.adds').attr('planGoodsId'))
        }
    }, 'json')
    
    // 为此页面打印标签按钮
    $('.printlabelBtn').click(function () {
        printlabel = true;
    })
    // 删除
    $('.deleteBtn').click(function () {
        $(this).parent().parent().remove();
    })
    // 继续
    $('.goBtn').click(function () { 
        goodsLable = [];
        $('#showTmpl .adds').each(function (index, item, array) {
            var obj = {};
            $(' #showTmpl .adds select[name="childSelect"]').each(function () {
                if ($(this).val() == '卖家') {
                    obj.labelOwner = 1;
                } else if ($(this).val() == '亚马逊') {
                    obj.labelOwner  = 2;
                } else {
                    obj.labelOwner  = 0;
                }
            })
            obj.planGoodsId = $(this).attr('planGoodsId'),
            obj.labelOwner = labelOwner,
            obj.labelQuantity = $(this).find('.labelQuantity').val().trim()
            goodsLable.push(obj)
        })
        var strGoodsLableJson;
        strGoodsLableJson = JSON.stringify({
            goodsLable: goodsLable   
        });
        $.post(baseUrl + '/SetGoodsLable', {
            strGoodsLableJson: strGoodsLableJson,
            planId:planId
        }, function (res) {
            console.log(res);
            if (res.result == '1') {
                console.log('success!')
                $(location).attr('href', '/seller/manage_inventory_checking_cargo.html');
            }
        }, 'json')

    })

    // 获取进度操作数据
    $.post(baseUrl + '/GetSchedule', {
        tag: '3',
        planId: planId,
        cargoNo:""
    }, function (res) {
        console.log(res);
        $('.name').text(decodeURIComponent(res.adrInfo.name));
        $('.address').text(decodeURIComponent(res.adrInfo.address));
        $('.address2').text(decodeURIComponent(res.adrInfo.address2));
        $('.detailAddress').text(`${decodeURIComponent(res.adrInfo.city)} ${decodeURIComponent(res.adrInfo.province)}`);
        $('.zipcode').text(decodeURIComponent(res.adrInfo.zipcode));
        $('.country').text(decodeURIComponent(res.adrInfo.country));
        $('.packMethod').text(decodeURIComponent(res.packMethod));
        $('.storeName').text(decodeURIComponent(res.storeName));
    }, 'json')

    // 返回
    $('.returnBtn').click(function () {
        $(location).attr('href', '/seller/manage_inventory_preprocessed_goods.html');
    })
})