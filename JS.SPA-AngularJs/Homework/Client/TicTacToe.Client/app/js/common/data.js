(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('data', ['$http', '$q', 'authorization', 'notifier', 'baseServiceUrl', data]);

    function data($http, $q, authorization, notifier, baseServiceUrl) {

        function get(url, queryParams) {

            var authHeader = authorization.getAuthorizationHeader();

            var deferred = $q.defer();
            $http.get(baseServiceUrl + '/' + url, { params: queryParams, headers: authHeader })
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

            var authHeader = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + '/' + url, postData, { headers: authHeader })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function put() {
            throw new Error('Not implemented exception!');
        }

        function getErrorMessage(response) {
            var error = response.data.modelState;

            if (error && error[Object.keys(error)[0]][0]) {
                error = error[Object.keys(error)[0]][0];
            } else {
                error = response.data.message;
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