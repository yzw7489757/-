window.onload=function(){
    $('.tip').hover(function () { 
        $('.personal').show()
     },function () {
        $('.personal').hide()
     })
     $('.tip2').hover(function () { 
        $('.business').show()
     },function () {
        $('.business').hide()
     })
}