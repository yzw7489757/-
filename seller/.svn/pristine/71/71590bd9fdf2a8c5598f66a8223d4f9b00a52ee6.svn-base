function addPopup(obj,callback,GetTimeZone) {
    if ($('.model-wrapper').length === 0) {
        $('body').append($(`<div class="model-wrapper ${obj.parentClass||''}">
                                <div class="model-wrapper-bg">
                                    <div class="model-content ${obj.className}" style="width:${obj.width};">
                                        <div class="model-content-header">
                                            <h4 class="model-wrapper-content-text">${obj.title}</h4>
                                        </div>
                                        <div class="model-wrapper-content">

                                        </div>
                                        <div class="model-footer">
                                            <span class=" a-button-inner  a-button">
                                                <span class="a-button-text border_box block btnstyle model-cancel">${obj.btn[1]}</span>
                                            </span>
                                            <span class=" a-button-inner  a-button a-button-primary">
                                                <span class="a-button-text border_box block btnstyle model-commit">${obj.btn[0]}</span>
                                            </span>
                                        </div>
                                    </div>
                                    </div>
                                </div> 
                            </div>`))
    } else {
        $('.model-wrapper').show();
        if (obj.type === 1) {
            if ($(`.${obj.className} `).length !== 0) {
                $(`.${obj.className}`).show();
                return
            }
            $('.model-wrapper .model-wrapper-bg').append(`<div class="model-content ${obj.className}" style="width:${obj.width};">
                                            <div class="model-content-header">
                                                <h4 class="model-wrapper-content-text">${obj.title}</h4>
                                            </div>
                                            <div class="model-wrapper-content">

                                            </div>
                                            <div class="model-footer">
                                                        <span class=" a-button-inner  a-button">
                                                            <span class="a-button-text border_box block btnstyle model-cancel">${obj.btn[1]}</span>
                                                        </span>
                                                        <span class=" a-button-inner  a-button a-button-primary">
                                                            <span class="a-button-text border_box block btnstyle model-commit">${obj.btn[0]}</span>
                                                        </span>
                                            </div>
                                        </div>`)
        }
    }
    if (obj.commit) {
        $(`.${obj.className} .model-commit`).click(obj.commit)
    }
    if (obj.cancel) {
        $(`.${obj.className} .model-cancel`).click(obj.cancel)
    }
    // if (obj.contral) {
    //     $('.model-wrapper-bg').on('click', function () {
    //         $('.model-wrapper').hide();
    //         $(obj.className).hide();
    //     })
    // }

    if (obj.content) {
        $(`.${obj.className} .model-wrapper-content`).append(obj.content)  
    }
    if(callback){
        callback()
    }
    if(GetTimeZone){
        GetTimeZone()
    }
}