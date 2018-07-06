window.onload = function(){
  let timer = null;
  $('.a-declarative').hover(function(){
    clearTimeout(timer)
    $('#model').fadeIn(200).show();
  },function(){
    timer = setTimeout(function(){
      $('#model').fadeOut(200).hide();
    },300)
   
  })
  $('.a-icon-close').click(function(){
    $('#model').hide();
  })
  $('.startCheck').click(function(){
    $('.startCheck').addClass('active_style')
    $('.stopCheck').removeClass('active_style')
    $('.readyCheck').attr('checked',true)
    $('.tostopCheck').attr('checked',false);
  });

  $('.stopCheck').click(function(){
    $('.stopCheck').addClass('active_style')
    $('.startCheck').removeClass('active_style')
    $('.tostopCheck').attr('checked',true)
    $('.readyCheck').attr('checked',false);
  })
}