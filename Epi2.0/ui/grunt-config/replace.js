module.exports = {
    cachebust: {
        options: {
            variables: {
                // Generate a truly random number by concatenating the current date with a random number
                // The variable name corresponds with the same in our HTML file
                'hash': '<%= ((new Date()).valueOf().toString()) + (Math.floor((Math.random()*1000000)+1).toString()) %>'
            }
        },
        // Source and destination files
        files: [{
            '<%= uiPaths.css_dist %>/master.css': '<%= uiPaths.css_dist %>/master.css'
        }]
    }

};