$(function () {
    var planGoodsId; // 运输计划商品唯一标识
    var prepOwner; // 准备方（1 卖家 2 亚马逊）
    var cateId;
    var planGoods ;
    var obj ;
    var baseUrl = 'http://192.168.2.164:8096/QAMZNAPI.asmx';
    if (window.sessionStorage) {
        var planId = sessionStorage.getItem('planId')
        var planGoodsId = sessionStorage.getItem('planGoodsId')
    }
    
    $('select[name="childSelect"]').change(function () {
        if ($(this).val() == '卖家') {
            prepOwner = 1;
        } else if ($(this).val() == '亚马逊') {
            prepOwner = 2;
        } else {
            prepOwner = 0;
        }
    })
    // 商品信息初始化
    $.post(baseUrl + '/GetPrepInfo', {
        planId: planId
    }, function (res) {
        console.log(res)
        detail = res.prepGoods;
        let detailTmpl = doT.template($('#showArray').text());
        $('#showTmpl').html(detailTmpl(detail));
        // 显示商品件数
        $('.packagesNum').text(detail.length)
        // 准备方（1 卖家 2 亚马逊）
        if (detail.prepOwner == '1') {
            prepOwner = 1;  
        } else if (detail.prepOwner == '2') {
            prepOwner = 2;  
        } else {
            prepOwner = 0;
        }
        // 准备指导   固体   液体
        $('.selection_classification').click(function () {
            planGoodsId =  $(this).parents('.adds').attr('planGoodsId');
            $('.model-wrapper').show();
            $.post(baseUrl + '/GetFBAGoodsCategory', function (res) {
                console.log(res);
                var data = res.cateInfo
                var add = doT.template($('#addArray').text());
                $('#addTmpl').html(add(data))
                cateId = $('.select').find('option:selected').attr('data-id');
                GetFBAGoodsCategoryDetails();
                $('#addTmpl .select').change(function () {
                    cateId = $('.select').find('option:selected').attr('data-id');
                    GetFBAGoodsCategoryDetails();
                })
            }, 'json')
        })
        // 适用于全部   select
        $('#select').change(function () {
            $("select[name=childSelect]").find('option').attr('selected', false)
            if ($(this).val() == '适用于全部') {
                $("select[name=childSelect]").find('option[value="适用于全部"]').attr('selected', true)
            }
        })
        // 商品数量总计
        function labelQuantitySpan() { 
            var goodsNumSum = 0;
            $('#showTmpl .adds').each(function (index, item, array) {
                goodsNumSum += parseInt($(this).find('.goodsNum').text())
                $('.goodsNumSpan').text(goodsNumSum)
            })
         }
        labelQuantitySpan();
        if (window.sessionStorage) {
            planGoodsId = sessionStorage.setItem('planGoodsId', $('.adds').attr('planGoodsId'))
        }

    }, 'json')

    // 获取进度操作数据
    $.post(baseUrl + '/GetSchedule', {
        tag: '2',
        planId: planId
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

    // 获取物流商品类目详情（准备指导详情）
    function GetFBAGoodsCategoryDetails() {
        $.post(baseUrl + '/GetFBAGoodsCategoryDetails', {
            cateId: cateId
        }, function (request) {
            $('.cateInfo').text(decodeURIComponent(request.cateInfo))
            $('.catePrep').text(decodeURIComponent(request.catePrep))
        }, 'json')
    }

    // 选择物流商品类目
    $('.chooseBtn').click(function () {
        $.post(baseUrl + '/SelectFBAGoodsCategory', {
            planGoodsId: planGoodsId,
            cateId: cateId
        }, function (res) {
            console.log(res)
            if (res.result == "1") {
                $('.model-wrapper').hide();
                 window.location.reload();
            }
        }, 'json')
    })

    // 关闭
    $('.closeBtn').click(function () {
        $('.model-wrapper').hide();
    })

    // 删除
    $('.deleteBtn').click(function () {
        $(this).parent().parent().remove();
    })

    // 继续
    $('.goBtn').click(function () {
        planGoodsId =  $('.adds').attr('planGoodsId');
        planGoods = [];
        $('#showTmpl .adds').each(function (index, item, array) {
            obj = {};
            obj.planGoodsId = $(this).attr('planGoodsId'),
            obj.prepOwner = prepOwner,
            obj.guidance = ''
            planGoods.push(obj)
        })
        var strPlanGoodsJson;
        $.post(baseUrl + '/SetPrepGoods', {
            strPlanGoodsJson: JSON.stringify({
                planGoods :planGoods
            })
        }, function (res) {
            console.log(res);
            if (res.result == '1') {
                console.log('success!')
                $(location).attr('href', '/seller/manage_inventory_labeling_goods.html');
            }
        }, 'json')
    })

    // 返回
    $('.returnBtn').click(function () {
        $(location).attr('href', '/seller/manage_inventory_setNumber.html');
    })
})