(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('ProjectsController',
        [
            'identity',
            'projects',
            ProjectsController
        ]);

    function ProjectsController(identity, projects) {
        var vm = this;

        vm.identity = identity;
        vm.request = {
            Page: 1
        };

        projects.getPublicProjects()
            .then(function (publicProjects) {
                //console.log(publicProjects);
                vm.projects = publicProjects;
            });

        vm.filterProjects = function () {
            //console.log(vm.request);
            projects.filterProjects(vm.request)
            .then(function (filteredProjects) {
                //console.log(filteredProjects);
                vm.projects = filteredProjects;
            });
        }

        vm.prevPage = function () {
            if (vm.request.Page === 1) {
                return;
            }

            vm.request.Page--;
            vm.filterProjects();
        }

        vm.nextPage = function () {
            vm.request.Page++;
            vm.filterProjects();
        }
    }
}());