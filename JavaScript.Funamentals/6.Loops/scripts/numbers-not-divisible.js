(function () {
    "use strict";

    var n, i;

    n = 100;

    for (i = 0; i <= n; i += 1) {
        if (!(i % 7 === 0 && i % 3 === 0)) {
            console.log(i);
        }
    }
}());