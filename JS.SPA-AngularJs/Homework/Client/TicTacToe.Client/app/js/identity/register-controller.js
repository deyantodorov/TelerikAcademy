(function () {
    'use strict';

    angular.module('myApp.controllers')
        .controller('RegisterController', ['$scope', '$location', 'auth', 'notifier', RegisterController]);

    function RegisterController($scope, $location, auth, notifier) {
        $scope.register = function (user) {
            //console.log(user);
            auth.register(user)
                .then(function () {
                    notifier.success('Registration successful!');
                    $location.path('/');
                }, function (error) {
                    notifier.error(error);
                });
        }
    }
}());