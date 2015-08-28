(function (){
    'use strict';

    function insertSpace(text) {
        var result = "";

        for (var i = 0; i < text.length - 2; i++) {
            if (text[i] === " " && text[i + 1] === " ") {
                result += "&nbsp;"
            }
            else {
                result += text[i];
            }
        }

        return result;
    }

    var text = " Write a function                 that replaces                            non breaking white-spaces in a text with                              ";

    var newText = insertSpace(text);

    console.log(newText);
}());