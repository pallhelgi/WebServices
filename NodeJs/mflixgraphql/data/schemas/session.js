const Schema = require('mongoose').Schema;

module.exports = new Schema({
    user_id: String,
    jwt: String
})