(function (){
    'use strict';

    function extractEmails(text) {

        var arr = text.match(/([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})/gim);

        return arr;
    }

    var text = "Lorem pesho_peshev@vsgb.bg Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled misho_pishev@agb.bg it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, rambo@abv.bs.bg.co remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum pipi@yahoo.co.uk.";

    console.log("Text: " + text);
    console.log("");
    console.log("Emails: " + extractEmails(text));
}());