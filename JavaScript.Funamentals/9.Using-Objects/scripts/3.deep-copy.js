(function (){
    'use strict';

    // Deep copy implementation
    function deepCopy(obj) {

        // String, Number, Boolean
        if (null === obj || typeof obj !== "object") {
            return obj;
        }

        // Arrays
        if (obj instanceof Array) {
            var copy = [];
            for (var i = 0, len = obj.length; i < len; i++) {
                copy[i] = deepCopy(obj[i]);
            }

            return copy;
        }

        // Object
        if (obj instanceof Object) {
            var copy = {};
            for (var i in obj) {
                if (obj.hasOwnProperty(i)) {
                    copy[i] = deepCopy(obj[i]);
                }
            }

            return copy;
        }

        throw new Error("Unable to copy obj! Its type isn't supported!");
    }

    // Some tests about correct work
    var arr = new Array(5);

    for (var i = 0; i < arr.length; i++) {
        arr[i] = i * 5;
    }

    console.log("Source: " + arr);

    var arrCopy = deepCopy(arr);

    console.log("Copy: " + arrCopy);

    arrCopy[0] = 1000;

    console.log("Source after change of copy: " + arr);
    console.log("Changed copy: " + arrCopy);

    var a = 5;
    var b = deepCopy(a);

    console.log(a);
    console.log(b);
    b++;
    console.log(a);
    console.log(b);
}());