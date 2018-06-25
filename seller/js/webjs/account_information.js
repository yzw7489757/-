window.onload = function() {
    //新建弹窗，然后里面的样式你自己去写
    var  what = document.getElementById('what')
    what.onclick = openwindow();
  function openwindow() {
    let width = document.documentElement.clientWidth;//获取当前屏幕的宽度，这个宽度是除去控制台的宽度，body的宽度
    let height = window.screen.height;//获取当前显示器的高度，浏览器
    // console.log(width,height)
    let left = (width - 350) / 2;
    let top = (height - 458) / 3;
    // console.log(left,top)
    window.open(
      "./shared.html",
      "_blank",
      `width=350,height=458,left=${left},top=${top},menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes`
    );
  }


};
