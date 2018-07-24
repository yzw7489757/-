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
        $('.a-icon-checkbox').addClass('checkbox_click')
    })
    // 默认的自动批准退货申请规则

    function changeImgclick(ulName, classNameHover, classNameClick, input_click) {

        $(`${ulName} li`).click(function (e) {
            e.preventDefault();
            let index = $(this).index();
            // $(ulName).find('li').eq(0).find('i').addClass(classNameClick)
            $(ulName).find('.a-icon-radio').removeClass(classNameClick); //先删除所有的
            $(ulName).find('input').removeClass(input_click); //先删除所有的
            $(ulName).find('li').eq(index).find('i').addClass(classNameClick);
            $(ulName).find('li').eq(index).find('input').addClass(input_click);

        })
        $(`${ulName} li`).hover(function (e) {
            e.preventDefault();
            let index = $(this).index();
            $(ulName).find('.a-icon-radio').removeClass(classNameHover); //先删除所有的
            // $(ulName).find('li').eq(0).find('i').addClass(classNameHover)
            $(ulName).find('li').eq(index).find('i').addClass(classNameHover);
        })
    }
    changeImgclick('.return_request', 'radio_hover', 'radio_click', 'input_click')
    changeImgclick('.RMA', 'radio_hover', 'radio_click', 'input_click')


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

    // 无法退还商品的退款 删除
    function bindRemove( target) {
        $(`${target} li .removeReason`).off('click').on('click', function () {
            let index = $(this).parents('li').attr('data-index');
            $(`${target} li`).eq(index).remove();
            let ul = $(`${target} li`);
            for (let i = 0; i < ul.length; i++) {
                ul.eq(i).attr('data-index', i)
            }
        })
    }

    // 无法退还商品的退款 点击添加按钮
    function addBtn(btnName, ulName, deleteBtn) {
        $(btnName).click(function () {
            var str = ($(ulName).find('p')[0].innerText).replace(/\s+/g, "")
            deteleList(deleteBtn, str)
            bindRemove(deleteBtn)
        })
    }
    addBtn('.return_add', '#choose_why', '.deleteBtn')

    function addBtn2(btnName, ulName, deleteBtn) {
        $(btnName).click(function () {
            var str2 = ($(ulName).find('input').val()).replace(/\s+/g, "")
            deteleList(deleteBtn, str2)
            bindRemove(deleteBtn)
        })
    }
    addBtn2('.addition_add', '#choose_type', '.deleteBtn2')
})