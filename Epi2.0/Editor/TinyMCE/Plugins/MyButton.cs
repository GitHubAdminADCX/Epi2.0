﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Editor.TinyMCE;

namespace WebClient.Editor.TinyMCE.Plugins
{
    /// <summary>
    /// Author: Snehal Jadhav
    /// Purpose of the Class : Creates a button in tiny mce plugin in Episerver Admin
    /// How to use: Add the control from the custom setting of the XHTMLString property    
    /// </summary>
    [TinyMCEPluginButton(PlugInName = "mybutton", ButtonName =
           "My Button", GroupName = "misc", LanguagePath =
           "/admin/tinymce/plugins/mybutton", EditorInitConfigurationOptions = "@{ extended_valid_elements:'img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name]'}"
            )]
    public class MyButton
    {
    }
}