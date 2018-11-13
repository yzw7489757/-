let campaign_advertising_charge_method={};
let addressList=[];

$(function(){
	campaign_advertising_charge_method.GetChargeMethods();
})
campaign_advertising_charge_method.GetChargeMethods=function(){
	let request_data={
		buyerID:amazon_userid,
		isAddr:0
	}
	$.ajax({
        type:'POST',
        url:baseUrl+'/GetPaymentMethod',
        data:request_data,
        dataType:"json",
        success:function(data){
//      	if(data.result==1){
				let result_data={};
				result_data.data=data;
        		var html=template(document.getElementById('payment-methods-wrap-tpl').innerHTML,result_data);
				document.getElementById('payment-methods-wrap').innerHTML = html;

//      	}else{
// 				
//      	}
        },
        error:function(XHR){
          
        }
    }); 
}

//添加新的支付方式
campaign_advertising_charge_method.AddNewCreditCard=function(target){
		if(($(target).prop('id')=='addCreditCard')&& ($(target).is(':checked'))){
			campaign_advertising_charge_method.GetAddressList();
			$('#add-new-card-information').removeClass('hide');
		}else{
			$('#add-new-card-information').addClass('hide');
		}
}
//获取账单地址
campaign_advertising_charge_method.GetAddressList=function(){
	if(addressList.length==0){
		let request_data={
			userid:amazon_userid,
			sign:1
		}
		$.ajax({
	        type:'POST',
	        url:baseUrl+'/GetAddressList',
	        data:request_data,
	        dataType:"json",
	        success:function(data){
		      	if(data.result==1){
		      		addressList=data.List;
		      		let content='';
		      		for(let i=0;i<data.List.length;i++){
		      			if(data.List[i].is_default==1){
		      				content+='<li><input type="radio" checked="checked" address-id="'+data.List[i].address_id+'" name="addressSelect" id="address-'+data.List[i].address_id+'"/><label for="address-'+data.List[i].address_id+'">'+decodeURIComponent(data.List[i].address)+','+decodeURIComponent(data.List[i].city)+','+decodeURIComponent(data.List[i].province)+','+decodeURIComponent(data.List[i].country)+','+decodeURIComponent(data.List[i].zipcode)+ '</label></li>'
		      			}else{
		      				content+='<li><input type="radio"  address-id="'+data.List[i].address_id+'" name="addressSelect" id="address-'+data.List[i].address_id+'"/><label for="address-'+data.List[i].address_id+'">'+decodeURIComponent(data.List[i].address)+','+decodeURIComponent(data.List[i].city)+','+decodeURIComponent(data.List[i].province)+','+decodeURIComponent(data.List[i].country)+','+decodeURIComponent(data.List[i].zipcode)+ '</label></li>'
		      			}
		      		 	
		      		}
		      		content+='<li><input type="radio" name="" disabled="disabled"/><label><b>添加不同的账单地址</b></label></li>'
		      		$('#billing-address-container ul').html(content);
		      	}else{
		 			alert(decodeURIComponent(data.error))
		      	}
	        },
	        error:function(XHR){
	          
	        }
	    });
	}else{
		
	}
}

//添加新的支付方式
campaign_advertising_charge_method.AddNewCreditCardCommitdata=function(){
	let card_number=$('#add-new-card-information #card_number').val();
	let valid_through_month=$('#valid_through_month').attr('data-condition');
	let valid_through_year=$('#valid_through_year').attr('data-condition');
	let card_holder_name=$('#card_holder_name').val();
	let address_id=$('#billing-address-container input[name="addressSelect"]:checked').attr('address-id');
	if(!card_number || !valid_through_month || !valid_through_year || !card_holder_name){
		alert('请填写完整！')
	}else{
		let request_data={
				json:{
					buyerID:amazon_userid,
					card_number:card_number,
					valid_through_month:valid_through_month,
					valid_through_year:valid_through_year,
					card_holder_name:card_holder_name,
					isdefault:0,
					address_id:address_id
				}
		}
		request_data.json=JSON.stringify(request_data.json)
		$.ajax({
	        type:'POST',
	        url:baseUrl+'/AddPaymentMethod',
	        data:request_data,
	        dataType:"json",
	        success:function(data){
	        	if(data.result==1){
	        		campaign_advertising_charge_method.GetChargeMethods();
	        	}else{
	        		alert(decodeURIComponent(data.error));
	        	}
	 			
	        },
	        error:function(XHR){
	          
	        }
	    });
	}
	
}

//提交选中的支付方式
campaign_advertising_charge_method.SetChargeMethod=function(){
	let method_id=$('#charge-methods-list-table input[type="radio"]:checked').prop('id');
	if(!method_id){
		alert('请选择支付方式！')
	}else{
		let request_data={
			data:{
				seller_id:amazon_userid,
				method_id:method_id
			}
		}
		request_data.data=JSON.stringify(request_data.data);
		$.ajax({
	        type:'POST',
	        url:baseUrl+'/SetCampaingAccount',
	        data:request_data,
	        dataType:"json",
	        success:function(data){
	        	if(data.result==1){
	        		 location.href="campaign_manager.html";
	        	}else{
	        		alert(decodeURIComponent(data.error));
	        	}
	 			
	        },
	        error:function(XHR){
	          
	        }
	    });
	}

}
