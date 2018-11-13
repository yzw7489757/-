let data_analysis={};
$(function(){
	inputctr.public.judgeBegaintask('1601');
	inputctr.public.judgeRecodertask('1601','下载订单数据报告');
})
data_analysis.Initdata=function(){
	let days=$('#selectday').val();
	let reauest_data={
		json:{
			seller_id:amazon_userid,
			days:days
		}
		
	}
	reauest_data.json=JSON.stringify(reauest_data.json);
	$.ajax({
        type:'POST',
        url:baseUrl+'/AllOrders',
        data:reauest_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		inputctr.public.judgeFinishtask('1601',data_analysis.InitdataCallback,data);
        	}else{
        		alert(decodeURIComponent(data.error));
        	}
        	
        },
        error:function(XHR){
          
        }
    });
}
data_analysis.InitdataCallback=function(data){
	var html=template(document.getElementById('amazon-data-analysis-table-tpl').innerHTML,data);
	document.getElementById('amazon-data-analysis-table').innerHTML = html;
}
//下载
data_analysis.DownloadDataAnalysis=function(){
	let days=$('#selectday').val();
	let reauest_data={
		json:{
			seller_id:amazon_userid,
			days:days
		}
	}
	reauest_data.json=JSON.stringify(reauest_data.json);
	$.ajax({
        type:'POST',
        url:baseUrl+'/AllOrdersDown',
        data:reauest_data,
        dataType:"json",
        success:function(data){
        	if(data.result==1){
        		location.href=data.data.path;
        	}else{
        		alert(decodeURIComponent(data.error));
        	}
        	
        },
        error:function(XHR){
          
        }
    });
}
