$(function () { 
    inputctr.public.checkLogin();
    $.ajax({
        url: baseUrl + '/GetUserTax',
        method: 'post',
        dataType: "json",
        data: {
          userid: amazon_userid,
        },
        success: function (res) {
          console.log(res)
          if (res.result == 1) {
            var data = res.data
            $('.company_name').text(decodeURIComponent(res.company_name))
            $('.country').text(decodeURIComponent(data.country))
            $('.address').text(decodeURIComponent(data.address))
            $('.address2').text(decodeURIComponent(data.address2))
            $('.city').text(decodeURIComponent(data.city))
            $('.province').text(decodeURIComponent(data.province))
            $('.zipcode').text(decodeURIComponent(data.zipcode))
            $('.fullname').text(decodeURIComponent(data.full_name))
            $('.phone').text(decodeURIComponent(data.phone))
            $('.email').text(decodeURIComponent(data.email))
            sessionStorage.setItem('tax_id',res.tax_id)
          }
        },
        error:function (res) { 
            console.log(decodeURIComponent(res.error))
         }
      })
    $('.goBack').click(function(){
      $(location).attr('href','/seller/account_information.html')
    })
 })