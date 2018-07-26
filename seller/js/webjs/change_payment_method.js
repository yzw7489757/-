$(function () {
    var method_id = null;
    var checked = false;
    // 初始化付费方式(初始化信用卡列表) 
    $.ajax({
        url: baseUrl + '/InitializaCharge',
        method: 'post',
        dataType: "json",
        data: {
            userid: store_id,
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                var data = res.data;
                var bank = doT.template($('#bankArray').text());
                $('#bankTmpl').html(bank(data))
                var bankInput = 
                $('#bankTmpl input').each(function (i) {
                    $('#bankTmpl input').eq(i).click(function (i) {
                            alert(i)
                    })
                })
            } else {
                console.log(decodeURIComponent(res.error))
            }
        }
    })
    
    //初始化账单寄送地址
    $.ajax({
        url: baseUrl + '/GetAddressList',
        method: 'post',
        dataType: "json",
        data: {
            userid: store_id,
            sign: '1'
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                var data= res.List
                var add = doT.template($('#addArray').text());
                $('#addTmpl').html(add(data))
            } else {
                console.log(decodeURIComponent(res.error))
            }
        },
        error: function () {
            console.log(decodeURIComponent(res.error))
        }
    })

    //初始化账单寄送地址 新增邮寄地址
    $('.submitBtn').click(function (e) {
        e.preventDefault();
        //设置付款方式1
        $.ajax({
            url: baseUrl + '/SetChargeMade',
            method: 'post',
            dataType: 'json',
            data: {
                userid: store_id,
                method_id: '13'
            },
            success: function (res) {
                console.log(res)
                if (res.result == 1) {

                } else {
                    console.log(decodeURIComponent(res.error))
                }
            },
            error: function () {
                console.log(decodeURIComponent(res.error))
            }
        })

        //新增邮寄地址
        $.ajax({
            url: baseUrl + '/AddAddress',
            method: 'post',
            dataType: "json",
            data: {
                userid: store_id,
                address: '1',
                address2: '2',
                city: '3',
                province: '4',
                country: '5',
                zipcode: '6',
                type: '1'
            },
            success: function (res) {
                console.log(res)
                if (res.result == 1) {

                } else {
                    console.log(decodeURIComponent(res.error))
                }
            },
            error: function () {
                console.log(decodeURIComponent(res.error))
            }
        })
    })

})