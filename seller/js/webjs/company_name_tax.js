window.onload = function () {
    $('.tip').hover(function () {
        $('.personal').show()
    }, function () {
        $('.personal').hide()
    })
    $('.tip2').hover(function () {
        $('.business').show()
    }, function () {
        $('.business').hide()
    })
    function chooseClass (btn1,btn2,className){
        $(btn1).click(function () { 
            $(btn1).addClass(className)
            $(btn2).removeClass(className)
         })
    }
    // $('#select').hover(function(){
    //     $('#select').css({
    //         backgroundColor:' #dcdfe3',
    //     })
    // })
    chooseClass('.a-choose-yes','.a-choose-no','a-button-choose')
    chooseClass('.a-choose-no','.a-choose-yes','a-button-choose')
    chooseClass('.a-choose-business','.a-choose-persinal','a-button-choose')
    chooseClass('.a-choose-persinal','.a-choose-business','a-button-choose')
    
    let arr =  $('.country li');
    for(let i=0;i<arr.length;i++){
        arr[i].addEventListener('click',function(){
            $('#select').text(this.innerText);
            $('.country').hide();
        })
    }
    $('#select').on('click',function(){
        $('.country').show();
        
    })
    addwarn('full_name',2,'必填字段') 
    addwarn('tel',2,'必填字段') 
       /* $('.country').find('li').each(function(i){
            $('.country').find('li').eq(i).click(function () {
                console.log( $('.country').find('li').eq(i).text())
                console.log($('#select').eq(0).innerHTML)    
            })
           
        })*/
    
}

