(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('GamePlayController', ['$location', '$interval', '$routeParams', 'identity', 'notifier', 'games', GamePlayController]);

    function GamePlayController($location, $interval, $routeParams, identity, notifier, games) {
        var vm = this;

        vm.gameId = $routeParams.gameId;

        if (!identity.isAuthenticated()) {
            $location.path('/unauthorized');
        }

        function status() {
            // Check whether the user has changed the route in order to stop refreshing the status of the current game
            if (!vm.gameId || $location.path() !== '/games/' + vm.gameId) {
                return;
            }

            games.status(vm.gameId).then(function (gameInfo) {
                vm.game = gameInfo;
            }, function (error) {
                notifier.error(error.Message);
            });
        }

        $interval(status, 1000);

        vm.play = function (row, index) {
            var col = (index % 3) + 1;

            games.play({ GameId: vm.gameId, Row: row, Col: col })
                .then(function () {
                    notifier.success('Successful turn.');
                }, function (error) {
                    notifier.error(error.Message);
                });
        }
    }

}());