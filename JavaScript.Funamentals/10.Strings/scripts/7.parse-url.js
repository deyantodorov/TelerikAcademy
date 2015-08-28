(function (){
    'use strict';

    var url = "https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/push";

    function parseUrlToJSON(url) {

        var protocol = url.substring(0, url.indexOf(":"));

        url = url.substring(protocol.length + 3);

        var server = url.substring(0, url.indexOf("/"));

        url = url.substring(server.length + 1);

        var resource = "/" + url;

        var url_to_JSON = {
            protocol: protocol,
            server: server,
            resource: resource,
        };

        return url_to_JSON
    }

    var urlToJSON = parseUrlToJSON(url);

    console.log('URL ' + url);
    console.dir("JSON values: " + urlToJSON);
    console.log(urlToJSON.protocol);
    console.log(urlToJSON.server);
    console.log(urlToJSON.resource);
}());