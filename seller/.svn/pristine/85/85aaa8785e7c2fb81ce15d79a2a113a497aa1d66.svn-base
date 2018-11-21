$(function(){
    var status_nav = $('.status-nav');
    var status_tab = $('.status-tab');
    status_nav.on('click', 'li', function(event) {
        event.preventDefault();
        if($(this).hasClass('active')){
            return;
        }
        $(this).addClass('active').siblings().removeClass('active');
        status_tab.eq($(this).index()).removeClass('hide').siblings().addClass('hide');    
    })
})