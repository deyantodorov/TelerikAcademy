var UserController;
var MessageController;

module.exports = {
    init: function () {
        require('./db')();
        UserController = require('../controllers/UserController');
        MessageController = require('../controllers/MessageController');
    },
    registerUser: function registerUser(user) {
        UserController.registerUser(user);
    },
    findUser: function findUser(user){
        UserController.findUser(user);
    },
    sendMessage: function sendMessage(msg) {
        MessageController.sendMessage(msg);
    },
    getMessages: function getMessages(msgs){
        MessageController.getMessages(msgs,function(messages){
           console.log(messages.join('\n\n'));
        });
    }
};