let campaign_detail={};
$(function(){
	campaign_detail.GetCampaignDetail()
	
})
//获取广告详情
campaign_detail.GetCampaignDetail=function(){
	let campaign_id=inputctr.public.getQueryString('campaignid');
	let request_data={
			json:{
				campaign_id:campaign_id,
			}
	}
	request_data.json=JSON.stringify(request_data.json);
	$.ajax({
        type:'POST',
        url:baseUrl+'/GetCampaingInfo',
        data:request_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		$('#Campaign-name-box').html(data.data.name);
    			campaign_detail.GetCampaignList('1');
				campaign_detail.InitFilterCondition('.a-dropdown-container');
        	}else{
        		alert(decodeURIComponent(data.error));
        	}
        },
        error:function(XHR){
          
        }
    }); 
	
}
//初始化筛选条件
campaign_detail.InitFilterCondition=function(target){
	let ctr_dom=$(target).find('.dropdown-menu').find('li a');
	ctr_dom.each(function(){
		$(this).click(function(){
			if($(this).parent('li').attr('aria-checked')=="true"){
				//没有改变筛选条件
				 if($(target).prop('id')=="operationAdCampaign"){
					campaign_detail.OperationAdGroup();
				}else{
					return true;
				}
			}else{
				$(this).addClass('active');
				$(this).parent('li').attr('aria-checked',"true");
				$(this).parent('li').siblings('li').attr('aria-checked',"false");
				$(this).parent('li').siblings('li').find('a').removeClass('active');
				let val=$(this).attr('data-value');
				let tex=$(this).attr("replace-text");
				$(this).parents('.a-dropdown-container').attr('data-condition',val);
				$(this).parents('.a-dropdown-container').find('.a-dropdown-prompt').html(tex);
				let flag=$('.spa-tab-container').find('.active a').attr('data-id');
				if($(this).parents('.a-dropdown-container').prop('id')=="operationAdGroup"){
					campaign_detail.GetCampaignList('1')
				}else if($(this).parents('.a-dropdown-container').prop('id')=="select-group-action"){
					campaign_detail.OperationAdGroup();
				}
				
			}
		})
	})
}

//获取分组列表 
campaign_detail.GetCampaignList=function(num){
	let key=$('#product-search').val();
	let status=$('#operationAdGroup').attr('data-condition');
	let campaign_id=inputctr.public.getQueryString('campaignid');
	let request_data={
			json:{
				campaign_id: campaign_id,
				key:key,
				status:status
			}
	}
	request_data.json=JSON.stringify(request_data.json);
	$.ajax({
        type:'POST',
        url:baseUrl+'/GetCampaingGroupList',
        data:request_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
    			var html=template(document.getElementById('Group-table-container-tpl').innerHTML,data);
				document.getElementById('Group-table-container').innerHTML = html;
        	}
        },
        error:function(XHR){
          
        }
    }); 
}

campaign_detail.GoCreatCampaign=function(){
	location.href="campaign_advertising_creat.html"
}
//改变广告状态
campaign_detail.OperationAdGroup=function(){
	let groupid="";
	$('#Group-table-container table tbody input[type="checkbox"]:checked').each(function(){
		groupid+=$(this).prop('id')+','
	})
	if(!groupid){
		alert('请选择需要操作的分组！');
		return false;
	}else{
		groupid=groupid.substr(0,groupid.length-1);
	}
	let action=$('#select-group-action').attr('data-condition');
	let request_data={
			data:{
				id:groupid,
				action:action 
			}
	}
	request_data.data=JSON.stringify(request_data.data);
	$.ajax({
        type:'POST',
        url:baseUrl+'/CampaingGroupActions',
        data:request_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		 campaign_detail.GetCampaignList('1')
        	}
        },
        error:function(XHR){
          
        }
    }); 
}

//选择所有的活动
campaign_detail.CheckCampaign=function(target){
	if($(target).prop('id')=='check-all'){
		//点击全选
		if($(target).is(':checked')){
			$('#Group-table-container table tbody input[type="checkbox"]').prop('checked',true);
		}else{
			$('#Group-table-container table tbody input[type="checkbox"]').prop('checked',false);
		}
	}else{
		let flag=1;
		$('#Group-table-container table tbody input[type="checkbox"]').each(function(){
			if(!$(this).prop('checked')){
				flag=0;
			}
		})
		if(flag==0){
			$('#Group-table-container table #check-all').prop('checked',false);
		}else{
			$('#Group-table-container table #check-all').prop('checked',true);
		}
	}
	
}
 campaign_detail.GotoCreateGroup=function(){
	let campaign_id=inputctr.public.getQueryString('campaignid');
	let request_data={
			json:{
				campaign_id:campaign_id,
			}
	}
	request_data.json=JSON.stringify(request_data.json);
	$.ajax({
        type:'POST',
        url:baseUrl+'/GetCampaingInfo',
        data:request_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		location.href="campaign_advertising_creat2.html?flag=group&campaingId="+data.data.campaign_id+'&campaingType='+data.data.targeting_type;
        	}
        },
        error:function(XHR){
          
        }
    }); 
 	
 }
