$(function () { 
    $.ajax({
        url: baseUrl + '/GetBusinessInfo',
        method: 'post',
        dataType: "json",
        data: {
            userid: store_id,
           
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
              var data =res.strAddress
              $('.address').text(decodeURIComponent(data.address))
              $('.city').text(decodeURIComponent(data.city))
              $('.province').text(decodeURIComponent(data.province))
              $('.zipcode').text(decodeURIComponent(data.zipcode))
              $('.country').text(decodeURIComponent(data.country))
              $('.phone').text(decodeURIComponent(data.phone))

            } else {
                console.log(decodeURIComponent(res.error))
            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
 })