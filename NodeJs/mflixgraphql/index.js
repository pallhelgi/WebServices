const { ApolloServer } = require('apollo-server');
const typeDefs = require('./schema');
const resolvers = require('./resolvers');
const db = require('./data/db');

const server = new ApolloServer({
    typeDefs,
    resolvers,
    context: {
        db: db
    }
});

server.listen()
    .then(({ url }) => console.log(`GraphQL Service is running on ${url}`));