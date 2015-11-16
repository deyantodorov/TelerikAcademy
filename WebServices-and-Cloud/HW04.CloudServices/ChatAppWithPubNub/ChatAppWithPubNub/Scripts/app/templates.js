var templates = function () {
    'use strict';

    var handlebars = window.handlebars || window.Handlebars,
        Handlebars = window.handlebars || window.Handlebars,
        cache = {};

    function get(name) {
        var promise = new Promise(function (resolve, reject) {
            //if (cache[name]) {
            //    resolve(cache[name]);
            //    return;
            //}
            var url = '/Scripts/app/templates/' + name + '.handlebars';
            $.get(url, function (html) {
                var template = handlebars.compile(html);
                cache[name] = template;
                resolve(template);
            }).then(function(res){
                reject(res);
            });
        });
        return promise;
    }

    return {
        get: get
    };
}();