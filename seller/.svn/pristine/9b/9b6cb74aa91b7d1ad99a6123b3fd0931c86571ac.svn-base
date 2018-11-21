$(function () {
    // 买家位置
    $('.country').change(function () {
        $('.choose_country').text($('.country').find('option:selected').text())
    })

    //  全部   中文
    function Comment(tabAll, tabCh, className) {
        $(tabAll).click(function (e) {
            e.preventDefault();
            $(tabCh).removeClass(className)
            $(tabAll).addClass(className)
        })
    }
    Comment('.tab_click_all', '.tab_click_ch', 'border_bottom7')
    Comment('.tab_click_ch', '.tab_click_all', 'border_bottom7')
})