$(function () {
    var baseUrl = "http://192.168.2.164:8096/QAMZNAPI.asmx";
    var file = null;
    var fd = null;
    // 获取公司徽标
    $.ajax({
        url: baseUrl + '/GetShopLogo',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid
        },
        success: function (res) {
            console.log(res);
            $('.logo').attr('src', res.shopLogoImg)
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
    inputctr.public.initImgUploader($('input[type="file"]')[0],'/GetShopLogo',function(){},function(){alert('success')},'','')

    /*// 设置公司徽标
    $('input').on('change',function (e) {
        //e.preventDefault();
        file = e.target.files[0];
        console.log(file)
        fd = new FormData();
        //console.log($("input[type='file']")[0].files[0])
        fd.append('fileToUpload',file); 
    });
    
    $('button').click(function (e) { 
        e.preventDefault()
        $.ajax({
            url :  baseUrl + '/GetShopLogo',  
            type : 'post',
            data : {
                userid: amazon_userid,
                shopLogoImg:fd
            },
            cache: false,
            processData: false,
            contentType: false,
            success : function (url) {
                console.log(url);
            }
        });
     })*/
})