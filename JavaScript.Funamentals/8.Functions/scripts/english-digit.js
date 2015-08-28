(function () {
    'use strict';

    function lastDigit(value) {
        var last = value % 10;

        switch (last) {
            case 0:
                return 'zero';
            case 1:
                return 'one';
            case 2:
                return 'two';
            case 3:
                return 'three';
            case 4:
                return 'four';
            case 5:
                return 'five';
            case 6:
                return 'six';
            case 7:
                return 'seven';
            case 8:
                return 'eight';
            case 9:
                return 'nine';
            default:
                return undefined;
        }
    }

    var numbers,
        i;

    numbers = [512, 1024, 12309];

    for (i = 0; i < numbers.length; i += 1) {
        console.log('Last digit of ' + numbers[i] + ' is ' + lastDigit(numbers[i]))
    }
}());
