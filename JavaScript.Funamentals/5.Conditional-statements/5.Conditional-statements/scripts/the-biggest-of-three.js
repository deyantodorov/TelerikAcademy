(function() {
    "use strict";

    function bigestOfThree(a, b, c) {

        console.log('Numbers: a = ' + a + ', b = ' + b + ', c = ' + c);

        if (a > b) {
            if (a > c) {
                console.log(a);
            } else {
                console.log(c);
            }
        } else if (b > a) {
            if (b > c) {
                console.log(b);
            } else {
                console.log(c);
            }
        } else {
            console.log(c);
        }
    }

    var digits = [
        [5, 2, 2],
        [-2, -2, 1],
        [-2, 4, 3],
        [0, -2.5, 5],
        [-0.1, -0.5, -1.1]
    ];

    for (var i = 0; i < digits.length; i++) {
        bigestOfThree(digits[i][0], digits[i][1], digits[i][2]);
    }
}());
