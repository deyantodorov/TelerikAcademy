(function(){
    'use strict';

    var sammyApp = Sammy('#main', function(){
        this.get('#/', function(context){
            context.redirect('#/home');
        });

        this.get('#/home', cookieController.getAll);

        this.get('#/users', usersController.users);
        this.get('#/login', usersController.login);
        this.get('#/logout', usersController.logout);
        this.get('#/register', usersController.register);

        this.get('#/my-cookie', cookieController.getMyCookie);
        this.get('#/cookie/add', cookieController.add);
        this.get('#/cookie/like/:id', cookieController.like);
        this.get('#/cookie/dislike/:id', cookieController.dislike);
        this.get('#/cookie/reshare/:id', cookieController.reshare);

        if(data.users.hasUser()){
            $('#btn-nav-log').hide();
            $('#btn-nav-reg').hide();
            $('#btn-nav-out').show();
            $('#btn-nav-users').show();
        } else{
            $('#btn-nav-log').show();
            $('#btn-nav-reg').show();
            $('#btn-nav-out').hide();
            $('#btn-nav-users').hide();
        }
    });

    $(function(){
        sammyApp.run('#/');
    });
}());