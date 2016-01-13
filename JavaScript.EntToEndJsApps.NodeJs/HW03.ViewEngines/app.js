var PORT = 1234;

var http = require('http'),
    url = require('url'),
    fs = require('fs');

var jadeRender = require('./jadeRender');
var db = require('./shopDb');
var httpHead = require('./httpHead');

var model = {
    menus: db.menu()
};

http.createServer(function (req, res) {
    var parseUrl = url.parse(req.url, true).pathname.toLowerCase();
    var fileType = parseUrl.split('.').pop();

    switch (fileType) {
        case 'css':
            httpHead.css(res);
            break;
        case 'js':
            httpHead.js(res);
            break;
    }

    switch (parseUrl) {
        case '/':
        case '/home':
            httpHead.ok(res);

            model.pageTitle = 'Home';

            jadeRender.render('home.jade', model, function (view) {
                res.end(view);
            });

            break;
        case '/phones':
            httpHead.ok(res);

            model.pageTitle = 'All Phones';
            model.products = db.phones();

            jadeRender.render('phones.jade', model, function (view) {
                res.end(view);
            });

            break;
        case '/tablets':
            httpHead.ok(res);

            model.pageTitle = 'All Tablets';
            model.products = db.tablets();

            jadeRender.render('tablets.jade', model, function (view) {
                res.end(view);
            });

            break;
        case '/wearables':
            httpHead.ok(res);

            model.pageTitle = 'All Wearables';
            model.products = db.wearables();

            jadeRender.render('wearables.jade', model, function (view) {
                res.end(view);
            });

            break;
        case '/style/main.css':
            fs.readFile('style/main.css', 'utf8', function (err, data) {
                if (err) {
                    console.log(err);
                }
                res.end(data);
            });
            break;
        default:
            httpHead.notFound(res);
            res.end();
            break;
    }
}).listen(PORT);

console.log('Server is listening on port ' + PORT);