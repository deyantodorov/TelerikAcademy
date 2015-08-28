(function (){
    "use strict";

    var i,
        arr,
        counter,
        max,
        lastMaxIndex;

    arr = [3, 2, 3, 4, 2, 2, 4];
    counter = 1;
    max = 1;
    lastMaxIndex = 0;

    for (i = 0; i < arr.length - 1; i++) {
        if (arr[i] < arr[i + 1]) {
            counter++;
        } else {
            counter = 1;
        }

        if (counter > max) {
            max = counter;
            lastMaxIndex = i + 1;
        }
    }

    console.log("Array: " + arr);

    console.log("Number of elements: " + max);

    console.log("Elements: ");

    for (i = 0; i < max; i++) {
        console.log(arr[(lastMaxIndex - max) + i + 1] + " ");
    }
}());