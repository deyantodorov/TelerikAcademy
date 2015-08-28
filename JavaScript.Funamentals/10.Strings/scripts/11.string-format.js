(function (){
    'use strict';

    function stringFormat() {

        if (arguments[0].indexOf("{0}") > -1) {

            var arrOfArgs = [];

            for (var argument in arguments) {
                arrOfArgs.push(arguments[argument]);
            }

            var i, param, value, text, result;

            text = arguments[0];

            for (i = 1; i < arrOfArgs.length; i++) {

                param = "{" + (i - 1) + "}";
                value = arrOfArgs[i];

                result = text.replace(param, value);
                text = result;

                // repeat operation again if not everything is replaced
                if (text.indexOf(param) > -1) {
                    i--;
                }
            }

            return result;
        }
        else {
            return undefined;
        }
    }

    var str = stringFormat("Hello {0} {1}. Are {2} years old! ", "Peter", "Miller", 32);
    console.log(str)

    var format = "{0}, {1}, {0} text {2}";
    str = stringFormat(format, 1, "Pesho", "Gosho");
    console.log(str)

    format = "{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11} - {12} - {13} - {14} - {15} - {16} - {17} - {18} - {19} - {20} - {21} - {22} - {23} - {24} - {25} - {26} - {27} - {28} - {29}";
    str = stringFormat(format, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30);
    console.log(str);
}());