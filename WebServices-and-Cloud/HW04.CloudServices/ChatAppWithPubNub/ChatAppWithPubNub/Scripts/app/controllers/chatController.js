var chatController = (function () {
    'use strict';

    function getAll(context) {
        var messages;

        data.chat.getAll()
            .then(function (data) {
                //console.log(data);
                messages = data;
                return templates.get('chat');
            })
            .then(function (template) {
                context.$element().html(template(messages));

                $('#btn-send').on('click', function () {
                    var messageContent = $('#tb-message').val();

                    if (messageContent !== '') {

                        var message = {
                            message: messageContent
                        };

                        data.chat.send(message)
                            .then(function() {
                                toastr.success('Message send');
                            })
                            .then(function() {
                                context.redirect('#/');
                            });
                    } else {
                        toastr.error('Write some message to be send');
                    }

                });
            });
    }

    return {
        getAll: getAll
    }
}());