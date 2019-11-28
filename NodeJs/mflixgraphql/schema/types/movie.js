module.exports = `
    type Movie{
        id: ID!
        plot: String!
        genres: [String!]!
        runtime: Float!
        cast: [String!]!
        num_mflix_comments: Int!
        title: String!
        fullplot: String!
        countries: [String!]!
        released: String!
        directors: [String!]!
        rated: String!
        awards: Awards!
        lastupdated: String!
        year: Int!
        imdb: Imdb!
        type: String!
        tomatoes: Tomatoes!
    }
`;