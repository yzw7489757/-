let common_methods={};
common_methods.public={};

//输入框失去焦点的时候就验证
common_methods.public.CheckInput = function(target,set_error_callback,clear_error_callback) {
	var flag=1;
	var currentInput = $(target);
	//获取要求的数据格式
	var dataType = currentInput.attr('data-type');
	//获取错误提示信息
	var errortext = currentInput.attr('errortext');
	//	用户的输入值
	var currentval = currentInput.val();
	if(currentInput.prop('required') == true) {
		if(!currentval) {
			let currenterrortext = errortext + '为必填'
			set_error_callback(currentInput, currenterrortext);
			flag=0;
			return false;
		} else {
			var checkflag = common_methods.public.checkType(dataType, currentval);
			if(checkflag == 0) {
				let currenterrortext = '';
				if(dataType == 'password') {
					currenterrortext = '密码长度为8-16位';
				} else {
					currenterrortext = errortext + '格式有误'
				}
				flag=0;
				set_error_callback(currentInput, currenterrortext);
				return false;
			} else {
				clear_error_callback(currentInput);
				return true;
			}

		}
	} else {
		//当不是必填的时候  验证输入的格式是否正确
		if(!currentval) {
			return true;
		} else {
			var checkflag = common_methods.public.checkType(dataType, currentval);
			if(checkflag == 0) {
				let currenterrortext = '';
				if(dataType == 'password') {
					currenterrortext = '密码长度为8-16位';
				} else {
					currenterrortext = errortext + '格式有误'
				}
				flag=0;
				set_error_callback(currentInput, currenterrortext);
				return false;
			} else {
				clear_error_callback(currentInput);
				return true;
			}

		}
	}
	return flag;
}
common_methods.public.checkType = function(dataType, val) {
	var flag = 1;
	if(dataType == 'shopName') {
		//数据格式为店铺名称

	} else if(dataType == 'email') {
		//数据格式为邮箱
		if(!inputctr.public.isemail(val)) {
			flag = 0;
			return false;
		}
	} else if(dataType == 'mobile') {
		//数据格式为手机号
		if(!inputctr.public.ismobile(val)) {
			flag = 0;
			return false;
		}
	} else if(dataType == 'postcode') {
		//数据格式为邮编,为英文和数字都可以
		let newVal=inputctr.public.Trim(val,'g');
		if(!inputctr.public.isEnglishAndNumber(newVal)) {
			flag = 0;
			return false;
		}
	} else if(dataType == 'idcard') {
		//数据格式为身份证
		if(!inputctr.public.isidcard(val)) {
			flag = 0;
			return false;
		}
	} else if(dataType == 'password') {
		//数据格式为密码
		if(val.length < 8 || val.length > 16) {
			flag = 0;
			return false;
		}
	}else if(dataType == 'boolean') {
		//数据格式为布尔值
		if(val.toLowerCase()!='yes' && val.toLowerCase()!='no' ) {
			flag = 0;
			return false;
		}
	}else if(dataType =='ChineseName'){
		//名字为中文
		if(!inputctr.public.isChineseName(val)) {
			flag = 0;
			return false;
		}
	} else if(dataType=='price'){
		//价格类型
		if(!inputctr.public.isPrice(val)) {
			flag = 0;
			return false;
		}
	}else if(dataType=='Integer'){
		//类型为整数
		if(!inputctr.public.isInteger(val)) {
			flag = 0;
			return false;
		}
	}else if(dataType=='Decimal'){
		//类型为小数
		if(!inputctr.public.isDecimal(val)) {
			flag = 0;
			return false;
		}
	}else if(dataType=='EnglishAndNumber'){
		//类型为数字和英文的集合
		//去除空格
		let newVal=inputctr.public.Trim(val,'g');
		if(!inputctr.public.isEnglishAndNumber(newVal)) {
			flag = 0;
			return false;
		}
	}else{}
	return flag;
}

//表单提交验证
common_methods.public.CheckForm = function(e,set_error_callback,clear_error_callback) {
	var target = $(e);
	var flag=1;
	target.find('input,textarea,select').each(function() {
		if(common_methods.public.CheckInput(this,set_error_callback,clear_error_callback)==0){
			flag=0;
		}
	})
	return flag;
}

//设置loading
common_methods.public.ShowLoading=function(){
	 let content='<div class="modal fade" id="loadingLayer" tabindex="-1" data-backdrop="false">'
                +'<div class="loading-box"><div class="load-container load7">'
              	+'<img src="img/same-load.gif" style="border:1px solid #efefef; border-radius: 4px;">'
                +'</div></div></div>';
    $('body').append(content);
    $('#loadingLayer').modal();
    $('#loadingLayer').on('hidden.bs.modal', function () {
        $('#loadingLayer').remove();
    })
}
common_methods.public.HideLoading=function(){
    $('#loadingLayer').modal('hide');
}
common_methods.AlertError=function(title,content,callback){
	let errorLayer='<div class="modal fade" id="errorLayer" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">'
					+'<div class="modal-dialog" role="document">'
					+'<div class="modal-content">'
					+'<div class="modal-header">'
					+'<a href="javascript:;" class="a-button-close" data-dismiss="modal" aria-label="Close"><i class="a-icon a-icon-close"></i></a>'
					+'<h4 class="modal-title" id="myModalLabel">'+title+'</h4>'
					+'</div>'
					+'<div class="modal-body"><div class="alert alert-error bg-danger">'
					+'<strong><div style="word-break: break-all;">'+content+'</div></strong></div></div>'
					+'<div class="modal-footer">'
					+'<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>'
					+'</div>'
					+'</div>'
					+'</div>'
					+'</div>';
		$('body').append(errorLayer);	
		$('#errorLayer').modal();
		$('#errorLayer').on('hidden.bs.modal', function () {
			if(!callback){
				$('#errorLayer').remove();
			}else{
				callback();
				$('#errorLayer').remove();
			}
			
				
		})
}