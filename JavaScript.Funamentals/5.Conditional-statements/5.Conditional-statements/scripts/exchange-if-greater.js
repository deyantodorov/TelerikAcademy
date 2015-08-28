(function() {
    "use strict";

    var digits, i, temp;

    digits = [
        [5, 2],
        [3, 4],
        [5.5, 4.5],
    ];

    console.log("Initial values:");
    console.dir(digits);

    console.log("Changed values:");
    for (i = 0; i < digits.length; i++) {
        if (digits[i][0] > digits[i][1]) {
            temp = digits[i][0];
            digits[i][0] = digits[i][1];
            digits[i][1] = temp;
        }

        console.log(digits[i][0] + " " + digits[i][1]);
    }
}());
