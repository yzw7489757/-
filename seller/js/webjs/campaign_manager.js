let campaign_manager={};
$(function(){
	campaign_manager.InitFilterCondition('.a-dropdown-container');
})
//初始化筛选条件
campaign_manager.InitFilterCondition=function(target){
	let ctr_dom=$(target).find('.dropdown-menu').find('li a');
	ctr_dom.each(function(){
		$(this).click(function(){
			if($(this).parent('li').attr('aria-checked')=="true"){
				//没有改变筛选条件
				return true;
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
			}
		})
	})
}