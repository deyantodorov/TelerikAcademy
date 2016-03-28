(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('AddProjectController',
        [
            '$location',
            'identity',
            'projects', 
            'licenses', 
            AddProjectController
        ]);

    function AddProjectController($location, identity, projects, licenses) {
        var vm = this;

        if (!identity.isAuthenticated()) {
            return $location.path('/unauthorized');
        }

        licenses.getAll()
            .then(function (result) {
                vm.licenses = result;
            });

        vm.addProject = function (project) {
            //console.log(project);
            projects.addProject(project)
            .then(function (addedProjectId) {
                //console.log(addedProject);
                $location.path('/projects/' + addedProjectId);
            });
        }
    }
}());