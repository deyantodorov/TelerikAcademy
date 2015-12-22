(function () {
    'use strict';

    angular.module('myApp.filters')
        .filter('dateFilter', [dateFilter]);

    function dateFilter() {

        return function (input) {

            if (!input) {
                return 'no date';
            }

            var monthNames = [
                'January',
                'February',
                'March',
                'April',
                'May',
                'June',
                'July',
                'August',
                'September',
                'October',
                'November',
                'December'
            ];

            var date = new Date(input),
                day = date.getDate(),
                monthIndex = date.getMonth(),
                year = date.getFullYear(),
                hour = date.getHours(),
                minute = date.getMinutes(),
                second = date.getSeconds();

            return day + ' ' + monthNames[monthIndex] + ' ' + year + ' ' + hour + ':' + minute + ':' + second;
        }
    }
}());