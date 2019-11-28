const ObjectId = require('mongoose').Types.ObjectId;

module.exports = {
    queries: {
        allTheaters: (parent, args, context) => {
            return context.db.Theater.find({});
        },
        theater: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const theater = await context.db.Theater.findById(args.id);
            if (theater == null) { throw new NotFoundError() };
            return theater
        }
    },
    mutations: {
        createTheater: (parent, args, context) => {
            const newTheater = {
                theaterid: args.input.theaterid,
                location: args.input.location
            };
            context.db.Theater.create(newtheater);
            return newTheater;
        },
        deleteTheater: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const theater = await context.db.Theater.findById(args.id);
            if (theater == null) { throw new NotFoundError() };
            await context.db.Theater.deleteOne({ _id: args.id })
            return true;
        },
        updateTheater: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const theater = await context.db.Theater.findById(args.id);
            if (theater == null) { throw new NotFoundError() };
            theater.theaterid = args.input.theaterid;
            theater.location = args.input.location;
            theater.save();
            return theater;
        }
    }
}