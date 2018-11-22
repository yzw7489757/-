$(function () {
  inputctr.public.checkLogin();

  // 初始化存款方式
  $.ajax({
    url: baseUrl + '/InitializaDeposit',
    method: 'post',
    dataType: "json",
    data: {
      userid: amazon_userid,
    },
    success: function (res) {
      console.log(res)
      if (res) {
        inputctr.public.judgeBegaintask('1103');
      }
      if (res.result == 1) {
        $('.showCard').hide()
        var data = res.data
        $('.bank_location').text(decodeURIComponent(data.bank_location))
        $('.account_name').text(decodeURIComponent(data.account_name))
        $('.account_number').text(data.account_number)
      } else {
        $('.showList').hide()
      }
    },
    error: function (res) {
      $('.showList').hide()
    }
  })
  inputctr.public.judgeRecodertask('1103', '检查账号收款付款账户正确性开始');
  // 替换存款方法
  $('.deposit_method').click(function (e) {
    e.preventDefault();
    inputctr.public.judgeFinishtask('1103', link);
  })
  // 管理存款方法
  $('.management_deposit_method').click(function (e) {
    e.preventDefault();
    inputctr.public.judgeFinishtask('1103', link2);
  })
  function link() {
    window.location.href = 'deposit_method_distribution.html';
  }
  function link2() {
    window.location.href = 'deposit_method_manage.html';
  }
})