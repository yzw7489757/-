$(function () {
    // 搜索
    $('.cb-searchtool-button').click(function (e) {
        e.preventDefault();
        //$('.country').find('option:selected').text()
        $('.as-heading-country').text($('.country').find('option:selected').text())
        $('.as-heading-country-a').text($('.country').find('option:selected').text())
        $('.as-heading-search').text($('.search').find('option:selected').text())
    })
    // 更多  更少
    function changeLi(showClass, hideClass, className) {
        $(showClass).click(function (e) {
            e.preventDefault();
            $(hideClass).show()
            $(showClass).hide()
            $(className).show()
        })
    }
    changeLi('.more', '.less', '.changeLi')
})