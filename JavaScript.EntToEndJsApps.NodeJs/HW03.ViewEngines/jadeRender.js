var VIEWS_PATH = './views/';

var jade = require('jade'),
    fs = require('fs'),
    path = require('path');

function render(filePath, model, callback, isPretty) {
    fs.readFile(VIEWS_PATH + filePath, 'utf8', function (err, content) {
        isPretty = isPretty || false;

        if (err) {
            return callback(err.toString());
        }

        var template = jade.compile(content, {
            filename: VIEWS_PATH + filePath,
            pretty: isPretty
        });

        var output = template(model);

        return callback(output);
    });
}

module.exports = {
    render: render
};

