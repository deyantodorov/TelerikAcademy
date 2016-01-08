var User = require('mongoose').model('User');

module.exports = {
    registerUser: function registerUser(userToAdd) {
        if (!userToAdd || typeof(userToAdd) !== 'object') {
            console.log('Invalid user');
            return;
        }

        var newUser = new User({
            user: userToAdd.user,
            pass: userToAdd.pass
        });

        newUser.save(function (err, user) {
            if (err) {
                console.log(err);
            } else {
                console.log(user);
            }
        });
    },
    findUser: function findUser(userToFind) {
        if (!userToFind || typeof(userToFind) !== 'object') {
            User.find({}).exec(function (err, data) {
                if (err) {
                    console.log(err);
                }

                console.log(data);
            });
        } else {
            User.find(userToFind).exec(function (err, data) {
                if (err) {
                    console.log(err);
                }

                console.log(data);
            });
        }
    }
};