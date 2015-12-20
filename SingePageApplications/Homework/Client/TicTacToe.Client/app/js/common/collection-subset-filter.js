(function () {
    'use strict';

    angular.module('myApp.filters')
        .filter('collectionSubset', [collectionSubset]);

    function collectionSubset() {
        return function (input, startIndex, endIndex) {
            if (input) {
                return input.slice(+startIndex, endIndex+1);
            }

            return [];
        }
    }
}());