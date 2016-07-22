(function (tinymce, $) {
    tinymce.create('tinymce.plugins.MyButton', {
        init: function (ed, url) {

            /*add implementation logic here 
            below logic will open a open a window after button click            
            * Initializes the plugin, this will be executed after the plugin has been created.
            * This call is done before the editor instance has finished it's initialization so use the onInit event
            */
            ed.addButton('mybutton', {
                text: 'My button',
                title: 'My Button',
                icon: false,
                image: url + 'Util/Editor/tinymce/plugins/MyButton/MyButton.gif',
                onclick: function () {
                    // Add you own code to execute something on click
                    ed.focus();
                    ed.selection.setContent('Hello world!');
                }
            });

            tinymce.PluginManager.add('MyButton', tinymce.plugins.MyButton);
        }
    });
})(tinymce, epiJQuery);