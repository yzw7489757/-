$(function () {
    inputctr.public.checkLogin();
    var methos_id = null;
    
    function GetAddressList() {
        // 默认地址
        $.ajax({
            url: baseUrl + '/GetAddressList',
            method: 'post',
            dataType: "json",
            data: {
                userid: amazon_userid,
                sign: '3'
            },
            success: function (res) {
                console.log(res)
                if (res.result == 1) {
                    methos_id = res.registered_address_Id
                    address_data = res.List
                    for (let i = 0; i < address_data.length; i++) {
                        address_data[i].status = false;
                        if (address_data[i].address_id == res.registered_address_Id) {
                            address_data[i].status = true;
                        }
                    }
                    var add = doT.template($('#addArray').text());
                    $('#addTmpl ').html(add(address_data));
                    $('input[type="radio"]:checked').parents('.add').addClass('address-item-select')
                    $('.add input').each(function (i) {
                        $('.add input').eq(i).click(function () {
                            methos_id = $('input[type="radio"]:checked').parents('.add').attr('data-id')
                            console.log(methos_id)
                        })
                    })
                } else {
                    console.log(decodeURIComponent(res.error))
                }
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error))
            }
        })

    }

    function GetTimeZone () { 
        $.ajax({
            url: baseUrl + '/GetAddressList',
            method: 'post',
            dataType: "json",
            data: {
                userid: amazon_userid,
                sign: '3'
            },
            success: function (res) {
                console.log(res)
                if (res.result == 1) {
                
                } else {
                    console.log(decodeURIComponent(res.error))
                }
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error))
            }
        })
     }
   

    //配送设置（初始化详细信息）
    $.ajax({
        url: baseUrl + "/InitialShippingSettings",
        method: "post",
        dataType: "json",
        data: {
            userid: amazon_userid
        },
        success: function (res) {
            console.log(res);
            if (res.result == 1) {
                var data = res.data.strAddress
                $('.name').text(decodeURIComponent(data.name))
                $('.address').text(decodeURIComponent(data.address))
                $('.address2').text(decodeURIComponent(data.address2))
                $('.city').text(decodeURIComponent(data.city))
                $('.country').text(decodeURIComponent(data.country))
                $('.email').text(decodeURIComponent(data.email))
                $('.full_name').text(decodeURIComponent(data.full_name))
                $('.phone').text(decodeURIComponent(data.phone))
                $('.province').text(decodeURIComponent(data.province))
                $('.zipcode').text(decodeURIComponent(data.zipcode))
                console.log("success!");
                if (window.sessionStorage) {
                    sessionStorage.setItem('address_id', decodeURIComponent(data.address_id))
                }

            } else {
                console.log(decodeURIComponent(res.error));

            }
        },
        error: function (res) {
            console.log(decodeURIComponent(res.error));
        }
    });

  
   
     // 取消
     $('.layer-cancel').click(function () { 
       
      })
    $('.saveBtn').click(function () { 
        // 点击删除
        $.ajax({
            url: baseUrl + "/DelDistributionAddress",
            method: "post",
            dataType: "json",
            data: {
                addressId: methos_id
            },
            success: function (res) {
                console.log(res);
                if (res.result == 1) {
                   // window.location.reload();
                    console.log("success!");
                } else {
                    console.log(decodeURIComponent(res.error));
                }
            },
            error: function (res) {
                console.log(decodeURIComponent(res.error));
            }
        });
     })
        // 编辑
    $('.editBtn_first').click(function () {
        var obj = {
            type: "layerFadeIn",
            title: "编辑默认配送地址",
            classname:"modal-content-big",
            type:1,
            content: `<table class="a-normal">
                    <tr>
                        <td class="a-span8">
                            <div class="normal-font shipping_address_content">
                                <div class="alertBox"></div>
                                <div class="a-form-label margin-bottom">
                                    <span>选择地址</span>
                                </div>
                                <hr class="a-divider-normal">
                                <div class="addressList-size" id="addressList">
                                    <div id="addTmpl">
                                    </div>
                                    
                                </div>
                                <div>
                                    <a class="add_new_address">+ 添加新地址</a>
                                </div>
                                <div class="a-form-label relative">
                                    <div class="timeZoneTitle">
                                        <span>选择正确的时区作为您的默认配送地址</span>
                                    </div>
                                    <hr class="a-divider-normal">
                                    <div class="a-dropdown-container ">
                                        <div id="choose_time" class="bank-account-dropdown a-button a-button-dropdown relative">
                                            <p class="pstyle">(UTC-7:00) 美国/太平洋</p>
                                        </div>
                                        <div class="a-box time none">
                                            <ul class="a-box  overflow_y">
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_0" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Midway&quot;}" id="timeZoneDropdown_0"
                                                        class="a-dropdown-link">(UTC-11:00) 太平洋/中途岛</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_1" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Pago_Pago&quot;}" id="timeZoneDropdown_1"
                                                        class="a-dropdown-link">(UTC-11:00) 太平洋/帕果 - 帕果</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_2" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Honolulu&quot;}" id="timeZoneDropdown_2"
                                                        class="a-dropdown-link">(UTC-10:00) 太平洋/檀香山</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_3" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Hawaii&quot;}" id="timeZoneDropdown_3"
                                                        class="a-dropdown-link">(UTC-10:00) 美国/夏威夷</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_4" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Adak&quot;}" id="timeZoneDropdown_4"
                                                        class="a-dropdown-link">(UTC-9:00) 美洲/艾德克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_5" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Anchorage&quot;}" id="timeZoneDropdown_5"
                                                        class="a-dropdown-link">(UTC-8:00) 美洲/安克雷奇</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_6" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Alaska&quot;}" id="timeZoneDropdown_6"
                                                        class="a-dropdown-link">(UTC-8:00) 美国/阿拉斯加</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_7" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Los_Angeles&quot;}" id="timeZoneDropdown_7"
                                                        class="a-dropdown-link">(UTC-7:00) 美洲/洛杉矶</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_8" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Phoenix&quot;}" id="timeZoneDropdown_8"
                                                        class="a-dropdown-link">(UTC-7:00) 美洲/菲尼克斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_9" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Tijuana&quot;}" id="timeZoneDropdown_9"
                                                        class="a-dropdown-link">(UTC-7:00) 美洲/提华纳</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-checked="true" aria-labelledby="timeZoneDropdown_10" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Pacific&quot;}" id="timeZoneDropdown_10"
                                                        class="a-dropdown-link a-active">(UTC-7:00) 加拿大/太平洋</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_11" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Arizona&quot;}" id="timeZoneDropdown_11"
                                                        class="a-dropdown-link">(UTC-7:00) 美国/亚利桑那</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_12" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Pacific&quot;}" id="timeZoneDropdown_12"
                                                        class="a-dropdown-link">(UTC-7:00) 美国/太平洋</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_13" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Boise&quot;}" id="timeZoneDropdown_13"
                                                        class="a-dropdown-link">(UTC-6:00) 美洲/博伊西</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_14" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Chihuahua&quot;}" id="timeZoneDropdown_14"
                                                        class="a-dropdown-link">(UTC-6:00) 美洲/奇瓦瓦</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_15" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Denver&quot;}" id="timeZoneDropdown_15"
                                                        class="a-dropdown-link">(UTC-6:00) 美洲/丹佛</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_16" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Guatemala&quot;}" id="timeZoneDropdown_16"
                                                        class="a-dropdown-link">(UTC-6:00) 美洲/危地马拉</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_17" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Mountain&quot;}" id="timeZoneDropdown_17"
                                                        class="a-dropdown-link">(UTC-6:00) 加拿大/山区</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_18" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Saskatchewan&quot;}" id="timeZoneDropdown_18"
                                                        class="a-dropdown-link">(UTC-6:00) 加拿大/萨斯喀彻温</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_19" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Mountain&quot;}" id="timeZoneDropdown_19"
                                                        class="a-dropdown-link">(UTC-6:00) 美国/山脉</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_20" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Bogota&quot;}" id="timeZoneDropdown_20"
                                                        class="a-dropdown-link">(UTC-5:00) 美洲/波哥大</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_21" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Chicago&quot;}" id="timeZoneDropdown_21"
                                                        class="a-dropdown-link">(UTC-5:00) 美洲/芝加哥</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_22" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Mexico_City&quot;}" id="timeZoneDropdown_22"
                                                        class="a-dropdown-link">(UTC-5:00) 美洲/墨西哥城</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_23" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Central&quot;}" id="timeZoneDropdown_23"
                                                        class="a-dropdown-link">(UTC-5:00) 加拿大/中部</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_24" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Central&quot;}" id="timeZoneDropdown_24"
                                                        class="a-dropdown-link">(UTC-5:00) 美国/中部</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_25" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Caracas&quot;}" id="timeZoneDropdown_25"
                                                        class="a-dropdown-link">(UTC-4:00) 美洲/加拉加斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_26" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Manaus&quot;}" id="timeZoneDropdown_26"
                                                        class="a-dropdown-link">(UTC-4:00) 美洲/玛瑙斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_27" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/New_York&quot;}" id="timeZoneDropdown_27"
                                                        class="a-dropdown-link">(UTC-4:00) 美洲/纽约</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_28" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/St_Thomas&quot;}" id="timeZoneDropdown_28"
                                                        class="a-dropdown-link">(UTC-4:00) 美洲/圣托马斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_29" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Eastern&quot;}" id="timeZoneDropdown_29"
                                                        class="a-dropdown-link">(UTC-4:00) 加拿大/东部</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_30" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/East-Indiana&quot;}" id="timeZoneDropdown_30"
                                                        class="a-dropdown-link">(UTC-4:00) 美国/东印第安娜</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_31" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US/Eastern&quot;}" id="timeZoneDropdown_31"
                                                        class="a-dropdown-link">(UTC-4:00) 美国/东部</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_32" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Buenos_Aires&quot;}" id="timeZoneDropdown_32"
                                                        class="a-dropdown-link">(UTC-3:00) 美洲/布宜诺斯艾利斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_33" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Montevideo&quot;}" id="timeZoneDropdown_33"
                                                        class="a-dropdown-link">(UTC-3:00) 美洲/蒙得维的亚</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_34" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Santiago&quot;}" id="timeZoneDropdown_34"
                                                        class="a-dropdown-link">(UTC-3:00) 美洲/圣地亚哥</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_35" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Brazil/East&quot;}" id="timeZoneDropdown_35"
                                                        class="a-dropdown-link">(UTC-3:00) 巴西/东部</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_36" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Atlantic&quot;}" id="timeZoneDropdown_36"
                                                        class="a-dropdown-link">(UTC-3:00) 加拿大/大西洋</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_37" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Canada/Newfoundland&quot;}" id="timeZoneDropdown_37"
                                                        class="a-dropdown-link">(UTC-2:30) 加拿大/纽芬兰</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_38" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;America/Godthab&quot;}" id="timeZoneDropdown_38"
                                                        class="a-dropdown-link">(UTC-2:00) 美洲/努克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_39" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Atlantic/South_Georgia&quot;}" id="timeZoneDropdown_39"
                                                        class="a-dropdown-link">(UTC-2:00) 大西洋/南乔治亚岛</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_40" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Atlantic/Cape_Verde&quot;}" id="timeZoneDropdown_40"
                                                        class="a-dropdown-link">(UTC-1:00) 大西洋/佛得角</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_41" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Atlantic/Azores&quot;}" id="timeZoneDropdown_41"
                                                        class="a-dropdown-link">(UTC+0:00) 大西洋/亚速尔群岛</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_42" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Africa/Algiers&quot;}" id="timeZoneDropdown_42"
                                                        class="a-dropdown-link">(UTC+1:00) 非洲/阿尔及尔</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_43" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Africa/Casablanca&quot;}" id="timeZoneDropdown_43"
                                                        class="a-dropdown-link">(UTC+1:00) 非洲/卡萨布兰卡</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_44" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/London&quot;}" id="timeZoneDropdown_44"
                                                        class="a-dropdown-link">(UTC+1:00) 欧洲/伦敦</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_45" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Africa/Cairo&quot;}" id="timeZoneDropdown_45"
                                                        class="a-dropdown-link">(UTC+2:00) 非洲/开罗</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_46" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Africa/Harare&quot;}" id="timeZoneDropdown_46"
                                                        class="a-dropdown-link">(UTC+2:00) 非洲/哈拉雷</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_47" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Africa/Windhoek&quot;}" id="timeZoneDropdown_47"
                                                        class="a-dropdown-link">(UTC+2:00) 非洲/温特和克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_48" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Belgrade&quot;}" id="timeZoneDropdown_48"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/贝尔格莱德</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_49" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Berlin&quot;}" id="timeZoneDropdown_49"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/柏林</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_50" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Brussels&quot;}" id="timeZoneDropdown_50"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/布鲁塞尔</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_51" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Madrid&quot;}" id="timeZoneDropdown_51"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/马德里</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_52" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Paris&quot;}" id="timeZoneDropdown_52"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/巴黎</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_53" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Rome&quot;}" id="timeZoneDropdown_53"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/罗马</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_54" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Warsaw&quot;}" id="timeZoneDropdown_54"
                                                        class="a-dropdown-link">(UTC+2:00) 欧洲/华沙</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_55" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Africa/Nairobi&quot;}" id="timeZoneDropdown_55"
                                                        class="a-dropdown-link">(UTC+3:00) 非洲/内罗比</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_56" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Amman&quot;}" id="timeZoneDropdown_56"
                                                        class="a-dropdown-link">(UTC+3:00) 亚洲/安曼</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_57" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Baghdad&quot;}" id="timeZoneDropdown_57"
                                                        class="a-dropdown-link">(UTC+3:00) 亚洲/巴格达</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_58" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Beirut&quot;}" id="timeZoneDropdown_58"
                                                        class="a-dropdown-link">(UTC+3:00) 亚洲/贝鲁特</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_59" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Jerusalem&quot;}" id="timeZoneDropdown_59"
                                                        class="a-dropdown-link">(UTC+3:00) 亚洲/耶路撒冷</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_60" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Kuwait&quot;}" id="timeZoneDropdown_60"
                                                        class="a-dropdown-link">(UTC+3:00) 亚洲/科威特</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_61" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Athens&quot;}" id="timeZoneDropdown_61"
                                                        class="a-dropdown-link">(UTC+3:00) 欧洲/雅典</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_62" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Helsinki&quot;}" id="timeZoneDropdown_62"
                                                        class="a-dropdown-link">(UTC+3:00) 欧洲/赫尔辛基</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_63" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Minsk&quot;}" id="timeZoneDropdown_63"
                                                        class="a-dropdown-link">(UTC+3:00) 欧洲/明斯克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_64" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Moscow&quot;}" id="timeZoneDropdown_64"
                                                        class="a-dropdown-link">(UTC+3:00) 欧洲/莫斯科</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_65" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Europe/Istanbul&quot;}" id="timeZoneDropdown_65"
                                                        class="a-dropdown-link">(UTC+3:00) 欧洲/伊斯坦布尔</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_66" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Turkey&quot;}" id="timeZoneDropdown_66"
                                                        class="a-dropdown-link">(UTC+3:00) 土耳其</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_67" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Baku&quot;}" id="timeZoneDropdown_67"
                                                        class="a-dropdown-link">(UTC+4:00) 亚洲/巴库</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_68" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Muscat&quot;}" id="timeZoneDropdown_68"
                                                        class="a-dropdown-link">(UTC+4:00) 亚洲/马斯喀特</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_69" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Tbilisi&quot;}" id="timeZoneDropdown_69"
                                                        class="a-dropdown-link">(UTC+4:00) 亚洲/第比利斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_70" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Yerevan&quot;}" id="timeZoneDropdown_70"
                                                        class="a-dropdown-link">(UTC+4:00) 亚洲/耶烈万</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_71" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Kabul&quot;}" id="timeZoneDropdown_71"
                                                        class="a-dropdown-link">(UTC+4:30) 亚洲/喀布尔</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_72" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Tehran&quot;}" id="timeZoneDropdown_72"
                                                        class="a-dropdown-link">(UTC+4:30) 亚洲/德黑兰</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_73" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Karachi&quot;}" id="timeZoneDropdown_73"
                                                        class="a-dropdown-link">(UTC+5:00) 亚洲/卡拉奇</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_74" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Yekaterinburg&quot;}" id="timeZoneDropdown_74"
                                                        class="a-dropdown-link">(UTC+5:00) 亚洲/叶卡捷琳堡</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_75" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Calcutta&quot;}" id="timeZoneDropdown_75"
                                                        class="a-dropdown-link">(UTC+5:30) 亚洲/加尔各答</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_76" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Colombo&quot;}" id="timeZoneDropdown_76"
                                                        class="a-dropdown-link">(UTC+5:30) 亚洲/科伦坡</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_77" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Kolkata&quot;}" id="timeZoneDropdown_77"
                                                        class="a-dropdown-link">(UTC+5:30) 亚洲/加尔各答</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_78" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Katmandu&quot;}" id="timeZoneDropdown_78"
                                                        class="a-dropdown-link">(UTC+5:45) 亚洲/加德满都</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_79" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Dhaka&quot;}" id="timeZoneDropdown_79"
                                                        class="a-dropdown-link">(UTC+6:00) 亚洲/达卡</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_80" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Rangoon&quot;}" id="timeZoneDropdown_80"
                                                        class="a-dropdown-link">(UTC+6:30) 亚洲/仰光</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_81" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Bangkok&quot;}" id="timeZoneDropdown_81"
                                                        class="a-dropdown-link">(UTC+7:00) 亚洲/曼谷</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_82" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Krasnoyarsk&quot;}" id="timeZoneDropdown_82"
                                                        class="a-dropdown-link">(UTC+7:00) 亚洲/克拉斯诺亚尔斯克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_83" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Novosibirsk&quot;}" id="timeZoneDropdown_83"
                                                        class="a-dropdown-link">(UTC+7:00) 亚洲/新西伯利亚</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_84" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Irkutsk&quot;}" id="timeZoneDropdown_84"
                                                        class="a-dropdown-link">(UTC+8:00) 亚洲/伊尔库茨克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_85" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Kuala_Lumpur&quot;}" id="timeZoneDropdown_85"
                                                        class="a-dropdown-link">(UTC+8:00) 亚洲/吉隆坡</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_86" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Shanghai&quot;}" id="timeZoneDropdown_86"
                                                        class="a-dropdown-link">(UTC+8:00) 亚洲/上海</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_87" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Taipei&quot;}" id="timeZoneDropdown_87"
                                                        class="a-dropdown-link">(UTC+8:00) 亚洲/台北</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_88" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Perth&quot;}" id="timeZoneDropdown_88"
                                                        class="a-dropdown-link">(UTC+8:00) 澳大利亚/珀斯</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_89" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Seoul&quot;}" id="timeZoneDropdown_89"
                                                        class="a-dropdown-link">(UTC+9:00) 亚洲/首尔</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_90" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Tokyo&quot;}" id="timeZoneDropdown_90"
                                                        class="a-dropdown-link">(UTC+9:00) 亚洲/东京</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_91" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Yakutsk&quot;}" id="timeZoneDropdown_91"
                                                        class="a-dropdown-link">(UTC+9:00) 亚洲/雅库茨克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_92" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Palau&quot;}" id="timeZoneDropdown_92"
                                                        class="a-dropdown-link">(UTC+9:00) 太平洋/帕劳</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_93" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Adelaide&quot;}" id="timeZoneDropdown_93"
                                                        class="a-dropdown-link">(UTC+9:30) 澳大利亚/阿德莱德</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_94" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Darwin&quot;}" id="timeZoneDropdown_94"
                                                        class="a-dropdown-link">(UTC+9:30) 澳大利亚/达尔文</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_95" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Vladivostok&quot;}" id="timeZoneDropdown_95"
                                                        class="a-dropdown-link">(UTC+10:00) 亚洲/符拉迪沃斯托克</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_96" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Brisbane&quot;}" id="timeZoneDropdown_96"
                                                        class="a-dropdown-link">(UTC+10:00) 澳大利亚/布里斯班</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_97" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Hobart&quot;}" id="timeZoneDropdown_97"
                                                        class="a-dropdown-link">(UTC+10:00) 澳大利亚/霍巴特</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_98" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Melbourne&quot;}" id="timeZoneDropdown_98"
                                                        class="a-dropdown-link">(UTC+10:00) 澳大利亚/墨尔本</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_99" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Australia/Sydney&quot;}" id="timeZoneDropdown_99"
                                                        class="a-dropdown-link">(UTC+10:00) 澳大利亚/悉尼</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_100" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Guam&quot;}" id="timeZoneDropdown_100"
                                                        class="a-dropdown-link">(UTC+10:00) 太平洋/关岛</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_101" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Saipan&quot;}" id="timeZoneDropdown_101"
                                                        class="a-dropdown-link">(UTC+10:00) 太平洋/塞班</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_102" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Asia/Magadan&quot;}" id="timeZoneDropdown_102"
                                                        class="a-dropdown-link">(UTC+11:00) 亚洲/马加丹</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_103" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Kosrae&quot;}" id="timeZoneDropdown_103"
                                                        class="a-dropdown-link">(UTC+11:00) 太平洋/科斯瑞</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_104" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Auckland&quot;}" id="timeZoneDropdown_104"
                                                        class="a-dropdown-link">(UTC+12:00) 太平洋/奥克兰</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_105" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Fiji&quot;}" id="timeZoneDropdown_105"
                                                        class="a-dropdown-link">(UTC+12:00) 太平洋/斐济</a>
                                                </li>
                                                <li tabindex="0" role="option" aria-labelledby="timeZoneDropdown_106" class="a-dropdown-item">
                                                    <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;Pacific/Tongatapu&quot;}" id="timeZoneDropdown_106"
                                                        class="a-dropdown-link">(UTC+13:00) 太平洋/汤加塔布岛</a>
                                                </li>
                                            </ul>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </td>
                        <td class="a-span4">
                            <div class="shipping_address_illustrate">
                                <div class="a-form-label">
                                    <span>什么是默认配送地址？</span>
                                </div>
                                <div class="normal-font">
                                    <span>
                                        默认配送地址是用于配送订单的主要实际地址、电子邮件地址和电话号码。 此信息保存在您的帐户中，当您在“购买配送”首选项和“配送设置”页面中选择地址时会自动显示。
                                    </span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>`,
            btn: ["取消", "保存"]
        };
        method.msg_layer(obj , GetAddressList ,GetTimeZone );
        dropdown_box(".time", "#choose_time")
        $('.add_new_address').click(function () { 
            var objAddress = {
                type: "layerFadeIn",
                title: "添加新的送货地址",
                type:2,
                classname:"modal-content",
                content: `
                <div class="a-row">
                        <div class="addressEditItem" id="addressNameId">
                            <div class="addressEditTitle">
                                <span>地址名称</span>
                            </div>
                            <div class="a-spacing-mini">
                                <input class="addressName" type="text" placeholder="例如，西雅图仓库" maxlength="60">
                            </div>
                            <div>
                                <span class="font_color">您为地址选择的自定义名称。</span>
                            </div>
                        </div>
                    </div>
                    <hr>
                    <div class="addressEditItem">
                        <div class="addressEditTitle">
                            <span>国家/地区</span>
                        </div>
                        <div class="a-spacing-mini" id="country_regionId">
                            <div id="choose_country" class="bank-account-dropdown a-button a-button-dropdown relative">
                                <p class="pstyle country_region">---无---</p>
                            </div>
                            <div class="a-box country_city none" style="height: 251.75px; overflow-y: auto; min-width: 0px; width: 202px;">
                                <ul class="a-box  overflow_y">
                                    <li tabindex="0" role="option" aria-checked="true" aria-labelledby="shipFromCountryDropdown_0" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NONE&quot;}" id="shipFromCountryDropdown_0"
                                            class="a-dropdown-link a-active">--- 无 ---</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_1" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AL&quot;}" id="shipFromCountryDropdown_1"
                                            class="a-dropdown-link">阿尔巴尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_2" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;DZ&quot;}" id="shipFromCountryDropdown_2"
                                            class="a-dropdown-link">阿尔及利亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_3" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AF&quot;}" id="shipFromCountryDropdown_3"
                                            class="a-dropdown-link">阿富汗</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_4" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AR&quot;}" id="shipFromCountryDropdown_4"
                                            class="a-dropdown-link">阿根廷</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_5" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AE&quot;}" id="shipFromCountryDropdown_5"
                                            class="a-dropdown-link">阿拉伯联合酋长国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_6" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AW&quot;}" id="shipFromCountryDropdown_6"
                                            class="a-dropdown-link">阿鲁巴</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_7" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;OM&quot;}" id="shipFromCountryDropdown_7"
                                            class="a-dropdown-link">阿曼</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_8" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AZ&quot;}" id="shipFromCountryDropdown_8"
                                            class="a-dropdown-link">阿塞拜疆</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_9" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;EG&quot;}" id="shipFromCountryDropdown_9"
                                            class="a-dropdown-link">埃及</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_10" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ET&quot;}" id="shipFromCountryDropdown_10"
                                            class="a-dropdown-link">埃塞俄比亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_11" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IE&quot;}" id="shipFromCountryDropdown_11"
                                            class="a-dropdown-link">爱尔兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_12" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;EE&quot;}" id="shipFromCountryDropdown_12"
                                            class="a-dropdown-link">爱沙尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_13" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AD&quot;}" id="shipFromCountryDropdown_13"
                                            class="a-dropdown-link">安道尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_14" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AO&quot;}" id="shipFromCountryDropdown_14"
                                            class="a-dropdown-link">安哥拉</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_15" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AI&quot;}" id="shipFromCountryDropdown_15"
                                            class="a-dropdown-link">安圭拉</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_16" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AG&quot;}" id="shipFromCountryDropdown_16"
                                            class="a-dropdown-link">安提瓜和巴布达</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_17" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AT&quot;}" id="shipFromCountryDropdown_17"
                                            class="a-dropdown-link">奥地利</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_18" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AX&quot;}" id="shipFromCountryDropdown_18"
                                            class="a-dropdown-link">奥兰群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_19" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AU&quot;}" id="shipFromCountryDropdown_19"
                                            class="a-dropdown-link">澳大利亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_20" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BB&quot;}" id="shipFromCountryDropdown_20"
                                            class="a-dropdown-link">巴巴多斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_21" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PG&quot;}" id="shipFromCountryDropdown_21"
                                            class="a-dropdown-link">巴布亚新几内亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_22" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BS&quot;}" id="shipFromCountryDropdown_22"
                                            class="a-dropdown-link">巴哈马</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_23" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PK&quot;}" id="shipFromCountryDropdown_23"
                                            class="a-dropdown-link">巴基斯坦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_24" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PY&quot;}" id="shipFromCountryDropdown_24"
                                            class="a-dropdown-link">巴拉圭</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_25" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PS&quot;}" id="shipFromCountryDropdown_25"
                                            class="a-dropdown-link">巴勒斯坦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_26" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BH&quot;}" id="shipFromCountryDropdown_26"
                                            class="a-dropdown-link">巴林</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_27" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PA&quot;}" id="shipFromCountryDropdown_27"
                                            class="a-dropdown-link">巴拿马</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_28" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BR&quot;}" id="shipFromCountryDropdown_28"
                                            class="a-dropdown-link">巴西</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_29" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BY&quot;}" id="shipFromCountryDropdown_29"
                                            class="a-dropdown-link">白俄罗斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_30" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BM&quot;}" id="shipFromCountryDropdown_30"
                                            class="a-dropdown-link">百慕达群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_31" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BG&quot;}" id="shipFromCountryDropdown_31"
                                            class="a-dropdown-link">保加利亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_32" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MP&quot;}" id="shipFromCountryDropdown_32"
                                            class="a-dropdown-link">北马里亚纳群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_33" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BJ&quot;}" id="shipFromCountryDropdown_33"
                                            class="a-dropdown-link">贝宁</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_34" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BE&quot;}" id="shipFromCountryDropdown_34"
                                            class="a-dropdown-link">比利时</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_35" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IS&quot;}" id="shipFromCountryDropdown_35"
                                            class="a-dropdown-link">冰岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_36" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BO&quot;}" id="shipFromCountryDropdown_36"
                                            class="a-dropdown-link">玻利维亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_37" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PR&quot;}" id="shipFromCountryDropdown_37"
                                            class="a-dropdown-link">波多黎各</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_38" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BA&quot;}" id="shipFromCountryDropdown_38"
                                            class="a-dropdown-link">波黑</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_39" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PL&quot;}" id="shipFromCountryDropdown_39"
                                            class="a-dropdown-link">波兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_40" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BW&quot;}" id="shipFromCountryDropdown_40"
                                            class="a-dropdown-link">博茨瓦纳</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_41" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BZ&quot;}" id="shipFromCountryDropdown_41"
                                            class="a-dropdown-link">伯利兹</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_42" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BT&quot;}" id="shipFromCountryDropdown_42"
                                            class="a-dropdown-link">不丹</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_43" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BF&quot;}" id="shipFromCountryDropdown_43"
                                            class="a-dropdown-link">布基纳法索</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_44" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BV&quot;}" id="shipFromCountryDropdown_44"
                                            class="a-dropdown-link">布维岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_45" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KP&quot;}" id="shipFromCountryDropdown_45"
                                            class="a-dropdown-link">朝鲜</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_46" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GQ&quot;}" id="shipFromCountryDropdown_46"
                                            class="a-dropdown-link">赤道几内亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_47" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;DK&quot;}" id="shipFromCountryDropdown_47"
                                            class="a-dropdown-link">丹麦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_48" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;DE&quot;}" id="shipFromCountryDropdown_48"
                                            class="a-dropdown-link">德国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_49" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TL&quot;}" id="shipFromCountryDropdown_49"
                                            class="a-dropdown-link">东帝汶</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_50" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TG&quot;}" id="shipFromCountryDropdown_50"
                                            class="a-dropdown-link">多哥</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_51" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;DO&quot;}" id="shipFromCountryDropdown_51"
                                            class="a-dropdown-link">多米尼加共和国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_52" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;DM&quot;}" id="shipFromCountryDropdown_52"
                                            class="a-dropdown-link">多米尼克</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_53" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;RU&quot;}" id="shipFromCountryDropdown_53"
                                            class="a-dropdown-link">俄罗斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_54" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;EC&quot;}" id="shipFromCountryDropdown_54"
                                            class="a-dropdown-link">厄瓜多尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_55" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ER&quot;}" id="shipFromCountryDropdown_55"
                                            class="a-dropdown-link">厄立特里亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_56" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;FR&quot;}" id="shipFromCountryDropdown_56"
                                            class="a-dropdown-link">法国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_57" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TF&quot;}" id="shipFromCountryDropdown_57"
                                            class="a-dropdown-link">法国南部领土</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_58" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;FO&quot;}" id="shipFromCountryDropdown_58"
                                            class="a-dropdown-link">法罗群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_59" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PF&quot;}" id="shipFromCountryDropdown_59"
                                            class="a-dropdown-link">法属波利尼西亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_60" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GF&quot;}" id="shipFromCountryDropdown_60"
                                            class="a-dropdown-link">法属圭亚那</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_61" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PH&quot;}" id="shipFromCountryDropdown_61"
                                            class="a-dropdown-link">菲律宾</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_62" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;FI&quot;}" id="shipFromCountryDropdown_62"
                                            class="a-dropdown-link">芬兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_63" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CV&quot;}" id="shipFromCountryDropdown_63"
                                            class="a-dropdown-link">佛得角</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_64" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;FK&quot;}" id="shipFromCountryDropdown_64"
                                            class="a-dropdown-link">福克兰群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_65" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GM&quot;}" id="shipFromCountryDropdown_65"
                                            class="a-dropdown-link">冈比亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_66" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CG&quot;}" id="shipFromCountryDropdown_66"
                                            class="a-dropdown-link">刚果（布）</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_67" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CD&quot;}" id="shipFromCountryDropdown_67"
                                            class="a-dropdown-link">刚果（金）</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_68" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CO&quot;}" id="shipFromCountryDropdown_68"
                                            class="a-dropdown-link">哥伦比亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_69" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CR&quot;}" id="shipFromCountryDropdown_69"
                                            class="a-dropdown-link">哥斯达黎加</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_70" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GD&quot;}" id="shipFromCountryDropdown_70"
                                            class="a-dropdown-link">格林纳达</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_71" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GL&quot;}" id="shipFromCountryDropdown_71"
                                            class="a-dropdown-link">格陵兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_72" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GE&quot;}" id="shipFromCountryDropdown_72"
                                            class="a-dropdown-link">格鲁吉亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_73" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GG&quot;}" id="shipFromCountryDropdown_73"
                                            class="a-dropdown-link">根西岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_74" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CU&quot;}" id="shipFromCountryDropdown_74"
                                            class="a-dropdown-link">古巴</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_75" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GP&quot;}" id="shipFromCountryDropdown_75"
                                            class="a-dropdown-link">瓜德罗普岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_76" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GU&quot;}" id="shipFromCountryDropdown_76"
                                            class="a-dropdown-link">关岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_77" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GY&quot;}" id="shipFromCountryDropdown_77"
                                            class="a-dropdown-link">圭亚那</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_78" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KZ&quot;}" id="shipFromCountryDropdown_78"
                                            class="a-dropdown-link">哈萨克斯坦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_79" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;HT&quot;}" id="shipFromCountryDropdown_79"
                                            class="a-dropdown-link">海地</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_80" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KR&quot;}" id="shipFromCountryDropdown_80"
                                            class="a-dropdown-link">韩国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_81" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NL&quot;}" id="shipFromCountryDropdown_81"
                                            class="a-dropdown-link">荷兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_82" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AN&quot;}" id="shipFromCountryDropdown_82"
                                            class="a-dropdown-link">荷属安的列斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_83" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;HM&quot;}" id="shipFromCountryDropdown_83"
                                            class="a-dropdown-link">赫德岛和麦克唐纳群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_84" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;HN&quot;}" id="shipFromCountryDropdown_84"
                                            class="a-dropdown-link">洪都拉斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_85" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KI&quot;}" id="shipFromCountryDropdown_85"
                                            class="a-dropdown-link">基里巴斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_86" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;DJ&quot;}" id="shipFromCountryDropdown_86"
                                            class="a-dropdown-link">吉布提</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_87" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KG&quot;}" id="shipFromCountryDropdown_87"
                                            class="a-dropdown-link">吉尔吉斯斯坦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_88" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GN&quot;}" id="shipFromCountryDropdown_88"
                                            class="a-dropdown-link">几内亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_89" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GW&quot;}" id="shipFromCountryDropdown_89"
                                            class="a-dropdown-link">几内亚比绍</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_90" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CA&quot;}" id="shipFromCountryDropdown_90"
                                            class="a-dropdown-link">加拿大</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_91" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GH&quot;}" id="shipFromCountryDropdown_91"
                                            class="a-dropdown-link">加纳</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_92" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GA&quot;}" id="shipFromCountryDropdown_92"
                                            class="a-dropdown-link">加蓬</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_93" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KH&quot;}" id="shipFromCountryDropdown_93"
                                            class="a-dropdown-link">柬埔寨</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_94" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CZ&quot;}" id="shipFromCountryDropdown_94"
                                            class="a-dropdown-link">捷克共和国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_95" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ZW&quot;}" id="shipFromCountryDropdown_95"
                                            class="a-dropdown-link">津巴布韦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_96" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CM&quot;}" id="shipFromCountryDropdown_96"
                                            class="a-dropdown-link">喀麦隆</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_97" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;QA&quot;}" id="shipFromCountryDropdown_97"
                                            class="a-dropdown-link">卡塔尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_98" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KY&quot;}" id="shipFromCountryDropdown_98"
                                            class="a-dropdown-link">开曼群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_99" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CC&quot;}" id="shipFromCountryDropdown_99"
                                            class="a-dropdown-link">科科斯群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_100" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KM&quot;}" id="shipFromCountryDropdown_100"
                                            class="a-dropdown-link">科摩罗</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_101" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CI&quot;}" id="shipFromCountryDropdown_101"
                                            class="a-dropdown-link">科特迪瓦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_102" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KW&quot;}" id="shipFromCountryDropdown_102"
                                            class="a-dropdown-link">科威特</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_103" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;HR&quot;}" id="shipFromCountryDropdown_103"
                                            class="a-dropdown-link">克罗地亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_104" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KE&quot;}" id="shipFromCountryDropdown_104"
                                            class="a-dropdown-link">肯尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_105" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CK&quot;}" id="shipFromCountryDropdown_105"
                                            class="a-dropdown-link">库克群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_106" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LV&quot;}" id="shipFromCountryDropdown_106"
                                            class="a-dropdown-link">拉脱维亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_107" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LS&quot;}" id="shipFromCountryDropdown_107"
                                            class="a-dropdown-link">莱索托</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_108" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LA&quot;}" id="shipFromCountryDropdown_108"
                                            class="a-dropdown-link">老挝</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_109" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LB&quot;}" id="shipFromCountryDropdown_109"
                                            class="a-dropdown-link">黎巴嫩</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_110" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LR&quot;}" id="shipFromCountryDropdown_110"
                                            class="a-dropdown-link">利比里亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_111" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LY&quot;}" id="shipFromCountryDropdown_111"
                                            class="a-dropdown-link">利比亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_112" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LT&quot;}" id="shipFromCountryDropdown_112"
                                            class="a-dropdown-link">立陶宛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_113" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LI&quot;}" id="shipFromCountryDropdown_113"
                                            class="a-dropdown-link">列支敦士登</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_114" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;RE&quot;}" id="shipFromCountryDropdown_114"
                                            class="a-dropdown-link">留尼汪</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_115" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LU&quot;}" id="shipFromCountryDropdown_115"
                                            class="a-dropdown-link">卢森堡</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_116" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;RW&quot;}" id="shipFromCountryDropdown_116"
                                            class="a-dropdown-link">卢旺达</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_117" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;RO&quot;}" id="shipFromCountryDropdown_117"
                                            class="a-dropdown-link">罗马尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_118" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MG&quot;}" id="shipFromCountryDropdown_118"
                                            class="a-dropdown-link">马达加斯加</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_119" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MT&quot;}" id="shipFromCountryDropdown_119"
                                            class="a-dropdown-link">马耳他</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_120" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MV&quot;}" id="shipFromCountryDropdown_120"
                                            class="a-dropdown-link">马尔代夫</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_121" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MW&quot;}" id="shipFromCountryDropdown_121"
                                            class="a-dropdown-link">马拉维</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_122" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MY&quot;}" id="shipFromCountryDropdown_122"
                                            class="a-dropdown-link">马来西亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_123" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ML&quot;}" id="shipFromCountryDropdown_123"
                                            class="a-dropdown-link">马里</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_124" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MK&quot;}" id="shipFromCountryDropdown_124"
                                            class="a-dropdown-link">马其顿</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_125" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MH&quot;}" id="shipFromCountryDropdown_125"
                                            class="a-dropdown-link">马绍尔群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_126" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MQ&quot;}" id="shipFromCountryDropdown_126"
                                            class="a-dropdown-link">马提尼克</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_127" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;YT&quot;}" id="shipFromCountryDropdown_127"
                                            class="a-dropdown-link">马约特</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_128" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MU&quot;}" id="shipFromCountryDropdown_128"
                                            class="a-dropdown-link">毛里求斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_129" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MR&quot;}" id="shipFromCountryDropdown_129"
                                            class="a-dropdown-link">毛里塔尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_130" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;US&quot;}" id="shipFromCountryDropdown_130"
                                            class="a-dropdown-link">美国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_131" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;UM&quot;}" id="shipFromCountryDropdown_131"
                                            class="a-dropdown-link">美国本土外小岛屿</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_132" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AS&quot;}" id="shipFromCountryDropdown_132"
                                            class="a-dropdown-link">美属萨摩亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_133" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VI&quot;}" id="shipFromCountryDropdown_133"
                                            class="a-dropdown-link">美属维尔京群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_134" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MN&quot;}" id="shipFromCountryDropdown_134"
                                            class="a-dropdown-link">蒙古</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_135" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MS&quot;}" id="shipFromCountryDropdown_135"
                                            class="a-dropdown-link">蒙特塞拉特</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_136" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BD&quot;}" id="shipFromCountryDropdown_136"
                                            class="a-dropdown-link">孟加拉国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_137" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PE&quot;}" id="shipFromCountryDropdown_137"
                                            class="a-dropdown-link">秘鲁</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_138" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;FM&quot;}" id="shipFromCountryDropdown_138"
                                            class="a-dropdown-link">密克罗尼西亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_139" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MM&quot;}" id="shipFromCountryDropdown_139"
                                            class="a-dropdown-link">缅甸</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_140" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MD&quot;}" id="shipFromCountryDropdown_140"
                                            class="a-dropdown-link">摩尔多瓦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_141" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MA&quot;}" id="shipFromCountryDropdown_141"
                                            class="a-dropdown-link">摩洛哥</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_142" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MC&quot;}" id="shipFromCountryDropdown_142"
                                            class="a-dropdown-link">摩纳哥</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_143" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MZ&quot;}" id="shipFromCountryDropdown_143"
                                            class="a-dropdown-link">莫桑比克</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_144" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MX&quot;}" id="shipFromCountryDropdown_144"
                                            class="a-dropdown-link">墨西哥</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_145" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NA&quot;}" id="shipFromCountryDropdown_145"
                                            class="a-dropdown-link">纳米比亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_146" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ZA&quot;}" id="shipFromCountryDropdown_146"
                                            class="a-dropdown-link">南非</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_147" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AQ&quot;}" id="shipFromCountryDropdown_147"
                                            class="a-dropdown-link">南极洲</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_148" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GS&quot;}" id="shipFromCountryDropdown_148"
                                            class="a-dropdown-link">南乔治亚岛和南桑威奇群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_149" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NP&quot;}" id="shipFromCountryDropdown_149"
                                            class="a-dropdown-link">尼泊尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_150" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NI&quot;}" id="shipFromCountryDropdown_150"
                                            class="a-dropdown-link">尼加拉瓜</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_151" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NE&quot;}" id="shipFromCountryDropdown_151"
                                            class="a-dropdown-link">尼日尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_152" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NG&quot;}" id="shipFromCountryDropdown_152"
                                            class="a-dropdown-link">尼日利亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_153" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NU&quot;}" id="shipFromCountryDropdown_153"
                                            class="a-dropdown-link">纽埃</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_154" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NO&quot;}" id="shipFromCountryDropdown_154"
                                            class="a-dropdown-link">挪威</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_155" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NF&quot;}" id="shipFromCountryDropdown_155"
                                            class="a-dropdown-link">诺福克岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_156" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PW&quot;}" id="shipFromCountryDropdown_156"
                                            class="a-dropdown-link">帕劳</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_157" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PN&quot;}" id="shipFromCountryDropdown_157"
                                            class="a-dropdown-link">皮特凯恩</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_158" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PT&quot;}" id="shipFromCountryDropdown_158"
                                            class="a-dropdown-link">葡萄牙</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_159" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BI&quot;}" id="shipFromCountryDropdown_159"
                                            class="a-dropdown-link">蒲隆地</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_160" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;JP&quot;}" id="shipFromCountryDropdown_160"
                                            class="a-dropdown-link">日本</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_161" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SE&quot;}" id="shipFromCountryDropdown_161"
                                            class="a-dropdown-link">瑞典</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_162" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CH&quot;}" id="shipFromCountryDropdown_162"
                                            class="a-dropdown-link">瑞士</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_163" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SV&quot;}" id="shipFromCountryDropdown_163"
                                            class="a-dropdown-link">萨尔瓦多</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_164" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;WS&quot;}" id="shipFromCountryDropdown_164"
                                            class="a-dropdown-link">萨摩亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_165" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CS&quot;}" id="shipFromCountryDropdown_165"
                                            class="a-dropdown-link">塞尔维亚和黑山</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_166" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SL&quot;}" id="shipFromCountryDropdown_166"
                                            class="a-dropdown-link">塞拉利昂</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_167" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SN&quot;}" id="shipFromCountryDropdown_167"
                                            class="a-dropdown-link">塞内加尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_168" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CY&quot;}" id="shipFromCountryDropdown_168"
                                            class="a-dropdown-link">塞浦路斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_169" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SC&quot;}" id="shipFromCountryDropdown_169"
                                            class="a-dropdown-link">塞舌尔</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_170" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SA&quot;}" id="shipFromCountryDropdown_170"
                                            class="a-dropdown-link">沙特阿拉伯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_171" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CX&quot;}" id="shipFromCountryDropdown_171"
                                            class="a-dropdown-link">圣诞岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_172" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ST&quot;}" id="shipFromCountryDropdown_172"
                                            class="a-dropdown-link">圣多美普林西比</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_173" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SH&quot;}" id="shipFromCountryDropdown_173"
                                            class="a-dropdown-link">圣赫勒拿</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_174" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;KN&quot;}" id="shipFromCountryDropdown_174"
                                            class="a-dropdown-link">圣基茨和尼维斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_175" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LC&quot;}" id="shipFromCountryDropdown_175"
                                            class="a-dropdown-link">圣卢西亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_176" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SM&quot;}" id="shipFromCountryDropdown_176"
                                            class="a-dropdown-link">圣马力诺</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_177" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;PM&quot;}" id="shipFromCountryDropdown_177"
                                            class="a-dropdown-link">圣皮埃尔和密克隆</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_178" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VC&quot;}" id="shipFromCountryDropdown_178"
                                            class="a-dropdown-link">圣文森特和格林纳丁斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_179" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SZ&quot;}" id="shipFromCountryDropdown_179"
                                            class="a-dropdown-link">史瓦济兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_180" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;LK&quot;}" id="shipFromCountryDropdown_180"
                                            class="a-dropdown-link">斯里兰卡</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_181" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SK&quot;}" id="shipFromCountryDropdown_181"
                                            class="a-dropdown-link">斯洛伐克</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_182" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SI&quot;}" id="shipFromCountryDropdown_182"
                                            class="a-dropdown-link">斯洛文尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_183" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SJ&quot;}" id="shipFromCountryDropdown_183"
                                            class="a-dropdown-link">斯瓦尔巴特群岛和扬马延</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_184" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SD&quot;}" id="shipFromCountryDropdown_184"
                                            class="a-dropdown-link">苏丹</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_185" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SR&quot;}" id="shipFromCountryDropdown_185"
                                            class="a-dropdown-link">苏里南</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_186" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SO&quot;}" id="shipFromCountryDropdown_186"
                                            class="a-dropdown-link">索马里</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_187" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SB&quot;}" id="shipFromCountryDropdown_187"
                                            class="a-dropdown-link">所罗门群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_188" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TJ&quot;}" id="shipFromCountryDropdown_188"
                                            class="a-dropdown-link">塔吉克斯坦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_189" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TH&quot;}" id="shipFromCountryDropdown_189"
                                            class="a-dropdown-link">泰国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_190" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TZ&quot;}" id="shipFromCountryDropdown_190"
                                            class="a-dropdown-link">坦桑尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_191" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TO&quot;}" id="shipFromCountryDropdown_191"
                                            class="a-dropdown-link">汤加</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_192" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TC&quot;}" id="shipFromCountryDropdown_192"
                                            class="a-dropdown-link">特克斯和凯科斯群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_193" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TT&quot;}" id="shipFromCountryDropdown_193"
                                            class="a-dropdown-link">特立尼达和多巴哥</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_194" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TN&quot;}" id="shipFromCountryDropdown_194"
                                            class="a-dropdown-link">突尼斯</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_195" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TV&quot;}" id="shipFromCountryDropdown_195"
                                            class="a-dropdown-link">图瓦卢</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_196" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TR&quot;}" id="shipFromCountryDropdown_196"
                                            class="a-dropdown-link">土耳其</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_197" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TM&quot;}" id="shipFromCountryDropdown_197"
                                            class="a-dropdown-link">土库曼</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_198" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TK&quot;}" id="shipFromCountryDropdown_198"
                                            class="a-dropdown-link">托克劳</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_199" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;WF&quot;}" id="shipFromCountryDropdown_199"
                                            class="a-dropdown-link">瓦利斯和富图纳</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_200" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VU&quot;}" id="shipFromCountryDropdown_200"
                                            class="a-dropdown-link">瓦努阿图</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_201" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GT&quot;}" id="shipFromCountryDropdown_201"
                                            class="a-dropdown-link">危地马拉</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_202" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VE&quot;}" id="shipFromCountryDropdown_202"
                                            class="a-dropdown-link">委内瑞拉</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_203" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;BN&quot;}" id="shipFromCountryDropdown_203"
                                            class="a-dropdown-link">文莱</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_204" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;UG&quot;}" id="shipFromCountryDropdown_204"
                                            class="a-dropdown-link">乌干达</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_205" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;UA&quot;}" id="shipFromCountryDropdown_205"
                                            class="a-dropdown-link">乌克兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_206" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;UY&quot;}" id="shipFromCountryDropdown_206"
                                            class="a-dropdown-link">乌拉圭</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_207" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;UZ&quot;}" id="shipFromCountryDropdown_207"
                                            class="a-dropdown-link">乌兹别克斯坦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_208" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ES&quot;}" id="shipFromCountryDropdown_208"
                                            class="a-dropdown-link">西班牙</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_209" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;EH&quot;}" id="shipFromCountryDropdown_209"
                                            class="a-dropdown-link">西撒哈拉</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_210" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GR&quot;}" id="shipFromCountryDropdown_210"
                                            class="a-dropdown-link">希腊</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_211" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SG&quot;}" id="shipFromCountryDropdown_211"
                                            class="a-dropdown-link">新加坡</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_212" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NC&quot;}" id="shipFromCountryDropdown_212"
                                            class="a-dropdown-link">新喀里多尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_213" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NZ&quot;}" id="shipFromCountryDropdown_213"
                                            class="a-dropdown-link">新西兰</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_214" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;HU&quot;}" id="shipFromCountryDropdown_214"
                                            class="a-dropdown-link">匈牙利</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_215" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;SY&quot;}" id="shipFromCountryDropdown_215"
                                            class="a-dropdown-link">叙利亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_216" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;JM&quot;}" id="shipFromCountryDropdown_216"
                                            class="a-dropdown-link">牙买加</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_217" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;AM&quot;}" id="shipFromCountryDropdown_217"
                                            class="a-dropdown-link">亚美尼亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_218" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;YE&quot;}" id="shipFromCountryDropdown_218"
                                            class="a-dropdown-link">也门</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_219" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IQ&quot;}" id="shipFromCountryDropdown_219"
                                            class="a-dropdown-link">伊拉克</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_220" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IR&quot;}" id="shipFromCountryDropdown_220"
                                            class="a-dropdown-link">伊朗</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_221" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IL&quot;}" id="shipFromCountryDropdown_221"
                                            class="a-dropdown-link">以色列</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_222" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IT&quot;}" id="shipFromCountryDropdown_222"
                                            class="a-dropdown-link">意大利</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_223" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IN&quot;}" id="shipFromCountryDropdown_223"
                                            class="a-dropdown-link">印度</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_224" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ID&quot;}" id="shipFromCountryDropdown_224"
                                            class="a-dropdown-link">印尼</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_225" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GB&quot;}" id="shipFromCountryDropdown_225"
                                            class="a-dropdown-link">英国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_226" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VG&quot;}" id="shipFromCountryDropdown_226"
                                            class="a-dropdown-link">英属维尔京群岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_227" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;IO&quot;}" id="shipFromCountryDropdown_227"
                                            class="a-dropdown-link">英属印度洋领地</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_228" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;JO&quot;}" id="shipFromCountryDropdown_228"
                                            class="a-dropdown-link">约旦</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_229" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VN&quot;}" id="shipFromCountryDropdown_229"
                                            class="a-dropdown-link">越南</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_230" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;ZM&quot;}" id="shipFromCountryDropdown_230"
                                            class="a-dropdown-link">赞比亚</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_231" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;JE&quot;}" id="shipFromCountryDropdown_231"
                                            class="a-dropdown-link">泽西岛</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_232" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TD&quot;}" id="shipFromCountryDropdown_232"
                                            class="a-dropdown-link">乍得</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_233" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;GI&quot;}" id="shipFromCountryDropdown_233"
                                            class="a-dropdown-link">直布罗陀</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_234" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CL&quot;}" id="shipFromCountryDropdown_234"
                                            class="a-dropdown-link">智利</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_235" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CF&quot;}" id="shipFromCountryDropdown_235"
                                            class="a-dropdown-link">中非共和国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_236" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;CN&quot;}" id="shipFromCountryDropdown_236"
                                            class="a-dropdown-link">中国</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_237" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;MO&quot;}" id="shipFromCountryDropdown_237"
                                            class="a-dropdown-link">中国澳门</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_238" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;TW&quot;}" id="shipFromCountryDropdown_238"
                                            class="a-dropdown-link">中国台湾</a>
                                    </li>
                                    <li tabindex="0" role="option">
                                        <a tabindex="-1" href="javascript:void(0)">中国香港</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_240" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;NR&quot;}" id="shipFromCountryDropdown_240"
                                            class="a-dropdown-link">瑙鲁</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_241" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;VA&quot;}" id="shipFromCountryDropdown_241"
                                            class="a-dropdown-link">梵帝冈</a>
                                    </li>
                                    <li tabindex="0" role="option" aria-labelledby="shipFromCountryDropdown_242" class="a-dropdown-item">
                                        <a tabindex="-1" href="javascript:void(0)" data-value="{&quot;stringVal&quot;:&quot;FJ&quot;}" id="shipFromCountryDropdown_242"
                                            class="a-dropdown-link">斐济</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="a-row">
                        <div class="addressEditItem">
                            <div class="addressEditTitle">
                                <span>地址</span>
                            </div>
                            <div class="a-spacing-mini" id="line_oneId">
                                <input class="line_one" type="text" placeholder="地址行 1" maxlength="60">
                            </div>
                            <div class="a-spacing-mini">
                                <input class="line_two" type="text" placeholder="地址行 2" maxlength="60">
                            </div>
                        </div>
                    </div>
                    <div class="a-row">
                        <div class="addressEditItem">
                            <div class="addressEditTitle">
                                <span>邮政编码</span>
                            </div>
                            <div class="a-row" id="postalcodeId">
                                <div class="a-spacing-mini width48 float_left">
                                    <input class="postalcode" type="text"  maxlength="60">
                                </div>
                                <div class="width48 float_right">
                                    <a class="checkCodeLink">
                                        检查邮政编码
                                    </a>
                                    <i class="a-icon a-icon-success postalSuccessIcon"></i>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </div>
                    <div class="a-row">
                        <div class="addressEditItem">
                            <div class="a-row">
                                <div class="a-spacing-mini width48 float_left" id="city_townId">
                                    <div class="addressEditTitle">
                                        <span>市/镇</span>
                                    </div>
                                    <div class="a-row a-spacing-mini float_left">
                                        <input class="city_town" type="text" maxlength="60">
                                    </div>
                                </div>
                                <div class="a-spacing-mini width48 float_right" id="state_provinceId">
                                    <div class="addressEditTitle">
                                        <span>州、省、直辖市或自治区</span>
                                    </div>
                                    <div class="a-row a-spacing-mini float_left">
                                        <input class="state_province" type="text" maxlength="60">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr>
                    <div class="a-row">
                        <div class="addressEditItem">
                            <div class="a-row">
                                <div class="a-spacing-mini width48 float_left" id="telId">
                                    <div class="addressEditTitle">
                                        <span>主要电话</span>
                                    </div>
                                    <div class="a-row a-spacing-mini float_left">
                                        <input class="tel" type="text" maxlength="60">
                                    </div>
                                </div>
                                <div class="a-spacing-mini width48 float_right" id="E_mailId">
                                    <div class="addressEditTitle">
                                        <span>电子邮件地址</span>
                                    </div>
                                    <div class="a-row a-spacing-mini float_left">
                                        <input class="E_mail" type="text" maxlength="60">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                `,
                btn: ["取消", "保存"]
            } 
            method.msg_layer(objAddress,callback);
            var addressName = $('.addressName').val().trim();
            var country_region = $('.country_region').text();
            var line_one = $('.line_one').val().trim();
            var line_two = $('.line_two').val().trim();
            var postalcode = $('.postalcode').val().trim();
            var city_town = $('.city_town').val().trim();
            var state_province = $('.state_province').val().trim();
            var tel = $('.tel').val().trim();
            var E_mail = $('.E_mail').val().trim();
         })
        
       
        
        function callback() {
            $("div.myWarn").remove();
            $("input").removeClass("activebtn");

            console.log($('.addressName'))
            if(addressName && line_one && state_province && city_town && postalcode && tel){
                
                $.ajax({
                    url: baseUrl + '/AddAddressNew',
                    method: 'post',
                    dataType: "json",
                    data: {
                        userid: amazon_userid,
                        address: line_one,
                        address2: line_two,
                        city: city_town,
                        province: state_province,
                        country: country_region,
                        zipcode: postalcode,
                        phone: tel,
                        type: '1',
                        name: addressName,
                        email: E_mail,
                        full_name: ''
                    },
                    success: function (res) {
                        console.log(res)
                    },
                    error: function (res) {
                        console.log(decodeURIComponent(res.error))
                    }
                })
            }
            if(!addressName){
                addwarn("addressNameId", 2, "请输入库房名称。");
                $('.addressName').addClass('activebtn')
            }
            if(!line_one){
                addwarn("line_oneId", 2, "请输入地址");
                $('.line_one').addClass('activebtn')
            }

            if(!state_province){
                addwarn("state_provinceId", 2, "请输入州、省、直辖市或自治区");
                $('.state_province').addClass('activebtn')
            }
            if(!city_town){
                addwarn("city_townId", 2, "请输入市/镇");
                $('.city_town').addClass('activebtn')
            }
            if(!postalcode){
                addwarn("postalcodeId", 2, "请输入一个有效邮政编码。");
                $('.postalcode').addClass('activebtn')
            }
            if(!tel){
                addwarn("telId", 2, "请输入一个电话号码。");
                $('.tel').addClass('activebtn')
            }
            if(country_region==='---无---'){
                addwarn("country_regionId", 2, "请选择国家/地区");
            }
        }
        //console.log(typeof (dropdown_box(".time", "#choose_time")))
    });
    
})