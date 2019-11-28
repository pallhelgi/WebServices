const userMutations = require('./userMutations');
const commentMutations = require('./commentMutations');
const sessionsMutations = require('./sessionMutations');
const theaterMutations = require('./theaterMutations');
const movieMutations = require('./movieMutations');

module.exports = `
    type Mutation {
        ${userMutations}
        ${commentMutations}
        ${sessionsMutations}
        ${theaterMutations}
        ${movieMutations}
    }
`;