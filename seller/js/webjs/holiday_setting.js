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
    $('.readyCheck').val(['0'])
    
  });

  $('.stopCheck').click(function(){
    $('.tostopCheck').val(['1'])
  })
}