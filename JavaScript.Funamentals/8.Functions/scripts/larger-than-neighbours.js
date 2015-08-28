(function () {
    'use strict';

    var arr = [4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2];

    // Return 1 for true, -1 for not true
    function isBigger(a, pos) {

        if (a.length > 0) {

            if (pos === a.length - 2 && a[pos] > a[pos - 1]) {
                return 1;
            }

            if (pos === 0 && a[pos] > a[pos + 1]) {
                return 1;
            }

            if (a[pos] > a[pos - 1] && a[pos] > a[pos + 1]) {
                return 1;
            }
        }

        return -1;
    }

    console.log(arr);
    console.log("Is bigger: " + isBigger(arr, 0));
}());