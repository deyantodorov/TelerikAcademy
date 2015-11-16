var chat = Handlebars.template({"1":function(depth0,helpers,partials,data) {
    var helper, alias1=helpers.helperMissing, alias2="function", alias3=this.escapeExpression;

  return "                <div class=\"col-md-2\">IP: "
    + alias3(((helper = (helper = helpers.Ip || (depth0 != null ? depth0.Ip : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"Ip","hash":{},"data":data}) : helper)))
    + "</div>\r\n                <div class=\"col-md-10\">Message: "
    + alias3(((helper = (helper = helpers.Message || (depth0 != null ? depth0.Message : depth0)) != null ? helper : alias1),(typeof helper === alias2 ? helper.call(depth0,{"name":"Message","hash":{},"data":data}) : helper)))
    + "</div>\r\n";
},"compiler":[6,">= 2.0.0-beta.1"],"main":function(depth0,helpers,partials,data) {
    var stack1;

  return "﻿<div class=\"container\">\r\n    <h2>List of received messages:</h2>\r\n    <div class=\"row\">\r\n        <div class=\"messages p20\">\r\n            <div class=\"messsage row\">\r\n"
    + ((stack1 = helpers.each.call(depth0,depth0,{"name":"each","hash":{},"fn":this.program(1, data, 0),"inverse":this.noop,"data":data})) != null ? stack1 : "")
    + "            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"row mt-30\">\r\n        <div class=\"col-md-8\">\r\n            <div class=\"form-group\">\r\n                <label for=\"tb-message\">Type some message to be send: </label>\r\n                <textarea rows=\"3\" cols=\"30\" class=\"form-control\" id=\"tb-message\"></textarea>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-2 pt-22\">\r\n            <a href=\"javascript:void(0);\" class=\"btn btn-lg btn-primary\" id=\"btn-send\">Send Message</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n";
},"useData":true});