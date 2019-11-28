module.exports = `
    createMovie(input: MovieInput!): Movie!
    deleteMovie(id: String!): Boolean!
    updateMovie(id: String! input: MovieInput!): Movie!
`;