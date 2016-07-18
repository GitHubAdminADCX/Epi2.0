(function () {
    tinymce.create('tinymce.plugins.MyPlugin', {
        init: function (ed, url) {
            //add implementation logic here 
            return "My custom plugin"
        }
    });
    tinymce.PluginManager.add('MyPlugin', tinymce.plugins.MyPlugin);
})();


