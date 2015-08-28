(function () {
    "use strict";

    var arr = [1, 84, 1, 54, 95, 64, 71, 92, 48, 15, 36, 72, 84, 50, 90, 88, 32, 37, 43, 4, 81, 8, 91, 41, 6, 1, 74, 64, 37, 38];
    arr.sort();

    var search = 50;

    function binarySearch(array, key, min, max) {

        var mid;

        while (max >= min) {
            mid = min + (((max - min) / 2) | 0);

            if (array[mid] === key) {
                return mid;
            } else if (array[mid] < key) {
                min = mid + 1;
            } else {
                max = mid - 1;
            }
        }

        return -1;
    }

    console.log("Array: " + arr);
    console.log("Searching for: " + search);

    var result = binarySearch(arr, search, 0, arr.length - 1);
    if (result === -1) {
        console.log("Index not found");
    } else {
        console.log("Result is at index: " + result);
    }
}());