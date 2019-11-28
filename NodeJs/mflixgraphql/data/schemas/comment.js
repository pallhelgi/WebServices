const Schema = require('mongoose').Schema;

module.exports = new Schema({
    name: { type: String, required: true },
    email: { type: String, required: true },
    movie_id: { type: Number, required: true },
    text: { type: String, required: true },
    date: { type: Date, required: true }
})