window.onload = function () {
  var what = document.getElementById('what')
  var showList = true
  what.onclick = openwindow();


  function openwindow() {
    let width = document.documentElement.clientWidth; //获取当前屏幕的宽度，这个宽度是除去控制台的宽度，body的宽度
    let height = window.screen.height; //获取当前显示器的高度，浏览器
    let left = (width - 350) / 2;
    let top = (height - 458) / 3;
    // console.log(left,top)
    /*window.open(
      "./shared.html",
      "_blank",
      `width=350,height=458,left=${left},top=${top},menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes`
    );*/
  }


  //移动DOM
  var spaui = document.getElementById('spaui');
  var toggleChange = document.getElementById('toggleChange');
  var getSurport = document.getElementById('getSurport');
  var search = document.getElementById('spaui-head-controls-search');
  var timer = null;
  var show = false; //控制显示隐藏
  var showToggle = true; //控制放大
  var timerForInput = null; //搜索框变化
  let divWidth = 410;

  toggleChange.onclick = function () {
    showToggle ? divWidth = 571 : divWidth = 410;
    spaui.style.width = divWidth + 'px';
    if (showToggle) {
      search.style.width = '466px'
    } else {
      search.style.width = '302px'
    }
    spaui.style.right = '0px';
    showToggle = !showToggle
  }
  getSurport.onclick = function () {
    show ? spaui.style.right = -divWidth + 'px' : spaui.style.right = '0px';
    show = !show;
  }

  function moveto(object, itarget) {
    show = !show;
    let obj = document.getElementById(object);
    clearInterval(timer);
    timer = setInterval(function () {
      let speed = 0;
      if (obj.offsetLeft < itarget) {
        //通过位移量除以10，使speed递减，实现减速停止。
        speed = (itarget - obj.offsetLeft) / 15;
      } else {
        // 乘以10则为加速。通过乘除的数字，控制快慢
        speed = -(obj.offsetLeft - itarget) / 15;
      }
      speed = speed > 0 ? Math.ceil(speed) : Math.floor(speed); //取整，解决最后不足1px的位移量被忽略的问题
      if (obj.offsetLeft == itarget) {
        clearInterval(timer);
      } else {
        obj.style.left = obj.offsetLeft + speed + 'px';
      };
    }, 20);
  };
  var sc_hover_nav = $('.sc-hover-nav');
  var sc_sub_nav = $('.sc-sub-nav')
  var spaui_get_support_card_body = $('.spaui-get-support-card-body')
  var spaui_get_support_card_item = $('.spaui-get-support-card-item')
  console.log(sc_hover_nav)

  for (let i = 0; i < sc_hover_nav.length; i++) {
    $('.sc-hover-nav').eq([i]).attr('data-list', i)
    $('.sc-hover-nav')[i].addEventListener('mouseover', function () {
      $('.sc-hover-nav').eq([this.dataset.list])
        .find('.sc-nav-arrow').eq(0).css({
          opacity: 1,
          visibility: 'visible'
        });
      $('.sc-hover-nav').eq([this.dataset.list])
        .find('.sc-sub-nav').eq(0).css({
          display: 'block'
        });
    })
    $('.sc-hover-nav')[i].addEventListener('mouseout', function () {
      $('.sc-hover-nav').eq([this.dataset.list])
        .find('.sc-nav-arrow').eq(0).css({
          opacity: 0,
          visibility: 'hidden'
        });
      $('.sc-hover-nav').eq([this.dataset.list])
        .find('.sc-sub-nav').eq(0).css({
          display: 'none'
        });
    })
  }

  // 获得支持
  for (let i = 0; i < spaui_get_support_card_item.length; i++) {
    $('.spaui-get-support-card-item').eq([i]).attr('data-list', i)
    $('.spaui-get-support-card-item')[i].addEventListener('click', function () {
      if (showList) {
        showList = false
        $('.spaui-get-support-card-item').eq([this.dataset.list])
          .find('.spaui-get-support-card-item-body').eq(0).css({
            display: 'block'
          });
      } else {
        showList = true
        $('.spaui-get-support-card-item')[i].addEventListener('click', function () {
          $('.spaui-get-support-card-item').eq([this.dataset.list])
            .find('.spaui-get-support-card-item-body').eq(0).css({
              display: 'none'
            });
        })
      }
    })
  }

  // $('#sc-ql-sz').on("mouseover", function () {
  //   $('.sc-nav-arrow-right').css({
  //     opacity: 1,
  //     visibility: 'visible'
  //   });
  //   $('.sc-sub-nav-right').css({
  //     display: 'block'
  //   });
  // })
  // $('#sc-ql-sz').on("mouseout", function () {
  //   timeout = setTimeout(function () {
  //     $('.sc-nav-arrow-right').css({
  //       opacity: 0,
  //       visibility: 'hidden'
  //     });
  //     $('.sc-sub-nav-right').css({
  //       display: 'none'
  //     });
  //     $('.sc-sub-nav-right-hover').on("mouseover", function () {
  //       $('#sc-sub-nav-right-hover').addClass('bgColor')
  //     });
  //     $('.sc-sub-nav-right-hover').on("mouseout", function () {
  //       $('#sc-sub-nav-right-hover').removeClass('bgColor')
  //     })
  //   },2000)
  // })
  var timer_sc = null;
  $('#sc-ql-sz').hover(function () {
    $('.sc-nav-arrow-right').addClass('opacity_visibility')
    $('.sc-sub-nav-right').addClass('display_block');
    console.log('触发显示1')
  }, function () {
    timer_sc = setTimeout(function () {
      $('.sc-nav-arrow-right').removeClass('opacity_visibility')
      $('.sc-sub-nav-right').removeClass('display_block')
    }, 1000)
    console.log('触发隐藏1')

  })
  // 点击关闭按钮
  $('.spaui-close').on('click', function () {

  })
$('#sc-sub-nav-right').hover(function(){
    clearInterval(timer_sc); //做的就是将延迟事件移除掉，
  },function(){
    $('.sc-nav-arrow-right').removeClass('opacity_visibility')
   $('#sc-sub-nav-right').removeClass('display_block')
  })
  /*let i = 0;
  let active = document.getElementById('sc-sub-nav-right')
  active.onmouseover = function(){
    clearInterval(timer_sc); //做的就是将延迟事件移除掉，
    console.log('触发显示'+i)
    i++
  }
  active.onmouseout = function(){
    console.log('触发隐'+i)//git 我看下为什么会触发多次onmouseout事件
  i++ 
  $('.sc-nav-arrow-right').removeClass('opacity_visibility')
   $('#sc-sub-nav-right').removeClass('display_block')
  }*/
 /*$('#sc-sub-nav-right').mouseover( function () { //移入ul的时候，也让它显示
    clearInterval(timer_sc); //做的就是将延迟事件移除掉，
    console.log('触发显示'+i)
    i++
  });
  $('#sc-sub-nav-right').mouseout(function () {
   console.log('触发隐'+i)
  i++      
  })*/
};