const { NotFoundError, BadRequest, EmailExistsError } = require('../errors');
const ObjectId = require('mongoose').Types.ObjectId;

module.exports = {
    queries: {
        allUsers: (parent, args, context) => {
            return context.db.User.find({});
        },
        user: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const user = await context.db.User.findById(args.id);
            if (user == null) { throw new NotFoundError() };
            return user
        }
    },
    mutations: {
        createUser: async (parent, args, context) => {
            const user = await context.db.User.findOne({ email: args.input.email });
            if (user != null) { throw new EmailExistsError };
            const newUser = {
                name: args.input.name,
                email: args.input.email,
                password: args.input.password
            };
            context.db.User.create(newUser);
            return newUser;
        },
        deleteUser: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const user = await context.db.User.findById(args.id);
            if (user == null) { throw new NotFoundError() };
            await context.db.User.deleteOne({ _id: args.id })
            return true;
        },
        updateUser: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const user = await context.db.User.findById(args.id);
            if (user == null) { throw new NotFoundError() };
            if (user.email == args.input.email) {
                user.name = args.input.name;
                user.password = args.input.password;
            }
            else {
                const user = await context.db.User.findOne({ email: args.input.email })
                if (user != null) { throw new EmailExistsError };
                user.name = args.input.name;
                user.email = args.input.email;
                user.password = args.input.password;
            }

            user.save();
            return user;
        }
    }
}