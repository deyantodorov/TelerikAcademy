(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('CommitDetailsController',
        [
            '$routeParams', 
            '$location', 
            'identity', 
            'commits', 
            CommitDetailsController
        ]);

    function CommitDetailsController($routeParams, $location, identity, commits) {
        var vm = this;

        if (!identity.isAuthenticated()) {
            return $location.path('/unauthorized');
        }

        vm.id = $routeParams.id;

        commits.getCommit(vm.id)
            .then(function (response) {
                //console.log(response);
                vm.commit = response;
            });
    }
}());