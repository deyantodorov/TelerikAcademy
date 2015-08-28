(function() {
    "use strict";

    function biggestOfFive(a, b, c, d, e) {
        var biggest = a;

        if (b > biggest) {
            biggest = b;
        } else if (c > biggest) {
            biggest = c;
        } else if (d > biggest) {
            biggest = d;
        } else if (e > biggest) {
            biggest = e;
        }

        return biggest;
    }

    var digits = [
        [5, 2, 2, 4, 1],
        [-2, -22, 1, 0, 0],
        [-2, 4, 3, 2, 0],
        [0, -2.5, 0, 5, 5],
        [-3, -0.5, -1.1, -2, -0.1]
    ];

    for (var i = 0; i < digits.length; i++) {
        var biggest = biggestOfFive(digits[i][0], digits[i][1], digits[i][2], digits[i][3], digits[i][4]);
        console.info("Here: " + digits[i]);
        console.info("Biggest is: " + biggest);
    }
}());
