var method = {
    msg_layer: function (obj) {
        $(".popup").append(
            `
        <div class="popup none">
            <div class="model-wrapper">
                <div class="modal-popover-under-layer msg-layer-bg"></div>
                <div class="a-popover-modal modal-content-big msg-layer showAlert">
                    <div class="msg-con">
                        <div class="a-popover-header">
                            <h4 class="a-popover-header-content">编辑默认配送地址</h4>
                        </div>
                        <div class="a-popover-inner ">
                            <div class="a-popover-footer layer-btn">
                                <div>
                                    <span class=" a-button-inner  a-button">
                                        <span class="a-button-text border_box block btnstyle layer-cancel">取消</span>
                                    </span>
                                    <span class=" a-button-inner  a-button a-button-primary">
                                        <span class="a-button-text border_box block btnstyle layer-commit">保存</span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            `
        )
        var _layerBg = $(".msg-layer-bg"),
        _layer = $(".msg-layer"),
        _close = $(".layer-close"),
        _cansel = $(".layer-cancel"),
        _commit = $(".layer-commit");
    }
}