(function () {
    'use strict';

    function wordCounter(text, word, isCaseSensitive) {

        switch (arguments.length) {
            case 2:
                return wordCountSensitive(text, word);
            case 3:
                return isCaseSensitive ? wordCountSensitive(text, word) : wordCountInsensitive(text, word);
            default:
                return undefined;
        }

        function wordCountSensitive(text, word) {
            var arr,
                counter,
                i;

            arr = text.split(" ");
            counter = 0;

            for (i = 0; i < arr.length; i += 1) {
                if (word === arr[i]) {
                    counter++;
                }
            }

            return counter;
        }

        function wordCountInsensitive(text, word) {
            var input,
                search,
                arr,
                counter,
                i;

            input = text.toLowerCase();
            search = word.toLowerCase();

            arr = input.split(" ");
            counter = 0;

            for (i = 0; i < arr.length; i += 1) {
                if (search === arr[i]) {
                    counter++;
                }
            }

            return counter;
        }
    }

    var text = "Lorem ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

    console.log("Text:  " + text)
    console.log("Found 'ipsum' : " + wordCounter(text, "ipsum", false));
    console.log("Found 'Ipsum' : " + wordCounter(text, "Ipsum", true));

    console.log("Found 'It' (defualt is case sensitive) : " + wordCounter(text, "It"));
}());