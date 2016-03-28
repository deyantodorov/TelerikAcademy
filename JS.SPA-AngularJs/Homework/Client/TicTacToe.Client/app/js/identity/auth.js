(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('auth', ['$http', '$q', 'notifier', 'identity', 'authorization', 'baseServiceUrl', auth]);

    function auth($http, $q, notifier, identity, authorization, baseServiceUrl) {

        var USERS_API = baseServiceUrl + 'api/account';

        function register(user) {
            var deferred = $q.defer();

            $http.post(USERS_API + '/register', user)
                .then(function () {
                    deferred.resolve();
                }, function (response) {
                    //console.log(response);
                    var error = response.data.ModelState;

                    if (error && error[Object.keys(error)[0]][0]) {
                        error = error[Object.keys(error)[0]][0];
                    } else {
                        error = response.data.Message;
                    }

                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function login(user) {
            var deferred = $q.defer();

            user['grant_type'] = 'password';
            var data = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';

            $http.post(baseServiceUrl + 'Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response) {
                    if (response["access_token"]) {
                        identity.setCurrentUser(response);
                        deferred.resolve(true);
                    } else {
                        deferred.resolve(false);
                    }
                })
                .error(function (err) {
                    notifier.error(err.error_description);
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        function logout() {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(USERS_API + '/logout', {}, { headers: headers })
                .then(function () {
                    identity.setCurrentUser(undefined);
                    deferred.resolve();
                });

            return deferred.promise;
        }

        function isAuthenticated() {
            if (identity.isAuthenticated()) {
                return true;
            } else {
                return $q.reject('Not Authorized');
            }
        }

        return {
            register: register,
            login: login,
            logout: logout,
            isAuthenticated: isAuthenticated
        }
    }
}());