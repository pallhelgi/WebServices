module.exports = `
    createUser(input: UserInput!): User!
    deleteUser(id: String!): Boolean!
    updateUser(id: String! input: UserInput!): User!
`;