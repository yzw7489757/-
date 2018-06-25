﻿﻿var inputctr = {};
inputctr.public = {};
//亚马逊请求接口
var BaseUrl='http://192.168.2.168:8006/QAMZN.asmx';
//任务请求接口地址
var TaskUrl='http://192.168.2.168:10000/CourseService.asmx';
//派安盈请求接口地址
var PayoneerUrl='http://192.168.2.168:9030/WishBind.aspx'; 
//网上银行请求接口地址
var BankUrl='http://192.168.2.168:9030/WishBind.aspx';
var userid='';
var account='';
var TrainingID='';
var studentID='';
var store_id='';
var traintype='';
$(function(){
	inputctr.public.catchError(); 
    inputctr.public.LoadLang();
    inputctr.public.popover();
})
inputctr.public.LoadLang=function(){
    $("#languageSwitcher").change(function(){ 
        inputctr.public.setCookie("lang",$(this).val());
        window.location.reload();
    });
}
inputctr.public.LoadLang1=function(){
    var  filename=location.href; 
    filename=filename.substr(filename.lastIndexOf('/')+1);   
    filename=filename.substring(0,filename.indexOf('.'));
    var lang='en';
    if(inputctr.public.getCookie('lang')){
		lang=inputctr.public.getCookie('lang');
	}
    var js='/seller/lang/'+lang+'/'+filename+'.js';
    jQuery.getScript(js)
         .done(function () {
            var arrKey=new Array(),arrValue=new Array();
            function f(obj,path){
                var keyPath=path;
                for(var key in obj){
                    path = keyPath+"_"+key;
                    if(typeof obj[key]=="object"){
                        f(obj[key],path)
                    }else{
                        //alert(path+':'+obj[key]);
                        arrKey[arrKey.length]=path; 
                        arrValue[arrValue.length]=obj[key];
                        console.log(obj[key]);
　　                }
                }
            }
            var rootP='';
            f(PageObject,rootP);
            var html =$('head').html();
            for(var i =0;i < arrKey.length;i++){ 
                html = html.replace('{{'+arrKey[i]+'}}',arrValue[i]); 
            } 
            $('head').html(html);
            
            var html =$('body').html();
            for(var i =0;i < arrKey.length;i++){ 
                html = html.replace('{{'+arrKey[i]+'}}',arrValue[i]); 
            } 
            $('body').html(html);
    });
} 
//设置cookie
inputctr.public.setCookie=function(cname, cvalue, exdays) {
	var d = new Date();
	d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
	var expires = "expires=" + d.toUTCString(); 
	document.cookie = cname + "=" + cvalue + "; " + expires;
}
//获取cookie
inputctr.public.getCookie=function(cname) {
	var name = cname + "=";
	var ca = document.cookie.split(';');
	for(var i = 0; i < ca.length; i++) {
		var c = ca[i];
		while(c.charAt(0) == ' ') c = c.substring(1);
		if(c.indexOf(name) != -1) return c.substring(name.length, c.length);
	}
	return "";
}
//清除cookie
inputctr.public.clearCookie=function(cname) {
	this.setCookie(cname, "", -1);
}

//验证是否登录
inputctr.public.checkLogin=function(){
	if(!inputctr.public.getCookie('storeInfo')){
		var recodeUrl=encodeURIComponent(window.location.href);
		window.location.href="Login.html?rediect="+	recodeUrl;
	}else{
		store_id=inputctr.public.getCookie('storeInfo');
	}
}
//js获取地址栏参数
inputctr.public.getQueryString=function(name) {
		var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
		var r = window.location.search.substr(1).match(reg);
		if(r != null) return unescape(r[2]);
		return null;
}
//ajax请求出错返回错误信息
inputctr.public.catchError=function(){
	$( document ).ajaxError(function( event, request, settings) {
		inputctr.alertError('Error',"Error requesting " + settings.url + ": " + request.status + " " + request.statusText);
	  	inputctr.public.hideLoading();
	});
} 
//邮编验证
inputctr.public.ispostcode = function(num) {
	var reNum = /^[1-9]\d{5}(?!\d)$/;
	return(reNum.test(num))
};

