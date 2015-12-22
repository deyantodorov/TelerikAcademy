(function() {
    'use strict';

    angular.module('myApp.services')
        .factory('commits', ['data', commits]);

    function commits(data) {

        var COMMITS_URL = 'api/commits';

        function getPublicCommits() {
            return data.get(COMMITS_URL);
        }

        function createCommit(newCommit) {
            return data.post(COMMITS_URL, newCommit);
        }

        function getCommit(id) {
            return data.get(COMMITS_URL + '/' + id);
        }
        
        function getCommitsByProject(id, filters) {
            return data.get(COMMITS_URL + '/byproject/' + id, filters);
        }

        return {
            getPublicCommits: getPublicCommits,
            createCommit: createCommit,
            getCommit: getCommit,
            getCommitsByProject: getCommitsByProject
        }
    }
}());