var usersController = (function () {
    'use strict';

    function usersLogin(context) {
        templates.get('login')
            .then(function (template) {
                context.$element().html(template());

                $('#btn-login').on('click', function () {
                    var user = {
                        username: $('#tb-username').val(),
                        password: $('#tb-password').val()
                    };

                    if(!validator.length(user.username)){
                        toastr.error('Invalid USERNAME. Must be length between 6 and 30.');
                        return;
                    }

                    if(!validator.latinLettersUnderscoreDot(user.username)){
                        toastr.error('Invalid USERNAME. Can contain only Latin letters, digits and the characters _ and .');
                        return;
                    }

                    if(!validator.length(user.password)){
                        toastr.error('Invalid PASSWORD. Must be length between 6 and 30. Additional check by ME. Do not send blank passwords');
                        return;
                    }

                    //console.log(user);

                    data.users.login(user)
                        .then(function () {
                            context.redirect('#/');
                            toastr.success('User logged!');
                            if (data.users.hasUser()) {
                                $('#btn-nav-users').show();
                                $('#btn-nav-log').hide();
                                $('#btn-nav-reg').hide();
                                $('#btn-nav-out').show();
                            }
                        }).catch(function (res) {
                            toastr.error(res.responseJSON);
                        });
                    ;
                });
            });
    }

    function usersRegister(context) {
        templates.get('register')
            .then(function (template) {
                context.$element().html(template());

                $('#btn-register').on('click', function () {
                    var user = {
                        username: $('#tb-username').val(),
                        password: $('#tb-password').val()
                    };

                    if(!validator.length(user.username)){
                        toastr.error('Invalid USERNAME. Must be length between 6 and 30.');
                        return;
                    }

                    if(!validator.latinLettersUnderscoreDot(user.username)){
                        toastr.error('Invalid USERNAME. Can contain only Latin letters, digits and the characters _ and .');
                        return;
                    }

                    if(!validator.length(user.password)){
                        toastr.error('Invalid PASSWORD. Must be length between 6 and 30. Additional check by ME. Do not send blank passwords');
                        return;
                    }

                    //console.log(user);

                    data.users.register(user)
                        .then(function () {
                            context.redirect('#/login');
                            toastr.success('User registered!');

                            //if(data.users.hasUser()){
                            //    $('#btn-nav-log').hide();
                            //    $('#btn-nav-reg').hide();
                            //    $('#btn-nav-out').show();
                            //}
                        }).catch(function (res) {
                            toastr.error(res.responseJSON);
                        });
                });
            });
    }

    function usersLogout(context) {
        data.users.logout().then(function () {
            context.redirect('#/');
            toastr.success('User logged out!');
            if (!data.users.hasUser()) {
                $('#btn-nav-log').show();
                $('#btn-nav-reg').show();
                $('#btn-nav-users').hide();
                $('#btn-nav-out').hide();
            }
        });
    }

    function getUsers(context) {
        var users;

        data.users.get()
            .then(function (resUsers) {
                users = resUsers;
                //console.log(users);
                return templates.get('users');
            })
            .then(function (template) {
                context.$element().html(template(users));
            });
    }

    return {
        login: usersLogin,
        logout: usersLogout,
        register: usersRegister,
        users: getUsers,
    };
}());