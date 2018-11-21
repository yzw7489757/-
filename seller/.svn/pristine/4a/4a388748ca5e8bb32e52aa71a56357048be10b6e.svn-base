$(function () {
  inputctr.public.checkLogin();
  //过滤指定特殊字符
  function filterStr(str) {
    var pattern = new RegExp("[~@#$*_+<>?,.\/;]");
    var specialStr = "";
    for (var i = 0; i < str.length; i++) {
      specialStr += str.substr(i, 1).replace(pattern, '');
    }
    return specialStr;
  }
  var statusName = false;
  var statusUrl = false;
  $('#shopName').blur(function (e) {
    $('.NameRepeat').hide()
    $('.canNotReceive').hide();
    $('.shopNameError').hide();
    $('.mustMes').hide();
    $('.successMes').hide();

    e.preventDefault();
    //非空验证 //必须填写显示名称
    if ($('#shopName').val() == '') {
      $('.mustMes').show();
      return
    } else {
      $('.mustMes').hide();
      var shopname = $('#shopName').val()
      if (shopname) {
        $.ajax({
          url: baseUrl + '/GetShopName',
          method: 'post',
          dataType: "json",
          data: {
            userid: amazon_userid,
            shopname: shopname
          },
          success: function (res) {
            console.log(res)
            if (res.result == 1) {

            } else {
              $('.NameRepeat').show()
              $('.successMes').hide()
              console.log(decodeURIComponent(res.error))
            }
          },
          error: function (res) {

            console.log(decodeURIComponent(res.error))
          }
        })
      }
    }
    //只有一位字符 //显示名称不可用
    if (($('#shopName').val()).length < 2) {
      $('.canNotReceive').show();
      return
    } else {
      $('.canNotReceive').hide();
    }

    //去掉特殊字符，剩余正常字符2个以上  //商品名称无效
    let str = filterStr($('#shopName').val())
    if (str.length < 2) {
      $('.shopNameError').show();
      return
    } else {
      $('.shopNameError').hide();
    }

    $('.successMes').show();
    statusName = true
  });
  // //店铺地址框
  $('#shopNameUrl').blur(function (e) {
    $('.urlCanNotReceive').hide();
    $('.shopNameNull').hide()
    $('.urlCanNotReceive').hide();
    $('.urlSuccessMes').hide();

    e.preventDefault();
    //为空判断 //商店名称为空
    if ($('#shopNameUrl').val() == '') {
      $('.shopNameNull').show()
      $('.NameRepeat').hide()
      return;
    } else {
      $('.shopNameNull').hide()

    }

    //只有一位字符 //商店名称不可用
    if (($('#shopNameUrl').val()).length < 2) {
      $('.urlCanNotReceive').show();
      return
    } else {
      $('.urlCanNotReceive').hide();
    }

    //去掉特殊字符，剩下的正常字符两个以上  //商店名称无效
    let str = filterStr($('#shopName').val())
    if (str.length < 2) {
      $('.urlCanNotReceive').show();
      return
    } else {
      $('.urlCanNotReceive').hide();
    }
    $('.urlSuccessMes').show();
    statusUrl = true;
  });

  //卖家信息
  $.ajax({
    url: baseUrl + '/GetShopInfo',
    method: 'post',
    dataType: "json",
    data: {
      userid: amazon_userid
    },
    success: function (res) {
      console.log(res)
      if (res) {
        inputctr.public.judgeBegaintask('1101');
      }
      if (res.result == 1) {
        var data = res.data;
        $('.name_input').val(decodeURIComponent(data.shop_name))
        $('.shop_link_input').val(decodeURIComponent(data.shop_link))
      }
    }
  })

  $('.submitSpan').click(function () {
    var name = $('.name_input').val().trim()
    var link = $('.shop_link_input').val().trim()
    inputctr.public.judgeRecodertask('1101', '开通店铺独立访问地址开始');
    $('.success_status').hide()
    // 店铺名称
    $('.urlCanNotReceive').hide();
    $('.shopNameNull').hide()
    $('.urlCanNotReceive').hide();
    $('.urlSuccessMes').hide();
    //为空判断 //商店名称为空
    if ($('#shopNameUrl').val() == '') {
      $('.shopNameNull').show()
      $('.NameRepeat').hide()
      return;
    } else {
      $('.shopNameNull').hide()

    }
    //只有一位字符 //商店名称不可用
    if (($('#shopNameUrl').val()).length < 2) {
      $('.urlCanNotReceive').show();
      return
    } else {
      $('.urlCanNotReceive').hide();
    }
    //去掉特殊字符，剩下的正常字符两个以上  //商店名称无效
    let str = filterStr($('#shopName').val())
    if (str.length < 2) {
      $('.urlCanNotReceive').show();
      return
    } else {
      $('.urlCanNotReceive').hide();
    }
    $('.urlSuccessMes').show();
    statusUrl = true;
    // 店铺地址框
    $('.NameRepeat').hide()
    $('.canNotReceive').hide();
    $('.shopNameError').hide();
    $('.mustMes').hide();
    $('.successMes').hide();
    //非空验证 //必须填写显示名称
    if ($('#shopName').val() == '') {
      $('.mustMes').show();
      return
    } else {
      $('.mustMes').hide();
      var shopname = $('#shopName').val()
      if (shopname) {
        $.ajax({
          url: baseUrl + '/GetShopName',
          method: 'post',
          dataType: "json",
          data: {
            userid: amazon_userid,
            shopname: shopname
          },
          success: function (res) {
            console.log(res)
            if (res.result == 1) {
              if (statusUrl && statusName) {
                $.ajax({
                  url: baseUrl + '/UpdateStoreDetails',
                  method: 'post',
                  dataType: "json",
                  data: {
                    userid: amazon_userid,
                    shop_name: name,
                    shop_link: link
                  },
                  success: function (res) {
                    console.log(res)
                    if (res.result == 1) {
                      inputctr.public.judgeFinishtask('1101', successStatus);
                    } else {
                      $('.success_status').hide()
                      console.log(decodeURIComponent(res.error))
                    }
                  },
                  error: function () {
                    console.log(res.error)
                  }
                })
              }
            } else {
              $('.NameRepeat').show()
              $('.successMes').hide()
              $('.success_status').hide()
              console.log(decodeURIComponent(res.error))
            }
          },
          error: function (res) {

            console.log(decodeURIComponent(res.error))
          }
        })
      }
    }
    //只有一位字符 //显示名称不可用
    if (($('#shopName').val()).length < 2) {
      $('.canNotReceive').show();
      return
    } else {
      $('.canNotReceive').hide();
    }

    //去掉特殊字符，剩余正常字符2个以上  //商品名称无效
    let str2 = filterStr($('#shopName').val())
    if (str2.length < 2) {
      $('.shopNameError').show();
      return
    } else {
      $('.shopNameError').hide();
    }

    $('.successMes').show();
    statusName = true
  })

  function successStatus() {
    $('.success_status').show();
  }

  // 返回
  $('.cancelBtn').click(function () {
    $(location).attr('href', '/seller/account_seller_information.html');
  })
})