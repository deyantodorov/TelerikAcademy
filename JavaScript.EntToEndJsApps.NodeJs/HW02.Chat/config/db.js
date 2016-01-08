var mongoose = require('mongoose');
var dbPath = 'mongodb://localhost:27017/';
var dbName = 'chat';

var User = require('../models/User');
var Message = require('../models/Message');

module.exports = function () {
    mongoose.connect(dbPath + dbName);
    var db = mongoose.connection;

    db.once('open', function(err){
        if(err){
            console.log(err);
            return;
        }

        console.log('MongoDb is up and running...');
    });

    db.on('error', function(err){
        console.log(err);
    });
};