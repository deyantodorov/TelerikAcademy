var chatDb = require('./config/chat-db');
chatDb.init();

chatDb.registerUser({user: 'MishoMishev', pass: '123123'});
chatDb.registerUser({user: 'PishoPishev', pass: '123123'});

chatDb.findUser();
chatDb.findUser({user: 'Misho'});

//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'MishoMishev',
    to: 'PishoPishev',
    text: 'Hey, Pisho!'
});
//returns an array with all messages between two users
chatDb.getMessages({
    with: 'MishoMishev',
    and: 'PishoPishev'
});