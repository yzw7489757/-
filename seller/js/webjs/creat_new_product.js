$(function(){
    var card_inner = $("#category_browse_card_1").find('.scrollable-browse');
    var loading_html = '<div class="loading_box">'+
                            '<img src="img/loading-2x.gif" alt="加载中..." />'+
                        '</div>'
    card_inner.append(loading_html)
    var block;
    inputctr.public.GetCategory(0, function (data){
        if(data){
            card_inner.empty()
        }else{
            alert("网络错误！");
            return;
        }
        for(var i in data){
            var product_html = '<li>'+
                                    '<a href="javascript:;" class="browse-link clear_both" id="'+data[i].id+'">'+
                                        '<span class="browse_path_label fl"> '+decodeURIComponent(data[i].name)+' </span>'+
                                        '<i class="a-icon-touch-link sprites fr"></i>'+
                                    '</a>'+
                                '</li>'
            card_inner.append(product_html)
            if(data[i].state != 1){
                $(".browse-link").addClass('lock-link')
            }
        }
        function append(){
           card_inner.find('.browse-link').on("click", function(){
               var card = $(this).parent().parent().attr('card');
               if(block-card>=2){
                    $('#category_browse_card_'+block+'').removeClass('active_card').find('.scrollable-browse').empty();
               }
               $('#category_browse_card_'+card+'').removeClass('active_card');
               card++;
               block = card;
               $('#category_browse_card_'+card+'').addClass('active_card');
               card_inner = $('#category_browse_card_'+card+'').find('.scrollable-browse');
               card_inner.append(loading_html)
               inputctr.public.GetCategory(this.id, function (data){
                   console.log(data)
                   if(data){
                       card_inner.empty()
                   }else{
                       alert("网络错误！");
                       return;
                   }
                   for(var i in data){
                       var product_html = '<li>'+
                                               '<a href="javascript:;" class="browse-link clear_both" id="'+data[i].id+'">'+
                                                   '<span class="browse_path_label fl"> '+decodeURIComponent(data[i].name)+' </span>'+
                                                   '<i class="a-icon-touch-link sprites fr"></i>'+
                                               '</a>'+
                                           '</li>'
                       card_inner.append(product_html)
                       if(data[i].state != 1){
                           $(".browse-link").addClass('lock-link')
                       }
                   }
                   append()
               })
           }) 
        }append()
    })
})
