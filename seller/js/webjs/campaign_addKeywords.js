let campaign_addKeywords={};
$(function(){
	campaign_addKeywords.GetKeywordsList();
})
campaign_addKeywords.GetKeywordsList=function(num){
	let group_id=inputctr.public.getQueryString('groupid');
	let request_data={
			json:{
				group_id:group_id 
			}
	}
	request_data.json=JSON.stringify(request_data.json);
	$.ajax({
        type:'POST',
        url:baseUrl+'/GetKeywordByGoods',
        data:request_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		if(data.data.keys.length>0){
        			var html=template(document.getElementById('suggestedkeywords-conatiner-tpl').innerHTML,data);
					document.getElementById('suggestedkeywords-conatiner').innerHTML = html;
        		}else{
        			var html=template(document.getElementById('suggestedkeywords-conatiner-tpl').innerHTML,data);
					document.getElementById('suggestedkeywords-conatiner').innerHTML = html;
        		}
        		
        	}else{
        		alert(decodeURIComponent(data.error));
        		
        	}
        },
        error:function(XHR){
          
        }
    }); 
}

campaign_addKeywords.SelectCurrentKeyword=function(target){
	let product_id=$(target).parents('.product_details').attr('data-id');
	//用来判断该产品是否已经选中
	let flag=1;
	$('#select-product-group ul li').each(function(){
		if($(this).attr('data-id')==product_id){
			flag=0;
		}
	})
	if(flag==1){
		let product_info=$(target).parents('.product_details').find('.product_details_right').html();
		let product_cover=$(target).parents('.product_details').find('.product_img').html();
		let content='<li data-id="'+product_id+'">'
			 		+'<div class="product_details clearfix">'
					+'<div class="product_details_right pull-left">'+product_info+'</div>'
					+'<div class="product_img pull-left">'+product_cover+'</div>' 
					+'<div class="close" onclick="campaign_addKeywords.DeleteSelectProduct(this)"></div>'
					+'</div></li>';
		$('#select-product-group ul').append(content);
		campaign_addKeywords.SelectNumber();
	}
	
}

  

//选择关键词
campaign_addKeywords.SelectCurrentKeyWords=function(target){
	let keywords_id=$(target).parents('tr').attr('data-id');
	//用来判断该产品是否已经选中
	let flag=1;
	$('#selected-keywords-table tbody tr').each(function(){
		if($(this).attr('data-id')==keywords_id){
			flag=0;
		}
	})
	let defaultBid=$('input[name="reference-price"]').val();
	if(flag==1){
		let keyword=$(target).parents('tr').find('.keyword').html();
		let match=$(target).parents('tr').find('.match').html();
		let content='<tr data-id="'+keywords_id+'"><td  class="keywords">'+keyword+'</td>'
					+'<td class="match">'+match+'</td>'
					+'<td><div><input type="text" name="" id="" value="'+defaultBid+'" class="pull-left" />'
					+'<div class="close" onclick="campaign_addKeywords.DeleteKeywords(this)"></div></div></td></tr>';
		$('#selected-keywords-table tbody').append(content);
		campaign_addKeywords.SelectKeyWordsNumber();
	}
	
}
//当前选中关键词的数量
campaign_addKeywords.SelectKeyWordsNumber=function(){
	let num=$('#selected-keywords-table tbody tr').length;
	if(num>0){
		$('.select-keywords-number span').html(num);
		$('.select-keywords-number').removeClass('hide');
		$('#selected-keywords-table').removeClass('hide');
	}else{
		$('.select-keywords-number').addClass('hide');
		$('#selected-keywords-table').addClass('hide');
	}
}
//删除选中的关键词
campaign_addKeywords.DeleteKeywords=function(target){
	$(target).parents('tr').remove();
	campaign_addKeywords.SelectKeyWordsNumber();
}
//选中全部关键词
campaign_addKeywords.SelectAllKeywords=function(){
	let has_choose=$('#selected-keywords-table tbody tr');
	let allcontent='';
	let defaultBid=$('input[name="reference-price"]').val();
	$('#all-suggest-keyWords .data-row').each(function(){
		let keywords_id=$(this).attr('data-id');
		//用来判断该关键词是否已经选中
		let flag=1;
		has_choose.each(function(){
			if($(this).attr('data-id')==keywords_id){
				flag=0;
			}
		})
		if(flag==1){
			let keyword=$(this).find('.keyword').html();
			let match=$(this).find('.match').html();
			let content='<tr data-id="'+keywords_id+'"><td  class="keywords">'+keyword+'</td>'
						+'<td class="match">'+match+'</td>'
						+'<td><div><input type="text" name="" id=""  value="'+defaultBid+'"  class="pull-left" />'
						+'<div class="close" onclick="campaign_addKeywords.DeleteKeywords(this)"></div></div></td></tr>';
			$('#selected-keywords-table tbody').append(content);
			campaign_addKeywords.SelectKeyWordsNumber();
		}
	})
	
	
}
//添加自己的关键词
campaign_addKeywords.AddOwnKeyWords=function(){
	let keywprds=$('#ownkeywords-textarea').val();
	let keywprdsList=keywprds.split('\n');
	let content='';
	let match='Droad';
	let defaultBid=$('input[name="reference-price"]').val();
	for(let i=0;i<keywprdsList.length;i++){
		content+='<tr data-id="'+keywprdsList[i]+'"><td class="keywords">'+keywprdsList[i]+'</td>'
					+'<td class="match">'+match+'</td>'
					+'<td><div><input type="text" name="" id="" value="'+defaultBid+'" class="pull-left" />'
					+'<div class="close" onclick="campaign_addKeywords.DeleteKeywords(this)"></div></div></td></tr>';
		
	}
	$('#selected-keywords-table tbody').append(content);
	campaign_addKeywords.SelectKeyWordsNumber();
}
//数据提交
campaign_addKeywords.CreateADGroupAuto=function(){
	let bid=$('#Manual-targeting input[name="reference-price"]').val();
	bid=campaign_addKeywords.FormatPrice(bid);
	if(!bid){
		alert('价格格式错误！');
		return false;
	}
	let keywords=[];
	let match='Droad';
	$('#selected-keywords-table tbody tr').each(function(){
		let keyword=$(this).find('.keywords').html();
		let keywordbid=$(this).find('td input').val();
		let kbid=campaign_addKeywords.FormatPrice(keywordbid);
		if(!kbid){
			alert('价格格式错误！');
			return false;
		}else{
			keywordbid=campaign_addKeywords.FormatPrice(keywordbid);
			let current={
				keyword:keyword,
				match:match,
				bid:keywordbid
			}
			keywords.push(current);
		}
		
	})
	let group_id=inputctr.public.getQueryString('groupid');
	let request_data={
			data:{
				group_id:group_id,
				bid:bid,
				keywords:keywords
			}
	}
	request_data.data=JSON.stringify(request_data.data);
	$.ajax({
        type:'POST',
        url:baseUrl+'/CreateADGroupKeywords',
        data:request_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		let group=inputctr.public.getQueryString('group');
        	 	location.href="campaign_ad_group.html?groupid="+group_id+'&group='+group;
        	}else{
        		alert(decodeURIComponent(data.error));
        	}
        },
        error:function(XHR){
          
        }
	})
}
//处理输入的价格
campaign_addKeywords.FormatPrice=function(price){
	let flag=1;
	let bid='';
	if(!inputctr.public.isPrice(price)){
		flag=0;
		return false;
	}else{
		if(price.indexOf('$')==0){
			bid=price.substr(1,price.length);
		}else{
			bid=price;
		}
		return bid;
	}
	
}
