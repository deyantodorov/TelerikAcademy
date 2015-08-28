(function() {
    "use strict";

    function sort3numbers(a, b, c) {

        var big, middle, small;

        console.log('Default values a = ' + a + ', b = ' + b + ', c = ' + c);

        if (a > b) {
            if (a > c && c > b) {
                big = a;
                middle = c;
                small = b;
            } else if (a > c && c < b) {
                big = a;
                middle = b;
                small = c;
            } else if (a > c && c == b) {
                big = a;
                middle = b;
                small = c;
            } else {
                big = c;
                middle = a;
                small = b;
            }
        }

        if (b > a) {
            if (b > c && c > a) {
                big = b;
                middle = c;
                small = a;
            } else if (b > c && c < a) {
                big = b;
                middle = a;
                small = c;
            } else if (b > c && c == a) {
                big = b;
                middle = c;
                small = a;
            } else {
                big = c;
                middle = b;
                small = a;
            }
        }

        if (c > b) {
            if (c > a && a > b) {
                big = c;
                middle = a;
                small = b;
            } else if (c > a && a < b) {
                big = c;
                middle = b;
                small = a;
            } else if (c > a && a == b) {
                big = c;
                middle = a;
                small = b;
            }
        } else if (a == b && a == c) {
            big = a;
            middle = b;
            small = c;
        }

        a = big;
        b = middle;
        c = small;

        console.log('Sorted values a = ' + a + ', b = ' + b + ', c = ' + c);
    }

    var digits = [
        [5, 1, 2],
        [-2, -2, 1],
        [-2, 4, 3],
        [0, -2.5, 5],
        [-1.1, -0.5, -0.1],
        [10, 20, 30],
        [1, 1, 1],
    ];

    for (var i = 0; i < digits.length; i++) {
        sort3numbers(digits[i][0], digits[i][1], digits[i][2]);
    }
}());
