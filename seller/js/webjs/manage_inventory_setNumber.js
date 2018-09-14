$(function () {
    var input_one = $('.input_one').val();
    var input_two = $('.input_two').val();
    var input_three = $('.input_three').val();
    var input_weight = $('.input_weight').val();
    var inputNum = $('.inputNum').val();
    var showTr = false;
    var showBtn = false;
    function inputValue() {
        input_one = $('.input_one').val();
        input_two = $('.input_two').val();
        input_three = $('.input_three').val();
        input_weight = $('.input_weight').val();
    }

    function changeBtnColor(target) {
        $(target).blur(function () {
            inputValue();
            if (input_one && input_two && input_three && input_weight) {
                $('.saveBtn').addClass('finishColor')
                showBtn = true;
            }
        })
    }
    changeBtnColor('.input_one')
    changeBtnColor('.input_two')
    changeBtnColor('.input_three')
    changeBtnColor('.input_weight')
    $('.saveBtn').click(function () {
        inputValue();
        if (input_one && input_two && input_three && input_weight) {
            alert('保存成功')
        }
    })
    // 混装商品 原厂包装发货商品
    $('.mixingBox a').click(function () {
        $('.mixingBox').hide()
        $('.originalBox').show()
        showTr = true;
        if (showTr) {
            $('.hiddenTr').removeClass('none')
        }
    })
    $('.originalBox a').click(function () {
        $('.originalBox').hide()
        $('.mixingBox').show()
        showTr = false;
        if (!showTr) {
            $('.hiddenTr').addClass('none')
        }
    })

    // 继续
    $('.goBtn').click(function () {
        inputNum = $('.inputNum').val();
        if (inputNum != "" && showBtn) {
            $(location).attr('href', '/seller/manage_inventory_preprocessed_goods.html');
        } else {
            alert('保存失败')
        }
    })
})