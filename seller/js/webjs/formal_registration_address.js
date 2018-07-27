window.onload=function () { 
    var showText = true;
    var timer = null
    $('.more_info').hover(
        function(){
            $('.more_info_style').show()
        },function(){
            timer = setTimeout(function () { 
                $('.more_info_style').hide()
             },1000)
             $('.more_info_style').hover(function () { 
                clearInterval(timer)
              },function () { 
                $('.more_info_style').hide()
            })
        }
    )
    bubble('.more_info',"您企业的合法注册地址","more_info_style")
    // 添加新地址
    $('.add_new_address_a').click(function(e){
        e.preventDefault();
        $('.add_new_address').hide();
        $('.select_existing_address').show();
        $('.Btn').show();
    })
    // 选择现有地址
    $('.select_existing_address_a').click(function(e){
        e.preventDefault();
        $('.add_new_address').show();
        $('.select_existing_address').hide()
        $('.Btn').show();
    })
    // 取消按钮
    $('.cancelBtn').click(function(e){
        e.preventDefault();
        $('.address_editing').show();
        $('.select_existing_address').hide();
        $('.add_new_address').hide();
        $('.Btn').hide();
    })
    // 编辑
    $('.address_editing_a').click(function(e){
        e.preventDefault();
        $('.add_new_address').show();
        $('.Btn').show();
        $('.select_existing_address').hide();
        $('.address_editing').hide();
       
    })
    // main_text
    $('.main_text_btn').click(function(){
        if(showText){
            $('.main_text_btn').find('i').removeClass('a-icon-section-expand')
            $('.main_text').hide()
            showText = false;
        }else{
            $('.main_text_btn').find('i').addClass('a-icon-section-expand')
            $('.main_text').show()
            showText = true
        }          
    })
    $.ajax({
        url: baseUrl + '/GetAddressList',
        method: 'post',
        dataType: "json",
        data: {
            userid: store_id,
            sign:'1'
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                console.log('success!')
               
            } else {
                console.log(decodeURIComponent(res.error))
            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })

 }