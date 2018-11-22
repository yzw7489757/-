$(function () {
    inputctr.public.checkLogin();
    var showTitle = true
    if(window.sessionStorage && sessionStorage.getItem('finishedInfo') && sessionStorage.getItem('companyInfo')){
        $('.account_setting_66').hide()
        $('.account_setting_100').show()
        $('.unfinishedBtn').show()
        $('.finishedBtn').show()
        $('.infoWeb').show()
        $('.messageboxsuccess').show()
        $('.finishBtn').show()
        $('.go_on_Btn').hide()
        $('.company_website').text(sessionStorage.getItem('company_website'))
        $('.website_categories').text(sessionStorage.getItem('website_categories'))
        $('.site_subcategories').text(sessionStorage.getItem('site_subcategories'))
        sessionStorage.removeItem('finishedInfo')
        sessionStorage.removeItem('companyInfo')
    }
    $('.usetitle').click(function (e) {
        e.preventDefault();
        if (showTitle) {   
            $('.useContent').show()
            showTitle = false
        } else {
            $('.useContent').hide()
            showTitle = true
        }
    })
    $('.stoptitle').click(function (e) {
        e.preventDefault();
        if (showTitle) {   
            $('.stopContent').show()
            showTitle = false
        } else {
            $('.stopContent').hide()
            showTitle = true
        }
    })
    $('.updatetitle').click(function (e) {
        e.preventDefault();
        if (showTitle) {   
            $('.updateContent').show()
            showTitle = false
        } else {
            $('.updateContent').hide()
            showTitle = true
        }
    })

    // 公司信息
    $.ajax({
        url: baseUrl + '/GetUserTax',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
        },
        success: function (res) {
            console.log(res)
            if (res.result == 1) {
                var data = res.data;
                $('.company_name').text(decodeURIComponent(res.company_name))
                $('.detailAddress').text(`${decodeURIComponent(data.address)} ${decodeURIComponent(data.address2)}`)
                $('.city').text(decodeURIComponent(data.city))
                $('.province').text(decodeURIComponent(data.province))
                $('.zipcode').text(decodeURIComponent(data.zipcode))
                $('.country').text(decodeURIComponent(data.country))
                $('.phone').text(decodeURIComponent(data.phone))
                if(window.sessionStorage){
                    sessionStorage.setItem('company_name',res.company_name)
                    sessionStorage.setItem('address_id',data.address_id)
                }
            } else {
                console.log(decodeURIComponent(res.error))
            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
    $('.link_unfinished').click(function () { 
        $(window).attr('location', './seller/administration_submit.html')
        if(window.sessionStorage){
            sessionStorage.setItem('changeInfo',1)
        }
     })
})