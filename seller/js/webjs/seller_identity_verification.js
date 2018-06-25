$(function(){
    var radio_button_cc_individual = $('#radio-button-cc--individual');
    var radio_button_bas_individual = $('#radio-button-bas--individual');
    var container_dnd_cc_individual = $('#container-dnd-cc--individual');
    var container_dnd_bas_individual = $('#container-dnd-bas--individual');
    radio_button_cc_individual.click(function(){
        if($(this).prop('checked')){
            container_dnd_cc_individual.show(150)
            container_dnd_bas_individual.hide(150)
        }
    })
    radio_button_bas_individual.click(function(){
        if($(this).prop('checked')){
            container_dnd_bas_individual.show(150)
            container_dnd_cc_individual.hide(150)
        }
    })
})