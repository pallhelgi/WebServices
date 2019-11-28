module.exports = `
    createComment(input: CommentInput!): Comment!
    deleteComment(id: String!): Boolean!
    updateComment(id: String! input: CommentInput!): Comment!
`;