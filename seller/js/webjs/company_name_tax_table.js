$(function () { 
    if(window.sessionStorage){
        // 选中checkbox
        if(sessionStorage.getItem('inputVal')){
            let getVal = sessionStorage.getItem('inputVal')
            let getStr = JSON.parse(getVal)
            $('.full_name').val(getStr.full_name)
            $('.tel_input').val(getStr.tel_input)
            $('.tel_input2').val(getStr.tel_input2)
            $('.signature').val(getStr.signature)
            $('.todayInput').val(getStr.todayInput)
             // 右国籍
            if(getStr.tel_input2){
                $('.nationality').val(getStr.nationality)
            }
            // 永久地址
            $('.choose_country_ever_p').val(getStr.choose_country_ever_p)
            // 国籍
            $('.choose_country_nationality').val(getStr.choose_country_nationality)
            $('.detali').val(`${getStr.city_town_input} ${getStr.province_input}`)
            $('.detali2').val(`${getStr.city_town_input2} ${getStr.province_input2}`)   
        } 
        // 未选中checkbox
        if(sessionStorage.getItem('inputVal2')){
            let getVal = sessionStorage.getItem('inputVal2')
            let getStr = JSON.parse(getVal)
            $('.full_name').val(getStr.full_name)
            $('.tel_input').val(getStr.tel_input)
            $('.tel_input2').val(getStr.tel_input2)
             // 右国籍
             if(getStr.tel_input2){ 
                $('.nationality').val(getStr.right_country_p)
             }
            // 永久地址
            $('.choose_country_ever_p').val(getStr.choose_country_ever_p)
            // 国籍
            $('.choose_country_nationality').val(getStr.choose_country_nationality)
            $('.detali').val(`${getStr.city_town_input} ${getStr.province_input}`)
            $('.detali2').val(`${getStr.city_town_input2} ${getStr.province_input2}`)  
        } 
    }
    if(window.sessionStorage){
        sessionStorage.setItem('updateTax','updateTax')
    }
 })