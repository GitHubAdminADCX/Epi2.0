using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebClient.Views.Blocks
{
    [ContentType(DisplayName = "DefaultBlock1", GUID = "134637cf-aeac-4c00-9ff7-2c39ba335073", Description = "")]
    public class DefaultBlock1 : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */
    }
}