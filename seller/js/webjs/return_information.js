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
    function changeImghover(ulName, className) {

        $(ulName).find('li').hover(function () {
            var index = $(this).index()
            // 
            $(ulName).find('li').eq(index).find('i').addClass(className).siblings().parents('.autoAuthType').find('i').removeClass(className)
            $(ulName).find('li').eq(0).find('i').addClass(className)
        })
    }
    changeImghover('.return_request', 'radio_hover')
    changeImghover('.RMA', 'radio_hover')

    function changeImgclick(ulName, className) {
        $(ulName).find('li').click(function () {
            var index = $(this).index()
            $(ulName).find('li').eq(0).find('i').removeClass(className)
            $(ulName).find('li').eq(index).find('i').addClass(className).siblings().parents('li').removeClass(className)      
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
})