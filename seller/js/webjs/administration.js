$(function () {
    $('.ski-btn').click = function (e) {
        e.preventDefault();
    }
    // 注册
    $('.registerBtn').click(function (e) {
        e.preventDefault()
        $(location).attr('href', '/seller/administration_submit.html');
    })
    // 取消
    $('.cancelBtn').click(function (e) {
        e.preventDefault()
        $(location).attr('href', '/seller/account_information.html');
    })
})