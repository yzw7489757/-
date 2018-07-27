$(function () { 
    $.ajax({
        url: baseUrl + '/GetToken',
        method: 'post',
        dataType: "json",
        data: {
            userid: store_id,
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                console.log('success!')
               
            } else {
                console.log(decodeURIComponent(res.error))
            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
 })