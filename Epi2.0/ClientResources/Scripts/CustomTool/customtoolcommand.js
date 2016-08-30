///FRM018
/// Author:Amol Pawar
///Purpose of the Module : Custom tool in Edit mode using DOJO
///Dependent entities : Module.config, javascript files under path \ClientResources\Scripts\CustomTool
///How to use: getActionPath in customtoolmaintoolbar.js is action after button click. Implement as per requirement.


define([
    // General application modules    
    'dojo/_base/declare',
    'dojo/_base/lang',
    'dojo/topic',
    'epi/cms/contentediting/ContentActionSupport',
    // Parent classes   
    'epi/shell/command/_Command',
    'epi/cms/_ContentContextMixin',
    // Resources  
    'epi/i18n!epi/nls/addon.dynamicproperties'
],
    function (
        declare,
        lang,
        topic,
        ContentActionSupport,
        _Command,
        _ContentContextMixin,
        resources
        ) {
        // module:  
        //        addon/command/EditDynamicProperties  
        // summary:   
        //        Displays the edit dynamic properties view in the main edit area when executed. Also listens  
        //        for context changes in order to update whether it can execute.  
        return declare([_Command, _ContentContextMixin], {
            // label: [public] String     
            //        The action text of the command to be used in visual elements.      
            label: "Report",
            // tooltip: [public] String  
            //        The description text of the command to be used in visual elements.       
            tooltip: "Report Center",
            // iconClass: [public] String      
            //        The icon class of the command to be used in visual elements.  
            iconClass: 'dijitNoIcon',
            contentContextChanged: function () {
                // summary:          
                //        Set the command's model to the new current content.          
                // tags:         
                //        protected          
                this.getCurrentContent().then(lang.hitch(this, 'set', 'model'));
            },
            _execute: function () {
                // summary:    
                //        Publishes a change view topic to switch to the dynamic properties view for the current model.          
                // tags:           
                //        protected        
                topic.publish('/epi/shell/action/changeview', 'custom/customtool/customtoolmaintoolbar', null, this.model);
            },
            _onModelChange: function () {
                // summary:         
                //        Updates canExecute after the model has been updated. Set to true if the current content is     
                //        a page and the current user has the administer access level; otherwise false.     
                // tags:           
                //        protected           
                var model = this.model,
                    canExecute = model && model.capabilities.isPage && ContentActionSupport.hasAccess(model.accessMask, ContentActionSupport.accessLevel.Administer); this.set('canExecute', canExecute);
            }
        });
    });