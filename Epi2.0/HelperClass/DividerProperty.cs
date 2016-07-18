using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.Web.PropertyControls;
using EPiServer.XForms.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using WebClient;

namespace Epi2._0.HelperClass
{
    /// <summary>
    /// Class DividerProperty.
    /// </summary>
    [PropertyDefinitionTypePlugIn(DisplayName = "Divider",
         Description = "Edit-mode divider with headline and description")]
    public class DividerProperty : PropertyData
    {

        /// <summary>
        /// Translates the display name to the current language.
        /// </summary>
        /// <returns>The translated display name.</returns>
        /// <remarks>If no translation is found the EditCaption defined in the <see cref="P:EPiServer.Core.PropertyData.PropertyDefinition" /> will be used.</remarks>
        public override string TranslateDisplayName()
        {
            const string header = "<div style='width: 530%; border-bottom: 1px solid #808080; padding: 6px 0px 2px; margin-bottom: 6px; '><b><font size=\"2\">{0}</font></b></div>";
            return string.Format(header, TranslateDescription());
        }

        /// <summary>
        /// Inherited. Gets the Type of the property value.
        /// </summary>
        /// <value>The <see cref="T:System.Type" /> of the property value.</value>
        public override Type PropertyValueType
        {
            get
            {
                return this.GetType();
            }
        }

        /// <summary>
        /// Inherited. Gets the property type as defined by enum PropertyDataType.
        /// </summary>
        /// <value>The type as defined by enum <see cref="T:EPiServer.Core.PropertyDataType" />.</value>
        public override EPiServer.Core.PropertyDataType Type
        {
            get
            {
                return PropertyDataType.String;
            }
        }

        /// <summary>
        /// Inherited. Gets or sets the value of the String property.
        /// </summary>
        /// <value>The value of the property.</value>
        /// <remarks>Value returns null if the property has no value defined.</remarks>
        public override object Value
        {
            get
            {
                return string.Empty;
            }
            set
            {
                // Ignore
            }

        }


        /// <summary>
        /// Inherited. Read property data from a string representation, ie reversed ToString().
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>EPiServer.Core.PropertyData.</returns>
        public override EPiServer.Core.PropertyData ParseToObject(string str)
        {
            DividerProperty prop = new DividerProperty();
            prop.SetDefaultValue();
            return prop;
        }


        /// <summary>
        /// Inherited. Read property data from string representation and set value of the invoking object based on this value.
        /// </summary>
        /// <param name="str">The string.</param>
        public override void ParseToSelf(string str)
        {
            SetDefaultValue();
        }

        /// <summary>
        /// Inherited. Set default value for this property.
        /// </summary>
        protected override void SetDefaultValue()
        {
            this.Value = string.Empty;
        }

        /// <summary>
        /// Inherited. Creates an IPropertyControl that is used to display a user interface for the property.
        /// </summary>
        /// <returns>An <see cref="T:EPiServer.Core.IPropertyControl" /> that is used to display a user interface for the property.</returns>
        /// <remarks>It is possible to change which control should be used by registering a different <see cref="T:EPiServer.Core.IPropertyControl" /> for the <see cref="T:EPiServer.Core.PropertyData" /> class in <see cref="T:EPiServer.Core.PropertyControlClassFactory" />.</remarks>
        public override EPiServer.Core.IPropertyControl CreatePropertyControl()
        {
            //Create an instance of MyCustomPropertyControl which is used for displaying the property.
            return new DividerPropertyControl();
        }
    }


    //[PropertyDefinitionTypePlugIn(DisplayName = "Divider",
    //     Description = "Edit-mode divider with headline and description")]

    /// <summary>
    /// PropertyControl implementation used for rendering Divider.
    /// </summary>
    public class DividerPropertyControl : PropertyDataControl
    {
        #region Divider
        /// <summary>
        /// Gets the Divider instance for this IPropertyControl.
        /// </summary>
        /// <value>The property that is to be displayed or edited.</value>
        public DividerProperty Divider
        {
            get
            {
                return PropertyData as DividerProperty;
            }
        }
        #endregion

        public override bool SupportsOnPageEdit
        {
            get
            {
                return false;
            }

        }

        #region CreateEditControls
        /// <summary>
        /// Empty
        /// </summary>
        //public override void CreateEditControls()
        //{
        //    Controls.Add(new Label() { });
        //}
        #endregion

        #region ApplyEditChanges
        /// <summary>
        /// We do nothing since we use the default valus to point out which properties to Collapse
        /// </summary>
        public override void ApplyEditChanges()
        {

        }
        #endregion

        #region CreateDefaultControls

        /// <summary>
        /// Should only be rendered in edit mode
        /// </summary>
        public override void CreateDefaultControls()
        {
            var ctrl = new HtmlGenericControl { InnerHtml = "" };
            Controls.Add(ctrl);
        }
        #endregion

        public override TableRowLayout RowLayout
        {
            get
            {
                return TableRowLayout.Wide;
            }
        }
    }
}