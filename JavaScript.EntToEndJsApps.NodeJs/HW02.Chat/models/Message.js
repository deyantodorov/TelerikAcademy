var mongoose = require('mongoose');

var messageSchema = mongoose.Schema({
    from: {
        type: String,
        required: true
    },
    to: {
        type: String,
        required: true
    },
    text: {
        type: String,
        required: true,
        minlength: 3,
        maxlength: 2000
    }
});

mongoose.model('Message', messageSchema);