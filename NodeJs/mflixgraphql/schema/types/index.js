const comment = require('./comment');
const movie = require('./movie');
const session = require('./session');
const theater = require('./theater');
const user = require('./user');
const location = require('./location');
const address = require('./address');
const awards = require('./awards');
const geo = require('./geo');
const imdb = require('./imdb');
const viewver = require('./viewer');
const tomatoes = require('./tomatoes');

module.exports = `
        ${user}
        ${comment}
        ${movie}
        ${session}
        ${theater}
        ${location}
        ${address}
        ${awards}
        ${geo}
        ${imdb}
        ${viewver}
        ${tomatoes}

`;