(function(){
    'use strict';

    var sammyApp = Sammy('#main', function () {
        this.get('#/', function(context) {
            context.redirect('#/chat');
        });
        this.get('#/chat', chatController.getAll);
    });

    $(function(){
        sammyApp.run('#/');
    });
}());