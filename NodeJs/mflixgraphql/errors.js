class NotFoundError extends Error {
    constructor(message = 'Id was not found') {
        super(message);
        this.name = 'NotFoundError';
        this.code = 404;
    }
}

class BadRequest extends Error {
    constructor(message = 'Field arguments were not setup correctly') {
        super(message);
        this.name = 'BadRequest';
        this.code = 400;
    }
}

class EmailExistsError extends Error {
    constructor(message = 'Email is being used by another user') {
        super(message);
        this.name = 'BadRequest';
        this.code = 400;
    }
}

module.exports = {
    NotFoundError,
    BadRequest,
    EmailExistsError
}