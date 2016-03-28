(function () {
    'use strict';

    angular.module('myApp.directives')
        .directive('allProjects', 
        [
            'directivesPath', 
            allProjects
        ]);

    function allProjects(directivesPath) {
        return {
            restrict: 'A',
            templateUrl: directivesPath + 'all-projects-directive.html'
        }
    }
}());