(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('HomeController',
        [
            'statistics',
            'projects',
            'commits',
            HomeController
        ]);

    function HomeController(statistics, projects, commits) {
        var vm = this;

        statistics.getStats()
            .then(function (stats) {
                //console.log(stats);
                vm.stats = stats;
            });

        projects.getPublicProjects()
            .then(function (publicProjects) {
                //console.log(publicProjects);
                vm.projects = publicProjects;
            });

        commits.getPublicCommits()
            .then(function (publicCommits) {
                //console.log(publicCommits);
                vm.commits = publicCommits;
            });
    }
}());