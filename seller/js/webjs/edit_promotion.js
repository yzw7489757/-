var E = window.wangEditor;
var editor = new E('#editor')
editor.customConfig.menus = ['head', 'bold','fontSize', 'fontName', 'italic', 'underline', 'strikeThrough', 'justify','undo','redo' ]
editor.create();
laydate.render({
  elem:'#Start-Date',
  lang: 'en',
  format: 'yyyy-MM-dd',
  min:0,
  showBottom: false
})
laydate.render({
  elem:'#End-Date',
  lang: 'en',
  min:0,
  format: 'yyyy-MM-dd',
  showBottom: false
})
$(function(){
    inputctr.public.checkLogin();
    var typeP = inputctr.public.getQueryString('type');
    var editID = inputctr.public.getQueryString('edit');
    var percent_quality = $('#percent-quality');
    var off_title = $('.off-title');
    if(typeP != 1){
        percent_quality.removeClass('hide').addClass('verify-require');
    }
    $(window).scrollTop(0);
    var day_time_am = $('#day-time-am');
    var AmArr = ['0:00 AM','1:00 AM','2:00 AM','3:00 AM','4:00 AM','5:00 AM','6:00 AM','7:00 AM','8:00 AM','9:00 AM','10:00 AM','11:00 AM','12:00 PM','1:00 PM','2:00 PM','3:00 PM','4:00 PM','5:00 PM','6:00 PM','7:00 PM','8:00 PM','9:00 PM','10:00 PM','11:00 PM']
    day_time_am.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'day_time_am',AmArr);
    })
    var day_time_pm = $('#day-time-pm');
    var PmArr = ['0:00 AM','1:00 AM','2:00 AM','3:00 AM','4:00 AM','5:00 AM','6:00 AM','7:00 AM','8:00 AM','9:00 AM','10:00 AM','11:00 AM','12:00 PM','1:00 PM','2:00 PM','3:00 PM','4:00 PM','5:00 PM','6:00 PM','7:00 PM','8:00 PM','9:00 PM','10:00 PM','11:00 PM']
    day_time_pm.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'day_time_pm',PmArr);
    })
    // 初始化创建促销选项
    var freeShipData = {
        seller_id:amazon_userid,
        type:typeP
    }
    var CreateData = {
        seller_id:amazon_userid,
        type:typeP,
        buyer_purchases:'',
        buyer_purchases_value:'',
        purchased_items:'',
        buyer_gets:'',
        buyer_gets_value:'',
        applies_to:'',
        qualifying_items_ASIN:'',
        qualifying_items_quantity:'',
        qualifying_items:[],
        exclude_items:'',
        tracking_id:'',
        description:'',
        start_date:'',
        start_date_hour:'',
        end_date:'',
        end_date_hour:'',
        claim_type:'3',
        one_per:'1',
        claim_code:'',
        combinability:'3',
        checkout_text:'',
        short_text:'',
        page_text_type:'1',
        page_text:'',
        precedence:'50',
        terms_conditions:''
    }
    var buyerO = {}; 
    var itemsO = {};
    var percentO = {};
    var appliesO = {};
    var buyer_purchases = $('#buyer-purchases');
    var purchased_items = $('#purchased-items');
    var Percent_off = $('#Percent_off');
    var applies_to = $('#applies-to');
    var viewData = {
        seller_id:amazon_userid,
        id:editID
    }
    function ViewPromotion(data){
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('GET', baseUrl + '/PromotionInfo', {json:JSON.stringify(data)}, function (data) {
            if(data.result == 1) {
                var val = data.data.promotion;
                promotionInit(freeShipData,val);
            }else{
                alert(data.error);
            }
        }, function (error) {
        })
    }ViewPromotion(viewData)
    function push(data,obj,target,t,k){
        if($.isEmptyObject(data)){
            target.attr('disabled',true);
            return;
        }
        for(var i in data){
            obj[i] = data[i];
        }
        target.children('span').text(data[k]).attr('k',k);
        CreateData[t] = k;
    }
    function qualifyingShow(){
        if(applies_to.children('span').attr('k') == 'qualifying'){
            $('.qualifying-benefit').fadeIn(150).find('input').addClass('verify-require');
        }
    }
    function promotionInit(data,v){
        inputctr.public.AjaxMethods('GET', baseUrl + '/InitPromotion', {json:JSON.stringify(data)}, function (data) {
            if(data.result == 1) {
                var val = data.data;
                push(val.buyers_purchase,buyerO,buyer_purchases,'buyer_purchases',v.buyer_purchases);
                push(val.purchased_items,itemsO,purchased_items,'purchased_items',v.purchased_Items);
                push(val.buyer_gets,percentO,Percent_off,'buyer_gets',v.buyer_gets);
                push(val.applies_to,appliesO,applies_to,'applies_to',v.applies_to);
                qualifyingShow();
                $('#purchases-quality').val(v.buyer_purchases_value);
                percent_quality.val(v.buyer_gets_value);
                $('#Qualifying-input').val(v.qualifying_items_ASIN);
                $('#applies-quantity').val(v.qualifying_items_quantity);
                $('#Tracking-ID').val(v.tracking_id);
                $('#Start-Date').val(v.start_date.split('T')[0]);
                day_time_am.children('span').text(AmArr[new Date(v.start_date).getHours()]);
                $('#End-Date').val(v.end_date.split('T')[0]);
                day_time_pm.children('span').text(PmArr[new Date(v.end_date).getHours()]);
                $('#Internal-Description').val(v.description);
                $('input.code-use').each(function(i,el){
                    if($(el).attr('ctype') == v.claim_type){
                        $(el).prop('checked',true);
                        return false;
                    }
                })
                if(v.one_per == 0){
                    $('#one_per').prop('checked',false);
                }
                $('#Cliam-Code').val(v.clain_code);
                $('#combinability').find('input').each(function(i,el){
                    if($(el).attr('ctype') == v.combinability){
                        $(el).prop('checked',true);
                        return false;
                    }
                })
                $('#Checkout-display').val(v.checkout_text);
                $('#Short-display').val(v.short_text);
                $('#detail-page').find('input.Detail').each(function(i,el){
                    if($(el).attr('ctype') == v.page_text_type){
                        $(el).prop('checked',true);return false;
                    }
                })
                if(v.page_text_type == 2){
                    $('#customized-text').val(v.page_text);
                }else{
                    $('#standard-text').val(v.page_text);
                }
                precedence_num.children('span').text(v.precedence);
                editor.txt.html(v.terms_conditions);
            }else{
                alert(data.error);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            alert(error.statusText);
        })
    }
    var Claim_Code = $('.Claim-Code');
    Claim_Code.click(function(event) {
        $('.claim_show').fadeToggle(100);
        $(this).children('i').toggleClass('a-step-drown');
    })
    $('input.code-use').change(function() {
        CreateData.claim_type = $(this).attr('ctype');
    })
    var Customsize_messageing = $('.Customsize-messageing');
    Customsize_messageing.click(function(event) {
        $('.customsize_show').fadeToggle(100);
        $(this).children('i').toggleClass('a-step-drown');
    })
    
    function change1(t){
        CreateData.buyer_purchases = t;
    }
    buyer_purchases.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'buyer_purchases',buyerO,change1);
    })
    function change2(t){
        CreateData.purchased_items = t;
    }
    purchased_items.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'purchased_items',itemsO,change2);
    })
    function change3(t){
        CreateData.buyer_gets = t;
    }
    Percent_off.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'Percent_off',percentO,change3);
    })
    function change4(t){
        CreateData.applies_to = t;
        if(t == 'qualifying'){
            $('.qualifying-benefit').fadeIn(150).find('input').addClass('verify-require');
        }else{
            $('.qualifying-benefit').fadeOut(150).find('input').removeClass('verify-require');
        }
    }
    applies_to.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'applies_to',appliesO,change4);
    })
    var precedence_num = $('#precedence-num');
    var precedenceArr = [];
    for(var p=1;p<100;p++){
        precedenceArr.push(p);
    }
    precedence_num.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'precedence_num',precedenceArr);
    })
    $('#detail-page').on('change','input.Detail',function(){
        CreateData.page_text_type = $(this).attr('ctype');
    })
    $('#combinability').on('change','input',function(){
        CreateData.combinability = $(this).attr('ctype');
    })
    // 选择ASIN
    var ASIN_inventory = {
        amazonUserid:amazon_userid,
        key:'',
        status:'',
        fulfilled:'',
        startDate:'',
        endDate:'',
        minPrice:'',
        maxPrice:'',
        pageSize:20,
        currentPage:1,
        orderBy:'',
        desc:''
    }
    var select_ASIN = $('#select-ASIN');
    $('#ASIN-link').click(function(e){
        e.stopPropagation();
        if(select_ASIN.hasClass('show')){
            return;
        }
        select_ASIN.fadeIn().addClass('show');
        $('body').css('overflow','hidden');
        renderASIN();
    })
    var ASINitable_search = $('#ASINitable-search');
    $('#ASIN-search-button').click(function(){
        if(ASINitable_search.val().trim() == ''){
            return;
        }
        ASIN_inventory.key = ASINitable_search.val().trim();
        renderASIN();
    })
    ASINitable_search.keyup(function(event) {
       if(event.keyCode == 13){
           if(ASINitable_search.val().trim() == ''){
               return;
           }
           ASIN_inventory.key = ASINitable_search.val().trim();
           renderASIN();
        }
    }) 
    var select_ASIN_table = $('#select-ASIN-table');
    var select_this = $('#select-this');
    function renderASIN(currentPage){
        if(currentPage){
            ASIN_inventory.currentPage = currentPage;
        }
        inputctr.public.AjaxMethods('POST', baseUrl + '/ProductList', {json:JSON.stringify(ASIN_inventory)}, function (data) {
            if(data.result == 1) {
                select_this.attr('disabled',false);
                ASIN_render(data,ASIN_inventory.currentPage);
                ASIN_inventory.currentPage = 1;
                ASIN_inventory.key = '';
            }else{
                $('#count-value').text('0');
                var error_html = '<tr>'+
                                    '<td colspan="4" style="text-align:center;font-size:14px;">'+
                                        'You currently have no listings that meet this criteria.'+
                                    '</td>'+
                                '</tr>'
                select_ASIN_table.find('tbody').html(error_html);
                initPage(0);
                select_this.attr('disabled',true);
            }
        }, function (error) {
            $('#count-value').text('0');
            var error_html = '<tr>'+
                                '<td colspan="4" style="text-align:center;font-size:14px;">'+
                                    error.statusText+
                                '</td>'+
                            '</tr>'
            select_ASIN_table.find('tbody').html(error_html);
            initPage(0);
            select_this.attr('disabled',true);
        })
    }
    function ASIN_render(data,currentPage){
        $('#count-value').text(data.totalRecords);
        initPage(data.totalPages,currentPage,renderASIN);
        var list_html = '';
        $.each(data.data, function(i, val) {
            var img_display = (Number(val.product_image) == 0) ? 'none' : 'inline-block';
            list_html += '<tr id='+val.sku_id+' class="render">'+
                            '<td><input type="radio" name="ASIN"/></td>'+
                            '<td>'+
                                '<img src="'+val.product_image+'" alt="" width="60" height="60" style="display:'+img_display+'"/>'+
                            '</td>'+
                            '<td class="goods-name">'+val.goods_name+'</td>'+
                            '<td>'+val.sku_id+'</td>'+
                        '</tr>'
        })
        select_ASIN_table.find('tbody').html(list_html);
    }
    select_ASIN_table.find('tbody').on('click','tr.render',function(e){
        e.stopPropagation();
        $(this).addClass('active').siblings().removeClass('active');
        $(this).find('input[type="radio"]').prop('checked',true);
        select_this.attr('a',this.id);
    })
    $(document).click(function(event) {
        if(!select_ASIN.is(event.target) && select_ASIN.has(event.target).length === 0){ 
            select_ASIN.fadeOut().removeClass('show');$('body').css('overflow','auto');
            ASINitable_search.val('');
        }
    })
    $('#close-ASIN').click(function(e){
        e.stopPropagation();
        select_ASIN.fadeOut().removeClass('show');$('body').css('overflow','auto');
        ASINitable_search.val('');
    })
    select_this.click(function(e){
        e.stopPropagation();
        select_ASIN.fadeOut().removeClass('show');$('body').css('overflow','auto');
        ASINitable_search.val('');
        $('#Qualifying-input').val(select_this.attr('a'));
    })
    // 提交创建促销条件
    $('.Rreview-button').click(function(){
        var verify = $('.verify-require').filter(function() {
            return this.value.replace(/(^\s*)|(\s*$)/g,'') == '';
        })
        var i_verify = $('.verify-require').filter(function() {
            return this.value.replace(/(^\s*)|(\s*$)/g,'') != '';
        })
        if(verify.length){
            verify.addClass('error-border');
        }
        i_verify.removeClass('error-border');
        if($('.error-border').length){
            return;
        }
        CreateData.buyer_purchases_value = $('#purchases-quality').val().trim();
        CreateData.buyer_gets_value = percent_quality.val().trim();
        if(CreateData.applies_to != ''){
            CreateData.qualifying_items_ASIN = $('#Qualifying-input').val().trim().removeClass('error-border');
            CreateData.qualifying_items_quantity = $('#applies-quantity').val().trim();
        }
        CreateData.tracking_id = $('#Tracking-ID').val().trim();
        CreateData.description = $('#Internal-Description').val().trim();
        CreateData.start_date = $('#Start-Date').val().trim();
        CreateData.start_date_hour = day_time_am.children('span').text();
        CreateData.end_date = $('#End-Date').val().trim();
        CreateData.end_date_hour = day_time_pm.children('span').text();
        CreateData.claim_code = $('#Cliam-Code').val().trim();
        if($('#one_per').prop('checked')){
            CreateData.one_per = 1;
        }else{
            CreateData.one_per = 0;
        }
        CreateData.checkout_text = $('#Checkout-display').val().trim();
        CreateData.short_text = $('#Short-display').val().trim();
        if(CreateData.page_text_type == 2){
            CreateData.page_text = $('#customized-text').val().trim();
        }else{
            CreateData.page_text = $('#standard-text').val().trim();
        }
        CreateData.precedence = precedence_num.children('span').text();
        if(editor.txt.html() != '<p><br></p>'){
            CreateData.terms_conditions = editor.txt.html();
        }
        inputctr.public.SellerRegisterLoading();
        inputctr.public.AjaxMethods('POST', baseUrl + '/PromotionEdit', {json:JSON.stringify(CreateData)}, function (data) {
            if(data.result == 1) {
               window.location.href = 'promotion.html?step=2';
            }else{
                $('#Qualifying-input').addClass('error-border');
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) {
            alert(error.statusText);
            inputctr.public.SellerRegisterLoadingRemove();
        })
    })
})