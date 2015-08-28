(function (){
    'use strict';

    var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

    var count = text.match(/in/gi);

    console.log("");
    console.log("Text: " + text);
    console.log("");
    console.log("Count: " + count.length);
    console.log("Result: " + count);
}());