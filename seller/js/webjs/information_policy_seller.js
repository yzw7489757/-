$(function () {
    var baseUrl = "http://192.168.2.164:8096/QAMZNAPI.asmx"
    var aboutSellerContent = $("input[name='attrValue']").val() 
    // 获取关于卖家内容
    $.ajax({
        url: baseUrl + '/GetAboutSeller',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
        },
        success: function (res) {
            console.log(res);
            console.log(decodeURIComponent(res.aboutSellerContent))
            aboutSellerContent = $("input[name='attrValue']").val(decodeURIComponent(res.aboutSellerContent))
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
   
    //设置关于卖家内容
    $('.saveBtn').click(function (e) {
        e.preventDefault(); 
        aboutSellerContent = document.getElementById("editattrValue").contentWindow.document.body.innerHTML
        $.ajax({
            url: baseUrl + '/SetAboutSeller',
            method: 'post',
            dataType: "json",
            data: {
                userid: amazon_userid,
                aboutSellerContent:aboutSellerContent
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