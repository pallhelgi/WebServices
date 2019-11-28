module.exports = `
    createSession(input: SessionInput!): Session!
    deleteSession(id: String!): Boolean!
    updateSession(id: String! input: SessionInput!): Session!
`;