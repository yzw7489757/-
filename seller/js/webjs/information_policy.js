    var teattrValue = new AMZTextEditor("0_attrValue",
        document.getElementById("edit0_attrValue"),
        document.getElementById("tabHolderDesignattrValue_0"),
        document.getElementById("tabHolderCodeattrValue_0"),
        document.getElementById("toolbar2attrValue_0"),
        0, 0,
        document.getElementById("text_component_0_attrValue"),
        "Enter a URL", "", "");
    var teattrValue_1 = new AMZTextEditor("1_attrValue",
        document.getElementById("edit1_attrValue"),
        document.getElementById("tabHolderDesignattrValue_1"),
        document.getElementById("tabHolderCodeattrValue_1"),
        document.getElementById("toolbar2attrValue_1"),
        0, 0,
        document.getElementById("text_component_1_attrValue"),
        "Enter a URL", "", "");



    if (window.addEventListener) {
        window.addEventListener("load", teattrValueInit("edit0_attrValue", "input[name='0_attrValue']"), true);
        window.addEventListener("load", teattrValueInit("edit1_attrValue", "input[name='1_attrValue']"), true);
    } else if (window.attachEvent) {
        window.attachEvent("onload", teattrValueInit("edit0_attrValue", "input[name='0_attrValue']"));
        window.attachEvent("onload", teattrValueInit("edit1_attrValue", "input[name='1_attrValue']"));
    } else if (window.attachEvent) {
    }