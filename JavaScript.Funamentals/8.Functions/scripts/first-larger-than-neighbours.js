(function () {
    'use strict';

    var arr = [2, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2];

    // Return 1 for true, -1 for not true
    function isBigger(a) {

        if (a.length > 0) {

            for (var i = 1; i < a.length; i++) {

                if (a[i - 1] > a[i]) {
                    return i - 1;
                }
            }
        }

        return -1;
    }

    console.log(arr)
    console.log("Is bigger: " + isBigger(arr));
}());