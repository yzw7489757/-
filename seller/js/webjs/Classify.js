$(function () {
    $("#find").click(function () {
        var key = $("#SearchBox").val().trim();
        if (key == '')
            return;
        location.href = "Classify.html?key=" + key;
    });
    inputctr.public.SellerRegisterLoading();
    var key = inputctr.public.getQueryString("key");
    var sign = inputctr.public.getQueryString("sign");
    var pcateid = inputctr.public.getQueryString("cateid");
    $("#search_name").html(key);
    if (sign == 1) {
        $(".js-refine").hide();
        $(".js-refine-title").hide();
        inputctr.public.AjaxMethods('GET', baseUrl + '/SearchCategoryByPID', { lang: 'en', port: 'pc', key: key, 'pid': pcateid }, function (data) {
            if (data.result == 1) {
                var refine = ''; 

                $(".js-possible").html('<b>1</b> to <b>' + data.list.length + '</b> of ' + data.list.length + ' Possible Categories');
                var html = '';
                for (var i = 0; i < data.list.length; i++) {
                    html += '<a href="product_details.html?cateid=' + data.list[i].id + '">' + data.list[i].name + '</a><br />';
                    html += '    <span class="tiny">' + data.list[i].name_path + '</span>';
                    html += '    <br />';
                    html += '    <br />';
                }
                $(".js-categories").html(html);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) { });
    }
    else {
        inputctr.public.AjaxMethods('GET', baseUrl + '/SearchCategoryByKey', { lang: 'en', port: 'pc', key: key }, function (data) {
            if (data.result == 1) {
                var refine = '';
                for (var dkey in data.type) {
                    var arr = dkey.split('|');
                    var cateid = arr[0];
                    var cateName = arr[1];
                    var num = data.type[dkey];
                    refine += '<a href="Classify.html?sign=1&cateid=' + cateid + '&key=' + key + '">' + cateName + '</a> <span>(' + num + ')</span><br />';
                }
                $(".js-refine").html(refine);

                $(".js-possible").html('<b>1</b> to <b>' + data.list.length + '</b> of ' + data.list.length + ' Possible Categories');
                var html = '';
                for (var i = 0; i < data.list.length; i++) {
                    html += '<a href="product_details.html?cateid=' + data.list[i].id + '">' + data.list[i].name + '</a><br />';
                    html += '    <span class="tiny">' + data.list[i].name_path + '</span>';
                    html += '    <br />';
                    html += '    <br />';
                }
                $(".js-categories").html(html);
            }
            inputctr.public.SellerRegisterLoadingRemove();
        }, function (error) { });
    }
})