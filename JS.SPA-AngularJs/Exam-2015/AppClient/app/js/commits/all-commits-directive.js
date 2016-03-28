(function () {
    'use strict';

    angular.module('myApp.directives')
        .directive('allCommits', ['directivesPath', allCommits]);

    function allCommits(directivesPath) {
        return {
            restrict: 'A',
            templateUrl: directivesPath + 'all-commits-directive.html'
        }
    }
}());