var UsersController = require('./UsersController'),
    FilesController = require('./FilesController'),
    ProfileController = require('./ProfileController');

module.exports = {
    users: UsersController,
    files: FilesController,
    profile: ProfileController
};