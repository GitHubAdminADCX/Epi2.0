using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Editor.TinyMCE;

namespace WebClient.Editor.TinyMCE.Plugins
{
    [TinyMCEPluginNonVisual(LanguagePath = "/admin/tinymce/plugins/MyPlugin", PlugInName = "MyPlugin")]
    public class MyPlugin
    {
    }
}