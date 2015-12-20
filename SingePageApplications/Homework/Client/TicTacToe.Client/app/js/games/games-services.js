(function () {
    'use strict';

    angular.module('myApp.services')
        .factory('games', ['$http', '$q', 'data', games]);

    function games($http, $q, data) {

        var GAMES_PATH = 'api/games/';

        function listGames() {
            return data.get(GAMES_PATH + 'listGames');
        }

        function create() {
            return data.post(GAMES_PATH + 'create');
        }

        function join(gameId) {
            return data.post(GAMES_PATH + 'join/' + gameId);
        }

        function status(gameId) {
            return data.get(GAMES_PATH + 'status/' + gameId);
        }

        function play(gameDetails) {
            return data.post(GAMES_PATH + 'play', gameDetails);
        }

        return {
            listGames: listGames,
            create: create,
            join: join,
            status: status,
            play: play
        }
    }
}());