var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);
    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    app.get('/upload-results', auth.isAuthenticated, controllers.files.getResults);

    app.get('/profile', auth.isAuthenticated, controllers.profile.getProfile);
    app.get('/edit-profile', auth.isAuthenticated, controllers.profile.getEditProfile);
    app.post('/edit-profile', auth.isAuthenticated, controllers.profile.postEditProfile);

    app.get('/files/download/:id', controllers.files.download);
    app.get('/files/delete/:id', auth.isAuthenticated, controllers.files.delete);

    app.get('/', function (req, res) {
        res.render('index');
    });

    app.get('*', function (req, res) {
        res.render('index', {currentUser: req.user});
    });
};