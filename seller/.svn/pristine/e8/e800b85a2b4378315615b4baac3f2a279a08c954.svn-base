var ask_inform_html = '<div class="ask_inform_box">'+
                          '<div class="showCloseIcon">'+
                              '<i class="a-icon a-icon-close"></i>'+
                          '</div>'+
                          '<div class="questionAnswer">'+
                              '<span class="ask_question a-text-bold"></span>'+
                              '<p class="b-color-tertiary answer_con"></p>'+
                          '</div>'+
                      '</div>'
function popover_click(ask,ask_inform_box){
    var answer_show = ask_inform_box.children('.questionAnswer');
    ask.click(function() {
       var t = $(this).offset().top - 10;
       var l = $(this).offset().left - ask_inform_box.outerWidth(true) - 20;
       answer_show.children('.ask_question').text($(this).attr("quesition"))
       answer_show.children('.answer_con').text($(this).attr("content"))
       ask_inform_box.css({ top: t,left: l}).fadeIn(300);
    })
    ask_inform_box.children('.showCloseIcon').click(function() {
        ask_inform_box.fadeOut(300);
    })
}
$(function(){
    $('body').append(ask_inform_html)
})

