$(function(){
    // 下拉菜单效果
    var other_filter = $(".other-filter");
    var splitdropdown = $('.splitdropdown');
    var popover_down = $(".popover_down");
    function dropdown(e,dir){
        dir = dir || 'l';
        e.click(function(){
            var t = $(this).offset().top-1;
            var l = $(this).offset().left-1;
            if(dir == 'r'){
                var r = $(window).width() - l - $(this).outerWidth(true);
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
        })
    }
    dropdown(other_filter)
    dropdown(splitdropdown,'r')
    dropdown($(".search_num"),'r')
    $(document).click(function(event) {
       if(!$(event.target).hasClass('drop_ul')){
            popover_down.css({
                top: "auto",
                left: "auto",
                right:"auto",
                display:'none'
            })
        }
    })
    // input "radio" "checked"
    var mt_select_all = $("#mt-select-all");
    var procuct_input = $("td[data-column='select']").find('input[type="checkbox"]');
    var declarative = $(".declarative");
    mt_select_all.click(function(){
        if($(this).prop('checked')){
            procuct_input.prop('checked',true);
            declarative.attr("disabled",false);
            declarative.children('span').text(procuct_input.length);
        }else{
            procuct_input.prop('checked',false);
            declarative.attr("disabled",true);
            declarative.children('span').text('0');
        }
    })
    procuct_input.click(function(){
        var product_select_all = procuct_input.filter(function(index) {
           return $(this).is(':not(:checked)');
        })
        if(procuct_input.is(":checked")){
            declarative.attr("disabled",false);
            declarative.children('span').text(procuct_input.length - product_select_all.length);
        }else{
            declarative.attr("disabled",true);
            declarative.children('span').text('0');
        }
        if(!product_select_all.length){
            mt_select_all.prop('checked',true);
        }else{
            mt_select_all.prop('checked',false);
        }
    })
})