//身份证验证
inputctr.public.isidcard = function(num) {
	var reNum = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;
	return(reNum.test(num))
};

//手机号码验证
inputctr.public.ismobile = function(num) {
	var reNum = /^1[3|4|5|7|8][0-9]{9}$/;
	return(reNum.test(num))
}
//邮箱验证
inputctr.public.isemail = function(num) {
	var reNum = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
	return(reNum.test(num))
};
//数字验证
inputctr.public.isNum = function(num) {
	var reNum = /(^[1-9]([0-9]+)?(\.[0-9]{1,2})?$)|(^(0){1}$)|(^[0-9]\.[0-9]([0-9])?$)/;
	return(reNum.test(num))
};
//中文名字验证
inputctr.public.isChineseName = function(num) {
	var reNum = /^[\u4E00-\u9FA5\uf900-\ufa2d·s]{1,20}$/;
	return(reNum.test(num))
};
//类型为 price
inputctr.public.isPrice = function(num) {
	var reNum = /^(\${0,1}[0-9]([0-9]+)?((\.[0-9]{1,2})?))$/;
	return(reNum.test(num))
};
//类型为Integer
inputctr.public.isInteger = function(num) {
	var reNum = /^([0-9]([0-9]+)?)$/;
	return(reNum.test(num))
};
//类型为Decimal
inputctr.public.isDecimal = function(num) {
	var reNum = /^([0-9]([0-9]+)?((\.[0-9]{1,2})?))$/;
	return(reNum.test(num))
};

//日期格式化
inputctr.formatTime=function(fmt,target){
	//fmt为日期格式，target为转化的时间
	var o = {  
        "M+": target.getMonth() + 1, //月份   
        "d+": target.getDate(), //日   
        "H+": target.getHours(), //小时   
        "m+": target.getMinutes(), //分   
        "s+": target.getSeconds(), //秒   
        "q+": Math.floor((target.getMonth() + 3) / 3), //季度   
        "S": target.getMilliseconds() //毫秒   
    };  
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (target.getFullYear() + "").substr(4 - RegExp.$1.length));  
    for (var k in o)  
    if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));  
    return fmt;  
}
inputctr.public.popover=function(){ 
    $(".js-popover").click(function() {
        var title = $(this).attr("header");
        var content = $(this).attr("content");
        if($(".a-popover").length==0)
        {
            var html='<div class="a-popover a-arrow-top">';
            html+='  <div class="a-popover-wrapper ">';
            html+='      <div class="a-popover-header">';
            html+='          <button data-action="a-popover-close" class="a-button-close  a-declarative" aria-label="Close">';
            html+='              <i class="a-icon a-icon-close"></i>';
            html+='          </button>';
            html+='          <h4 class="a-popover-header-content" id="a-popover-header-1">'+title+'</h4>';
            html+='      </div>';
            html+='      <div class="a-popover-inner" style="height: auto; overflow-y: auto;">';
            html+='          <div class="a-popover-content" id="a-popover-content-1">';
            html+=content;
            html+='          </div>';
            html+='      </div>';
            html+='      <div class="a-arrow-border" style="left: 50%;">';
            html+='          <div class="a-arrow">';
            html+='          </div>';
            html+='      </div>';
            html+='  </div>';
            html+='</div>';
            $("body").append(html);
        }else{
            $("#a-popover-header-1").html(title);
            $("#a-popover-content-1").html(content);
        }
        var a_popover = $('.a-popover');
        var l = $(this).offset().left - (a_popover.outerWidth(true)/2) + $(this).outerWidth(true)/2;
        var t = $(this).offset().top - a_popover.outerHeight(true);
        a_popover.css({
            'z-index': '299',
            visibility: 'visible',
            opacity:'1',
            display:'block',
            top:t,
            left:l
        })        
        a_popover.find('.a-button-close').click(function(){
            a_popover.css({
                'z-index': '0',
                visibility: 'hidden',
                opacity:'0',
                display:'none'
            })
        })
    })
}
 
