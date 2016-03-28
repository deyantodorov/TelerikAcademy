(function () {
    'use strict';

    angular.module('myApp.filters')
        .filter('gameState', [gameState]);

    function gameState() {
        return function (input) {

            switch (input) {
                case 0:
                    return 'Waiting for second player to join';
                case 1:
                    return 'First player turn';
                case 2:
                    return 'Second player turn';
                case 3:
                    return 'Won by first player';
                case 4:
                    return 'Won by second player';
                case 5:
                    return 'Draw';
                default:
                    return 'WaitingForSecondPlayer';
            }
        }
    }
}());