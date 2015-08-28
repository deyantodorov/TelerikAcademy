(function () {
    "use strict";
    
    function convertNumberToText(number) {
        var words = "";
        number = parseInt(number);
        
        if (number == 0) {
            return "zero";
        }

        if (Math.floor(number / 1000000) > 0) {
            words += convertNumberToText(Math.floor(number / 1000000)) + " million ";
            number %= 1000000;
        }
        
        if (Math.floor(number / 1000) > 0) {
            words += convertNumberToText(Math.floor(number / 1000)) + " thousand ";
            number %= 1000;
        }
        
        if (Math.floor(number / 100) > 0) {
            words += convertNumberToText(Math.floor(number / 100)) + " hundred ";
            number %= 100;
        }
        
        if (Math.floor(number) > 0) {
            if (words != "") {
                words += "and ";
            }
            
            var zeroToNineteen = [ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"];
            var zeroToNinety = [ "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];
            
            if (number < 20) {
                words += zeroToNineteen[number];
            }
            else {
                words += zeroToNinety[Math.floor(number / 10)];
                if (number % 10 > 0) {
                    words += " " + zeroToNineteen[number % 10];
                }
            }
        }

        return words;
    }
    
    var digits = [0, 9, 10, 12, 19, 25, 98, 98, 273, 400, 501, 617, 711, 999];
    
     for (var i = 0; i < digits.length; i++) {
         console.info(digits[i] + " " + convertNumberToText(digits[i]));
     }
}());