//生成图像验证码
inputctr.public.verifyCode=function(e){
	let verifyCode = new GVerify(e);
	return verifyCode;
} 
inputctr.public.initImgUploader = function(imguploader,serverUrl,fileQueuedcallbackfunction,uploadSuccesscallbackfunction,dragbox,fileNumLimit ){
	let limit = fileNumLimit?fileNumLimit:10;
	//参数传递：imguploader为要初始化的上传控件id，serverUrl为接口地址
	// 初始化Web Uploader
	var uploader = WebUploader.create({
	    // 选完文件后，是否自动上传。
	    auto: true,
	    fileNumLimit:limit,  
	    //可拖动的容器
	    dnd:$(dragbox),
	    // swf文件路径
	    swf: './Uploader.swf',
	    // 文件接收服务端。
	    server:baseUrl+serverUrl,
	    duplicate :true,
	    // 选择文件的按钮。可选。
	    // 内部根据当前运行是创建，可能是input元素，也可能是flash.
	    pick: imguploader,
	    // 只允许选择图片文件。
	    accept: {
	        title: 'Images',
	        extensions: 'gif,jpg,jpeg,bmp,png',
	        mimeTypes: 'image/*'
	    }
	});
	// 当有文件添加进来的时候
	uploader.on( 'fileQueued', function( file ) {
	   fileQueuedcallbackfunction(uploader,imguploader,file)
	});
	// 文件上传过程中创建进度条实时显示。
	uploader.on( 'uploadProgress', function( file, percentage ) {
	     
	});

	// 文件上传成功，给item添加成功class, 用样式标记上传成功。
	uploader.on( 'uploadSuccess', function( file,response ) {
		uploadSuccesscallbackfunction(uploader,imguploader,file,response)
	});
	// 文件上传失败，显示上传出错。
	uploader.on( 'uploadError', function( file ) {
	    var $li = $( '#'+file.id ),
	        $error = $li.find('div.error');
	    // 避免重复创建
	    if ( !$error.length ) {
	        $error = $('<div class="error"></div>').appendTo( $li );
	    }
	    $error.text('上传失败');
	});
	// 完成上传完了，成功或者失败，先删除进度条。
	uploader.on( 'uploadComplete', function( file ) {
	    $( '#'+file.id ).find('.progress').remove();
	});
} 

//文件自动上传
inputctr.public.initFileUploader=function(fileuploader,serverUrl,fileQueuedcallbackfunction,uploadSuccesscallbackfunction,dragbox,fileNumLimit){
	let limit = fileNumLimit?fileNumLimit:5;
	var uploader = WebUploader.create({
	    // 选完文件后，是否自动上传。
	    auto: true,
	    fileNumLimit:limit,  
	    //可拖动的容器
	    dnd:$(dragbox),
	    // swf文件路径
	    swf: './Uploader.swf',
	    // 文件接收服务端。
	    server:baseUrl+serverUrl,
	    // 选择文件的按钮。可选。
	    // 内部根据当前运行是创建，可能是input元素，也可能是flash.
	    pick: fileuploader,
	});
	
	// 当有文件添加进来的时候
	uploader.on( 'fileQueued', function( file ) {
	   fileQueuedcallbackfunction(uploader,fileuploader,file)
	});
	// 文件上传过程中创建进度条实时显示。
	uploader.on( 'uploadProgress', function( file, percentage ) {
	    var $li = $( '#'+file.id ),
	        $percent = $li.find('.progress span');
	    // 避免重复创建
	    if ( !$percent.length ) {
	        $percent = $('<p class="progress"><span></span></p>')
	                .appendTo( $li )
	                .find('span');
	    }
	    $percent.css( 'width', percentage * 100 + '%' );
	});

	// 文件上传成功，给item添加成功class, 用样式标记上传成功。
	uploader.on( 'uploadSuccess', function( file,response ) {
		uploadSuccesscallbackfunction(uploader,fileuploader,file,response)
	});
	// 文件上传失败，显示上传出错。
	uploader.on( 'uploadError', function( file ) {
	    var $li = $( '#'+file.id ),
	        $error = $li.find('div.error');
	    // 避免重复创建
	    if ( !$error.length ) {
	        $error = $('<div class="error"></div>').appendTo( $li );
	    }
	    $error.text('上传失败');
	});
	// 完成上传完了，成功或者失败，先删除进度条。
	uploader.on( 'uploadComplete', function( file ) {
	    $( '#'+file.id ).find('.progress').remove();
	});
	
}

