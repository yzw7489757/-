$(function(){
    inputctr.public.checkLogin();
    //获取退货详情
    var problem_id = inputctr.public.getQueryString('fld_id');
    var seller_id = amazon_userid;
    var address_id;
    function dec(str){
        return decodeURIComponent(str);
    }
    function detailsInit(){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/GetReturnRequestInfo', {seller_id:seller_id,problem_id:problem_id,isAddress:1}, function (data) {
            inputctr.public.SellerRegisterLoadingRemove();
            var order_html = '';  
            var address_html = '';
            if(data.result == 1) {
                    address_id = data.data.address[0].address_id;
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
                    address_html += '<ul class="displayAddressUL">'+
                                        '<li class="displayAddressLI displayAddressFullName">'+data.data.address[0].full_name+'</li>'+
                                        '<li class="displayAddressLI displayAddressAddressLine1">'+data.data.address[0].province+'</li>'+
                                        '<li class="displayAddressLI displayAddressAddressLine2">'+data.data.address[0].address+', '+data.data.address[0].address2+'</li>'+
                                        '<li class="displayAddressLI displayAddressCityStateOrRegionPostalCode">'+data.data.address[0].city+', '+data.data.address[0].zipcode+'</li>'+
                                        '<li class="displayAddressLI displayAddressCountryName">'+data.data.address[0].country+'</li>'+
                                        '<li class="displayAddressLI displayAddressPhoneNumber">Phone: '+data.data.address[0].phone+'</li>'+
                                    '</ul>'
            $('.order-information').html(order_html);   
            $('.address-information').html(address_html);
            }else{
                $('.order-information').html(dec(data.error));
                $('.address-information').html(dec(data.error));
            }
        }, function (error) {
            alert(error.statusText);
        })
    }detailsInit();
    // 确认退货
    var authorize_request = $('#authorize_request');
    authorize_request.click(function() {
        var requestData = {
            problem_id:problem_id,
            address_id:address_id
        }
        if(!requestData.address_id){
            return;
        }
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/ReturnAuthorizeRequest', requestData, function (data) {
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