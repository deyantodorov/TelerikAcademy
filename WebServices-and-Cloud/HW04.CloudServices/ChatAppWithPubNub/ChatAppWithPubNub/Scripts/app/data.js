var data = (function () {
    'use strict';

    var CHAT_PATH_GET_MESSAGES = '/api/chat/GetAll/';
    var CHAT_PATH_SEND_MESSAGES = '/api/chat/Send/';
    
    function getAllMessages() {
        return jsonRequester.get(CHAT_PATH_GET_MESSAGES)
            .then(function (data) {
                return data;
            });
    }

    function sendMessage(message) {
        var options = {
            data: message
        };

        return jsonRequester.post(CHAT_PATH_SEND_MESSAGES, options)
            .then(function (resp) {
                return resp;
            });
    }

    return {
        chat: {
            getAll: getAllMessages,
            send: sendMessage
        }
    }
}());