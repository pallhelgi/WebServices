const { NotFoundError, BadRequest } = require('../errors');
const ObjectId = require('mongoose').Types.ObjectId;

module.exports = {
    queries: {
        allComments: (parent, args, context) => {
            return context.db.Comment.find({});
        },
        comment: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const comment = await context.db.Comment.findById(args.id);
            if (comment == null) { throw new NotFoundError() };
            return comment
        }
    },
    mutations: {
        createComment: (parent, args, context) => {
            const newComment = {
                name: args.input.name,
                email: args.input.email,
                movie_id: args.input.email,
                text: args.input.text,
                date: args.input.date
            };
            context.db.Comment.create(newComment);
            return newComment;
        },
        deleteComment: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const comment = await context.db.Comment.findById(args.id);
            if (comment == null) { throw new NotFoundError() };
            await context.db.Comment.deleteOne({ _id: args.id })
            return true;
        },
        updateComment: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const comment = await context.db.Comment.findById(args.id);
            if (comment == null) { throw new NotFoundError() };
            comment.name = args.input.name;
            comment.email = args.input.email;
            comment.movie_id = args.input.movie_id;
            comment.text = args.input.text;
            comment.date = args.input.date;
            comment.save();
            return comment;
        }
    }
}