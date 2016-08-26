using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using WebClient.HelperClass.ComplexProperty;

namespace WebClient.Models.Blocks
{
    [ContentType(DisplayName = "LocationBlock", AvailableInEditMode = false, GUID = "1f8215e4-c3f1-4f25-a895-71c6e9cf4ef0", Description = "")]
    public class LocationBlock : BlockData
    {
        [SelectOne(SelectionFactoryType = typeof(CountrySelectionFactory))]
        public virtual string Country { get; set; }

        [ClientEditor(ClientEditingClass = "myproject/LocationBlockEditor/FilterableSelectionEditor", SelectionFactoryType = typeof(RegionSelectionFactory))]
     
        public virtual string Region { get; set; }
    }
}