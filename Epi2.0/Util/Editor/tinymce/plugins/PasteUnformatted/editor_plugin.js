/*

Author: Snehal Jadhav
Purpose of the Class : Creates a button in tiny mce plugin in Episerver Admin
How to use: Add the control from the custom setting of the XHTMLString property  
Points to take care: will have cs file with TinyMceButtonPlugin attribute
*/
(function () {

    tinymce.create('tinymce.plugins.PasteUnformattedPlugin', {
        init: function (ed, url) {
        /*
            * Initializes the plugin, this will be executed after the plugin has been created.
            * This call is done before the editor instance has finished it's initialization so use the onInit event
        */
            if (!ed.plugins.paste)
                return;
            ed.onInit.add(function (ed) {
                ed.pasteAsPlainText = true;
                ed.controlManager.setActive('pastetext', true);
            });
        }
    });

    tinymce.PluginManager.add('PasteUnformatted', tinymce.plugins.PasteUnformattedPlugin);

}());

