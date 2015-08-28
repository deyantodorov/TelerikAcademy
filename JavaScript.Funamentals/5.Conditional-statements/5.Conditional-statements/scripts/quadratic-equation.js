(function() {
    "use strict";

    function quadraticEquations(a, b, c) {
        var d = (b * b) - (4 * a * c);

        if (a == 0) {
            console.log("There is only one real root: {0}", -(c / b));
        } else if (a > 0 && d >= 0) {
            if (d > 0) {
                var x1 = (-b + Math.sqrt(d)) / 2 * a;
                var x2 = (-b - Math.sqrt(d)) / 2 * a;
                console.log("x1 = " + x1);
                console.log("x2 = " + x2);
            } else {
                var x1 = (-b + Math.sqrt(d)) / 2 * a;
                console.log("Both roots x1 and x2 = " + x1);
            }
        } else {
            console.log("There are no real roots");
        }
    }

    var digits = [
        [2, 5, -3],
        [-1, 3, 0],
        [-0.5, 4, -8],
        [5, 2, 8]
    ];

    for (var i = 0; i < digits.length; i++) {
        quadraticEquations(digits[i][0], digits[i][1], digits[i][2]);
    }
}());
