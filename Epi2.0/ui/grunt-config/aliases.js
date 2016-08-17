module.exports = {
    test: [
        'connect:test',
        'shell:mocha-phantomjs'
    ],

    build: [
        'jshint',
        'concurrent:dist',
        'jst',
        'requirejs',
        'styles'
//        'cssmin' // Not used! CSS is minified on server
    ],

    scripts: [
        'jshint',
        'jst',
        'requirejs'
    ],

    styles: [
        'sass:dist',
        'replace',
        'cssmin:default'
    ],

    icons: [
        'webfont:icons'
    ]

};
