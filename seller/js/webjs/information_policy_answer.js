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
//不要放在$(function(){ 里面 }) 因为这是闭包，外面取不到值。
//申明 teattrValue，具体信息看text-edit.js的AMZTextEditor方法;
//调用方法 teattrValueInit("iframe的id","初始值文本框")
var teattrValue = new AMZTextEditor("0_attrValue",
    document.getElementById("edit0_attrValue"),
    document.getElementById("tabHolderDesignattrValue_0"),
    document.getElementById("tabHolderCodeattrValue_0"),
    document.getElementById("toolbar2attrValue_0"),
    0, 0,
    document.getElementById("text_component_0_attrValue"),
    "Enter a URL", "", "");

if (window.addEventListener) {
    window.addEventListener("load", teattrValueInit("edit0_attrValue","input[name='0_attrValue']"), true);
} else if (window.attachEvent) {
    window.attachEvent("onload", teattrValueInit("edit0_attrValue","input[name='0_attrValue']"));
}