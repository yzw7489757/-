$(function () {
       // 初始化付费方式(初始化信用卡列表) 
       console.log(doT)
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
            } else {
                console.log(decodeURIComponent(res.error))
            }
        }
    })
})