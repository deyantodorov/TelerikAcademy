(function () {
    'use strict';

    var arr = [4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2];

    function countNumber(a, num) {

        var count = 0;

        for (var i = 0; i < a.length; i++) {
            if (a[i] === num) {
                count++;
            }
        }

        return count;
    }

    console.log(arr)
    console.log("Number 5 is found " + countNumber(arr, 5) + " time");
}());