(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController',
        [
            '$routeParams',
            '$location',
            'identity',
            'projects',
            'commits',
            'notifier',
            'validator',
            ProjectDetailsController
        ]);

    function ProjectDetailsController($routeParams, $location, identity, projects, commits, notifier, validator) {
        var vm = this;

        if (!identity.isAuthenticated()) {
            return $location.path('/unauthorized');
        }

        vm.request = {
            Page: 1
        };

        vm.identity = identity;
        vm.id = $routeParams.id;

        projects.getProject(vm.id)
            .then(function (projectData) {
                //console.log(projectData);
                vm.project = projectData;
            });

        commits.getCommitsByProject(vm.id)
            .then(function (commitsData) {
                //console.log(commitsData);
                vm.commits = commitsData;
            });

        vm.filterCommits = function () {
            //console.log(vm.request);
            commits.getCommitsByProject(vm.id, vm.request)
            .then(function (filteredCommits) {
                //console.log(filteredProjects);
                vm.commits = filteredCommits;
            });
        }

        vm.prevPage = function () {
            if (vm.request.Page === 1) {
                return;
            }

            vm.request.Page--;
            vm.filterCommits();
        }

        vm.nextPage = function () {
            if (vm.commits.length === 0) {
                return;
            }

            vm.request.Page++;
            vm.filterCommits();
        }

        projects.getCollaborators(vm.id)
            .then(function (collaborators) {
                //console.log(collaborators);
                vm.collaborators = collaborators;
                vm.isCollaborator = isCollaborator(collaborators);
            });

        vm.addCollaborator = function (collaborator) {
            if (!validator.forEmail(collaborator)) {
                return notifier.error('Invalid email address');
            }

            var data = '"' + collaborator + '"';

            projects.addCollaborator(vm.id, data)
                .then(function () {
                    notifier.success('Collaborator added successfully');

                    // TODO: refactor
                    projects.getCollaborators(vm.id)
                        .then(function (collaborators) {
                            //console.log(collaborators);
                            vm.collaborators = collaborators;
                            vm.isCollaborator = isCollaborator(collaborators);
                        });
                });
        }

        function isCollaborator(users) {
            var i,
                len = users.length,
                currentUser = identity.getCurrentUser()['userName'];

            for (i = 0; i < len; i++) {
                var user = users[i];
                if (user === currentUser) {
                    return true;
                }
            }

            return false;
        }
    }
}());