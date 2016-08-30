module.exports = {
    options: {
        livereload: true
    },
    sass: {
        files: ['<%= uiPaths.css_src %>/{,**/}*.{scss,sass}'],
        tasks: [
                'sass:server'
        ],
        options: {
            livereload: false
        }
    },
    assemble: {
        files: ['assemble/{,**/}*.{hbs,yml,json}'],
        tasks: [
                'assemble'
        ],
        options: {
            livereload: false
        }
    },
    html: {
        files: ['pages/*.html'],
        tasks: []
    },
    css: {
        files: ['<%= uiPaths.css_dist %>/*.css'],
        tasks: ['cssmin:default']
    },
    js: {
        files: ['<%= uiPaths.js_src %>/**/*.js', '<%= uiPaths.js_specs %>/**/*.js'],
        //tasks: ['shell:mocha-phantomjs']
        tasks: ['requirejs:dist']
    },
    css: {
        files: ['<%= uiPaths.css_dist %>/*.css'],
        tasks: ['cssmin:default']
    }

};
