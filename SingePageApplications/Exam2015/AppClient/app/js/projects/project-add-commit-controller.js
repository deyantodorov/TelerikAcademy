(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('ProjectAddCommitsController',
        [
            '$routeParams', 
            '$location', 
            'identity', 
            'projects',
            'commits',
            'notifier', 
            ProjectAddCommitsController
         ]);

    function ProjectAddCommitsController($routeParams, $location, identity, projects, commits, notifier) {
        var vm = this;

        if (!identity.isAuthenticated()) {
            return $location.path('/unauthorized');
        }

        vm.id = $routeParams.id;
       
        vm.addCommit = function (commit) {
            commit.ProjectId = vm.id;
            //console.log(commit);
            commits.createCommit(commit)
                .then(function (response) {
                    notifier.success('Commit added!');
                    //console.log(response);
                    $location.path('/projects/' + vm.id);
                });
        }
    }
}());