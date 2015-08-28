(function (){
    'use strict';

    function textExtractor(yourText) {

        // match html tags to be removed in replace function
        var regExp = new RegExp("<[^>]*>", "gim");

        // replace matched tags with blank space
        var newText = yourText.replace(regExp, "");

        return newText;
    }

    var text = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
    var text2 = "<div class='newsPost'><h1>Софтуерна академия</h1><p>Запишете се за нашите онлайн курсове с безплатен достъп до всички материали и видео уроци. Станете .NET нинджа!</p></div>"

    console.log(textExtractor(text));
    console.log(textExtractor(text2));
}());