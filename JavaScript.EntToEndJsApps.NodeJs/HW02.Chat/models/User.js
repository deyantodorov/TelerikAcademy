var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    user: {
        type: String,
        required: true,
        unique: true,
        minlength: 3,
        maxlength: 30
    },
    pass: {
        type: String,
        required: true,
        minlength: 6,
        maxlength: 30
    }
});

mongoose.model('User', userSchema);