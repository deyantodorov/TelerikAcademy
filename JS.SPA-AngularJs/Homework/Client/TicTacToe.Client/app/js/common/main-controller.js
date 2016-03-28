(function () {
    'use strict';

    function MainController($scope) {
        $scope.appName = 'Tic Tac Toe Game';
    }

    angular.module('myApp.controllers')
        .controller('MainController', ['$scope', MainController]);
}())