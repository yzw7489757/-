$(function () { 
     // tab切换
     $('.a-container>ul>li>a').click(function (item) {
        $('.a-container ul li a').removeClass('active');
        index = $(this).parent('li').index();
        $(this).addClass('active');
        $('.a-container>ol>li').eq(index).show().siblings().hide();
        console.log($('ol li').eq(index))
    })
 })