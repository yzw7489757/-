$(function () {
    inputctr.public.checkLogin();

    $.ajax({
        url: baseUrl + '/GetShopInfo',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid
        },
        success: function (res) {
            console.log(res)
           
            if (res.result == 1) {
                var data = res.data;
                // 电子邮件
                if (data.service_email == '') {
                    $('.pEmail').text('--');
                } else {
                    $('.pEmail').text(decodeURIComponent(data.service_email));
                }
               
                // 回复电子邮件
                if (data.service_reply_email == '') {
                    $('.replyEmail').text('--');
                } else {
                    $('.replyEmail').text(decodeURIComponent(data.service_reply_email));
                }
               
                // 显示名称
                $('.show_name').text(decodeURIComponent(data.shop_name));
                // 店面链接
                $('.shop_link').text(decodeURIComponent(data.shop_link));
                // 电话
                if (data.service_phone == '') {
                    $('.service_phone').text('（无）点击【编辑】进行设置');
                } else {
                    console.log(data.service_phone == '')
                    $('.service_phone').text(decodeURIComponent(data.service_phone));
                }

            }
        }
    })
})