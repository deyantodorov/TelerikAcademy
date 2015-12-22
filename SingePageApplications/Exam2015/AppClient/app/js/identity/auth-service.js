(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('auth', ['$http', '$q', 'identity', 'authorizationHeader', 'baseUrl', 'notifier', auth]);

    function auth($http, $q, identity, authorizationHeader, baseUrl, notifier) {

        var USERS_API = baseUrl + '/api/account';

        function register(user) {
            var deferred = $q.defer();

            $http.post(USERS_API + '/register', user)
                .then(function () {
                    deferred.resolve();
                }, function (response) {
                    var error = response.data.modelState;

                    if (error && error[Object.keys(error)[0]][0]) {
                        error = error[Object.keys(error)[0]][0];
                    } else {
                        error = response.data.message;
                    }

                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function login(user) {
            var deferred = $q.defer();

            user['grant_type'] = 'password';

            $http.post(baseUrl + '/token', 'username=' + user.username + '&password=' + user.password + '&grant_type=password', { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(function (response) {
                    if (response.data["access_token"]) {
                        identity.setCurrentUser(response.data);
                        deferred.resolve(true);
                    } else {
                        deferred.resolve(false);
                    }
                }, function (error) {

                    // TODO: Refactor in controller
                    //deferred.reject(error);
                    notifier.error(error.data.error_description);
                });

            return deferred.promise;
        }

        function logout() {
            var deferred = $q.defer();

            var headers = authorizationHeader.getAuthorizationHeader();
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