/*
FRM006
Author: Snehal Jadhav
Purpose of the Class : Creates a button which will display text in editor on click or open a window in tiny mce plugin
How to use: Add the control from the custom misc setting to the tiny mce editor toolbar of the XHTMLString property  
Points to take care: will have cs file with TinyMceButtonPlugin attribute
*/

(function () {
    //displays the version of tiny mce
    console.log(tinyMCE.majorVersion + '.' + tinyMCE.minorVersion);

    tinymce.create('tinymce.plugins.MyButtonPlugin', {
        init: function (ed, url) {

            /*  add implementation logic here 
                * Below logic will open a open a window after button click.           
                * Initializes the plugin, this will be executed after the plugin has been created.
                * This call is done before the editor instance has finished it's initialization so use the onInit event.
            */
            ed.addButton('MyButton', {
                text: 'My button',
                title: 'My Button',
                icon: false,
                image: url + '/Mybutton.gif',
                onclick: function () {
                    // Add you own code logic to execute on click
                    ed.focus();
                    ed.selection.setContent('Hello world ! ');

                    //// Open window on button click code               
                    //            ed.windowManager.open({
                    //                title: 'TinyMCE site',
                    //                url: 'http://www.tinymce.com',
                    //                width: 800,
                    //                height: 600,
                    //                buttons: [{
                    //                    text: 'Close',
                    //                    onclick: 'close'
                    //                }]
                    //            });
                }
            });
        }
    });

    tinymce.PluginManager.add('MyButton', tinymce.plugins.MyButtonPlugin);
    
/*Can be used in below formated also. Preferably the top one is used*/
    //tinymce.PluginManager.add('MyButton', function (editor, url) {
    //    alert('test plugin');
    //    // Add a button that opens a window
    //    editor.addButton('MyButton', {
    //        text: 'My button',
    //        title: 'My Button',
    //        icon: false,
    //        image: '/util/Editor/tinymce/plugins/MyButton/Mybutton.gif',
    //        onclick: function () {

    //            //inserts only Hello World Text in the Editor
    //            editor.selection.setContent('Hello World ');

    //           // Open window on button click code                              
    //            editor.windowManager.open({
    //                title: 'TinyMCE site',
    //                url: 'http://www.tinymce.com',
    //                width: 800,
    //                height: 600,
    //                buttons: [{
    //                    text: 'Close',
    //                    onclick: 'close'
    //                }]
    //            });
    //        }
    //    });
    //});

})();

