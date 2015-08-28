(function (){
    'use strict';

    function doMix(text) {

        var startIndex = text.indexOf("<mixcase>");

        while (startIndex > -1) {

            var textInside = text.substring(startIndex + 9, text.indexOf("</mixcase>", startIndex));
            var textToMix = new String(textInside);

            for (var i = 0; i < textToMix.length; i++) {
                if (i % 2 === 0) {
                    textToMix = textToMix.replace(textToMix[i], textToMix[i].toUpperCase());
                } else {
                    textToMix = textToMix.replace(textToMix[i], textToMix[i].toLowerCase());
                }
            }

            text = text.replace(textInside, textToMix);
            startIndex = text.indexOf("<mixcase>", startIndex + 1);
        }

        return text;
    }

    function doUp(text) {

        var startIndex = text.indexOf("<upcase>");

        while (startIndex > -1) {

            var textInside = text.substring(startIndex + 8, text.indexOf("</upcase>", startIndex));
            var textToUp = textInside.toUpperCase();
            text = text.replace(textInside, textToUp);
            startIndex = text.indexOf("<upcase>", startIndex + 1);
        }

        return text;
    }

    function doLow(text) {
        var startIndex = text.indexOf("<lowcase>");

        while (startIndex > -1) {

            var textInside = text.substring(startIndex + 9, text.indexOf("</lowcase>", startIndex));
            var textToLow = textInside.toLowerCase();
            text = text.replace(textInside, textToLow);
            startIndex = text.indexOf("<lowcase>", startIndex + 1);
        }

        return text;
    }

    var text = "We are <mixcase>li  <upcase>yellow submarine</upcase>   ving</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

    text = doUp(text);
    text = doLow(text);
    text = doMix(text);

    console.log(text);
}());