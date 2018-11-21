$(function () {
    
    var problemContent = $("input[name='attrValue']").val() 
    // 获取关于卖家内容
    $.ajax({
        url: baseUrl + '/GetProblem',
        method: 'post',
        dataType: "json",
        data: {
            userid: amazon_userid,
        },
        success: function (res) {
            console.log(res);
            console.log(decodeURIComponent(res.problemContent))
            problemContent = $("input[name='attrValue']").val(decodeURIComponent(res.problemContent))
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error))
        }
    })
   
    //设置关于卖家内容
    $('button').click(function (e) {
        e.preventDefault(); 
        problemContent = document.getElementById("editattrValue").contentWindow.document.body.innerHTML
        $.ajax({
            url: baseUrl + '/SetProblem',
            method: 'post',
            dataType: "json",
            data: {
                userid: amazon_userid,
                problemContent:problemContent
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