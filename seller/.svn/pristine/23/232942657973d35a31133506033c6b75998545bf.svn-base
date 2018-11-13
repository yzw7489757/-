let question={};
$(function(){
	question.GetQuestion();
	inputctr.public.judgeBegaintask('1501');
	inputctr.public.judgeRecodertask('1501','查看店铺数据绩效各项数据回答店铺绩效问题');
})

question.GetQuestion=function(){
	let reauest_data={
		seller_id:amazon_userid
	}
	$.ajax({
        type:'POST',
        url:baseUrl+'/GetQuestion',
        data:reauest_data,
        dataType:"json",
        success:function(data){
        	var html=template(document.getElementById('question-wrap-tpl').innerHTML,data);
			document.getElementById('question-wrap').innerHTML = html;
        },
        error:function(XHR){
          
        }
    });
}

//提交答案
question.CommitdataAnswer=function(target){
	let flag=1;
	$('#question-wrap input').each(function(){
		let currentVal=$(this).val();
		if(!currentVal){
			$(this).addClass('error');
			flag=0;
		}else{
			$(this).removeClass('error');
		}
	})
	if(flag==1){
		$(target).prop('disabled',true);
		let answer=[];
		$('#question-wrap input').each(function(){
			let current_answer={
				'id':$(this).attr('data-id'),
				'answer':$(this).val()
			}
			answer.push(current_answer);
		})
		let reauest_data={
				json:{
					seller_id:amazon_userid,
					answer:answer
				}
		}
		reauest_data.json=JSON.stringify(reauest_data.json);
		$.ajax({
	        type:'POST',
	        url:baseUrl+'/SubAnswer',
	        data:reauest_data,
	        dataType:"json",
	        success:function(data){
	        	inputctr.public.judgeFinishtask('1501',question.CommitdataAnswerCallback);
	        	
	        },
	        error:function(XHR){
	          $(target).prop('disabled',false);
	        }
	    });
	}
}
question.CommitdataAnswerCallback=function(){
	$('#CommitSuccess').removeClass('hide');
}
