var encryption = require('../utilities/encryption'),
    dates = require('../utilities/dates'),
    uploading = require('../utilities/uploading'),
    files = require('../data/files'),
    users = require('../data/users');

var CONTROLLER_NAME = 'files';
var URL_PASSWORD = 'Yes, I can';

var uploadFiles = {};


module.exports = {
    getUpload: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/upload');
    },
    postUpload: function (req, res, next) {
        var fstream;
        req.pipe(req.busboy);
        var username = req.user.username;

        req.busboy.on('file', function (fieldname, file, filename) {
            var fileNameHashed = encryption.generateHashedPassword(encryption.generateSalt(), filename);
            var currentDate = dates.getDate();
            var path = '/' + username + '/' + currentDate + '/';
            var url = path + fileNameHashed;
            var urlEncrypted = encryption.encrypt(url, URL_PASSWORD);

            uploading.saveFile(file, path, fileNameHashed);
            uploadFiles[username] = uploadFiles[username] || [];

            uploadFiles[username][fieldname] = uploadFiles[username][fieldname] || {};
            var dbFile = uploadFiles[username][fieldname];
            dbFile.url = urlEncrypted;
            dbFile.fileName = filename;
            dbFile.userId = req.user._id;
        });

        req.busboy.on('field', function (fieldname, val) {
            var index = fieldname.split('_')[1];
            uploadFiles[username] = uploadFiles[username] || [];
            uploadFiles[username]['file_' + index] = uploadFiles[username]['file_' + index] || {};
            var dbFile = uploadFiles[username]['file_' + index];
            dbFile.isPrivate = !!val;
        });

        req.busboy.on('finish', function () {
            files.addFiles(uploadFiles[username]);
            users.addPoints(username);
            res.redirect('/upload-results');
        });
    },
    getResults: function (req, res, next) {
        var resultFiles = uploadFiles[req.user.username];

        if (!resultFiles) {
            res.redirect('/upload');
        } else {
            var files = [];
            for (var file in resultFiles) {
                files.push(resultFiles[file]);
            }

            uploadFiles[req.user.username] = undefined;

            res.render(CONTROLLER_NAME + '/result', {files: files});
        }
    },
    download: function (req, res, next) {
        var url = req.params.id;

        files.getFileByUrl(url, function (err, file) {
            var fileName = file.fileName;

            var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);
            res.download(__dirname + '/../../files' + decryptedUrl, fileName);
        });
    },
    delete: function (req, res, next) {
        var url = req.params.id;
        files.deleteFileByUrl(url, function (err) {
            if(err){
                console.log(err);
            }

            res.redirect('/profile');
        });
    }
};