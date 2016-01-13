var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

var User;

module.exports = {
    init: function () {
        var userSchema = mongoose.Schema({
            username: {type: String, required: true, unique: true},
            firstName: String,
            lastName: String,
            birthdate: Date,
            salt: String,
            hashPass: String,
            points: Number
        });

        userSchema.method({
            authenticate: function (password) {
                return encryption.generateHashedPassword(this.salt, password) === this.hashPass;
            }
        });

        User = mongoose.model('User', userSchema);
    },
    //seedInitialUsers: function () {
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