(function () {
    'use strict';

    angular.module('myApp.services', []);

    angular.module('myApp.directives', []);

    angular.module('myApp.filters', []);

    angular.module('myApp.controllers', ['myApp.services']);

    angular.module('myApp', [
        'ngRoute',
        'ngCookies',
        'kendo.directives',
        'myApp.controllers',
        'myApp.directives',
        'myApp.filters'
    ])
        .config([
            '$routeProvider',
            '$locationProvider',
            config
        ])
        .value('toastr', toastr)
        .constant('directivesPath', 'app/views/directives/')
        .constant('baseUrl', 'http://spa.bgcoder.com');

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
            .when('/projects', {
                templateUrl: PARTIALS_PATH + 'projects/all-projects.html',
                controller: 'ProjectsController',
                controllerAs: VIEW_MODEL
            })
            .when('/projects/add', {
                templateUrl: PARTIALS_PATH + 'projects/add-project.html',
                controller: 'AddProjectController',
                controllerAs: VIEW_MODEL
            })
            .when('/projects/:id', {
                templateUrl: PARTIALS_PATH + 'projects/project-details.html',
                controller: 'ProjectDetailsController',
                controllerAs: VIEW_MODEL
            })
            .when('/projects/:id/addcommits', {
                templateUrl: PARTIALS_PATH + 'projects/project-addcommits.html',
                controller: 'ProjectAddCommitsController',
                controllerAs: VIEW_MODEL
            })
            .when('/commits', {
                templateUrl: PARTIALS_PATH + 'commits/all-commits.html',
                controller: 'CommitsController',
                controllerAs: VIEW_MODEL
            })
            .when('/commits/:id', {
                templateUrl: PARTIALS_PATH + 'commits/commit-details.html',
                controller: 'CommitDetailsController',
                controllerAs: VIEW_MODEL
            })
            //.when('/trips', {
            //    templateUrl: PARTIALS_PATH + 'trips/all-trips.html',
            //    controller: 'TripsController',
            //    controllerAs: VIEW_MODEL
            //})
            //.when('/trips/create', {
            //    templateUrl: PARTIALS_PATH + 'trips/create-trip.html',
            //    controller: 'CreateTripController',
            //    controllerAs: VIEW_MODEL
            //})
            //.when('/trips/:id', {
            //    templateUrl: PARTIALS_PATH + 'trips/trip-details.html',
            //    controller: 'TripDetailsController',
            //    controllerAs: VIEW_MODEL
            //})
            //.when('/drivers', {
            //    templateUrl: PARTIALS_PATH + 'drivers/all-drivers.html',
            //    controller: 'DriversController',
            //    controllerAs: VIEW_MODEL
            //})
            //.when('/drivers/:id', {
            //    templateUrl: PARTIALS_PATH + 'drivers/driver-details.html',
            //    controller: 'DriverDetailsController',
            //    controllerAs: VIEW_MODEL
            //})
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