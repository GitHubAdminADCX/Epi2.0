/// <binding AfterBuild='sass' />
module.exports = function (grunt) {
    var path = require('path');


    // Loads grunt tasks defined in package.json
    require('load-grunt-config')(grunt, {
        configPath: path.join(process.cwd(), 'ui/grunt-config'), //path to task.js files, defaults to grunt dir
        init: true, //auto grunt.initConfig

        config: { //additional config vars
            uiRoot: 'ui/'
        }
    });

    grunt.registerTask('default', ['build']);

};
