$(function(){
    inputctr.public.checkLogin();
    var step = inputctr.public.getQueryString('step');
    var promotion_tab = $('.promotion_tab');
    var promotion_nav = $('.promotion-nav');
    var search_data = {
        seller_id:amazon_userid,
        type:'0',
        key:''
    }
    var promotionData = {
        seller_id:amazon_userid,
        type:'1',
        key:'0',
        order_by:''
    }
    var url_step = window.location.href.split('#')[1];
    function loadStep(url_step){
        promotion_nav.find('li').eq(url_step-1).addClass('active').siblings().removeClass('active');
        promotion_tab.eq(url_step-1).removeClass('hide').siblings('.promotion_tab').addClass('hide');
        if(url_step == 3){
            selectionInit(search_data);
            promotion_nav.find('li').eq(2).addClass('clicked');
        }
        if(url_step == 2){
            promotionInit(promotionData);
            promotion_nav.find('li').eq(1).addClass('clicked');
        } 
    }
    if(url_step){
       loadStep(url_step);
    }else{
        if(step){
            loadStep(step);
        }
    }
    promotion_nav.on('click','li',function(){
        if($(this).hasClass('active')){
            return;
        }
        $(this).addClass('active').siblings('li').removeClass('active');
        promotion_tab.eq($(this).index()).removeClass('hide').siblings('.promotion_tab').addClass('hide');
        if($(this).hasClass('clicked')){
            return;
        }
        if($(this).index() == 2){
            $(this).addClass('clicked');
            selectionInit(search_data);
        }
        if($(this).index() == 1){
            $(this).addClass('clicked');
            promotionInit(promotionData);
        }
    })
    // 搜索商品列表
    var search_key = $('#search_key');
    var search_submit = $('#search-submit');
    function selectionInit(data){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('GET', baseUrl + '/ProductSelection', {json:JSON.stringify(data)}, function (data) {
            var selection_html = '';
            if(data.result == 1) {
                $('.num_selection').children().html(data.data.length+' product selections');
                if(data.data.length != 0){
                    $.each(data.data, function(index, val) {
                        selection_html += '<tr>'+
                                               '<td>'+val.tracking_id+'</td>'+
                                               '<td>'+val.description+'</td>'+
                                               '<td>'+val.createtime+'</td>'+
                                               '<td>'+val.type+'</td>'+
                                               '<td class="button-td"><button class="secondaryAUIButton edit_product" onclick="javascript:location.href=\'edit_product_selection.html?edit='+val.fld_id+'\'">Edit</button></td>'+
                                           '</tr>'
                    })
                }
                $('.product_selection_table').find('tbody').html(selection_html);
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            alert(error.statusText);
        })
    }
    search_submit.click(function(){
        search_data.key = search_key.val().trim();
        selectionInit(search_data);
    })
    var search_type = $('#search_type');
    var typeArr = ['Select One','Tracking ID'];
    function selectionType(type){
        search_data.type = type;
    }
    search_type.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'search_type',typeArr,selectionType);
    })
    // 创建商品列表
    var browse_class = $('#browse-class');
    var create_list_button = $('.create_list_button');
    var browseArr = ['高级商品列表','SKU 列表','ASIN 列表','浏览分类节点编号列表','品牌名称列表','供应商部门代码列表','商品组列表','商品类型名称列表','供货商编码列表'];
    function ListType(type){
        create_list_button.attr('onclick',"javascript:location.href=\'create_product_selection.html?type="+type+"\'").attr('type',type);
    }
    browse_class.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'browse_class',browseArr,ListType);
    })
    // 搜索促销列表
    var promotion_term = $('#promotion-term');
    var termArr = ['全部','未来','正在进行','已过期'];
    function promotionType(key){
        promotionData.key = key;
    }
    promotion_term.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'promotion_term',termArr,promotionType);
    })
    function promotionInit(data){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('GET', baseUrl + '/PromotionList', {json:JSON.stringify(data)}, function (data) {
            var promotion_html = '';
            if(data.result == 1) {
                $('.num_promotions').children().html(data.data.length+' product promotion');
                if(data.data.length == 0){
                    inputctr.public.SellerRegisterLoadingRemove();
                    $('.promotion_manage_table').find('tbody').html(promotion_html);
                    return;
                }
                $.each(data.data, function(index, val) {
                    promotion_html += '<tr>'+
                                        '<td>'+
                                            '<a href="view_promotion.html?view='+val.fld_id+'" class="a-link-normal">'+val.tracking_id+'</a>'+
                                        '</td>'+
                                        '<td>'+val.description+'</td>'+
                                        '<td>'+val.start_date+'</td>'+
                                        '<td>'+val.end_date+'</td>'+
                                        '<td class="button-td">'+
                                            '<div class="view-button clear_both">'+
                                               '<button class="secondaryAUIButton view fl" onclick="javascript:location.href=\'view_promotion.html?view='+val.fld_id+'\'">View</button>'+
                                               '<button class="secondaryAUIButton splitdropdown" id='+val.fld_id+' type='+val.type+'>'+
                                                  '<i class="a-icon a-icon-dropdown drop_ul"></i>'+
                                               '</button>'+
                                            '</div>'+
                                        '</td>'+
                                    '</tr>'
                })
                $('.promotion_manage_table').find('tbody').html(promotion_html);
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            alert(error.statusText);
        })
    }
    var search_promotion = $('#search-promotion');
    search_promotion.click(function() {
        promotionInit(promotionData);
    })
    $('.promotion_manage_table').on('click','.end-date-link',function(e){
        e.stopPropagation();
        $(this).toggleClass('desc');
        if($(this).hasClass('desc')){
            promotionData.order_by = 'date_asc';
            $(this).children('.desc-icon-down').addClass('desc-icon-up');
        }else{
            promotionData.order_by = 'date_desc';
            $(this).children('.desc-icon-down').removeClass('desc-icon-up');
        }
        promotionInit(promotionData);
    })
    // Actions
    var split_down = $('.split-down');
    function dropdown(e,popover_down,id,type,dir){
        dir = dir || 'r';
        distribution(e,popover_down,id,type);
        var Wh = $(window).height();
        var popover_h = popover_down.height();
        var t = e.offset().top-1;
        if((t + popover_h) > Wh){
            t = t - popover_h + e.outerHeight(true);
        }
        var l = e.offset().left;
        if(dir == 'r'){
            var r = $(window).width() - l - e.outerWidth(true) -3;
            popover_down.css({
                top: t,
                right: r,
                left:"auto",
                display:'block'
            })
        }else{
            popover_down.css({
                top: t,
                left: l,
                right:"auto",
                display:'block'
            })
        }
    }
    function distribution(e,popover_down,id,type){ 
        var html = '';
        if(e.hasClass('splitdropdown')){
             html += '<li>'+
                            '<a href="view_promotion.html?view='+id+'" class="drop_link a-selected">'+
                                'View'+
                            '</a>'+
                        '</li>';
             html += '<li>'+
                            '<a href="edit_promotion.html?edit='+id+'&type='+type+'" class="drop_link">'+
                                'Edit'+
                            '</a>'+
                        '</li>';
             html += '<li>'+
                            '<a href="manage_claim_codes.html?manage='+id+'" class="drop_link">'+
                                'Manage'+
                            '</a>'+
                        '</li>';
            popover_down.find('.down_list').html(html);
        }
    }
    $('.promotion_manage_table').on('click','.splitdropdown',function(e){
        e.stopPropagation();
        $(this).off('click');
        dropdown($(this),split_down,this.id,$(this).attr('type'))
    })
    $(document).click(function(event) {
        if(!split_down.is(event.target) && split_down.has(event.target).length === 0){ 
            split_down.fadeOut(0);
        }
    })
})