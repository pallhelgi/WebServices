const Schema = require('mongoose').Schema;

module.exports = new Schema({
    name: String,
    email: String,
    password: String
})