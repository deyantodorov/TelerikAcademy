(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('MainController',
        [
            MainController
        ]);

    function MainController() {
        var vm = this;
        vm.appName = 'Source Control System';
    }
}())