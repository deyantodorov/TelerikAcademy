(function() {
    "use strict";

    function showSignOfProduct(a, b, c) {
        console.log('Numbers: a = ' + a + ', b = ' + b + ', c = ' + c);
        console.log('Result is ');
        if (a === 0 || b === 0 || c === 0) {
            console.log('0');
        } else {
            if (a < 0 && (b > 0 && c > 0)) {
                console.log("-");
            } else if (b < 0 && (a > 0 && c > 0)) {
                console.log("-");
            } else if (c < 0 && (a > 0 && b > 0)) {
                console.log("-");
            } else if (a > 0 && (b < 0 && c < 0)) {
                console.log("+");
            } else if (b > 0 && (a < 0 && c < 0)) {
                console.log("+");
            } else if (c > 0 && (a < 0 && b < 0)) {
                console.log("+");
            } else if (a > 0 && b > 0 && c > 0) {
                console.log("+");
            } else {
                console.log("-");
            }
        }
    }

    var digits = [
        [5, 2, 2],
        [-2, -2, 1],
        [-2, 4, 3],
        [0, -2.5, 4],
        [-1, -0.5, -5.1]
    ];

    for (var i = 0; i < digits.length; i++) {
    	showSignOfProduct(digits[i][0], digits[i][1], digits[i][2]);
    }
}());