//文件手动上传
inputctr.public.initOperationFileUploader=function(fileuploader,serverUrl,fileQueuedcallbackfunction,uploadSuccesscallbackfunction,controlbtn){
	var uploader = WebUploader.create({	    
	    // swf文件路径
	    swf: './Uploader.swf',
	    // 文件接收服务端。
	    server:baseUrl+serverUrl,
	    // 选择文件的按钮。可选。
	    // 内部根据当前运行是创建，可能是input元素，也可能是flash.
	    pick: fileuploader,
	    accept:{
	    	title: 'File',
	        extensions: 'csv,xlsx',
	        mimeTypes: 'text/csv'
	    }
	});
	
	// 当有文件添加进来的时候
	uploader.on( 'fileQueued', function( file ) {
	   fileQueuedcallbackfunction(uploader,fileuploader,file)
	});
	// 文件上传过程中创建进度条实时显示。
	uploader.on( 'uploadProgress', function( file, percentage ) {
	    var $li = $( '#'+file.id ),
	        $percent = $li.find('.progress span');
	    // 避免重复创建
	    if ( !$percent.length ) {
	        $percent = $('<p class="progress"><span></span></p>')
	                .appendTo( $li )
	                .find('span');
	    }
	    $percent.css( 'width', percentage * 100 + '%' );
	});

	// 文件上传成功，给item添加成功class, 用样式标记上传成功。
	uploader.on( 'uploadSuccess', function( file,response ) {
		uploadSuccesscallbackfunction(uploader,fileuploader,file,response)
	});
	// 文件上传失败，显示上传出错。
	uploader.on( 'uploadError', function( file ) {
	    var $li = $( '#'+file.id ),
	        $error = $li.find('div.error');
	    // 避免重复创建
	    if ( !$error.length ) {
	        $error = $('<div class="error"></div>').appendTo( $li );
	    }
	    $error.text('上传失败');
	});
	// 完成上传完了，成功或者失败，先删除进度条。
	uploader.on( 'uploadComplete', function( file ) {
	    $( '#'+file.id ).find('.progress').remove();
	});
	
	$(controlbtn).on('click',function(){
		 uploader.upload();
	})
}
 


inputctr.public.loadTaskConfig=function(){
	$.getJSON('js/TaskConfig.js',function(result){
		let data=result.taskConfig;
		 inputctr.public.loadTaskList(data);
	})
}

