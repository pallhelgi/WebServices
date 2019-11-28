const { NotFoundError, BadRequest } = require('../errors');
const ObjectId = require('mongoose').Types.ObjectId;

module.exports = {
    queries: {
        allMovies: (parent, args, context) => {
            return context.db.Movie.find({});
        },
        movie: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const movie = await context.db.Movie.findById(args.id);
            if (movie == null) { throw new NotFoundError() };
            return movie
        }
    },
    mutations: {
        createMovie: (parent, args, context) => {
            const newMovie = {
                plot: args.input.plot,
                genres: args.input.genres,
                runtime: args.input.runtime,
                cast: args.input.runtime,
                num_mflix_comments: args.input.num_mflix_comments,
                title: args.input.title,
                fullplot: args.input.fullplot,
                countries: args.input.countries,
                released: args.input.released,
                directors: args.input.directors,
                rated: args.input.rated,
                awards: args.input.awards,
                lastupdated: args.input.lastupdated,
                year: args.input.year,
                imdb: args.input.imdb,
                type: args.input.type,
                tomatoes: args.input.tomatoes
            };
            context.db.Movie.create(newMovie);
            return newMovie;
        },
        deleteMovie: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const movie = await context.db.Movie.findById(args.id);
            if (movie == null) { throw new NotFoundError() };
            await context.db.Movie.deleteOne({ _id: args.id })
            return true;
        },
        updateMovie: async (parent, args, context) => {
            if (!ObjectId.isValid(args.id)) { throw new BadRequest() };
            const movie = await context.db.Movie.findById(args.id);
            if (movie == null) { throw new NotFoundError() };
            movie.plot = args.input.plot;
            movie.genres = args.input.genres;
            movie.runtime = args.input.runtime;
            movie.cast = args.input.runtime;
            movie.num_mflix_comments = args.input.num_mflix_comments;
            movie.title = args.input.title;
            movie.fullplot = args.input.fullplot;
            movie.countries = args.input.countries;
            movie.released = args.input.released;
            movie.directors = args.input.directors;
            movie.rated = args.input.rated;
            movie.awards = args.input.awards;
            movie.lastupdated = args.input.lastupdated;
            movie.year = args.input.year;
            movie.imdb = args.input.imdb;
            movie.type = args.input.type;
            movie.tomatoes = args.input.tomatoes;
            movie.save();
            return movie;
        }
    }
}