(function () {
    "use strict";

    var input = parseInt(prompt('Enter value from 0 to 9', 0));
        var msg;

        switch (input) {
            case 0: msg = 'zero'; break;
            case 1: msg = 'one'; break;
            case 2: msg = 'two'; break;
            case 3: msg = 'three'; break;
            case 4: msg = 'four'; break;
            case 5: msg = 'five'; break;
            case 6: msg = 'six'; break;
            case 7: msg = 'seven'; break;
            case 8: msg = 'eight'; break;
            case 9: msg = 'nine'; break;
            default: msg = 'No such value'; break;
        }

        var doc = document.getElementById('result');
        console.log(msg);
        doc.style.fontWeight = "900";
        doc.innerHTML = msg;
}());
