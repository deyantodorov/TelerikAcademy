var User = require('mongoose').model('User');

module.exports = {
    create: function (user, callback) {
        User.create(user, callback);
    },
    getByUsername: function(username, callback){
        User.findOne(username,callback);
    },
    addPoints: function (username) {
        User.findOne({username: username}, function (err, user) {
            if(err){
                console.log(err);
            } else {
                user.points = user.points || 0;
                user.points++;

                user.save();
            }
        });
    }
};