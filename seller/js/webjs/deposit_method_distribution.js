window.onload = function() {
  $(".update_deposit").click(function(e) {
    e.preventDefault();
    $(".table_one").hide();
    $(".table_two").show();
    $('.table_three').show();
    $('.table_four').show();
  });
  $('.selectNowHaveSaleStyle').click(function (e) { 
    e.preventDefault();
    $(".table_one").show();
    $(".table_two").hide();
    $('.table_three').hide();
    $('.table_four').hide();
  });
  let timer = null;
  $('.hasModel').hover(function(){
    clearTimeout(timer)
    $('.model').fadeIn(200).show();
  },function(){
    timer = setTimeout(function(){
      $('.model').fadeOut(200).hide();
    },300)
  })
  // var beforeValue = '';//记录上一次的值
  // $('select[name=bankCountrySelect]').click(function(){
  //   beforeValue = $('select[name=bankCountrySelect]').val();
  // })
  $('select[name=bankCountrySelect]').change(function(){
        $('.width99.a-spacing-top-base').hide()
        $('#agreement').show();
        let selectVal = $('select[name=bankCountrySelect]').val()
    // console.log(beforeValue == selectVal);//没变就return
    switch(selectVal){
      case 'string:CN': //中国
        $('.chinaese').show();
      break;
      case 'string:CA': //加拿大
        $('#hasUser').show();
        $('#organization').show();
        $('#transfer').show();
        $('#bankIds').show();
        $('#againBankIds').show();
        $('#userType').show();
      break;
      case 'string:LU': //卢森堡
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:IN': //印度
        $('#hasUser').show();
        $('#userType').show();
        $('#bankIds').show();
        $('#againBankIds').show();
        $('#ifsc').show();
        break;
      case 'string:CY': //塞浦路斯
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:MX': //墨西哥
        $('#hasUser').show();
        $('#userType').show();
        $('#bankCode').show();
        $('#userType').show();
        $('#bankIds').show();
        $('#againBankIds').show();
        $('#agreement').hide();
      break;
      case 'string:AT': //奥地利
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:GR': //希腊
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:DE': //德国
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:IT': //意大利
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:SK': //斯洛伐克
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:SI': //斯洛文尼亚
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:NZ': //新西兰
        $('#hasUser').show();
        $('#bsb').show();
        $('#bankIds').show();
        $('#againBankIds').show();
      break;
      case 'string:BE': //比利时
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:FR': //法国
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:AU': //澳大利亚
        $('#hasUser').show();
        $('#bsb').show();
        $('#bankIds').show();
        $('#againBankIds').show();
      break;
      case 'string:IE': //爱尔兰
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:EE': //爱沙尼亚
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:US': //美国
          $('.us').show();
      break;
      case 'string:FI': //芬兰
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:GB': //英国
        $('#hasUser').show();
        $('#bankCodeType').show();
        $('#bankIds').show();
        $('#againBankIds').show();
      break;
      case 'string:NL': //荷兰
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:PT': //葡萄牙
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:ES': //西班牙
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;
      case 'string:HK': //香港
        $('#hasUser').show();
        $('#liquidation').show();
        $('#branchBankCode').show();
        $('#bankIds').show();
        $('#againBankIds').show();
        $('#readSample').show();
      break;
      case 'string:MT': //马耳他
        $('#hasUser').show();
        $('#bic').show();
        $('#intBank').show();
        $('#iban').show();
      break;

    }
  });

  $('.table_three input[type=radio][name=license]').change(function() {
    if(this.value == 'yes'){
        $('#cnaps').show();
    }else{
      $('#cnaps').hide();
    }
  });
  $('.table_three input[type=radio][name=enterprise]').change(function() {
    if(this.value == 'yes'){
        $('.licenseId').show();
        $('.userId').hide();
      }else{
        $('.licenseId').hide();
        $('.userId').show();
    }
  });
  $('.table_three input[type=radio][name=bankId]').change(function() {
    if(this.value == 'yes'){
        $('.bankUser').show();
        $('.credit').hide();
      }else{
        $('.bankUser').hide();
        $('.credit').show();
    }
  });
};