inputctr.public.loadTaskList=function(taskList){
	let commitdata={
		TrainingID:TrainingID,
		studentID:studentID
	}
	$.post(TaskUrl+'/TrainingTaskUserList',commitdata,function(response){
		let data=eval(response);
		let tasklist='';
		if(data.list.length>0){
			for(var i=0;i<data.list.length;i++){
				for(var j=0;j<taskList.length;j++){
					if(data.list[i].number==taskList[j].number){
						if(data.list[i].finish==0){
							if(data.list[i].number=='28' || data.list[i].number=='29' || data.list[i].number=='30'){
								//wish邮注册开通
								tasklist+='<li class="clearfix tasklist "><p class="pull-left">'+data.list[i].number+'、'+decodeURIComponent(data.list[i].name)+'</p><a href="'+shpostwishUrl+'?userid='+userid+'&account='+account+'&trainingid='+TrainingID+'&traintype='+traintype+'&taskid='+data.list[i].number+'"><p class="pull-right checklist-item-btn">开始</p></a></li>'
							}else{
								tasklist+='<li class="clearfix tasklist "><p class="pull-left">'+data.list[i].number+'、'+decodeURIComponent(data.list[i].name)+'</p><a href="'+taskList[j].taskurl+'"><p class="pull-right checklist-item-btn">开始</p></a></li>'
							}
						}else{
							tasklist+='<li class="clearfix tasklist checklist-item-complete"><p class="pull-left">'+data.list[i].number+'、'+decodeURIComponent(data.list[i].name)+'</p><p class="pull-right checklist-item-btn">完成</p></li>'
						}
	
					}
				}
			}
			let content='<div class="modal fade" id="taskContainer" tabindex="-1" role="dialog"><div class="modal-dialog" role="document">'
			   		+'<div class="modal-content"><div class="modal-header">'
			        +'<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>'
			        +'<h4 class="modal-title">任务列表</h4></div>'
			      	+'<div class="modal-body">'
			        +'<ul>'+tasklist+'</ul>'
			      	+'</div>'
			      	+'<div class="modal-footer"><button type="button" class="btn btn-primary" data-dismiss="modal">确定</button></div>'
			   	 	+'</div></div></div>';
			 $('body').append(content); 
			 $('#taskContainer').modal();
			 $('#taskContainer').on('hidden.bs.modal', function () {
				$('#taskContainer').remove();
			})
		}
		
	})
}


inputctr.public.judgeTask=function(callback,parameter){
	userid=inputctr.public.getCookie('userid')?inputctr.public.getCookie('userid'):inputctr.public.getQueryString('userid');
	account=inputctr.public.getCookie('account')?inputctr.public.getCookie('account'):inputctr.public.getQueryString('account');
	TrainingID=inputctr.public.getCookie('TrainingID')?inputctr.public.getCookie('TrainingID'):inputctr.public.getQueryString('TrainingID');
	studentID=inputctr.public.getCookie('studentID')?inputctr.public.getCookie('studentID'):inputctr.public.getQueryString('userid');
	traintype=inputctr.public.getCookie('traintype')?inputctr.public.getCookie('traintype'):inputctr.public.getQueryString('traintype');
	inputctr.public.setCookie('userid',userid);
	inputctr.public.setCookie('account',account);
	inputctr.public.setCookie('TrainingID',TrainingID);
	inputctr.public.setCookie('studentID',userid);
	inputctr.public.setCookie('traintype',traintype);
	if(!userid || !account){
		location.href="404page.html";
	}else{
		let taskList=sessionStorage.getItem('taskList');
		if(!taskList){
			let commitdata={
				TrainingID:TrainingID,
				studentID:studentID
			}
			$.post(TaskUrl+'/TrainingTaskUserList',commitdata,function(response){
				let data=eval(response);
				sessionStorage.setItem('taskList', JSON.stringify(data));
				if(data.list.length>0){
					$('#taskButton').removeClass('hide');
				}
				if(!callback){}else{
					callback(parameter);
				}
			})
		}else{
			let taskListParse=JSON.parse(taskList);
			if(taskListParse && taskListParse.list.length>0){
				$('#taskButton').removeClass('hide');
			}
			if(!callback){}else{
					callback(parameter);
			}
		}
	}
	
}

