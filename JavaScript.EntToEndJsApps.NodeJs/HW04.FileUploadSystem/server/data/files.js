var File = require('mongoose').model('File');

module.exports = {
    addFiles: function (files) {
        for (var file in files) {
            File.create(files[file]);
        }
    },
    getFiles: function (id, callback) {
        File.find({userId: id}, callback);
    },
    getFileByUrl: function (url, callback) {
        File.findOne({url: url}, callback);
    },
    deleteFileByUrl: function (url, callback) {
        File.remove({url: url}, callback);
    }
};