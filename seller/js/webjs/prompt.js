
    function addwarn(target,type,text){
        /*
        * @target 插入的目标节点
        * @type图片类型，1为info i，2是error ！
        * @text  提示文字
        */
        let imgtype = '';
        type == 1?imgtype="info":imgtype="error";
        let div = document.createElement('div');
        div.setAttribute('class','a-row myWarn')
        div.innerHTML = `<div class="a-column ">
                                <div  class="a-box a-alert-inline a-alert-inline-${imgtype}" >
                                    <div class="a-box-inner a-alert-container">
                                        <i class="a-icon a-icon-alert"></i>
                                        <div class="a-alert-content">
                                            ${text}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        `
        if(document.getElementById(target).getElementsByTagName('input')[0]){
          //input框
          $(`#${target} input`).after(div)
        }else if(document.getElementById(target).getElementsByTagName('select')[0]){
          //select下拉框
          $(`#${target} select`).after(div)
          
        }else{
          //其他处理
        }
      }
    