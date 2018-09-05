$(function () {
    var baseUrl = "http://192.168.2.164:8096/QAMZNAPI.asmx"
    var aboutSellerContent = $("input[name='attrValue']").val() 
    // 获取卖家保密帮助内容
    $.ajax({
        url: baseUrl + '/GetPrivacyPolicy',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
        },
        success: function (res) {
            console.log(res);
            console.log(decodeURIComponent(res.PrivacyPolicyContent))
            PrivacyPolicyContent = $("input[name='attrValue']").val(decodeURIComponent(res.PrivacyPolicyContent))
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
   
    //设置卖家保密帮助内容
    $('.saveBtn').click(function (e) {
        e.preventDefault(); 
        PrivacyPolicyContent = document.getElementById("editattrValue").contentWindow.document.body.innerHTML
        $.ajax({
            url: baseUrl + '/SetPrivacyPolicy',
            method: 'post',
            dataType: "json",
            data: {
                userid: amazon_userid,
                PrivacyPolicyContent:PrivacyPolicyContent
            },
            success: function (res) {
                console.log(res);
                if(res.result == 1){
                    $('.submitInfo').show()
                } 
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error))
            }
        })
    })
})