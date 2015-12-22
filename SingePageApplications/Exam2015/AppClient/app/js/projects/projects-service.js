(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('projects', ['data', projects]);

    function projects(data) {

        var PROJECTS_URL = 'api/projects';

        function getPublicProjects() {
            return data.get(PROJECTS_URL);
        }

        function addProject(newProject) {
            return data.post(PROJECTS_URL, newProject);
        }

        function filterProjects(filters) {
            //console.log(filters);
            return data.get(PROJECTS_URL + '/all', filters);
        }

        function getProject(id) {
            return data.get(PROJECTS_URL + '/' + id);
        }

        function addCollaborator(id, collaborator) {
            return data.put(PROJECTS_URL + '/' + id, collaborator);
        }

        function getCollaborators(id) {
            return data.get(PROJECTS_URL + '/collaborators/' + id);
        }

        return {
            getPublicProjects: getPublicProjects,
            addProject: addProject,
            filterProjects: filterProjects,
            getProject: getProject,
            addCollaborator: addCollaborator,
            getCollaborators: getCollaborators
        }
    }
}());