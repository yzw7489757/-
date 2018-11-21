$(function () {
	inputctr.public.checkLogin();


//获取 运费计算方式
var shippingModel
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
					shippingModel=1
				else
					shippingModel=2



			},
			error:function(res){
				console.log(decodeURIComponent(res))
			}
		})


	//按钮点击
	$(".buttonContinue").click(function(){


		var upData=new Array();
		//遍历所有条目
		$("#table").find(".contentBar").each(function(index,e){
			var  data={
				fld_id:$(this).attr("id"),
				country:$(this).find(".address").text(),
				standard:isCheck(this,1),
				expedited:isCheck(this,2),
				two_day:isCheck(this,3),
				one_day:isCheck(this,4)
			}
			if(!isAllZero(data))
			upData.push(data)

		});

		upData=JSON.stringify(upData);
		upData="{"+"'shippingArr':"+upData+"}";
		console.log(upData)


		$.ajax({
			url: baseUrl + '/SetUserShipping',
			method: 'post',
			dataType: "json",
			data: {
				userid: amazon_userid,
				shipping_model:"2",
				strJson:upData,
			},
			success: function (res) {	
				console.log(res)
				console.log(decodeURIComponent(res.error))

				if(shippingModel==1)
					$(window).attr('location','./distribution_setting_current_freight.html')
				else
					$(window).attr('location','./distribution_setting_byweight_freight_setup.html')


			},
			error:function(res){
				console.log(decodeURIComponent(res))
			}
		})


	});


	$("#table").find(".contentBar").each(function(index,e){
		data={
			fld_id:this.attr("id"),
			country:this.find(".address").text(),
			standard:"1",
			expedited:"1",
			two_day:"1",
			one_day:"1"
		}
		console.log(data+1112121);
	});



//载入数据
$.ajax({
	url: baseUrl + '/GetDeliveryArea',
	method: 'post',
	dataType: "json",
	data: {
		userid: amazon_userid,
	},
	success: function (res) {
		var data
		console.log(res)

		res.result.forEach(function(e,index){
			//console.log(e);


			data={
				country:decodeURIComponent(e.country),
				fldId:isEmpty(e.shippingSeting[0],"fld_id"),
				OneDay:e.one_day,
				TwoDay:e.two_day,
				Standard:e.standard,
				Expedited:e.expedited,
				isStandard:isEmpty(e.shippingSeting[0],"is_standard"),
				isExpedited:isEmpty(e.shippingSeting[0],"is_expedited"),
				isTwoDay:isEmpty(e.shippingSeting[0],"is_two_day"),
				isOneDay:isEmpty(e.shippingSeting[0],"is_one_day"),
			}

			console.log(data);


			var tpl = doT.template($("#tableTrContent").html());
			$("#table").append(tpl(data));

		})
	},
	error:function(res){
				console.log(res)
			}
})

//判定是否为空
function isEmpty(obj,obj2){

	if(obj==undefined)
		return 0;
	else
	{
		return obj[obj2];
	}
}
//判断是否勾选
function isCheck(obj,num){
	if($(obj).find("input[name='checkbox"+num+"'][type=checkbox]").prop("checked"))
		return 1;
	else
		return 0;

}

})
//判断是否全为0
function isAllZero(data){
	var count=0;
	Object.keys(data).forEach(function(key){
		if(data[key]==0)
			count++;

	});
	if (count==5)
		return 1;
    else 
    	return 0;
}



	/*
    var data1 =new Array();
    var data2={
    	fld_id:"0",
	    country:"美国阿拉斯加",
	    standard:"1",
	    expedited:"1",
	    two_day:"1",
	    one_day:"1"};
	var data3= {
    	fld_id:"0",
	    country:"美国大陆 街道",
	    standard:"1",
	    expedited:"1",
	    two_day:"1",
	    one_day:"1"};
	    data1.push(data2);
	    data1.push(data3);
	    data1=JSON.stringify(data1);
	    data1="{"+"'shippingArr':"+data1+"}";
	    console.log(data1);
*/