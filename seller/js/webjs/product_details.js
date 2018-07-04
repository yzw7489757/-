$(function(){
    // 双滑块点击同步效果
    var switch_background = $(".switch-background");
    var advanced_view_switch = $(".toggle-input");
    var nav_tab = $(".nav_tab");
    var flag = 1;
    switch_background.click(function(){
        flag++;
        setTimeout(function(){
            if(flag%2 == 0){
                advanced_view_switch.prop("checked",true);
                nav_tab.children('.tab[name="off"]').removeClass('hide')
            }else{
                advanced_view_switch.prop("checked",false);
                nav_tab.children('.tab[name="off"]').addClass('hide')
            }
        }, 0)
    })
    // 产品详情选项卡
    var product_nav = $(".nav_tab");
    var product_tab = product_nav.children('.tab');
    var segment = $(".content .segment");
    product_tab.click(function(){
        $(this).addClass('active').siblings().removeClass('active');
        segment.eq($(this).index()).removeClass('hide').siblings().addClass('hide');
    })
    // Add More 
    var attributeMultiControls = $(".attributeMultiControls");
    var bullet_point = $(".bullet-point")[0];
    var add_n = 0;
    attributeMultiControls.children('.AddMore').click(function(){
        add_n++;
        if($(this).attr('add') == 'bullet-point'){
            $(this).parent().before('<input type="text" class="bullet-point">');
        }
        if(add_n >= 4){
            $(this).addClass('hide').siblings().toggleClass('hide');
            return;
        }
    })
})