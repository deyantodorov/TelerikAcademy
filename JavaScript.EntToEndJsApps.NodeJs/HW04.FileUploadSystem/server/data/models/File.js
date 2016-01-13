var mongoose = require('mongoose');

var File;

module.exports = {
    init: function () {
        var fileSchema = mongoose.Schema({
            url: {type: String, required: true, unique: true},
            uploadingDate: {type: Date, default: new Date()},
            fileName: String,
            isPrivate: {type: Boolean, default: false},
            userId: {type: String, required: true}
        });

        File = mongoose.model('File', fileSchema);
    }
    //seedInitialFiles: function () {
    //    User.find({}).exec(function (err, collection) {
    //        if (err) {
    //            console.log('Cannot find users: ' + err);
    //            return;
    //        }
    //
    //        if (collection.length === 0) {
    //            var salt;
    //            var hashedPwd;
    //
    //            salt = encryption.generateSalt();
    //            hashedPwd = encryption.generateHashedPassword(salt, 'Ivaylo');
    //            User.create({
    //                username: 'Ivo',
    //                salt: salt,
    //                hashPass: hashedPwd,
    //                points: 0
    //            });
    //            salt = encryption.generateSalt();
    //            hashedPwd = encryption.generateHashedPassword(salt, 'Nikolay');
    //            User.create({
    //                username: 'Niki',
    //                salt: salt,
    //                hashPass: hashedPwd,
    //                points: 0
    //            });
    //            salt = encryption.generateSalt();
    //            hashedPwd = encryption.generateHashedPassword(salt, 'Doncho');
    //            User.create({
    //                username: 'Doncho',
    //                salt: salt,
    //                hashPass: hashedPwd,
    //                points: 0
    //            });
    //            console.log('Users added to database...');
    //        }
    //    });
    //}
};