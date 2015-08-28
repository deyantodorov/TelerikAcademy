(function (){
    'use strict';

    var text = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
    // Result: <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

    function tag_A_replacer(yourText) {

        var openA = new RegExp("\<a href=\"", "gim");
        var endOpenA = new RegExp("\"\>", "gim");
        var closeA = new RegExp("</a>", "gim");

        var newText = yourText.replace(closeA, "[/URL]");
        newText = newText.replace(openA, "[URL=");
        newText = newText.replace(endOpenA, "]");

        return newText;
    }

    console.log(tag_A_replacer(text));
}());