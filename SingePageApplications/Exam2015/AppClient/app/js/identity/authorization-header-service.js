(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('authorizationHeader', ['identity', authorizationHeader]);

    function authorizationHeader(identity) {
        return {
            getAuthorizationHeader: function () {

                if (!identity.isAuthenticated()) {
                    return {};
                }

                return {
                    'Authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                }
            }
        }
    }
}());