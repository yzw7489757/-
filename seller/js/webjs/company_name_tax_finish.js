$(function () { 
    if(window.sessionStorage){
        $('.full_name').val(sessionStorage.getItem('full_name'))
        $('.tel_input').val(sessionStorage.getItem('tel_input'))
        $('.tel_input2').val(sessionStorage.getItem('tel_input2'))
        $('.signature').val(sessionStorage.getItem('signature'))
        $('.todayInput').val(sessionStorage.getItem('todayInput'))
         // 右国籍
        $('.nationality').val(sessionStorage.getItem('nationality'))
        // 永久地址
        $('.choose_country_ever_p').val(sessionStorage.getItem('choose_country_ever_p'))
        // 国籍
        $('.choose_country_nationality').val(sessionStorage.getItem('choose_country_nationality'))
        $('.detali').val(`${sessionStorage.getItem('city_town_input')} ${sessionStorage.getItem('province_input')}`)
        $('.detali2').val(`${sessionStorage.getItem('city_town_input2')} ${sessionStorage.getItem('province_input2')}`)
    }
 })