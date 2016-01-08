var Message = require('mongoose').model('Message');

module.exports = {
    sendMessage: function sendMessage(msg) {
        if (!msg || typeof(msg) !== 'object') {
            console.log('Invalid message');
            return;
        }

        var newMessage = new Message({
            from: msg.from,
            to: msg.to,
            text: msg.text,
            createdOn: msg.createdOn
        });

        newMessage.save(function (err, message) {
            if (err) {
                console.log(err);
            } else {
                console.log(message);
            }
        });
    },
    getMessages: function getMessages(msgs, callback) {
        Message.find([
            {from: msgs.with, to: msgs.to},
            {from: msgs.and, to: msgs.with}
        ]).exec(function (err, result) {
            if(err){
                console.log(err);
                return;
            } else {
                callback(result);
            }
        });
    }
};