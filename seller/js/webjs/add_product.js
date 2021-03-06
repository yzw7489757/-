$(function () {
    inputctr.public.checkLogin();
    //var variant_show = $('.variant_show');
    //var product_group = $('.product_group');
    var classId = inputctr.public.getCookie('classid');
    var searchGoods = {
        classid:classId,
        key:'',
        pageSize:3,
        currentPage:1
    }
    // variant_show.click(function () {
    //     $(this).removeClass('primaryAUIButton').addClass('secondaryAUIButton').text('隐藏商品变体')
    // })
    var product_search_key = $('input#product-search-key');
    $(".button-search").click(function () {
        var key = $("#product-search").val().trim();
        if (key == ''){
            return;
        }
        product_search_key.val(key);
        searchGoods.currentPage = 1;
        SearchInit(searchGoods);
    })
    $("#product-search").keyup(function(event) {
        if(event.keyCode == 13){
            var key = $(this).val().trim();
            if (key == ''){
                return;
            }
            product_search_key.val(key);
            searchGoods.currentPage = 1;
            SearchInit(searchGoods);
        }
    })
    // 开始搜索
    var search_right = $('.search_right');
    function SearchInit(searchGoods){
        inputctr.public.SellerRegisterLoading();
        searchGoods.key = product_search_key.val();
        inputctr.public.AjaxMethods('POST', baseUrl + '/SearchWithSellGoods', {json:JSON.stringify(searchGoods)}, function (data) {
            inputctr.public.judgeBegaintask('1208');
            if(data.result == 1) {
                productShow(data,data.data,search_right,searchGoods.currentPage,searchGoods.pageSize);
            }else{
                inputctr.public.SellerRegisterLoadingRemove();
                search_right.html('<p style="padding: 18px;font-size: 15px;">'+decodeURIComponent(data.error)+'</p>');
            }
        }, function (error) {
            inputctr.public.SellerRegisterLoadingRemove();
            alert(error.statusText);
        })
    }
    // 展示搜索结果
    function productShow(data,list,box,currentPage,pageSize){
        var html = '';
        var lastResult = (data.totalRecords > currentPage*pageSize) ? currentPage*pageSize : data.totalRecords;
        var startResult = (currentPage-1)*pageSize + 1;
        html += '<div class="product_show">'+
                            '<div class="page_show">'+
                                '<div class="a-search_innner clear_both">'+
                                    '<div class="product_tote fl">'+
                                        '<b>'+data.totalRecords+'</b> 个结果中的 <b>'+startResult+'</b> 至 <b>'+lastResult+'</b>'+
                                    '</div>'+
                                    '<div class="products-pagination fr">'+
                                        '<ul class="a-pagination clear_both">'+
                                        '</ul>'+
                                    '</div>'+
                                '</div>'+
                            '</div>'
        for(var i=0;i<list.length;i++){
            var condition = (list[i].condition == 'New') ? '新品' : '非全新品';
            var sale = (list[i].is_sale == 1) ? '促销' : '';
            html += '<div class="product_list">'+
                        '<div class="a-search_innner">'+
                            '<div class="product_details clear_both">'+
                                '<div class="product_img fl">'+
                                    '<img src="'+decodeURIComponent(list[i].product_image)+'" width="75" height="75">'+
                                '</div>'+
                               ' <div class="product_details_right fl">'+
                                    '<div class="product-description">'+
                                        '<span class="text-bold">'+list[i].goods_name+'</span><span>'+list[i].product_id_type+': '+list[i].product_id+'</span>'+
                                        '<ul class="offerCountDetails">'+
                                            '<li>'+list[i].goods_id+'&nbsp;</li>'+
                                            '<li>'+condition+'&nbsp;</li>'+
                                           ' <li>'+sale+' </li>'+
                                        '</ul>'+
                                        '<a href="javascript:;">查看全部的产品详细信息</a>'+
                                    '</div>'+
                                '</div>'+
                            '</div>'+
                            '<div class="Release_restrictions">'+
                                '<div class="limitations-heading">'+
                                    '<a class="sell_link"><i class="a-icon a-icon-extender-expand a-icon-extender-drop"></i>'+
                                        '<span>有商品发布限制</span> </a>'+
                                '</div>'+
                                '<div class="expander-content">'+
                                    '<div class="listing-limitations-box">'+
                                        '<div class="a-search_innner">'+
                                            '<div class="condition clear_both">'+
                                                '<ul class="unordered-list fl">'+
                                                    '<li><span class="text-bold">'+condition+' 条件</span> </li>'+
                                                '</ul>'+
                                                '<div class="button-container">'+
                                                    '<button class="primaryAUIButton sell-yours" onclick="javascript:location.href=\'add_other_conditions.html?skuID='+list[i].sku_id+'&goodsID='+list[i].goods_id+'\'">出售您的</button>'+
                                                '</div>'+
                                            '</div>'+
                                            '<div class="listing-limitations-divider">'+
                                            '</div>'+
                                            '<div class="collection_require">'+
                                                '<ul class="unordered-list">'+
                                                    '<li><span class="text-bold">收藏品 条件</span> <span class="text-explain">您未获得在该产品类别下列示的批准，我们当前不接受申请。'+
                                                    '</span></li>'+
                                                '</ul>'+
                                            '</div>'+
                                       ' </div>'+
                                    '</div>'+
                                '</div>'+
                            '</div>'+
                        '</div>'+
                    '</div>'
        }
        html += '<div class="page_show page_show_bottom">'+
                    '<div class="a-search_innner clear_both">'+
                        '<div class="product_tote fl">'+
                            '<b>'+data.totalRecords+'</b> 个结果中的 <b>'+startResult+'</b> 至 <b>'+lastResult+'</b>'+
                        '</div>'+
                        '<div class="products-pagination fr">'+
                            '<ul class="a-pagination clear_both">'+
                            '</ul>'+
                        '</div>'+
                    '</div>'+
                '</div>'+
            '</div>'
        box.html(html);
        box.on('click', '.sell-yours', function() {
            inputctr.public.judgeRecodertask('1208','了解并跟卖一个指定商品开始');
        });
        var pagebox = box.find('.products-pagination ul.a-pagination');
        initPage(data.totalPages,searchGoods.currentPage,pagebox);
        inputctr.public.SellerRegisterLoadingRemove();
    }
    //创建分页模板
    //var currentPage; // 当前页码, 从1开始
    var maxButtons = 3; // 显示的分页按钮数量
    //var totalPage // 总页数
    function  initPage(totalPage,currentPage,pagebox) {
        var pageHtml = '';
        if(totalPage >= 1){
            var rangeStart = Math.max(1, currentPage - parseInt(currentPage % maxButtons)); //开始页
            var rangeEnd = Math.min(totalPage, rangeStart + maxButtons - 1); //最后一页
            if(currentPage != 1){
               pageHtml += '<li><a href="javascript:;" data-num='+(currentPage - 1)+'>← &nbsp;上一页</a></li>'
            }else{
               //如果是第一页，禁用上一页
               pageHtml += '<li><span>← &nbsp;上一页</span></li>'
            }
           // 中间页码
           for (var i = rangeStart; i <= rangeEnd; i++){
               if (i == currentPage) {
                   pageHtml += '<li><a href="javascript:;" class="selected_page">'+i+'</a></li>'; 
               } else {
                   pageHtml += '<li><a href="javascript:;" data-num="'+i+'">'+i+'</a></li>';
               }
           }
           //当前页不是总页，即是最后一页
           if (currentPage != totalPage) {
               pageHtml += '<li><a href="javascript:;" data-num='+(parseInt(currentPage)+1)+'>下一页&nbsp; →</a></li>';
           } else {
               //如果是最后页，禁用下一页
               pageHtml += '<li><span>下一页&nbsp; →</span></li>';
           }
       }
        pagebox.html(pageHtml);
        pagebox.find('a').off('click').click(function(){
            if($(this).hasClass('selected_page')){
                return;
            }
            var currentP = $(this).attr('data-num');
            searchGoods.currentPage = currentP;
            SearchInit(searchGoods);
        })
    }
})