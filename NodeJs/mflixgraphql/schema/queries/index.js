const userQueries = require('./userQueries');
const commentQueries = require('./commentQueries');
const sessionsQueries = require('./sessionQueries');
const theaterQueries = require('./theaterQueries');
const movieQuries = require('./movieQueries');

module.exports = `
    type Query {
        ${userQueries}
        ${commentQueries}
        ${sessionsQueries}
        ${theaterQueries}
        ${movieQuries}
    }
`;