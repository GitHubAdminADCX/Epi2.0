///FRM018
/// Author:Amol Pawar
///Purpose of the Module : Custom tool in Edit mode using DOJO
///Dependent entities : Module.config, javascript files under path \ClientResources\Scripts\CustomTool
///How to use: getActionPath in customtoolmaintoolbar.js is action after button click. Implement as per requirement.


define([
    // General application modules   
    'dojo/_base/declare',
    'epi/routes',    // Parent classes   
    'epi/shell/widget/Iframe'
], function (declare,
    routes,
    Iframe
    ) {
    // module: 
    //        addon/view/DynamicProperties  
    // summary:  
    //        Displays the legacy dynamic properties edit view for the current page.
    return declare([Iframe], {
        // baseUrl: [public] String     
        //        The base URL to the edit dynamic properties page.
        baseUrl: null,
        constructor: function () {
          
            // summary:         
            //        Construct the dynamic properties view and set the base URL.         
            // tags:         
            //        public
            this.baseUrl = routes.getActionPath({
                //path: 'Edit/EditDynProp.aspx',
                path: 'Report/default.aspx',
                moduleArea: 'LegacyCMS'
            });
        },
        updateView: function (data) {
            // summary:
            //        Load a new view in the iframe using the base URL and the current page's content link.
            // tags:          
            //        public

            this.load(this.baseUrl, {
                query: {
                    id: data.contentLink
                }
            });
        }
    });
});