$(function () {
    inputctr.public.checkLogin();
    var trackNo = $('.trackNo').val();
    var deleteO;
    if (window.sessionStorage) {
        var cargoNo = sessionStorage.getItem('cargoNo')
        var planId = sessionStorage.getItem('planId')
        var planNo = sessionStorage.getItem('planNo')
        sessionStorage.removeItem('planNo')
        if(planNo){
            planId = planNo;
        }
    }
    $('.cargoTitle li').click(function () {
        var index = $(this).index();
        $(this).addClass('selectColor').siblings().removeClass('selectColor');
        $('.cargo>li').eq(index).removeClass('none').siblings().addClass('none')
    })
    $('.anotherGoods').click(function () {
        $(window).attr('location', '/seller/manage_inventory_checking_cargo.html')
    })
    // 获取进度操作数据
    $.post(baseUrl + '/GetSchedule', {
        tag: '6',
        planId: planId,
        cargoNo: cargoNo
    }, function (res) {
        console.log(res);
        $('.cargoName').text(decodeURIComponent(res.cargoName));
        $('.cargoNo').text(decodeURIComponent(res.cargoNo));
        $('.name').text(decodeURIComponent(res.adrInfo.name));
        $('.address').text(decodeURIComponent(res.adrInfo.address));
        $('.address2').text(decodeURIComponent(res.adrInfo.address2));
        $('.detailAddress').text(`${decodeURIComponent(res.adrInfo.city)} ${decodeURIComponent(res.adrInfo.province)}`);
        $('.zipcode').text(decodeURIComponent(res.adrInfo.zipcode));
        $('.country').text(decodeURIComponent(res.adrInfo.country));
        $('.goodsNum').text(decodeURIComponent(res.goodsNum));
        $('.createTime').text(res.createTime)
        $('.cargoStatus').text(decodeURIComponent(res.cargoStatus))
        // 配送地址 
        $('.toCity').text(decodeURIComponent(res.toCity))
        $('.toZipcode').text(decodeURIComponent(res.toZipcode))
        $('.toAdr').text(decodeURIComponent(res.toAdr))
    }, 'json')

    // 6.4 查看货件内商品
    $.post(baseUrl + '/GetCargoGoods', {
        planId: cargoNo
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
            $('.deliveried').text('0')
        }
        // 收货（1是 0否）
        if (data.Collected == '1') {
            $('.Collected').text('是')
        } else {
            $('.Collected').text('0')
        }
    }, 'json')

    // 获取货件商品信息
    $.post(baseUrl + '/GetCargoGoodsInfo', {
        cargoNo: cargoNo,
        planId: planId
    }, function (res) {
        console.log(res);
        var detail = res.boxInfo;
        let detailTmpl = doT.template($('#addArray').text());
        $('#addTmpl').html(detailTmpl(detail));
        let detailTmpl2 = doT.template($('#addArray2').text());
        $('#addTmpl2').html(detailTmpl2(detail));
        // 返回
        $('.returnBtn').click(function () {
            if (res.isBack == "1") {
                $(window).attr('location', '/seller/manage_inventory_pretreatment_cargo.html')
            } else {
                $(window).attr('location', '/seller/cargo_handling_progress.html')
            }

        })
        // 箱号
        $('.cargoId').text(res.cargoId);
        // 追踪编号
        $('.trackNo').val(decodeURIComponent(res.shippingNumber));
        // 承运人状态
        if (res.shippingStatus == "") {
            $('.shippingStatus').text('-');
        } else {
            $('.shippingStatus').text(decodeURIComponent(res.shippingStatus));
        }
    }, 'json')
    // 返回“货件处理进度”
    $('.cargohandlingBtn').click(function () {
        $(window).attr('location', '/seller/cargo_handling_progress.html')
    })
    // 删除货件
    $('.deleteCargeBtn').click(function () { 
        if(planNo){
            planId = planNo;
            sessionStorage.removeItem('planNo')
        }
        $.post(baseUrl + '/DeleteCargo', {
            cargoNo: cargoNo,
            planId: planId
        }, function (res) {
            console.log(res);
            if(res.result =="1"){
                alert("删除货件成功")
                sessionStorage.removeItem('planNo')
                if(res.backTag == "1"){
                    $(location).attr('href', '/seller/manage_inventory_checking_cargo.html');
                }else{
                    $(location).attr('href', '/seller/cargo_handling_progress.html');
                }  
            }
        }, 'json')
     })
    // 保存货件跟踪编号
    $('.saveBtn').click(function () {
        trackNo = $('.trackNo').val();
        $.post(baseUrl + '/SaveTrackNo', {
            cargoNo: cargoNo,
            trackNo: trackNo,
            sellerId:amazon_userid
        }, function (res) {
            console.log(res);
            if (res.result == '1') {
                $('.successInfo').show();
                console.log('success!')
            }
        }, 'json')
    })
})