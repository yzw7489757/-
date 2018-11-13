$(function(){
    inputctr.public.checkLogin();
    //获取退货详情
    var problem_id = inputctr.public.getQueryString('fld_id');
    var seller_id = amazon_userid;
    function dec(str){
        return decodeURIComponent(str);
    }
    function detailsInit(){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/GetReturnRequestInfo', {seller_id:seller_id,problem_id:problem_id,isAddress:0}, function (data) {
            inputctr.public.SellerRegisterLoadingRemove();
            var order_html = '';  
            if(data.result == 1) {
                    order_html += '<div class="order-detainls-container clearfix">'+
                                    '<div class="pull-left order-information-container1">'+
                                        '<h3>'+data.data.title+'</h3>'+
                                        '<div class="order-detail">'+
                                            '<div class="info-list">'+
                                                '<span>Order ID:</span>'+
                                                '<a>'+data.data.order_no+'</a>'+
                                            '</div>'+
                                            '<div  class="info-list">'+
                                                '<span>Buyer:</span>'+
                                                '<a>'+data.data.buyer+'</a>'+
                                            '</div>'+
                                            '<div  class="info-list">'+
                                                '<span>Request Date:</span>'+
                                                '<span>'+data.data.createtime+'</span>'+
                                            '</div>'+
                                        '</div>'+
                                    '</div>'+
                                    '<div class="pull-left order-information-container2">'+
                                        '<h3 style="color: #c60;">'+data.data.problem+'</h3>'+
                                        '<div class="clearfix goods-list">'+
                                            '<div class="pull-left goods-cover">'+
                                                '<img src="'+dec(data.data.goods[0].product_image)+'"/>'+
                                            '</div>'+
                                            '<div class="pull-left goods-information">'+
                                                '<div class="goods-name">'+
                                                    '<a href="javascript:;">'+dec(data.data.goods[0].goods_name)+'</a>'+
                                                '</div>'+
                                                '<div class="buy-comments">'+
                                                    '<span>Description:</span>'+
                                                    '<span>'+data.data.describe+'</span>'+
                                                '</div>'+
                                            '</div>'+
                                        '</div>'+
                                    '</div>'+
                                '</div>'
            $('.order-information').html(order_html);   
            }else{
                $('.order-information').html(dec(data.error));
            }
        }, function (error) {
            alert(error.statusText);
        })
    }detailsInit();
    // 关闭退货申请
    var select_reason = $('#select-reason');
    var message_to_buyer = $('#message-to-buyer');
    $('#close_request').click(function() {
        if(select_reason.val() == ''){
            select_reason.addClass('error-border');
            return;
        }else{
            select_reason.removeClass('error-border');
        }
        inputctr.public.SellerRegisterLoading();
        var requestData = {
            question_id:problem_id,
            reason:select_reason.val(),
            content:message_to_buyer.val()
        }
        inputctr.public.AjaxMethods('POST', baseUrl + '/ReturnCloseRequest', {json:JSON.stringify(requestData)}, function (data) {
            inputctr.public.SellerRegisterLoadingRemove();
            if(data.result == 1) {
                $('#auth-pv-client-side-success-box').removeClass('hide');
            }else{
                alert(dec(data.error));
            }
        }, function (error) {
            alert(error.statusText);
        })
    })
})