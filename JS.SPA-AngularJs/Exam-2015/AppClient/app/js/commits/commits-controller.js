(function() {
    'use strict';

    angular.module('myApp.controllers')
        .controller('CommitsController',
        [
            'identity',
            'commits',
            CommitsController
        ]);

    function CommitsController(identity, commits) {
        var vm = this;

        vm.identity = identity;

        commits.getPublicCommits()
            .then(function (publicCommits) {
                //console.log(publicCommits);
                vm.commits = publicCommits;
            });
    }
}());