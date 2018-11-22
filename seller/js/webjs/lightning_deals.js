laydate.render({
  elem:'#Start-Date',
  lang: 'en',
  format: 'yyyy-MM-dd',
  min:0,
  showBottom: false
})
$(function(){
    inputctr.public.checkLogin();
    var step = inputctr.public.getQueryString('step');
    var promotion_tab = $('.promotion_tab');
    var promotion_nav = $('.promotion-nav');
    var url_step = window.location.href.split('#')[1];
    function loadStep(url_step){
        promotion_nav.find('li').eq(url_step-1).addClass('active').siblings().removeClass('active');
        promotion_tab.eq(url_step-1).removeClass('hide').siblings('.promotion_tab').addClass('hide');
        if(url_step == 2){
            promotion_nav.find('li').eq(1).addClass('clicked');
        }
        if(url_step == 1){
            promotion_nav.find('li').eq(0).addClass('clicked');
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
        if($(this).index() == 1){
            $(this).addClass('clicked');
        }
        if($(this).index() == 0){
            $(this).addClass('clicked');
        }
    })
    // 选择时间段
    var day_time_am = $('#day-time-am');
    var AmArr = ['0:00 AM','1:00 AM','2:00 AM','3:00 AM','4:00 AM','5:00 AM','6:00 AM','7:00 AM','8:00 AM','9:00 AM','10:00 AM','11:00 AM','12:00 PM','1:00 PM','2:00 PM','3:00 PM','4:00 PM','5:00 PM','6:00 PM','7:00 PM','8:00 PM','9:00 PM','10:00 PM','11:00 PM']
    function selectTime1(i){
        day_time_am.attr('i',i);
    }
    day_time_am.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'day_time_am',AmArr,selectTime1);
    })
    var day_time_pm = $('#day-time-pm');
    function selectTime2(i){
        day_time_pm.attr('i',i);
    }
    var PmArr = ['0:00 AM','1:00 AM','2:00 AM','3:00 AM','4:00 AM','5:00 AM','6:00 AM','7:00 AM','8:00 AM','9:00 AM','10:00 AM','11:00 AM','12:00 PM','1:00 PM','2:00 PM','3:00 PM','4:00 PM','5:00 PM','6:00 PM','7:00 PM','8:00 PM','9:00 PM','10:00 PM','11:00 PM']
    day_time_pm.click(function(event){
        event.stopPropagation();
        CreatSelect($(this),'day_time_pm',PmArr,selectTime2);
    })
    // 选择秒杀商品
    var deal_inventory = {
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
    $('#deals-link').click(function(e){
        e.stopPropagation();
        if(select_ASIN.hasClass('show')){
            return;
        }
        select_ASIN.fadeIn().addClass('show');
        $('body').css('overflow','hidden');
        renderDeal();
    })
    var ASINitable_search = $('#ASINitable-search');
    $('#ASIN-search-button').click(function(){
        if(ASINitable_search.val().trim() == ''){
            return;
        }
        deal_inventory.key = ASINitable_search.val().trim();
        renderDeal();
    })
    ASINitable_search.keyup(function(event) {
       if(event.keyCode == 13){
           if(ASINitable_search.val().trim() == ''){
               return;
           }
           deal_inventory.key = ASINitable_search.val().trim();
           renderDeal();
        }
    }) 
    var select_ASIN_table = $('#select-ASIN-table');
    var select_this = $('#select-this');
    function renderDeal(currentPage){
        if(currentPage){
            deal_inventory.currentPage = currentPage;
        }
        inputctr.public.AjaxMethods('POST', baseUrl + '/ProductList', {json:JSON.stringify(deal_inventory)}, function (data) {
            if(data.result == 1) {
                select_this.attr('disabled',false);
                Deal_render(data,deal_inventory.currentPage);
                deal_inventory.currentPage = 1;
                deal_inventory.key = '';
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
    function Deal_render(data,currentPage){
        $('#count-value').text(data.totalRecords);
        initPage(data.totalPages,currentPage,renderDeal);
        var list_html = '';
        $.each(data.data, function(i, val) {
            var img_display = (Number(val.product_image) == 0) ? 'none' : 'inline-block';
            list_html += '<tr id='+val.sku_id+' class="render">'+
                            '<td><input type="radio" name="deal"/></td>'+
                            '<td>'+
                                '<img src="'+val.product_image+'" alt="" width="60" height="60" style="display:'+img_display+'"/>'+
                            '</td>'+
                            '<td class="goods-name">'+val.goods_name+'</td>'+
                            '<td>$'+val.your_price+'</td>'+
                        '</tr>'
        })
        select_ASIN_table.find('tbody').html(list_html);
        select_ASIN_table.find('tbody').on('click','tr.render',function(e){
            e.stopPropagation();
            $(this).addClass('active').siblings().removeClass('active');
            $(this).find('input[type="radio"]').prop('checked',true);
            selectedProduct(data.data[$(this).index()]);
        })
    }
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
    function selectedProduct(data){
        if(Number(data.product_image) == 0){
            $('#product-img').addClass('hide')
        }else{
            $('#product-img').attr('src',data.product_image).removeClass('hide');
        }
        $('#product_name').text(data.goods_name);
        $('#product_price').text('$ '+data.your_price);
    }
    var create_light = $('#create-light');
    select_this.click(function(e){
        e.stopPropagation();
        select_ASIN.fadeOut().removeClass('show');$('body').css('overflow','auto');
        ASINitable_search.val('');
        $('.select').fadeIn();
        create_light.prop('disabled',false);
    })
    // 提交创建秒杀
    var timeError1 = $('#timeError1');
    var timeError2 = $('#timeError2');
    var Start_Date = $('#Start-Date');
    function tabDate(date1,date2){
        var oDate1 = new Date(date1);
        var oDate2 = new Date(date2);
        if(oDate1.getTime() > oDate2.getTime()){
            return true;
        } else {
            return false;
        }
    }
    create_light.click(function(){
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
        if(day_time_pm.attr('i') <= day_time_am.attr('i')){
            day_time_pm.addClass('error-border');
            timeError2.removeClass('hide');
        }else{
            day_time_pm.removeClass('error-border');
            timeError2.addClass('hide');
        }
        var deal_price = $('#deal-price');
        if(deal_price.val().trim() < 0){
            deal_price.addClass('error-border');
        }else{
            deal_price.removeClass('error-border');
        }
        var date = new Date();
        var seperator1 = "-";
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = year + seperator1 + month + seperator1 + strDate;
        if(Start_Date.val().trim() != ''){
            if(!tabDate(Start_Date.val(),currentdate)){
                var nowHour = date.getHours(); 
                if(nowHour > day_time_am.attr('i')){
                    day_time_am.addClass('error-border');
                    timeError1.removeClass('hide');
                }else{
                    day_time_am.removeClass('error-border');
                    timeError1.addClass('hide');
                }
            }
        }
        if($('.error-border').length){
            return;
        }
    })
})