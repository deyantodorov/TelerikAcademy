(function (){
    "use strict";

    var arr,
        i;

    arr = new Array(20);

    for (i = 0; i < arr.length; i++) {
        arr[i] = i * 5;
    }

    console.log(arr);
}());