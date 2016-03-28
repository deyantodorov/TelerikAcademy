(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('data', ['$http', '$q', 'authorizationHeader', 'notifier', 'baseUrl', data]);

    function data($http, $q, authorizationHeader, notifier, baseUrl) {

        function get(url, queryParams) {

            var authHeader = authorizationHeader.getAuthorizationHeader();

            var deferred = $q.defer();
            $http.get(baseUrl + '/' + url, { params: queryParams, headers: authHeader })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function post(url, postData) {
            var deferred = $q.defer();

            var authHeader = authorizationHeader.getAuthorizationHeader();

            $http.post(baseUrl + '/' + url, postData, { headers: authHeader })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function put(url, putData) {
            var deferred = $q.defer();

            var authHeader = authorizationHeader.getAuthorizationHeader();

            $http.put(baseUrl + '/' + url, putData, { headers: authHeader })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function getErrorMessage(response) {
            var error = response.data.modelState;
            if (error && error[Object.keys(error)[0]][0]) {
                error = error[Object.keys(error)[0]][0];
            } else {
                error = response.data.Message;
            }

            return error;
        }

        return {
            get: get,
            post: post,
            put: put
        }
    }
}());