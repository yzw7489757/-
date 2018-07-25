$(function () {
    $.ajax({
        url: baseUrl + '/InitializaChargeInfo',
        method: 'post',
        dataType: "json",
        data: {
            userid: '12',
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                var data = res.data.strChargeInfo; 
               $('.card_number').text(data.card_number)
               $('.card_holder_name').text(data.card_holder_name)
               $('.valid_through_month').text(data.valid_through_month) 
               $('.valid_through_year').text(data.valid_through_year)
            } else {
                console.log(decodeURIComponent(res.error))
            }
        }
    })
})