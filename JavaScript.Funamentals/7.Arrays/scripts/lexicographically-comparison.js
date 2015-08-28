(function (){
    "use strict";

    var arr1 = new Array("a", "b", "c", "d");
    var arr2 = new Array("e", "f", "g", "h");

    var str1 = arr1.join("");
    var str2 = arr2.join("");

    var result = str1.localeCompare(str2);

    if (result === -1) {
        console.log(str1 + " > " + str2);
    } else if (result > 0) {
        console.log(str1 + " < " + str2);
    } else {
        console.log(str1 + " == " + str2);
    }
}());