///FRM018
/// Author:Amol Pawar
///Purpose of the Module : Custom tool in Edit mode using DOJO
///Dependent entities : Module.config, javascript files under path \ClientResources\Scripts\CustomTool
///How to use: getActionPath in customtoolmaintoolbar.js is action after button click. Implement as per requirement.

require([
    'dojo/aspect',
    'epi/dependency',
    'custom/customtool/customtoolcommand'
], function (
    aspect,
    dependency,
    customtoolcommand) {
    // summary:   
    //        Initialize the addon by registering the command in the global toolbar.
    var handle,
         key = 'epi.cms.globalToolbar',
         registry = dependency.resolve('epi.globalcommandregistry'),
           callback = function (identifier, provider) {
               if (identifier !== key) {
                   return;
               }

               // When the command provider for the global toolbar is registered add our additional command.         
               provider.addCommand(new customtoolcommand(), {

                   showLabel: true
               });
               // Remove the aspect handle.         
               handle.remove();
           };
    // Listen for when the global toolbar command provider is registered in the command provider registry.  
    handle = aspect.after(registry, 'registerProvider', callback, true);
});