(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('licenses', 
        [
            'data', 
            licenses
        ]);

    function licenses(data) {

        function getAll() {
            return data.get('api/licenses');
        }

        return {
            getAll: getAll
        }
    }
}());