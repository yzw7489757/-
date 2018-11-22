$(function () {
    inputctr.public.checkLogin();
    inputctr.public.selectCountry();
    var country = $('.country_select option:selected').text(); //国家地区
    var name = $('.name').val(); // 名称
    var addressOne = $('.addressOne').val(); // 地址行1
    var addressTwo = $('.addressTwo').val(); // 地址行2
    var city = $('.city').val(); // 城市
    var stateProvinceRegion = $('.stateProvinceRegion').val(); // 州/省/地区
    var zipCode = $('.zipCode').val(); // 邮编
    var phone = $('.phone').val(); // 电话
    var adrId;
    var edit = false;
    goodId = inputctr.public.getQueryString('goodsID');
    skuId = inputctr.public.getQueryString('sku_id');
    function inputValue() {
        country = $('select option:selected').text();
        name = $('.name').val().trim();
        addressOne = $('.addressOne').val().trim();
        addressTwo = $('.addressTwo').val().trim();
        city = $('.city').val().trim();
        stateProvinceRegion = $('.stateProvinceRegion').val().trim();
        zipCode = $('.zipCode').val().trim();
        phone = $('.phone').val();
    }

    function changeBtnColor(target) {
        $(target).blur(function () {
            inputValue();
            if ( addressOne && city && stateProvinceRegion && zipCode) {
                $('.unfinishBtn').hide();
                $('.finishBtn').show()
                    
            }
            if (window.sessionStorage) {
                adrId = sessionStorage.getItem('adrId');
            }
            
        })
    }
   
    changeBtnColor('.addressOne');
    changeBtnColor('.city');
    changeBtnColor('.stateProvinceRegion');
    changeBtnColor('.zipCode');

    function AddAddress() { 
        inputValue()
        var data = {
            userid: amazon_userid,
            address: addressOne,
            address2: addressTwo,
            city: city,
            province: stateProvinceRegion,
            country: country,
            zipcode: zipCode,
            phone: phone,
            type: '3',
            name: name,
            email: '',
            full_name: ''
        };
        if ( addressOne && city && stateProvinceRegion && zipCode) {
            $.ajax({
                url: baseUrl + '/AddAddress',
                method: 'post',
                dataType: "json",
                data: { json: JSON.stringify(data) },
                success: function (res) {
                    console.log(res)
                    if (res.result == 1) {
                        if (window.sessionStorage) {
                            sessionStorage.setItem('adrId', res.addressid)
                        }
                        $(location).attr("href", "/seller/manage_inventory_restocking.html?goodsID="+goodId+"&sku_id="+skuId);
                    } else {
                        console.log(decodeURIComponent(res.error))
                    }
                },
                error: function (res) {
                    console.log(decodeURIComponent(res.error))
                }
            })
        }
     }

    function DelDistributionAddress() {
        inputValue()
        if ( addressOne && city && stateProvinceRegion && zipCode) {
            $.post(baseUrl + '/UpdateDistributionAddress', {
                addressId: adrId,
                country: country,
                address: addressOne,
                address2: addressTwo,
                city: city,
                province: stateProvinceRegion,
                zipcode: zipCode,
                phone: phone,
                email: '',
                name: name
            }, function (res) {
                console.log(res);
                if (res.result == '1') {
                    console.log(adrId)
                    $(location).attr("href", "/seller/manage_inventory_restocking.html?goodsID="+goodId+"&sku_id="+skuId);
                }
            }, 'json')
        }
    }

    $('.country_select').change(function () {
        console.log($(this).val())
        console.log($(this).find('option:selected').text())
    })

    function setOption(str) {
        $(".country_select").find("option").each(function (data) {
            var $this = $(this);
            if ($this.text() === str) {
                $this.attr("selected", true);
            }
        });
    }
    // 获取地址列表
    $.post(baseUrl + '/GetAdrList',{ sellerId:amazon_userid}, function (res) {
        console.log(res);
        detail = res.adrInfo;
        let detailTmpl = doT.template($('#addArray').text());
        $('#addTmpl').html(detailTmpl(detail));
        $('#addTmpl .editBtn').each(function (i) {
            $('#addTmpl .editBtn').eq(i).click(function () {
                // 编辑按钮
                edit = true;
                adrId = $(this).parents('.adds').attr('adrId');
                var h = $(document).height() - $(window).height();
                $(document).scrollTop(h);
                // 国家地区
                var detailCountry = $(this).parents('.adds').find('.detailCountry').text();
                setOption(detailCountry)
                // 名称
                $('.name').val($(this).parents('.adds').attr('name'));
                // 地址行1
                $('.addressOne').val($(this).parents('.adds').find('.detailAddress').text().split('-')[2]);
                // 地址行2
                $('.addressTwo').val($(this).parents('.adds').find('.detailAddress2').text());
                // 城市
                $('.city').val($(this).parents('.adds').find('.detailAddress').text().split('-')[1]);
                // 州/省/地区
                $('.stateProvinceRegion').val($(this).parents('.adds').find('.detailAddress').text().split('-')[0]);
                // 邮编
                $('.zipCode').val($(this).parents('.adds').find('.detailAddress').text().split('-')[3]);
                // 电话
                $('.phone').val($(this).parents('.adds').find('.detailPhone').text())
                // 从该地址发货
                $('.unfinishBtn').hide();
                $('.finishBtn').show()
                if (window.sessionStorage) {
                    sessionStorage.setItem('adrId', adrId)
                }
                
            })
        })
        $('#addTmpl .finishSendBtn').each(function (i) {
            $('#addTmpl .finishSendBtn').eq(i).click(function () {
                adrId = $(this).parents('.adds').attr('adrId');
                if (window.sessionStorage) {
                    sessionStorage.setItem('adrId', adrId)
                    $(location).attr("href", "/seller/manage_inventory_restocking.html?goodsID="+goodId+"&sku_id="+skuId);
                }
            })
        })
        $('.sendBtn').click(function () {
            if(edit){
                if (window.sessionStorage) {
                    adrId = sessionStorage.getItem('adrId');
                }
                DelDistributionAddress();
            }else{
                console.log(edit)
                AddAddress();
            }
        })
        // 删除
        $('#addTmpl .deleteBtn').click(function () {
            adrId = $(this).parents('.adds').attr('adrId');
            $.post(baseUrl + '/DeleteAddress', {
                addressID: adrId,
            }, function (res) {
                console.log(res);
                if (res.result == '1') {
                    window.location.reload()
                }
            }, 'json')
            console.log(adrId)
        })
    }, 'json')

    $('.goBtn').click(function () {
        $(location).attr("href", "/seller/manage_inventory_restocking.html?goodsID="+goodId+"&sku_id="+skuId);
    })


})