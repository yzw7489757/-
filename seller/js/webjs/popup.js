var method = {
    msg_layer: function (obj,callback,GetTimeZone) {
        $("body").append(
            `
            <div class="model-wrapper">
                <div class="modal-popover-under-layer msg-layer-bg"></div>
                <div class="a-popover-modal  msg-layer showAlert">
                    <div class="a-popover-header">
                        <h4 class="a-popover-header-content"></h4>
                    </div>
                    <div class="a-popover-inner msg-con">
                    </div>
                    <div class="a-popover-footer layer-btn">
                        <div>
                            <span class=" a-button-inner  a-button">
                                <span class="a-button-text border_box block btnstyle layer-cancel"></span>
                            </span>
                            <span class=" a-button-inner  a-button a-button-primary">
                                <span class="a-button-text border_box block btnstyle layer-commit"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            `
        )
        var _layerBg = $(".msg-layer-bg"),
            _layer = $(".msg-layer"),
            _cancel = $(".layer-cancel"),
            _commit = $(".layer-commit");
        if(obj.classname){
            _layer.addClass(obj.classname)
        }
        if (obj.title) {
            _layer.find("h4").html(obj.title);
        } else {
            _layer.find("h4").parents('.a-popover-header').hide()
        }
        if (obj.content) {
            _layer.find($(".msg-con")).html(obj.content);
        }
        if (obj.btn) {
            //按钮
            if (obj.btn[0] != "") {
                // _cancel.css("display", "inline-block");
                _cancel.text(obj.btn[0]);
                _cancel.on("click", function () {
                    if(obj.type===1){
                        $('.model-wrapper').remove()
                    }else{
                       
                    }
                })

            }
            if (obj.btn[1] != "") {
                //  _commit.css("display", "inline-block");
                _commit.text(obj.btn[1]);
                _commit.on("click", function () {
                    if(obj.type===1){
                        $('.popup').hide()
                    }else{
                        callback()
                        return;
                    }
                })
            }
        }
        if(callback && typeof callback ==='function'){
            callback();
        }
        if(GetTimeZone && typeof GetTimeZone ==='function'){
            GetTimeZone();
        }
        
    }
    
}