inputctr.public.judgeBegaintask=function(taskId,callback,parmameter){
	if(!TrainingID || !studentID){
		if(!callback){}else{
			callback(parmameter);
		}
	}else{
		let taskList=JSON.parse(sessionStorage.getItem('taskList'));
		if(taskList && taskList.list.length>0){
			let flag=1;
			for(var i=0;i<taskList.list.length;i++){
				if(taskList.list[i].number==taskId){
					flag=0;
					inputctr.public.begaintask(taskId,callback,parmameter);
				}
			}
			if(flag==1){
				if(!callback){}else{
					callback(parmameter);
				}
			}
		}else{
			if(!callback){}else{
				callback(parmameter);
			}
		}
	}
	
}
inputctr.public.judgeRecodertask=function(taskId,content,callback,parmameter){
	if(!TrainingID || !studentID){
		if(!callback){}else{
					callback(parameter);
			}
	}else{
		let taskList=JSON.parse(sessionStorage.getItem('taskList'));
		if(taskList && taskList.list.length>0){
			let flag=1;
			for(var i=0;i<taskList.list.length;i++){
				if(taskList.list[i].number==taskId){
					flag=0;
					inputctr.public.recodertask(taskId,content,callback,parmameter);
				}
			}
			if(flag==1){
				if(!callback){}else{
					callback(parmameter);
				}
			}
		}else{
			if(!callback){}else{
				callback(parmameter);
			}
		}
	}
	
}
inputctr.public.judgeFinishtask=function(taskId,callback,parmameter){
	if(!TrainingID || !studentID){
		if(!callback){
			
		}else{
			callback(parameter);
		}
	}else{
		let taskList=JSON.parse(sessionStorage.getItem('taskList'));
		if(taskList && taskList.list.length>0){
			let flag=1;
			for(var i=0;i<taskList.list.length;i++){
				if(taskList.list[i].number==taskId){
					flag=0;
					inputctr.public.finishtask(taskId,callback,parmameter);
				}
			}
			if(flag==1){
				if(!callback){}else{
					callback(parmameter);
				}
			}
		}else{
			if(!callback){}else{
				callback(parmameter);
			}
			
		}
	}
	
}

inputctr.public.begaintask=function(taskID,callback,parmameter){
	let userdata={
			TrainingID:TrainingID,
			studentID:studentID,
			taskID:taskID,
			TrainingSign:traintype
		};
		$.post(TaskUrl+'/TrainingTaskUserBegin',userdata,function(response){
			let data=eval(response);
			if(data.result=='1'){
				if(!callback){}else{
					callback(parmameter);
				}
			}else{
				inputctr.alertError('错误',decodeURIComponent(data.error));
			}
		})
},
inputctr.public.recodertask=function(taskID,content,callback,parmameter){
	let userdata={
			TrainingID:TrainingID,
			studentID:studentID,
			taskID:taskID,
			content:content,
			taskProcess:100,
			TrainingSign:traintype
		};
		$.post(TaskUrl+'/TrainingTaskUserRecordAdd',userdata,function(response){
			let data=eval(response)
			if(data.result=='1'){
				if(!callback){}else{
					callback(parmameter);
				}
			}else{
				inputctr.alertError('错误',decodeURIComponent(data.error));
			}

		})
},
inputctr.public.finishtask=function(taskID,callback,parmameter){
	let userdata={
		TrainingID:TrainingID,
		studentID:studentID,
		taskID:taskID,
		report:'',
		reportPath:'',
		TrainingSign:traintype
		};
		$.post(TaskUrl+'/TrainingTaskUserEnd',userdata,function(response){
			let data=eval(response)
			if(data.result=='1'){
				if(!callback){}else{
					callback(parmameter);
				}
			}else{
				inputctr.alertError('错误',decodeURIComponent(data.error));
			}
		})
}

inputctr.public.begaintriann=function(successCallback,tasklist){
	inputctr.public.showLoading();
	let userdata={
		TrainingID:TrainingID,
		studentID:studentID,
		TrainingSign:traintype
	};
	$.post(TaskUrl+'/TrainingUserBegin',userdata,function(response){
		if(!successCallback){
			location.href="Register.html";
		}else{
			successCallback(tasklist);
		}
		
	})
}