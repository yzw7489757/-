$(function () {
    inputctr.public.checkLogin();
    var methos_id = null;
    dropdown_box(".time", "#choose_time");
    //配送设置（初始化详细信息）
    $.ajax({
        url: baseUrl + "/InitialShippingSettings",
        method: "post",
        dataType: "json",
        data: {
            userid: amazon_userid
        },
        success: function (res) {
            console.log(res);
            if (res.result == 1) {
                var data = res.data.strAddress
                $('.name').text(decodeURIComponent(data.name))
                $('.address').text(decodeURIComponent(data.address))
                $('.address2').text(decodeURIComponent(data.address2))
                $('.city').text(decodeURIComponent(data.city))
                $('.country').text(decodeURIComponent(data.country))
                $('.email').text(decodeURIComponent(data.email))
                $('.full_name').text(decodeURIComponent(data.full_name))
                $('.phone').text(decodeURIComponent(data.phone))
                $('.province').text(decodeURIComponent(data.province))
                $('.zipcode').text(decodeURIComponent(data.zipcode))
                console.log("success!");
                if (window.sessionStorage) {
                    sessionStorage.setItem('address_id', decodeURIComponent(data.address_id))
                }

            } else {
                console.log(decodeURIComponent(res.error));

            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error));
        }
    });
    // 默认地址
    $.ajax({
        url: baseUrl + '/GetAddressList',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
            sign: '3'
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                methos_id = res.registered_address_Id
                address_data = res.List
                for (let i = 0; i < address_data.length; i++) {
                    address_data[i].status = false;
                    if (address_data[i].address_id == res.registered_address_Id) {
                        address_data[i].status = true;
                    }
                }
                var add = doT.template($('#addArray').text());
                $('#addTmpl ').html(add(address_data));
                $('input[type="radio"]:checked').parents('.add').addClass('address-item-select')
                $('.add input').each(function (i) {
                    $('.add input').eq(i).click(function () {
                        methos_id = $('input[type="radio"]:checked').parents('.add').attr('data-id')
                        console.log(methos_id)
                    })
                })
            } else {
                console.log(decodeURIComponent(res.error))
            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })

    // 编辑
    $('.editBtn_first').click(function () { 
        $('.popup').show()
     })

     // 取消
     $('.layer-cancel').click(function () { 
        $('.popup').hide()
      })
    $('.saveBtn').click(function () { 
        // 点击删除
        $.ajax({
            url: baseUrl + "/DelDistributionAddress",
            method: "post",
            dataType: "json",
            data: {
                addressId: methos_id
            },
            success: function (res) {
                console.log(res);
                if (res.result == 1) {
                   // window.location.reload();
                    console.log("success!");
                } else {
                    console.log(decodeURIComponent(res.error));
                }
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error));
            }
        });
     })

})