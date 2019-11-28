const Schema = require('mongoose').Schema;

module.exports = new Schema({
    theaterid: Number,
    location: {
        address: {
            street1: String,
            city: String,
            state: String,
            zipcode: String
        },
        geo: {
            type: String,
            coordinates: [Number]
        }
    }
})