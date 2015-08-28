(function () {
    'use strict';

    function reverseDigit(value) {
        var result = (value + '').split('');

        result.reverse();
        result = result.join('');

        return result;
    }

    var numbers,
        i;
    numbers = [256, 123.45];

    for (i = 0; i < numbers.length; i += 1) {
        console.log("Num is: " + numbers[i])
        console.log("Reversed is: " + reverseDigit(numbers[i]));
    }
}());