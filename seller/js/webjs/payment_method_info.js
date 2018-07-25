$(function () {
    $.ajax({
        url: baseUrl + '/InitializaCharge',
        method: 'post',
        dataType: "json",
        data: {
            userid: '12',
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                var data = res.data; 
                
            } else {
                console.log(decodeURIComponent(res.error))
            }
        }
    })
})