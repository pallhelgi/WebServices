const commentResolver = require('./commentResolver');
const movieResolver = require('./movieResolver');
const sessionResolver = require('./sessionResolver');
const theaterResolver = require('./theaterResolver');
const userResolver = require('./userResolver');

module.exports = {
    Query: {
        ...userResolver.queries,
        ...commentResolver.queries,
        ...sessionResolver.queries,
        ...theaterResolver.queries,
        ...movieResolver.queries
    },
    Mutation: {
        ...userResolver.mutations,
        ...commentResolver.mutations,
        ...sessionResolver.mutations,
        ...theaterResolver.mutations,
        ...movieResolver.mutations
    },
}