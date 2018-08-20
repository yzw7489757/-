$(function () { 
    inputctr.public.checkLogin();
    $.ajax({
        url: baseUrl + '/GetShopInfo',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
            account: '201801@qgy.com',
            password:'000000',
        },
        success: function (res) {
          console.log(res)
          if (res.result == 1) {
            var data = res.data;
            $('.service_email').text(decodeURIComponent(data.service_email))
            $('.service_phone').text(decodeURIComponent(data.service_phone))
            $('.shop_name').text(decodeURIComponent(data.shop_name))  
            sessionStorage.setItem('shop_name',data.shop_name)
            sessionStorage.setItem('service_email',data.service_email)      
          }
        }
      })
 })