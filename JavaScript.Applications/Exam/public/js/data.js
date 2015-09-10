var data = (function () {
    'use strict';

    var LOCAL_STORAGE_USERNAME_KEY = 'username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'authKey',
        MY_COOKIE_GET_PATH = 'api/my-cookie',
        COOKIES_PATH = 'api/cookies',
        USERS_GET_PATH = 'api/users',
        LOGIN_PATH = 'api/auth',
        REGISTER_PATH = 'api/users';


    /* USERS */

    function usersLogin(user) {
        var reqUser = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.username + user.password).toString()
        };

        var options = {
            data: reqUser
        };

        return jsonRequester.put(LOGIN_PATH, options)
            .then(function (resp) {
                var user = resp.result;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
                return user;
            });
    }

    function usersRegister(user) {
        var reqUser = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.username + user.password).toString()
        };

        return jsonRequester.post(REGISTER_PATH, {
            data: reqUser
        })
            .then(function (resp) {
                var user = resp.result;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                //localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
                //console.log(resp);
                return {
                    username: resp.result.username
                };
            });
    }

    function usersLogout() {
        var promise = new Promise(function (resolve, reject) {
            localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
            localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
            resolve();
        });

        return promise;
    }

    function hasUser() {
        return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) && !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
    }

    function usersGet() {
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        //console.log(options);

        return jsonRequester.get(USERS_GET_PATH, options)
            .then(function (res) {
                return res.result;
            });
    }

    /* COOKIES */

    function getMyCookie() {
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        //console.log(options);

        return jsonRequester.get(MY_COOKIE_GET_PATH, options)
            .then(function (res) {
                //console.log(res);
                return res.result;
            });
    }

    function getAll() {
        return jsonRequester.get(COOKIES_PATH)
            .then(function (res) {
                return res.result;
            });
    }

    function add(cookie) {
        var options = {
            data: cookie,
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        return jsonRequester.post(COOKIES_PATH, options)
            .then(function (resp) {
                return resp;
            });
    }

    function like(id) {
        var options = {
            data: {
              type: 'like',
            },
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        jsonRequester.put(COOKIES_PATH + '/' + id, options);
    }

    function dislike(id) {
        var options = {
            data: {
                type: 'dislike',
            },
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        jsonRequester.put(COOKIES_PATH + '/' + id, options);
    }

    function reshare(id) {

    }

    return {
        users: {
            login: usersLogin,
            register: usersRegister,
            logout: usersLogout,
            hasUser: hasUser,
            get: usersGet,
        },
        cookies: {
            getMyCookie: getMyCookie,
            getAll: getAll,
            add: add,
            like: like,
            dislike: dislike,
            reshare: reshare,
        }
    };
}());