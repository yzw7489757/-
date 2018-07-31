$(function () {
  //配送设置（初始化详细信息）
  $.ajax({
    url: baseUrl + "/InitialShippingSettings",
    method: "post",
    dataType: "json",
    data: {
      userid: store_id
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


})