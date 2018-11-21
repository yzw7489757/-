$(function () {
    if(window.sessionStorage && sessionStorage.getItem('changeInfo')){
        $('.account_setting_100').show()
        $('.account_setting_66').hide()
        sessionStorage.removeItem('changeInfo')
    }
    // 公司网站 URL：
    var company_website = $('.company_website').val().trim()
    // 网站类别：
    var website_categories = $('.embuWebsiteInfo_WebsiteUrlCategory option:selected').text();
    // 网站子类别：
    var site_subcategories = $('.embuWebsiteInfo_WebsiteUrlSubCategory option:selected').text();

    $('.button_label_save').click(function () {
        if ($('.company_website').val() != '') {
            $(window).attr('location', './seller/administration_submit.html')
        }
    })
    $('.submitBtn').click(function () {
        $('.errinfo').hide()
        $('.company_website_tr').removeClass('errBgcolor')
        $('.scui-alert').hide()
        // 公司网站 URL：
        company_website = $('.company_website').val().trim()
        // 网站类别：
        website_categories = $('.embuWebsiteInfo_WebsiteUrlCategory option:selected').text();
        // 网站子类别：
        site_subcategories = $('.embuWebsiteInfo_WebsiteUrlSubCategory option:selected').text();
        if (company_website) {
            $.ajax({
                url: baseUrl + '/',
                method: 'post',
                dataType: "json",
                data: {
                    userid: company_website,
                    address: website_categories,
                    address2: site_subcategories,
                },
                success: function (res) {
                    console.log(res)
                    if (res.result == 1) {
                        if (window.sessionStorage) {
                            sessionStorage.setItem('successInfo', '1')
                            sessionStorage.setItem('company_website', site_subcategories)
                            sessionStorage.setItem('website_categories', site_subcategories)
                            sessionStorage.setItem('site_subcategories', site_subcategories)
                            sessionStorage.setItem('finishedInfo', 'finishedInfo')

                        }
                        $(location).attr('href', '/seller/administration_submit.html')
                    } else {
                        console.log(decodeURIComponent(res.error))
                    }
                },
                error: function (res) {
                    console.log(decodeURIComponent(res.error))
                }
            })
        } else {
            $('.errinfo').show()
            $('.company_website_tr').addClass('errBgcolor')
            $('.scui-alert').show()
        }


    })
})