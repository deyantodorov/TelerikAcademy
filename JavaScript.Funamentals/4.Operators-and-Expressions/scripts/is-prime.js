(function () {
    "use strict";

    function isPrime(number) {

        if ((number & 1) == 0) {
            if (number == 2) {
                return true;
            }
            else {
                return false;
            }
        } else if (number < 1) {
            return false;
        }

        for(var i = 3; (i * i) <= number; i += 2) {
            if ((number % i) == 0) {
                return false;
            }
        }

        return number != 1;
    }

    var numbers = [1, 2, 3, 4, 9, 37, 97, 51, -3, 0];
    var i;

    for(i = 0; i < numbers.length; i++) {
        if (isPrime(numbers[i])) {
            console.log("True. Number " + numbers[i] + " is prime");
        } else {
            console.log("False. Number " + numbers[i] + " is not prime");
        }
    }
}());