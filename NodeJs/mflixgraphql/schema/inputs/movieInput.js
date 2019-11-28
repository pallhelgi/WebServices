module.exports = `
    input MovieInput{
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
        awards: [String]!
        lastupdated: String!
        year: Int!
        imdb: [String]!
        type: String!
        tomatoes: [String]!
    }
`