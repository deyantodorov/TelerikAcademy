(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('GamesController', ['$location', 'games', 'identity', 'notifier', GamesController]);

    function GamesController($location, games, identity, notifier) {
        var vm = this;
        vm.identity = identity;

        vm.createGame = function () {
            games.create()
                .then(function (response) {
                    notifier.success('Game successfully created.');
                    vm.gameId = response;
                    $location.path('/games/' + vm.gameId);
                }, function (err) {
                    notifier.error(err.Message);
                });
        }

        games.listGames()
            .then(function (listedGames) {
                vm.games = listedGames;
            });

        vm.joinGame = function (gameId) {
            games.join(gameId)
                .then(function (response) {
                    notifier.success('Game successfully joined.');
                    vm.gameId = response;
                    $location.path('/games/' + vm.gameId);
                }, function (err) {
                    notifier.error(err.Message);
                });
        }
    }
}());