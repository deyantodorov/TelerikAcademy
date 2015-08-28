(function () {
    "use strict";

    var number;
    var i;
    var bit;

    number = [5, 8, 0, 15, 5343, 62241];

    for(i = 0; i < number.length; i++) {
        bit = (number[i] >> 2) & 1;

        console.log('Third bit is: ' + bit);
        console.log('Number ' + number[i] + ' as binary is: ' + number[i].toString(2) + '\n');
    }
}());