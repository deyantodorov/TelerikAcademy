(function () {
    "use strict";

    var i,
        arr,
        counter,
        max,
        lastMaxIndex;

    arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

    console.log("Array: " + arr);

    arr.sort();

    counter = 1;
    max = 1;
    lastMaxIndex = 0;

    for (i = 1; i < arr.length; i++) {
        if (arr[i - 1] === arr[i]) {
            counter++;
        } else {
            counter = 1;
        }

        if (counter > max) {
            max = counter;
            lastMaxIndex = i;
        }
    }

    console.log("Number of equal elements: " + max);

    console.log("Elements: ");

    for (i = 0; i < max; i++) {
        console.log(arr[lastMaxIndex - i] + " ");
    }
}());