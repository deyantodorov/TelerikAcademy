module.exports = {
    ok: function ok(res) {
        res.writeHead(200, {
            'Content-Type': 'text/html'
        });
    },
    notFound: function notFound(res) {
        res.writeHead(404);
    },
    css: function css(res){
        res.writeHead(200, {
            'Content-Type': 'text/css'
        });
    },
    js: function js(res){
        res.writeHead(200, {
            'Content-Type': 'application/javascript'
        });
    }
};
