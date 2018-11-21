$(function () {
    var other_filter = $(".other-filter");
    var other_filter_down = $(".other-filter-down");
    var split_down = $('.split-down');
    var search_num_down = $('.search_num_down');
    var popover_down = $('.popover_down');
    var search_num = $(".search_num");
    var keyWordwl;
    var keyWordkl;
    var keyWordry;
    var buttonSizeRy;
    var buttonSizeKl;
    var buttonSizeWl;
    var currentPageRy;
    var currentPageKl;
    var currentPageWl;
    var index;
    inputctr.public.checkLogin();
    function inputValue(){
        keyWordwl = $('.keyWordwl').val().trim();
        keyWordkl = $('.keyWordkl').val().trim();
        keyWordry = $('.keyWordry').val().trim();
        buttonSizeRy = $('.buttonSizeRy').attr('size');
        buttonSizeKl = $('.buttonSizeKl').attr('size');
        buttonSizeWl = $('.buttonSizeWl').attr('size');
        currentPageRy = $('.currentPagery').val();
        currentPageKl = $('.currentPageKl').val();
        currentPageWl = $('.currentPageWl').val();
    }
    inputValue()
    // tab切换
    $('.a-container ul li a').click(function (item) {
        $('.a-container ul li a').removeClass('active');
        index = $(this).parent('li').index();
        $(this).addClass('active');
        $('ol li').eq(index).show().siblings().hide();
        $('ol li').eq(index).attr('index',index)
    })
    // 下拉选项
    function dropdown(e, popover_down, dir) {
        dir = dir || 'l';
        e.click(function () {
            // distribution($(this),popover_down);
            var Wh = $(window).height();
            var popover_h = popover_down.height();
            var t = $(this).offset().top - 1;
            if ((t + popover_h) > Wh) {
                t = t - popover_h + e.outerHeight(true);
            }
            var l = $(this).offset().left;
            if (dir == 'r') {
                var r = $(window).width() - l - $(this).outerWidth(true);
                popover_down.css({
                    top: t,
                    right: r,
                    left: "auto",
                    display: 'block'
                })
            } else {
                popover_down.css({
                    top: t,
                    left: l,
                    right: "auto",
                    display: 'block'
                })
            }
        })
    }
    dropdown(search_num, search_num_down, 'r')
    $(document).click(function (event) {
        if (!$(event.target).hasClass('drop_ul')) {
            popover_down.css({
                top: "auto",
                left: "auto",
                right: "auto",
                display: 'none'
            })
        }
    })
    // 每页搜索结果
    var search_num_size;
    search_num_down.find('.drop_link').click(function () {
        // 管理冗余库存
        if(index == 2){
            $('.buttonSizeRy').text($(this).text()).attr('size',$(this).attr('size'));
            inputValue();
            Redundancy();
        }else if(index == 3){
            // 库龄
            $('.buttonSizeKl').text($(this).text()).attr('size',$(this).attr('size'));
            inputValue();
            LibraryAge();
        }else{
            // 管理亚马逊物流退货
            $('.buttonSizeWl').text($(this).text()).attr('size',$(this).attr('size'));
            inputValue();
        }
    })

    // 查看绩效
    $.ajax({
        url: baseUrl + '/Achievements',
        method: 'post',
        dataType: 'json', 
        data: {
            sellerId:amazon_userid,
        },
        success: function (res) {
            console.log(res);
            var widthTemp = (res.IPI / 10).toFixed(1) + '%';
            // IPI指数
            $('.IPI').css('left', widthTemp);
            $('.IPIspan').css('left', widthTemp).text(res.IPI);
            // 冗余库存
            $('.redundancy').css('left', res.redundancy.substr(0,res.redundancy.length-1)-3+"%");
            $('.redundancSpan').css('left', res.redundancy).text(res.redundancy);
            // 销量
            $('.SalesVolume').css('left', res.SalesVolume.substr(0,res.SalesVolume.length-1)-3+"%");
            $('.SalesVolumeSpan').css('left', res.SalesVolume).text(res.SalesVolume);
            // 无在售信息的亚马逊库存
            $('.noSalesStock').css('left', res.noSalesStock.substr(0,res.noSalesStock.length-1)-3+"%");
            $('.noSalesStockSpan').css('left', res.noSalesStock).text(res.noSalesStock);
            // 有存货库存
            $('.cargoStock').css('left', res.cargoStock.substr(0,res.cargoStock.length-1)-3+"%");
            $('.cargoStockSpan').css('left', res.cargoStock).text(res.cargoStock);
        },
        error: function () {
            console.log(decodeURIComponent(res.error))
        }
    })
    

    // 查看亚马逊仓库商品库龄信息
    function LibraryAge() { 
        $.ajax({
            url: baseUrl + '/LibraryAge',
            method: 'post',
            dataType: 'json',
            data: {
                sellerId:amazon_userid,
                keyWord:keyWordkl,
                currentPage:currentPageKl,
                pageSize:buttonSizeKl
            },
            success: function (res) {
                //console.log(res)
                console.log(res.list)
                let resData = res.list
                var add = doT.template($('#addArray').text());
                $('#addTmpl').html(add(resData));
                $('.num').text(res.totalRecords);
            },
            error: function () {
                console.log(decodeURIComponent(res.error))
            }
        })
    }
    LibraryAge()
    // 管理冗余库存
    function Redundancy() {  
        $.ajax({
            url: baseUrl + '/Redundancy',
            method: 'post',
            dataType: 'json',
            data: {
                sellerId:amazon_userid,
                keyWord:keyWordry,
                currentPage:currentPageRy,
                pageSize: buttonSizeRy 
            },
            success: function (res) {
                console.log(res)
                let resData = res.list
                var ryAdd = doT.template($('#ryArray').text());
                $('#ryTmpl').html(ryAdd(resData));
                $('.num').text(res.totalRecords);
                $('.totalPages').text(res.totalPages);
                $('input[type="number"]').attr('max',res.totalPages)
            },
            error: function () {
                console.log(decodeURIComponent(res.error))
            }
        })
    }
    Redundancy()
  
    $('.goToRy').click(function () {
        inputValue()
        if(currentPageRy != $('.currentPagery').attr('max')){
            Redundancy()
        }    
    })
    
})