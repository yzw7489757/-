$(function () {
    inputctr.public.checkLogin();
    tag = inputctr.public.getQueryString('tag');
    var showTr = true;
    var dataLength = false;
    var endTime="";
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
    
    inputctr.public.SellerRegisterLoading();
    
    $.ajax({
        url: baseUrl + '/GetDownloadRecord',
        method: 'post',
        dataType: "json",
        data: {
            sellerId: amazon_userid,
            tag: tag
        },
        success: function (res) {
            if (res.result == 1) {
                dataLength = false;
                var data = res.data
                var add = doT.template($('#addArray').text());
                $('#addTmpl').html(add(data));
            }else{
                dataLength = true;
                if((tag==1) || (tag==3) || (tag==7) || (tag==8) || (tag==13) || (tag==14)){
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
                    $('#addTmpl').html(html);
                }else{
                    let html=`
                    <tr>
                        <td>报告类型</td>
                        <td>涵盖的日期范围</td>
                        <td>请求日期</td>
                        <td>报告状态</td>
                    </tr>
                    <tr>
                        <td colspan="4">您尚未请求任何报告。</td>
                    </tr>
                    `
                    $('#addTmpl').html(html);
                }
                
            }
            inputctr.public.SellerRegisterLoadingRemove();
        },
        error: function (res) {
            inputctr.public.SellerRegisterLoadingRemove();
            alert(res.statusText);
        }
    })
    
    $('.downloadBtn').click(function () { 
        
        if(window.sessionStorage && sessionStorage.getItem('timeRange')){
            endTime = sessionStorage.getItem('timeRange');
            sessionStorage.removeItem('timeRange')
        }
        if($('select[name="dataSelect"] option:selected').val() && $('select[name="mouthSelect"] option:selected').val()){
            endTime = $('select[name="dataSelect"] option:selected').val() + $('select[name="mouthSelect"] option:selected').val()  
        }
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
                tag: tag,
                startTime:"",
                endTime:endTime
            },
            success: function (res) {
                var content;
                switch(parseInt(tag)){
                    case 1:content="无在售信息的亚马逊库存";break;
                    case 2:content="库存调整";break;
                    case 3:content="亚马逊库存";break;
                    case 4:content="每日库存历史记录";break;
                    case 5:content="每月库存历史记录";break;
                    case 6:content="库存动作详情";break;
                    case 7:content="库存状况";break;
                    case 8:content="管理亚马逊物流库存";break;
                    case 9:content="亚马逊配送货件";break;
                    case 10:content="所有订单";break;
                    case 12:content="月储存费用";break;
                    case 13:content="费用预览";break;
                    case 14:content="长期仓储费";break;
                    case 15:content="移除订单详情";break;
                }
                if (res.result == 1) {  
                    if(res.url){
                        if((tag==1) || (tag==3) || (tag==7) || (tag==8) || (tag==13) || (tag==14)){
                            var  appendHtml=`
                                            <tr>
                                                <td>${content}</td>
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
                            var appendHtml=`
                                            <tr>
                                                <td>${content}</td>
                                                <td>-</td>
                                                <td>${res.date}</td>
                                                <td>
                                                    <span class="awesomeButton buttonLarge secondaryLargeButton inner_button">
                                                        <span class="button_label loadBtn" path="${decodeURIComponent(res.url)}">下载</span>
                                                    </span>
                                                </td>
                                            </tr>
                                            `
                                            $('#addTmpl tr').eq(0).after(appendHtml);
                        }
                    } else{
                        if((tag==1) || (tag==3) || (tag==7) || (tag==8) || (tag==13) || (tag==14)){
                            var  appendHtml=`
                                            <tr>
                                                <td>${content}</td>
                                                <td>${res.date}</td>
                                                <td>暂无数据</td>
                                            </tr>
                                            `
                                            $('#addTmpl tr').eq(0).after(appendHtml);
                        }else{
                            var appendHtml=`
                                            <tr>
                                                <td>${content}</td>
                                                <td>-</td>
                                                <td>${res.date}</td>
                                                <td>暂无数据</td>
                                            </tr>
                                            `
                                            $('#addTmpl tr').eq(0).after(appendHtml);
                        }
                    } 
                }else{
                    alert("请求下载失败")
                }
            },
            error: function (res) {
                alert(res.statusText);
            }
        })
    })
    $('#addTmpl').on('click',".loadBtn",function () { 
        location.href=$(this).attr('path')
    })
})