const mongoose = require('mongoose');
const options = { dbName: "sample_mflix", useNewUrlParser: true };
const connection = mongoose.createConnection('mongodb+srv://Sigurdarson:i4VJd$ikDmau5$S@cluster0-1mcka.mongodb.net/test', options);

const commentSchema = require('./schemas/comment');
const movieSchema = require('./schemas/movie');
const sessionSchema = require('./schemas/session');
const theaterSchema = require('./schemas/theater');
const userSchema = require('./schemas/user');

module.exports = {
    Comment: connection.model('comments', commentSchema),
    Movie: connection.model('movies', movieSchema),
    Session: connection.model('sessions', sessionSchema),
    Theater: connection.model('theaters', theaterSchema),
    User: connection.model('users', userSchema)
};