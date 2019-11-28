const Schema = require('mongoose').Schema;

module.exports = new Schema({
    plot: { type: String, required: true },
    genres: [String],
    runtime: Number,
    cast: [String],
    num_mflix_comments: Number,
    title: String,
    countries: [String],
    released: Date,
    directors: [String],
    rated: String,
    awards: {
        wins: Number,
        nominations: Number,
        text: String
    },
    lastupdated: Date,
    year: Number,
    imdb: {
        rating: Number,
        votes: Number,
        id: Number
    },
    type: String,
    tomatoes: {
        viewver: {
            rating: Number,
            numReviews: Number,
            meter: Number
        },
        lastupdated: Date
    }
})