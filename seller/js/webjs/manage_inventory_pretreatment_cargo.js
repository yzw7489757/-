$(function () {
    var sizeInput1 = $('.sizeInput1').val();
    var sizeInput2 = $('.sizeInput2').val();
    var sizeInput3 = $('.sizeInput3').val();
    var inputweight = $('.inputweight').val();
    var moreSizeInput1 = $('.moreSizeInput1').val();
    var moreSizeInput2 = $('.moreSizeInput2').val();
    var moreSizeInput3 = $('.moreSizeInput3').val();
    var moreSizeweight = $('.moreSizeweight').val();
    
    if($('.addInput tr').length <= '2' ){
        $('.addInput tr').eq(0).find('.closeBtn').hide();
    }
    function inputValue() {
        sizeInput1 = $('.sizeInput1').val();
        sizeInput2 = $('.sizeInput2').val();
        sizeInput3 = $('.sizeInput3').val();
        inputweight = $('.inputweight').val();
        moreSizeInput1 = $('.moreSizeInput1').val();
        moreSizeInput2 = $('.moreSizeInput2').val();
        moreSizeInput3 = $('.moreSizeInput3').val();
        moreSizeweight = $('.moreSizeweight').val();
    }
    // 检查并修改商品
    $('.checkupBtn').click(function () {
        $('.checkupBtn').hide();
        $('.hiddengoodsBtn').removeClass('dispplay_none');
        $('.hiddenInfo').show();
    })
    // 隐藏商品
    $('.hiddengoodsBtn').click(function () {
        $('.hiddengoodsBtn').addClass('dispplay_none');
        $('.checkupBtn').show()
        $('.hiddenInfo').hide();
    })

    $('#packing_box_select').bind("change", function () {
        if ($(this).val() == 'multiple_boxes') {
            $('.multiple_boxes').show()
            $('.a_box').hide()
        } else if ($(this).val() == 'a_box') {
            $('.multiple_boxes').hide()
            $('.a_box').show()
        }
    })
    // 删除
    $('.deleteBtn').click(function () {
        $(this).parent().parent().remove();
    })
    // 确认
    $('.confirmBtn').click(function () {
        inputValue();
        if (sizeInput1 && sizeInput2 && sizeInput3 && inputweight) {
            $('.successInfo').show()
        }
    })
    $('.moreConfirmBtn').click(function () {
        inputValue();
        if (moreSizeInput1 && moreSizeInput2 && moreSizeInput3 && moreSizeweight) {
            alert('保存成功')
        }
    })
    // 添加其他箱子配置 添加
    $('.add_configuration').click(function () {
        var html = $(`
        <tr>
            <td class="addCommodityInput width18 align_right">
                <div class="a-spacing-small">
                    <input type="text" class="a-text-right">
                </div>
            </td>
            <td class="align_right">
                <div class="a-spacing-small addNumInput">
                    <div class="a-spacing-small">
                        <input type="text" class="a-text-right">
                        <img src="./img/icon_4.png" alt="closeImg" class="pdleft10 closeBtn">
                    </div>
                </div>

            </td>
            <td class=" width7 align_right">
                <div class="a-spacing-small height21">
                    <span>-</span>
                </div>

            </td>
            <td class=" align_right">
                <div class="a-spacing-small">
                    <input type="text" class="moreSizeweight">
                </div>
            </td>
            <td class="a-text-right">
                <div class="a-spacing-small">
                    <input type="text" class="moreSizeInput1 a-text-center">
                    <img src="./img/close.png" alt="">
                    <input type="text" class="moreSizeInput2 a-text-center">
                    <img src="./img/close.png" alt="">
                    <input type="text" class="moreSizeInput3 a-text-center">
                </div>
            </td>
        </tr>`)
        $('.addInput tr').eq(0).after(html)
        if($('.addInput tr').length > '2' ){
            $('.addInput tr').eq(0).find('.closeBtn').show();
        }
    })
    // 添加其他箱子配置 删除
    $('.addInput').on("click", '.closeBtn', function () {
        $(this).parent().parent().parent().parent().remove();
        if($('.addInput tr').length <= '2' ){
            $('.addInput tr').eq(0).find('.closeBtn').hide();
        }
    });

    // 完成货件
    $('.finishBtn').click(function () {
        $(location).attr('href', '/seller/manage_inventory_list.html');
    })
    // 返回
    $('.returnBtn').click(function () {
        $(location).attr('href', '/seller/manage_inventory_pretreatment_cargo.html');
    })
})