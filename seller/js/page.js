//创建分页模板
//var currentPage = 1; // 当前页码, 从1开始
var maxButtons = 3; // 最中间显示的分页按钮数量
//var totalPage  // 总页数
var pagebox = $('#pagn');
function  initPage(totalPage,currentPage,fun) {
    var pageHtml = '';
    totalPage = parseInt(totalPage);
    currentPage = parseInt(currentPage);
    function pageNormal(i){
        return '<li class="a-normal">'+
                   '<a href="javascript:;" data-num='+i+'>'+i+'</a>'+
               '</li>'
    }
    var pageSelected = '<li class="a-selected">'+
                           '<a href="javascript:;">'+currentPage+'</a>'+
                       '</li>';
    var pageLoad = '<li class="a-disabled">'+
                        '...'+
                   '</li>';
    var prevDisabled = '<li class="a-disabled">'+
                            '←'+
                            '<span class="a-letter-space"></span>'+
                            'Previous'+
                        '</li>';
    var nextDisabled = '<li class="a-disabled">'+
                            'Next'+
                            '<span class="a-letter-space"></span>'+
                            '→'+
                        '</li>';
    var prevPage = '<li>'+
                        '<a href="javascript:;" data-num='+(currentPage - 1)+'>'+
                            '←'+
                            '<span class="a-letter-space"></span>'+
                            'Previous'+
                        '</a>'+
                    '</li>';
    var nextPage = '<li>'+
                        '<a href="javascript:;" data-num='+(currentPage+1)+'>'+
                            'Next'+
                            '<span class="a-letter-space"></span>'+
                            '→'+
                        '</a>'+
                    '</li>';
    if(totalPage >= 1){
        pagebox.removeClass('hide');
        if(currentPage != 1){
            pageHtml += prevPage;
        }else{
           //如果是第一页，禁用上一页
            pageHtml += prevDisabled
        }
       // 中间数字页码
       var i = 1;
       if (totalPage <= 5 ) {
           for (i; i <= totalPage; i++) {
               if (i == currentPage) {
                   pageHtml += pageSelected
               }else{
                   pageHtml += pageNormal(i)
               }
           }
       }else if (totalPage > 5) {//总页数大于五页，则加载5页
           if (currentPage < 5) {//当前页小于5，加载1-4页
               for (i; i <= 4; i++) {
                   if (i == currentPage) {
                       pageHtml += pageSelected
                   }else{
                       pageHtml += pageNormal(i)
                   }
               };
               if (currentPage <= totalPage-2) {//最后一页追加“...”代表省略的页
                   pageHtml += pageLoad+pageNormal(totalPage)
                               
               }
           }else if (currentPage >= 5) {//当前页大于5页
               for (i; i <= 1; i++) {//1页码始终显示
                   pageHtml += pageNormal(i)
               }
               pageHtml += pageLoad //1页码后面用...代替部分未显示的页码
               if (totalPage - currentPage <= 2 && currentPage != totalPage) {
                   for(i = totalPage-maxButtons; i <= totalPage; i++){
                       if (i == currentPage) {
                           pageHtml += pageSelected
                       }else{
                           pageHtml += pageNormal(i)
                       }
                   }
               }else if (currentPage == totalPage) {//当前页数等于总页数则是最后一页页码显示在最后
                   for(i = currentPage-maxButtons; i <= totalPage; i++){//...后面跟maxButtons个页码当前页居中显示
                       if (i == currentPage) {
                           pageHtml += pageSelected
                       }else{
                           pageHtml += pageNormal(i)
                       }
                   }
               }else{//当前页小于总页数，则最后一页后面跟...
                   for(i = currentPage-1; i <= currentPage+1; i++){//currentPage+1页后面...
                       if (i == currentPage) {
                           pageHtml += pageSelected
                       }else{
                           pageHtml += pageNormal(i)
                       }
                   }
                   pageHtml += pageLoad+pageNormal(totalPage)
               }
           }
       }
       //当前页不是总页，即是最后一页
       if (currentPage != totalPage) {
            pageHtml += nextPage;
       } else {
           //如果是最后页，禁用下一页
           pageHtml += nextDisabled
       }
   }else{
      pagebox.addClass('hide');  
   }
    pagebox.html(pageHtml);
    pagebox.find('a').off('click').click(function(){
        if($(this).parent().hasClass('a-selected')){
            return;
        }
        if($.type(fun) === "function"){
            fun($(this).attr('data-num'));
        }
    })
}