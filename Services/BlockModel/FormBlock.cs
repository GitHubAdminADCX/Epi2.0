using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Services.BlockModel
{
    [ContentType(DisplayName = "FormBlock", GUID = "b2c0f105-17f2-43b9-8371-8395a7b3aa2d", Description = "")]
    public class FormBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Name { get; set; }
         */
    }
}