(function () {
    "use strict";
    var i, digit, digits;

    digits = [5, 701, 1732, 9703, 877, 777877, 9999799];

    for (i = 0; i < digits.length; i++) {
        digit = (digits[i] / 100) % 10;
        digit = Math.floor(digit);

        if (digit === 7) {
            console.log(digits[i] + " true");
        } else {
            console.log(digits[i] + " false");
        }
    }
}());