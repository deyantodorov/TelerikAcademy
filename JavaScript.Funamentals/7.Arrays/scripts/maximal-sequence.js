(function (){
    "use strict";

    var arr,
        i,
        counter,
        max,
        lastMaxIndex;

    arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1 ];
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

    console.log("Array: " + arr);
    console.log("Number of equal elements: " + max);
    console.log("Elements: ");
    for (i = 0; i < max; i++) {
        console.log(arr[lastMaxIndex - i] + " ");
    }
}());