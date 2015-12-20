(function () {
    'use strict';

    angular.module('myApp.services', []);
    
    angular.module('myApp.directives', []);
    
    angular.module('myApp.filters', []);

    angular.module('myApp.controllers', ['myApp.services']);
    
    angular.module('myApp', ['ngRoute', 'ngCookies', 'myApp.controllers', 'myApp.directives', 'myApp.filters'])
        .config(['$routeProvider', '$locationProvider', config])
        .value('toastr', toastr)
        .constant('directivesPath', 'app/views/directives/')
        .constant('baseServiceUrl', 'http://localhost:33257/');

    function config($routeProvider, $locationProvider) {
        var PARTIALS_PATH = 'app/views/partials/',
            VIEW_MODEL = 'vm';

        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                templateUrl: PARTIALS_PATH + 'home/home.html',
                controller: 'HomeController',
                controllerAs: VIEW_MODEL
            })
            .when('/games', {
                templateUrl: PARTIALS_PATH + 'games/all-games.html',
                controller: 'GamesController',
                controllerAs: VIEW_MODEL
            })
            .when('/games/:gameId', {
                templateUrl: PARTIALS_PATH + 'games/play-game.html',
                controller: 'GamePlayController',
                controllerAs: VIEW_MODEL
            })
            .when('/unauthorized', {
                templateUrl: PARTIALS_PATH + 'common/unauthorized.html'
            })
            .when('/register', {
                templateUrl: PARTIALS_PATH + 'identity/register.html',
                controller: 'RegisterController'
            })
            .otherwise({ redirectTo: '/' });
    }
}());