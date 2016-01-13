var path = require('path');
var rootPath = path.normalize(__dirname + '/../../');

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost:27017/fileuploadsystem',
        port: process.env.PORT || 1234
    }
    //production: {
    //    rootPath: rootPath,
    //    db: 'mongodb://admin/telerikacademycourse',
    //    port: process.env.PORT || 3030
    //}
};