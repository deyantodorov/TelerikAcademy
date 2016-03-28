(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('statistics', ['$q', 'data', statistics]);

    function statistics($q, data) {

        var cachedStats;

        function getStats() {
            if (cachedStats) {
                return $q.when(cachedStats);
            } else {
                return data.get('api/statistics')
                    .then(function (stats) {
                        cachedStats = stats;
                        return stats;
                    });
            }
        }

        return {
            getStats: getStats
        }
    }
}());