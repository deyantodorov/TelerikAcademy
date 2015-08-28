"use strict";

var arr;

arr = [3, 2, -2, -1, 0];

for (var i = 0; i < arr.length; i++) {
    if (arr[i] % 2 == 0) {
        console.log(arr[i] + " " + "false")
    } else {
        console.log(arr[i] + " " + "true");
    }
}