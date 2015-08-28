"use strict";

var arr;

arr = [3, 0, 5, 7, 35, 140];

for (var i = 0; i < arr.length; i++) {
    if (arr[i] % 7 == 0 && arr[i] % 5 == 0) {
        console.log(arr[i] + " " + "true")
    } else {
        console.log(arr[i] + " " + "false");
    }
}