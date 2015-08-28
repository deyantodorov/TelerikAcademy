(function () {
    'use strict';

    function countDivs()
    {
        var count;

        count = document.getElementsByTagName("div").length;
        console.log("Current page 'divs' are: " + count);
    }

    countDivs();
}());