var users = require('../data/users'),
    files = require('../data/files');

var CONTROLLER_NAME = 'profile';

module.exports = {
    getProfile: function (req, res) {
        users.getByUsername(req.user.username, function (err, user) {
            var data = {
                user: user
            };

            files.getFiles(req.user._id, function (err, userFiles) {
                if (err) {
                    console.log(err);
                }

                data.files = userFiles;
                res.render(CONTROLLER_NAME + '/profile', data);
            });
        });
    },
    getEditProfile: function (req, res) {
        users.getByUsername(req.user.username, function (err, user) {
            res.render(CONTROLLER_NAME + '/edit-profile', {user: user});
        });
    },
    postEditProfile: function (req, res) {
        users.getByUsername(req.user.username, function (err, user) {
            user.firstName = req.body.firstName;
            user.lastName = req.body.lastName;
            if (req.body.birthdate !== '') {
                user.birthdate = req.body.birthdate;
            }

            user.save();

            res.redirect('/profile');
        });
    }
};