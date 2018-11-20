$(function(){
    inputctr.public.checkLogin();
    var status_nav = $('.status-nav');
    var status_tab = $('.status-tab');
    var step = inputctr.public.getQueryString('sign');
    var sellerID = {
        seller_id:amazon_userid
    }
    var ViewData = {
        seller_id:amazon_userid,
        pageSize:20,
        currentPage:1
    }
    if(step){
        status_nav.find('li').eq(step-1).addClass('active').siblings().removeClass('active');
        status_tab.eq(step-1).removeClass('hide').siblings().addClass('hide');
        if(step == 2){
            Performance();
            status_nav.find('li').eq(1).addClass('clicked');
        }
        if(step == 3){
            feedbackRate();
            ViewFeedback();
            status_nav.find('li').eq(2).addClass('clicked');
        }
    }else{
        status_nav.find('li').eq(0).addClass('active').siblings().removeClass('active');
        status_tab.eq(0).removeClass('hide').siblings().addClass('hide');
    }
    status_nav.on('click', 'li', function(event) {
        event.preventDefault();
        if($(this).hasClass('active')){
            return;
        }
        $(this).addClass('active').siblings().removeClass('active');
        status_tab.eq($(this).index()).removeClass('hide').siblings().addClass('hide');
        if($(this).hasClass('clicked')){
            return;
        }
        if($(this).index() == 1){
            Performance();
            $(this).addClass('clicked');
        }
        if($(this).index() == 2){
            feedbackRate();
            ViewFeedback();
            $(this).addClass('clicked');
        }    
    })
    // 星级计算
    function star(star){if(star==0){review="a-star-0"}if(star==1){review="a-star-1"}if(star==2){review="a-star-2"}if(star==3){review="a-star-3"}if(star==4){review="a-star-4"}if(star==5){review="a-star-5"}if(star>0&&star<1){review="a-star-0-5"}if(star>1&&star<2){review="a-star-1-5"}if(star>2&&star<3){review="a-star-2-5"}if(star>3&&star<4){review="a-star-3-5"}if(star>4&&star<5){review="a-star-4-5"}}
    
    // 买家反馈
    //反馈管理器
    function feedbackRate(){
        inputctr.public.AjaxMethods('POST', baseUrl + '/SellerFeedbackAll', {json:JSON.stringify(sellerID)}, function (data) {
            var seller_feedback_html = ''
            if(data.result == 1) {
                seller_feedback_html = '<tr>'+
                                            '<td class="order-tip">'+
                                                '<span class="a-text-bold">好评</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_30.positive+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_90.positive+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_365.positive+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback.positive+'</span>'+
                                            '</td>'+
                                        '</tr>'+
                                        '<tr>'+
                                            '<td class="order-tip">'+
                                                '<span class="a-text-bold">中评</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_30.neutral+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_90.neutral+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_365.neutral+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                               ' <span>'+data.data.feedback.neutral+'</span>'+
                                            '</td>'+
                                        '</tr>'+
                                        '<tr>'+
                                            '<td class="order-tip">'+
                                                '<span class="a-text-bold">差评</span>'+
                                            '</td>'+
                                            '<td>'+
                                               ' <span>'+data.data.feedback_30.negative+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_90.negative+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_365.negative+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback.negative+'</span>'+
                                            '</td>'+
                                        '</tr>'+
                                        '<tr>'+
                                            '<td class="order-tip">'+
                                                '<span class="a-text-bold">计数</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_30.feedback+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_90.feedback+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback_365.feedback+'</span>'+
                                            '</td>'+
                                            '<td>'+
                                                '<span>'+data.data.feedback.feedback+'</span>'+
                                            '</td>'+
                                        '</tr>'
                $('.seller-feedback-table').find('tbody').html(seller_feedback_html);
            }else{
                alert(data.error);
            }
        }, function (error) {
            alert(error.statusText);
        })
    }
    //View Current Feedback
    var view_feedback_table = $('.view-feedback-table');
    function ViewFeedback(){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/SellerFeedback', {json:JSON.stringify(ViewData)}, function (data) {
            var view_feedback_html = '';
            inputctr.public.judgeBegaintask('1403');
            if(data.result == 1) {
                for(var i=0;i<data.data.length;i++){
                    star(data.data[i].rate);
                    var reply_s = (data.data[i].is_reply == 0) ? '' : 'hide';
                    var Delete_s = (data.data[i].is_reply == 0) ? 'hide' : '';
                    var on_Time = (data.data[i].delivery == 1) ? 'Yes' : 'No';
                    var Describe = (data.data[i].described == 1) ? 'Yes' : 'No';
                    var Service = (data.data[i].service == 1) ? 'Yes' : 'No';
                    var reply = (Number(data.data[i].reply) == 0) ? '' : data.data[i].reply;
                    view_feedback_html += '<tr>'+
                                            '<td>'+data.data[i].createtime+'</td>'+
                                            '<td>'+
                                                '<i class="a-icon a-icon-star '+review+'"></i>'+
                                            '</td>'+
                                            '<td class="Comments-td">'+
                                                '<div class="a-text-left a-spacing-micro">'+data.data[i].comment+'</div>'+
                                                '<div class="a-text-left">'+
                                                    '<button class="secondaryAUIButton a-size-mini table-button Respond-click '+reply_s+'">Respond</button>'+
                                                '</div>'+
                                                '<div class="a-text-left reply '+Delete_s+'" style="color:#8a8a8b"><span>'+reply+'</span> &nbsp;<button class="secondaryAUIButton a-size-mini table-button Delete-click '+Delete_s+'" fld_id='+data.data[i].fld_id+'>Delete</button></div>'+
                                            '</td>'+
                                            '<td>'+on_Time+'</td>'+
                                            '<td>'+Describe+'</td>'+
                                            '<td>'+Service+'</td>'+
                                            '<td><a href="javascript:;">'+data.data[i].order_no+'</a></td>'+
                                            '<td>'+data.data[i].rater_email+'</td>'+
                                            '<td>'+data.data[i].rater_role+'</td>'+
                                        '</tr>'+
                                        '<tr class="response-tr">'+
                                            '<td colspan="4" class="response-td-left">'+
                                                'Enter Your Response:'+
                                            '</td>'+
                                            '<td colspan="5" class="response-td-right">'+
                                                '<textarea name="Respond" class="Response-content"></textarea>'+
                                                '<button class="cancel-button">'+
                                                    '<span class="button-label">Cancel</span>'+
                                                '</button>'+
                                                '<button class="submit-button" fld_id='+data.data[i].fld_id+'>'+
                                                    '<span class="button-label">Submit</span>'+
                                                '</button>'+
                                            '</td>'+
                                        '</tr>'
                }
                $('.view-feedback-table').find('tbody').html(view_feedback_html)
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            inputctr.public.SellerRegisterLoadingRemove();
            alert(error.statusText);
        })
    }
    //回复
    view_feedback_table.on('click', '.Respond-click', function(e) {
        $(this).parents('tr').next('.response-tr').fadeIn(150);
        inputctr.public.judgeRecodertask('1403','针对订单反馈进行评价开始');
    })
    var submit_flag = true;
    // 取消
    view_feedback_table.on('click', '.cancel-button', function(e) {
         if(!submit_flag){
            return;
        }
        $(this).parents('tr').fadeOut(150);
    })
    // 提交回复
    view_feedback_table.on('click', '.submit-button', function(e) {
        if(!submit_flag){
            return;
        }
        var fld_id = $(this).attr('fld_id');
        var that = $(this);
        var content = $(this).siblings('.Response-content').val().trim();
        if(content == ''){
            $(this).siblings('.Response-content').addClass('error-border');
            return;
        }else{
            $(this).siblings('.Response-content').removeClass('error-border');
            $(this).parents('.response-tr').css({opacity: '0.5'});
            submit_flag = false;
        }
        var ReplyData = {
            id:fld_id,
            content:content
        }
        inputctr.public.AjaxMethods('POST', baseUrl + '/FeedbackReply', {json:JSON.stringify(ReplyData)}, function (data) {
            if(data.result == 1) {
               submit_flag = true;
               that.parents('.response-tr').css({opacity: '1'}).fadeOut(150).prev('tr').find('.Respond-click').addClass('hide').parent().siblings('.reply').removeClass('hide').children('span').html(ReplyData.content).siblings('.Delete-click').removeClass('hide');
               that.siblings('.Response-content').val('');
               inputctr.public.judgeFinishtask('1403');
            }else{
                alert(data.error);
            }
        }, function (error) {
            alert(error.statusText);
        })
    })
    // 删除回复
    var Delete_flag = true;
    view_feedback_table.on('click', '.Delete-click', function(e) {
        if(!Delete_flag){
            return;
        }
        var deleteData = {
            id:$(this).attr('fld_id')
        }
        Delete_flag = false;
        var that = $(this);
        inputctr.public.AjaxMethods('POST', baseUrl + '/FeedbackReplyDel', {json:JSON.stringify(deleteData)}, function (data) {
            if(data.result == 1) {
               Delete_flag = true;
               that.parent('.reply').fadeOut('150',function(){
                    that.parent('.reply').prev().children('.Respond-click').removeClass('hide');
               })
            }else{
                alert(data.error);
            }
        }, function (error) {
            alert(error.statusText);
        })
    })
    // 绩效指标
    function Performance(){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/SellerRating', {json:JSON.stringify(sellerID)}, function (data) {
            if(data.result == 1) {
               checkList(data.data.performance);
               orderDefect(data.data.ODR60,data.data.ODR90);
               sellerIndex(data.data.rate7,data.data.rate30);
               followRate(data.data.trace);
               contactRate(data.data.msg7,data.data.msg30,data.data.msg90);
               ReturnGoods(data.data.discontent,data.data.dis7,data.data.dis30,data.data.dis60);
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            inputctr.public.SellerRegisterLoadingRemove();
            alert(error.statusText);
        })
    }
    //绩效检查表
    function checkList(data){
        var check_html = '';
        check_html = '<li>'+
                        '<p class="a-spacing-medium">订单缺陷率</p>'+
                        '<div class="rate-box clear_both">'+
                            '<div class="fl">'+
                                '<img src="img/rate.jpg" />'+
                            '</div>'+
                            '<div class="fl target-rate a-size-mini">'+
                                '<span class="rate-number">'+data.rate_odr+'%</span>'+
                                '<span class="term">（长期）</span>'+
                                '<span class="Range">目标 < 1%</span>'+
                            '</div>'+
                        '</div>'+
                    '</li>'+
                    '<li>'+
                        '<p class="a-spacing-medium">取消率</p>'+
                        '<div class="rate-box clear_both">'+
                            '<div class="fl">'+
                                '<img src="img/rate.jpg" />'+
                            '</div>'+
                            '<div class="fl target-rate a-size-mini">'+
                               ' <span class="rate-number">'+data.rate_cancel+'%</span>'+
                                '<span class="term">（'+data.rate_cancel_days+'天）</span>'+
                                '<span class="Range">目标 < '+data.rate_cancel_max+'%</span>'+
                            '</div>'+
                        '</div>'+
                    '</li>'+
                    '<li>'+
                        '<p class="a-spacing-medium">迟发率</p>'+
                        '<div class="rate-box clear_both">'+
                            '<div class="fl">'+
                                '<img src="img/rate.jpg" />'+
                            '</div>'+
                            '<div class="fl target-rate a-size-mini">'+
                                '<span class="rate-number">'+data.rate_late+'%</span>'+
                                '<span class="term">（'+data.rate_late_days+'天）</span>'+
                                '<span class="Range">目标 < '+data.rate_late_max+'%</span>'+
                            '</div>'+
                        '</div>'+
                    '</li>'
        $('.check-list').html(check_html);
    }
    //订单缺陷率
    function orderDefect(data60,data90){
        var defect_html = '';
        defect_html = '<thead>'+
                            '<tr>'+
                                '<td colspan="5">'+
                                    '<div class="thead a-text-bold">'+
                                        '订单缺陷率'+
                                    '</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<thead class="cycle-thead">'+
                            '<tr>'+
                                '<td></td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">短期</div>'+
                                    '<div class="cycle-date">（'+data60.date+'）</div>'+
                                    '<div class="order-num">订单：'+data60.orders+'</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">长期</div>'+
                                    '<div class="cycle-date">（'+data90.date+'）</div>'+
                                    '<div class="order-num">订单：'+data90.orders+'</div>  '+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">目标</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<tbody>'+
                            '<tr>'+
                                '<td class="a-text-bold order-tip">订单缺陷率</td>'+
                                '<td>'+
                                    '<span class="a-text-bold">'+data60.odr+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span class="a-text-bold">'+data90.odr+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span class="a-text-bold">< 1%</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip"> <span>—</span> <span class="a-text-bold">负面反馈率</span></td>'+
                                '<td>'+
                                    '<span>'+data60.negative+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data90.negative+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>--</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip"> <span>—</span> <span class="a-text-bold">已提交的亚马逊商城交易保障索赔率</span></td>'+
                                '<td>'+
                                    '<span>'+data60.claim+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data90.claim+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>--</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip"> <span>—</span> <span class="a-text-bold">服务性拒付率</span></td>'+
                                '<td>'+
                                    '<span>'+data60.refusal+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data90.refusal+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>--</span>'+
                                '</td>'+
                            '</tr>'+
                        '</tbody>'
        $('.order-defect-table').html(defect_html)
    }
    // 最近卖家指标数据
    function sellerIndex(data7,data30){
        var index_html = '';
        index_html = '<thead>'+
                            '<tr>'+
                                '<td colspan="5">'+
                                    '<div class="thead a-text-bold">'+
                                        '最近卖家指标数据'+
                                    '</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<thead class="cycle-thead">'+
                            '<tr>'+
                                '<td></td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">7天</div>'+
                                    '<div class="cycle-date">（'+data7.date+'）</div>'+
                                    '<div class="order-num">订单：'+data7.orders+'</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">30天</div>'+
                                    '<div class="cycle-date">（'+data30.date+'）</div>'+
                                    '<div class="order-num">订单：'+data30.orders+'</div>  '+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">目标</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<tbody>'+
                            '<tr>'+
                                '<td class="a-text-bold order-tip">取消率</td>'+
                                '<td>'+
                                    '<span>'+data7.cancel+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data30.cancel+'%</span>'+
                                '</td>'+
                               ' <td>'+
                                    '<span>< 2.5%</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip"><span class="a-text-bold">迟发率</span></td>'+
                                '<td>'+
                                   ' <span>'+data7.late+'%</span>'+
                               ' </td>'+
                                '<td>'+
                                    '<span>'+data30.late+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>< 4%</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip"><span class="a-text-bold">退款率</span></td>'+
                                '<td>'+
                                    '<span>'+data7.refund+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data30.refund+'%</span>'+
                                '</td>'+
                                '<td>'+
                                   ' <span>--</span>'+
                                '</td>'+
                            '</tr>'+
                        '</tbody>'
        $('.seller-defect-table').html(index_html);
    }
    //有效追踪率 
    function followRate(data){
        var follow_html = '';
        follow_html = '<thead>'+
                            '<tr>'+
                                '<td colspan="5">'+
                                    '<div class="thead">'+
                                        '<span class="a-text-bold">有效追踪率</span>  &nbsp;（仅限卖家自配送订单）'+
                                    '</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<thead class="cycle-thead">'+
                            '<tr>'+
                                '<td></td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">7天</div>'+
                                    '<div class="cycle-date">（'+data.date7+'）</div>'+
                                   ' <div class="order-num">订单：'+data.orders7+'</div>'+
                               ' </td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">30天</div>'+
                                    '<div class="cycle-date">（'+data.date30+'）</div>'+
                                    '<div class="order-num">订单：'+data.orders30+'</div>  '+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">目标</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<tbody>'+
                            '<tr>'+
                                '<td class="a-text-bold order-tip">有效追踪率</td>'+
                                '<td>'+
                                    '<span>'+data.trace7+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data.trace30+'%</span>'+
                                '</td>'+
                                '<td>'+
                                   ' <span class="a-text-bold">> 95%</span>'+
                                '</td>'+
                            '</tr>'+
                        '</tbody>'
        $('.effective-tracking-table').html(follow_html)
    }
    // 买家与卖家联系指标
    function contactRate(data7,data30,data90){
        var contact_html = '';
        contact_html = '<thead>'+
                            '<tr>'+
                                '<td colspan="5">'+
                                    '<div class="thead a-text-bold">'+
                                        '买家与卖家联系指标'+
                                    '</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<thead class="cycle-thead">'+
                            '<tr>'+
                                '<td></td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">7天</div>'+
                                    '<div class="cycle-date">（'+data7.date+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">30天</div>'+
                                    '<div class="cycle-date">（'+data30.date+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">90天</div>'+
                                    '<div class="cycle-date">（'+data90.date+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">目标</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<tr>'+
                            '<td class="order-tip">'+
                                '<span class="a-text-bold">客户服务不满意率 </span>'+
                                '<span class="a-color-price">(Bata)</span>&nbsp;'+
                                '<button class="secondaryAUIButton a-size-mini apply-data">请求报告</button>&nbsp;'+
                                '<button class="secondaryAUIButton a-size-mini history-data">下载历史报告</button>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data7.diss+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data30.diss+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data90.diss+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>< 25%</span>'+
                            '</td>'+
                        '</tr>'+
                        '<thead class="cycle-thead">'+
                            '<tr>'+
                                '<td></td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">7天</div>'+
                                    '<div class="cycle-date">（'+data7.date+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">30天</div>'+
                                    '<div class="cycle-date">（'+data30.date+'）</div>'+
                                '</td>'+
                                '<td>'+
                                   ' <div class="cycle a-text-bold">90天</div>'+
                                    '<div class="cycle-date">（'+data90.date+'）</div>'+
                                '</td>'+
                                '<td>'+
                                   ' <div class="cycle a-text-bold">目标</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<tr>'+
                            '<td class="order-tip"><span class="a-text-bold">24小时之内回复数</span></td>'+
                            '<td>'+
                                '<span>'+data7.h24+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data30.h24+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data90.h24+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>> 90%</span>'+
                            '</td>'+
                        '</tr>'+
                        '<tr>'+
                            '<td class="order-tip"><span class="a-text-bold">延迟回复</span></td>'+
                            '<td>'+
                                '<span>'+data7.h24out+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data30.h24out+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data90.h24out+'%</span>'+
                            '</td>'+
                            '<td>'+
                               ' <span>≤ 10%</span>'+
                            '</td>'+
                        '</tr>'+
                        '<tr>'+
                            '<td class="order-tip"><span> &nbsp;&nbsp;超过24小时没有回复</span></td>'+
                            '<td>'+
                                '<span>'+data7.h24noreply+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data30.h24noreply+'%</span>'+
                            '</td>'+
                            '<td>'+
                               ' <span>'+data90.h24noreply+'%</span>'+
                            '</td>'+
                            '<td>'+
                               ' <span>--</span>'+
                            '</td>'+
                        '</tr>'+
                        '<tr>'+
                            '<td class="order-tip"><span> &nbsp;&nbsp;24小时之内回复次数</span></td>'+
                           ' <td>'+
                                '<span>'+data7.h24reply+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data30.h24reply+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>'+data90.h24reply+'%</span>'+
                            '</td>'+
                            '<td>'+
                                '<span>--</span>'+
                            '</td>'+
                        '</tr>'+
                        '<tr>'+
                           ' <td colspan="5" class="a-text-left">您在过去7天有<a href="javascript:;">0 条消息</a>没有回复。</td>'+
                        '</tr>'
        $('.seller-buyer-table').html(contact_html);
    }
    //退货不满意率
    function ReturnGoods(dis,data7,data30,data60){
        var return_html = '';
        return_html = '<thead>'+
                            '<tr>'+
                                '<td colspan="5">'+
                                    '<div class="thead">'+
                                        '<span class="a-text-bold">退货不满意率</span> <span class="a-color-price">(Bata)</span>'+
                                    '</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<thead class="cycle-thead">'+
                            '<tr>'+
                                '<td></td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">7天</div>'+
                                    '<div class="cycle-date">（'+dis.date7+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">30天</div>'+
                                    '<div class="cycle-date">（'+dis.date30+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">60天</div>'+
                                    '<div class="cycle-date">（'+dis.date60+'）</div>'+
                                '</td>'+
                                '<td>'+
                                    '<div class="cycle a-text-bold">目标</div>'+
                                '</td>'+
                            '</tr>'+
                        '</thead>'+
                        '<tbody>'+
                            '<tr>'+
                                '<td class="order-tip">'+
                                    '<span class="a-text-bold">退货不满意率</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+dis.dis7+'</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+dis.dis30+'</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+dis.dis60+'</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>< 10%</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                               ' <td class="order-tip">'+
                                   ' <span>—</span>'+
                                    '<span class="a-text-bold">负面退货反馈率</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data7.negative+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data30.negative+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data60.negative+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>--</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip">'+
                                    '<span>—</span>'+
                                    '<span class="a-text-bold">延迟回复率</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data7.delayeds+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data30.delayeds+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data60.delayeds+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>--</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td class="order-tip">'+
                                    '<span>—</span>'+
                                    '<span class="a-text-bold">无效拒绝率</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data7.refuses+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data30.refuses+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>'+data60.refuses+'%</span>'+
                                '</td>'+
                                '<td>'+
                                    '<span>--</span>'+
                                '</td>'+
                            '</tr>'+
                            '<tr>'+
                                '<td colspan="5" class="a-text-left">'+
                                    '<button class="secondaryAUIButton a-size-mini apply-data">请求报告</button>&nbsp;'+
                                    '<button class="secondaryAUIButton a-size-mini history-data">下载历史报告</button>'+
                                '</td>'+
                            '</tr>'+
                        '</tbody>'
        $('.return-goods-table').html(return_html);
    }
})