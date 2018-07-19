$(function () {
    dropdown_box(".day", "#choose_day");
    dropdown_box(".why", "#choose_why");
    dropdown_box(".type", "#choose_type");
    // tab切换
    $('.headList li').click(function () {
        var index = $(this).index()
        $('.headList li').eq(0).removeClass('activeStyle')
        $(this).addClass('activeStyle').siblings().removeClass('activeStyle')
        $('.mainList>li').eq(index).removeClass('none').siblings().addClass('none')
    })
    // 电子邮件格式
    $('.a-icon-checkbox').hover(function () {
        $('.a-icon-checkbox').addClass('checkbox_hover')
    }, function () {
        $('.a-icon-checkbox').removeClass('checkbox_hover')
    })
    $('.a-icon-checkbox').click(function () {
        $('.a-icon-checkbox').addClass('checkbox_hover')
    })
    // 默认的自动批准退货申请规则
    
    function changeImgclick(ulName, className) {
        $(`${ulName} li`).click(function (e) {
            e.preventDefault();
            var index = $(this).index();
            $(ulName).find('.a-icon-radio').removeClass(className);//先删除所有的
            $(ulName).find('li').eq(0).find('i').addClass(className)
            $(ulName).find('li').eq(index).find('i').addClass(className);      
        })
        $(`${ulName} li`).hover(function (e) {
            e.preventDefault();
            var index = $(this).index();
            $(ulName).find('.a-icon-radio').removeClass(className);//先删除所有的
            $(ulName).find('li').eq(0).find('i').addClass(className)
            $(ulName).find('li').eq(index).find('i').addClass(className);      
        })
    }
    changeImgclick('.return_request', 'radio_hover')
    changeImgclick('.RMA', 'radio_hover')



    // 添加新规则
    $('.ruleBtn').click(function () { 
        $('.old_rule').hide();
        $('.new_rule').show();
     })
    $('.setting_adjustment a').click(function (e) { 
        e.preventDefault();
        $('.setting_adjustment').hide();
        $('.delete_adjustment').show();
        $('.setting_address').show();
    })

   // 选择原因 添加
    $('.why ul li').click(function(){
        var index = $(this).index();
        console.log($(this).innerText)
    })   
    
})