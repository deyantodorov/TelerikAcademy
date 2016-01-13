var encryption = require('../utilities/encryption'),
    users = require('../data/users'),
    uploading = require('../utilities/uploading'),
    validate = require('../utilities/validate');

var CONTROLLER_NAME = 'users',
    MIN_USERNAME_LENGTH = 6,
    MAX_USERNAME_LENGTH = 20;

module.exports = {
    getRegister: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register');
    },
    postRegister: function (req, res, next) {

        var newUserData = req.body;
        newUserData.salt = encryption.generateSalt();
        newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);

        if (validate.passwordsNotMatch(newUserData.password, newUserData.confirmPassword)) {
            req.session.error = 'Passwords do not match';
            res.redirect('/register');
        } else if (validate.userIsBlank(newUserData)) {
            req.session.error = 'Fill required information';
            res.redirect('/register');
        } else if (!validate.range(MIN_USERNAME_LENGTH, MAX_USERNAME_LENGTH, newUserData.username.length)) {
            req.session.error = 'Username must be at least ' + MIN_USERNAME_LENGTH + ' symbols';
            res.redirect('/register');
        } else {
            users.create(newUserData, function (err, user) {
                if (err) {
                    console.log('Failed to register new user: ' + err);
                    return;
                }

                uploading.createDir('/', user.username);

                req.login(user, function (err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()}); // TODO
                    } else {
                        res.redirect('/');
                    }
                });
            });
        }
    },
    getLogin: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfile: function (req, res, next) {
        var userInfo = users.getUser(req.user.username);
        console.log(userInfo);

        res.render('/profile');
    }
};