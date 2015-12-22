(function () {
    'use strict';

    angular.module('myApp.filters')
        .filter('imgFilter', [imgFilter]);

    function imgFilter() {

        return function (input) {
            switch(input) {
                case 'MIT':
                    return 'mit.png';
                case 'Apache':
                    return 'apache.png';
                case 'GPL':
                    return 'gpl.png';
                case 'BSD':
                    return 'bsd.png';
                case 'Mozilla Public License':
                    return 'mozilla.jpeg';
            }
        }
    }
}());