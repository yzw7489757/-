$(function () { 
    var baseUrl = "http://192.168.2.164:8096/QAMZNAPI.asmx";
     // 获取自定义帮助
     $.ajax({
        url: baseUrl + '/GetCustomHelpList',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
            help_id:0
        },
        success: function (res) {
            console.log(res);

        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
   
    //设置自定义帮助
    $('button').click(function (e) {
        e.preventDefault(); 
        $.ajax({
            url: baseUrl + '/SetAboutShipping',
            method: 'post',
            dataType: "json",
            data: {
                userid: amazon_userid,
                shippingPolicies:shippingPolicies,
                shippingRates:shippingRates
            },
            success: function (res) {
                console.log(res);
                if(res.result == 1){
                    $('.submitInfo').show()
                } 
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error))
            }
        })
    })
 })