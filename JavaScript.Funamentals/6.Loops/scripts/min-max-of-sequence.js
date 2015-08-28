(function () {
    "use strict";

    // Generate random array
    var r;
    var a;
    var i;

    r = Math.floor(Math.random() * 50);
    a = [1];

    for (i = 1; i < r; i++) {
        a[i] = i * Math.floor(Math.random() * 3);
    }

    // Print result
    console.log('From numbers: ' + a);
    console.log('Max is: ' + Math.max.apply(null, a));
    console.log('Min is: ' + Math.min.apply(null, a));
}());