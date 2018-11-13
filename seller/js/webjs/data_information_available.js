$(function () {
    inputctr.public.checkLogin();
    var showTr = true;
    var dataLength = false;
    $('.a-container>ol>li').click(function (item) {
        $('.a-container ol li').removeClass('activeOl');
        index = $(this).index();
        $(this).addClass('activeOl');
        $('.a-container>ul>li').eq(index).show().siblings().hide();
        if (index != 1) {
            $('.screenTable').hide();
        } else {
            $('.screenTable').show();
        }
    })

    function GetDownloadRecord(tag) {
        $.ajax({
            url: baseUrl + '/GetDownloadRecord',
            method: 'post',
            dataType: "json",
            data: {
                sellerId: amazon_userid,
                tag: tag
            },
            success: function (res) {
                console.log(res)
                if (res.result == 1) {
                    dataLength = false;
                    var data = res.data
                    var add = doT.template($('#addArray').text());
                    $('#addTmpl').html(add(data));
                }else{
                    if(res.data == null){
                        dataLength = true;
                        let html=`
                        <tr>
                            <td>报告类型</td>
                            <td>请求日期</td>
                            <td>报告状态</td>
                        </tr>
                        <tr>
                            <td colspan="3">您尚未请求任何报告。</td>
                        </tr>
                       `
                       const index = $('.screenTable tr').length;
                       $('#addTmpl').append(html)
                    }
                    
                }
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error))
            }
        })
    }
    GetDownloadRecord(1);

    $('.downloadBtn').click(function () { 
        if(showTr && dataLength){
            const index = $('#addTmpl tr').length;
            if(index==2){
                $("#addTmpl tr:last").remove();
            };
            showTr = false;
        }
        $.ajax({
            url: baseUrl + '/DownloadRecord',
            method: 'post',
            dataType: "json",
            data: {
                sellerId: amazon_userid,
                tag: 1,
                startTime:"",
                endTime:""
            },
            success: function (res) {
                console.log(res)
                if (res.result == 1) {
                    let appendHtml=`
                    <tr>
                        <td>无在售信息的亚马逊库存</td>
                        <td>${res.date}</td>
                        <td>
                            <span class="awesomeButton buttonLarge secondaryLargeButton inner_button">
                                <span class="button_label loadBtn" path="${decodeURIComponent(res.url)}">下载</span>
                            </span>
                        </td>
                    </tr>
                    `
                    $('#addTmpl tr').eq(0).after(appendHtml);
                }else{
                    alert("请求下载失败")
                }
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error))
            }
        })
    })
    $('#addTmpl').on('click',".loadBtn",function () { 
        location.href=$(this).attr('path')
    })
})