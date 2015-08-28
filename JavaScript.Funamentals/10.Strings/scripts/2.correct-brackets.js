(function () {
    'use strict';

    function checkBrackets(str) {
        var brackets = 0;

        for (var i = 0, len = str.length; i < len; i++) {
            if (str[i] === "(") {
                brackets++;
            } else if (str[i] === ")") {
                brackets--;
            }
        }

        if (brackets === 0) {
            return true;
        } else {
            return false;
        }
    }

    var equation = "((a+b)/5-d)";
    var equation2 = ")(a+b))";

    console.log(equation + " is correct: " + checkBrackets(equation));
    console.log(equation2 + " is correct: " + checkBrackets(equation2));
}());