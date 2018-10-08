$(function () {
    var input_one = $('.input_one').val(); // 长
    var input_two = $('.input_two').val(); // 宽
    var input_three = $('.input_three').val(); // 高
    var input_weight = $('.input_weight').val(); // 重量
    var inputNum = $('.inputNum').val(); // 商品数量
    var box_goods_num = $('.box_goods_num').val(); // 每个箱子商品数量
    var box_num = $('.box_num').val(); // 箱子数量
    var showTr = false;
    var showBtn = false;
    var packMethod; // 包装类型（1 混装商品 2 原厂包装）
    var planGoodsId;
    var baseUrl = 'http://192.168.2.164:8096/QAMZNAPI.asmx';
    var strGoodsBoxJson;
    var goodsArr;
    var obj;
    if (window.sessionStorage) {
        var planId = sessionStorage.getItem('planId')
    }

    function inputValue() {
        goodsArr = [];
        $('#showTmpl .adds').each(function (index, item, array) {
            obj = {};
            obj.planGoodsId = $(this).attr('planGoodsId')
            obj.boxLength = $(this).find('.input_one').val();
            obj.boxWidth = $(this).find('.input_two').val();
            obj.boxHeight = $(this).find('.input_three').val();
            obj.boxWeights = $(this).find('.input_weight').val();
            obj.goodsNum = $(this).find('.inputNum').val();
            obj.boxGoodsNum = $(this).find('.box_goods_num').val();
            obj.boxNum = $(this).find('.box_num').val();
            goodsArr.push(obj)
        })
    }
    // 按钮变换颜色
    function notemptyInput() {
        inputValue();
        $('#showTmpl .adds').each(function (item) {
            if (obj.boxLength && obj.boxWidth && obj.boxHeight && obj.boxWeights) {
                $('.unfinishBtn').hide();
                $('.finishBtn').show();
                showBtn = true;
            } else {
                $('.unfinishBtn').show();
                $('.finishBtn').hide();
                showBtn = false;
            }
        })
    }
    // input 按钮变换颜色
    function changeBtnColor() {
        $('#showTmpl .adds input').each(function (item) {
            console.log($(this))
            $(this).change(function () {
                // if (obj.boxLength && obj.boxWidth && obj.boxHeight && obj.boxWeights) {
                //     $('.unfinishBtn').hide();
                //     $('.finishBtn').show();
                //     showBtn = true;
                // } else {
                //     $('.unfinishBtn').show();
                //     $('.finishBtn').hide();
                //     showBtn = false;
                // }
                console.log($(this).val());
            })
           
        })
    }
    changeBtnColor()

    // changeBtnColor('.input_one')
    // changeBtnColor('.input_two')
    // changeBtnColor('.input_three')
    // changeBtnColor('.input_weight')

    // 混装商品 原厂包装发货商品
    $('.mixingBox>a').click(function () {
        $('.mixingBox').hide();
        $('.originalBox').show();
        $('.hiddenTr').removeClass('none');
        packMethod = 2;
        UpdatePackMethod();
    })
    $('.originalBox>a').click(function () {
        $('.mixingBox').show();
        $('.originalBox').hide();
        $('.hiddenTr').addClass('none');
        packMethod = 1;
        UpdatePackMethod()
    })

    // 更改包装类型
    function UpdatePackMethod() {
        $.post(baseUrl + '/UpdatePackMethod', {
            planId: planId,
            packMethod: packMethod
        }, function (res) {
            console.log(res);
            if (res.result == '1') {
                console.log(decodeURIComponent(res.msg))
            }
        }, 'json')
    }

    // 计划商品初始化
    $.post(baseUrl + '/GetdeliveryAdr', {
        planNo: planId
    }, function (res) {
        console.log(res);
        detail = res.goodsInfo;
        let detailTmpl = doT.template($('#showArray').text());
        $('#showTmpl').html(detailTmpl(detail));
        if (res.packMethod === '1') {
            packMethod = 1;
            $('.mixingBox').show();
            $('.originalBox').hide();
            $('.hiddenTr').addClass('none');
        } else {
            packMethod = 2;
            $('.mixingBox').hide();
            $('.originalBox').show();
            $('.hiddenTr').removeClass('none');
        }
        $('.name').text(decodeURIComponent(res.adrInfo.name));
        $('.address').text(decodeURIComponent(res.adrInfo.address));
        $('.address2').text(decodeURIComponent(res.adrInfo.address2));
        $('.detailAddress').text(`${decodeURIComponent(res.adrInfo.city)} ${decodeURIComponent(res.adrInfo.province)}`);
        $('.zipcode').text(decodeURIComponent(res.adrInfo.zipcode));
        $('.country').text(decodeURIComponent(res.adrInfo.country));
        $('.shopName').text(decodeURIComponent(res.storeName))
        notemptyInput();

    }, 'json')
    // 保存
    $('.saveBtn').click(function () {
        strGoodsBoxJson = JSON.stringify({
            goodsArr: goodsArr
        });
        $.post(baseUrl + '/SetingNumber', {
            strGoodsBoxJson: strGoodsBoxJson
        }, function (res) {
            console.log(res);
            if (res.result == '1') {
                alert('保存成功!');
                $('.redgoBtn').show();
                $('.yellowgoBtn').hide();
                $('.Lack_parcel_size').text('-')
            }
        }, 'json')
    })
    // 继续
    $('.goBtn').click(function () {
        inputNum = $('.inputNum').val();
        if (inputNum != "" && showBtn) {
            $(location).attr('href', '/seller/manage_inventory_preprocessed_goods.html');
        } else {
            alert('保存失败')
        }
    })
})