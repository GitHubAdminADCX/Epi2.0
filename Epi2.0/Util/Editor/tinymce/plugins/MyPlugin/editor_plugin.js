(function () {
    tinymce.create('tinymce.plugins.MyPlugin', {
        /*
        * Initializes the plugin, this will be executed after the plugin has been created.
        * This call is done before the editor instance has finished it's initialization so use the onInit event
        */
        init: function (ed, url) {
            if (!ed.plugins.paste)
                return;
            ed.onInit.add(function (ed) {
                ed.pasteAsPlainText = true;
                ed.controlManager.setActive('pastetext', true);
            });
        }
    });

    tinymce.PluginManager.add('PasteUnformatted', tinymce.plugins.MyPlugin);

}());
