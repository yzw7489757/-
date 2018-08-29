$(function () {
	sessionStorage.clear();
	inputctr.public.checkLogin();
	//载入数据
   
	$.ajax({
		url: baseUrl + '/GetUserShippingPrice',
		method: 'post',
		dataType: "json",
		data: {
			userid: amazon_userid,
			shippingModel:2,
		},

		success: function (res) {
			//console.log(res);
			//console.log(res.result[0])
			//var tpl;
			var fldId=0;
			var tpl;
			console.log(res);
			res.result.forEach(function(e,index){
				//console.log(res.result[index]);
				res.result[index].country= decodeURIComponent(res.result[index].country);
			


				tpl = doT.template($("#tableTrContent").html());
				$("#table").append(tpl(res.result[index]));
				if(getModel(e)==2){

					$("#"+e.fld_id).find(".byWeight").attr("selected","selected");

				}
			})
		}
	})
	//确定按钮点击
	$(".a-button-primary").click(function(){
		$(".tbodyBar").each(function(index,e){
			var data1={};
			data1["model"]=$(e).find("select").val();



			if($(e).find(".model_fee1").find("input[type=text]").val()!=undefined){
				var level1={
					id:$(e).find(".shippingSection1").attr("shippingPriceId"),
					model_money:emptyJudge($(e).find(".model_money1").find("input[type=text]").val()),
					model_fee:emptyJudge($(e).find(".model_fee1").find("input[type=text]").val()),

				}
				data1["level1"]=level1;
				//data1.push(level1);
			}
			if($(e).find(".model_fee2").find("input[type=text]").val()!=undefined){
				var level2={
					id:$(e).find(".shippingSection2").attr("shippingPriceId"),
					model_money:emptyJudge($(e).find(".model_money2").find("input[type=text]").val()),
					model_fee:emptyJudge($(e).find(".model_fee2").find("input[type=text]").val()),
				}
				data1["level2"]=level2;
				//data1.push(level2);
			}
			if($(e).find(".model_fee3").find("input[type=text]").val()!=undefined){
				var level3={
					id:$(e).find(".shippingSection3").attr("shippingPriceId"),
					model_money:emptyJudge($(e).find(".model_money3").find("input[type=text]").val()),
					model_fee:emptyJudge($(e).find(".model_fee3").find("input[type=text]").val()),
				}
				data1["level3"]=level3;
				//data1.push(level3);
			}
			if($(e).find(".model_fee4").find("input[type=text]").val()!=undefined){
				var level4={
					id:$(e).find(".shippingSection4").attr("shippingPriceId"),
					model_money:emptyJudge($(e).find(".model_money4").find("input[type=text]").val()),
					model_fee:emptyJudge($(e).find(".model_fee4").find("input[type=text]").val()),
				}
				data1["level4"]=level4;
				//data1.push(level4);
			}
			console.log(data1)
			sessionStorage.setItem('data'+$(e).attr("id"),JSON.stringify(data1));
			console.log("sessionStorage1")
		})
	});
	

	function getModel(e){
		if(e.shippingLevel1!=undefined){
			if(e.shippingLevel1.shippingPrice.length!=0)
			return e.shippingLevel1.shippingPrice[0].model;
		    else 
		    	return 1;
		}
		if(e.shippingLevel2!=undefined){
			if(e.shippingLevel2.shippingPrice.length!=0)
			return e.shippingLevel2.shippingPrice[0].model;
		    else 
		    	return 1;
		}
		if(e.shippingLevel3!=undefined){
			if(e.shippingLevel3.shippingPrice.length!=0)
			return e.shippingLevel3.shippingPrice[0].model;
		    else 
		    	return 1;
		}
		if(e.shippingLevel4!=undefined){
			if(e.shippingLevel4.shippingPrice.length!=0)
			return e.shippingLevel4.shippingPrice[0].model;
		    else 
		    	return 1;
		}
		else
		{
			return 1;
		}

	}
	function emptyJudge(obj){
		var obj1=parseInt(obj);
		if(obj=="")
			return 0.00;
		else
			return  obj1.toFixed(2) ;

	}

	//载入数据
	/*
	$.ajax({
		url: baseUrl + '/GetDeliveryArea',
		method: 'post',
		dataType: "json",
		data: {
			userid: amazon_userid,
		},
		success: function (res) {
			console.log(res);
			var data
			//console.log(res)

			res.result.forEach(function(e,index){
				//console.log(e);


			data={
				country:decodeURIComponent(e.country),
				fldId:isEmpty(e.shippingSeting[0],"fld_id"),
				OneDay:e.one_day,
				TwoDay:e.two_day,
				isStandard:isEmpty(e.shippingSeting[0],"is_standard"),
				isExpedited:isEmpty(e.shippingSeting[0],"is_expedited"),
				isTwoDay:isEmpty(e.shippingSeting[0],"is_two_day"),
				isOneDay:isEmpty(e.shippingSeting[0],"is_one_day"),
			}
			


				console.log(data);
				if(!isAllZero(data)){
					var tpl = doT.template($("#tableTrContent").html());
					$("#table").append(tpl(data));
				}

			})
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
//判断是否全为0
function isAllZero(data){
	var count=0;
	Object.keys(data).forEach(function(key){
		if(data[key]==0)
			count++;

	});
	console.log(data)
	console.log("count="+count)

	if (count>=4)
		return 1;
    else 
    	return 0;
}
*/


})