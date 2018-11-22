$(function () { 
	inputctr.public.checkLogin();

		$.ajax({
			url: baseUrl + '/GetShippingModel',
			method: 'post',
			dataType: "json",
			data: {
				userid: amazon_userid,
			},
			success: function (res) {	
				console.log(res)
				if(res.result==1||res.result==0)
					$("input[type='radio'][value='money']").attr("checked","checked");
				else
					$("input[type='radio'][value='weight']").attr("checked","checked");
			},
			error:function(res){
				console.log(decodeURIComponent(res))
			}
		})
    $('.go_on_Btn').click(function () { 
    	var checked;
    	if($("input:checked").val()=='money'){
            checked=1;
        }else{
            checked=2;
        }
        	$.ajax({
			url: baseUrl + '/SetShippingModel',
			method: 'post',
			dataType: "json",
			data: {
				userid: amazon_userid,
				shippingModel:checked
			},
			success: function (res) {	
				console.log(res)
				console.log(decodeURIComponent(res.error))
				 //$(window).attr('location','/seller/distribution_setting_order_amount.html')
				$(window).attr('location','./distribution_setting_byweight.html')
		

			},
			error:function(res){
				console.log(decodeURIComponent(res))
			}
		})



    	/*
        if($("input:checked").val()=='money'){
            $(window).attr('location','/seller/distribution_setting_order_amount.html')
        }else{
            $(window).attr('location','./distribution_setting_byweight.html')
        }
        */
     })
 })