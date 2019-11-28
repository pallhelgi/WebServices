const inputs = require('./inputs');
const mutations = require('./mutations');
const queries = require('./queries');
const types = require('./types');

module.exports = `
        ${inputs}
        ${mutations}
        ${queries}
        ${types}

`;