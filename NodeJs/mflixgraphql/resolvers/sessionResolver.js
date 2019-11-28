const { NotFoundError, BadRequest } = require('../errors');
const ObjectId = require('mongoose').Types.ObjectId;

module.exports = {
    queries: {
        allSessions: (parent, args, context) => {
            return context.db.Session.find({});
        },
        session: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const session = await context.db.Session.findById(args.id);
            if (session == null) { throw new NotFoundError() };
            return session
        }
    },
    mutations: {
        createSession: (parent, args, context) => {
            const newSession = {
                user_id: args.input.user_id,
                jwt: args.input.jwt,
            };
            context.db.Session.create(newSession);
            return newSession;
        },
        deleteSession: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const session = await context.db.Session.findById(args.id);
            if (session == null) { throw new NotFoundError() };
            await context.db.Session.deleteOne({ _id: args.id })
            return true;
        },
        updateSession: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const session = await context.db.Session.findById(args.id);
            if (session == null) { throw new NotFoundError() };
            session.user_id = args.input.user_id;
            session.jwt = args.input.jwt;
            session.save();
            return session;
        }
    }
}