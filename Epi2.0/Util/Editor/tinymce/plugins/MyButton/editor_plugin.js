(function () {
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
                image: url + '/Mybutton.gif',
                onclick: function () {
                    // Open window
                    ed.windowManager.open({
                        title: 'Example plugin',
                        body: [
                            { type: 'textbox', name: 'title', label: 'Title' }
                        ],
                        onsubmit: function (e) {
                            // Insert content when the window form is submitted
                            ed.insertContent('Title: ' + e.data.title);
                        }
                    });
                }

            });

            tinymce.PluginManager.add('MyButton', tinymce.plugins.MyButton);
        }
    });
})();