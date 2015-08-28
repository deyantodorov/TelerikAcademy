(function (){
    'use strict';

    function findPalindroms(text) {

        // Help function for palindrom words match
        function isPalindrom(word) {

            var wordRevesed = word.split("").reverse().join("");

            if (wordRevesed === word) {
                return true;
            }

            return false;
        }

        // RegeExp mach for: ' ', '.', ',', '!', '?'
        var pattern = /\s|\,|\.|\,\s|\!\?/;

        var words = text.split(pattern);

        var palindroms = [];

        for (var i = 0, len = words.length; i < len; i++) {

            // Skip single letters
            if (words[i].length > 1) {

                if (isPalindrom(words[i])) {
                    palindroms.push(words[i]);
                }
            }
        }

        return palindroms;
    }

    var text = "Lorem Ipsum is lamal simply dummy bob text of the printing rur and typesetting industry. Lorem Ipsum sos has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a ABBA galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but lamal also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in ABBA the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software exe like Aldus PageMaker including versions of Lorem Ipsum exe";
    var palindrom = findPalindroms(text);

    console.log("Text: " + text)
    console.log("Number of palindroms: " + palindrom.length)
    console.log(palindrom)
}());