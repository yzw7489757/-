function CreatSelect(e,addClass,arrList,fun,dir){
    if(e.attr('creat') == "true"){
        var Wh = $(window).height();
        var selecrt_down_html = '<div class="popover_down '+addClass+'">'+
                                    '<div class="popover_down_innner" style="max-height:'+(Wh/2.5)+'px;min-width:'+e.outerWidth()+'px;">'+
                                        '<ul class="drop_group">'+
                                        '</ul>'+
                                    '</div>'+
                                '</div>';
        $('body').append(selecrt_down_html);
        var drop_group = $('.'+addClass).find('.drop_group');
        var drop_li_html = '';
        if($.type(arrList) == 'array'){
            for(var i=0;i<arrList.length;i++){
                if(e.children('span').text() == arrList[i]){
                    drop_li_html += '<li>'+
                                        '<a href="javascript:;" class="drop_link a-selected" i='+i+'>'+
                                            arrList[i]+
                                        '</a>'+
                                    '</li>'
                }else{
                    drop_li_html += '<li>'+
                                        '<a href="javascript:;" class="drop_link" i='+i+'>'+
                                            arrList[i]+
                                        '</a>'+
                                    '</li>'
                }
            }
            drop_group.html(drop_li_html);
        }
        if($.type(arrList) == 'object'){
            for(var j in arrList){
                if(e.children('span').text() == arrList[j]){
                    drop_li_html += '<li>'+
                                        '<a href="javascript:;" class="drop_link a-selected" i='+j+'>'+
                                            arrList[j]+
                                        '</a>'+
                                    '</li>'
                }else{
                    drop_li_html += '<li>'+
                                        '<a href="javascript:;" class="drop_link" i='+j+'>'+
                                            arrList[j]+
                                        '</a>'+
                                    '</li>'
                }
            }
            drop_group.html(drop_li_html);
        }
    }
    e.attr('creat',"false");
    dropdown(e,$('.'+addClass),dir);
    $('.'+addClass).fadeIn(0).siblings('.popover_down').fadeOut(0);
    var drop_group = $('.'+addClass).find('.drop_group');
    drop_group.off('click').on('click', '.drop_link', function(event) {
        event.stopPropagation();
        drop_group.find('.drop_link').removeClass('a-selected');
        $(this).addClass('a-selected');
        e.children('span').text($(this).text());
        if($.type(fun) === "function"){
            fun($(this).attr('i'));
        }
        $('.'+addClass).fadeOut(0);
    })
    $(document).off('click').click(function(event) {
        if(!$('.popover_down').is(event.target) && $('.popover_down').has(event.target).length === 0){ 
            $('.popover_down').fadeOut(0);
        }
    })
}
function dropdown(e,popover_down,dir){
    dir = dir || 'l';
    var Wh = $(window).height();
    var popover_h = popover_down.height();
    var SollTop = $(document).scrollTop();
    var t = e.offset().top-1;
    var wt = e.offset().top - SollTop;
    if(Wh - wt < popover_h){
        t = t - popover_h + e.outerHeight(true);
    }
    var l = e.offset().left-1;
    if(dir == 'r'){
        var r = $(window).width() - l - e.outerWidth(true);
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
