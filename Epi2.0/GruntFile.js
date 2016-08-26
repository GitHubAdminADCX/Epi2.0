/// <binding AfterBuild='sass' />
module.exports = function (grunt) {
    var path = require('path');

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        sass: {
            dist: {
                files: {
                    'public/stylesheets/style.css': 'sass/style.scss'
                }
            }
        },
        watch: {
            scripts: {
                files: ['scripts/**/*.js'],
                tasks: ['tags-debug'],
                options: {
                    livereload: true,
                },

            },
            source: {
                files: ['sass/*.scss'],
                tasks: ['sass'],
                options: {
                    livereload: true, // needed to run LiveReload
                }
            }
        }
    })

    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.registerTask('default', ['tags', 'sass']);
};
