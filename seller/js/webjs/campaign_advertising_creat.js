let campaign_advertising_create={};

$(function(){
	$('.ShipDate').each(function(){
			laydate.render({
		      elem:this,
		      lang: 'en',
		      showBottom: false,
		    });
	})
})

//创建广告第一步
campaign_advertising_create.Commitdata=function(){
	let flag=1;
	$('.creat-information input[type="text"]').each(function(){
		let current=$(this).val();
		if(!current){
			flag=0;
			
		}
	})
	if(flag==1){
		if(!$('.creat-information input[name="targeting-type"]:checked').val()){
			$('#commit-error').removeClass('hide');
		}else{
			$('#commit-error').addClass('hide')
			let name=$('.creat-information input[name="CampaignName"]').val();
			let daily_budget=$('.creat-information input[name="DailyBudget"]').val();
			let start_date=$('.creat-information #customize-begin-date').val();
			let end_date=$('.creat-information #customize-end-date').val();
			let type=$('.creat-information input[name="targeting-type"]:checked').val();
			if((new Date(start_date)).getTime()>(new Date(end_date)).getTime()){
				$('#commit-error .a-alert-heading').html('开始时间不能大于结束时间!')
				$('#commit-error').removeClass('hide');
				return false;
			}
			let reauest_data={
					data:{
						seller_id:amazon_userid,
						name:name,
						daily_budget:daily_budget,
						start_date:start_date,
						end_date:end_date,
						type:type
					}
			}
			reauest_data.data=JSON.stringify(reauest_data.data);
			$.ajax({
		        type:'POST',
		        url:baseUrl+'/CampaingSettings',
		        data:reauest_data,
		        dataType:"json",
		        success:function(data){
		        	if(data.result==1){
		        		location.href="campaign_advertising_creat2.html?campaingId="+data.id+'&campaingType='+type;
		        	}else{
		        		$('#commit-error .a-alert-heading').html(decodeURIComponent(data.error))
						$('#commit-error').removeClass('hide');
		        	}
		        },
		        error:function(XHR){
		          
		        }
		    });
		}
	}else{
		$('#commit-error').removeClass('hide')
	}
	
}
