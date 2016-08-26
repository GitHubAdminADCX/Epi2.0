define([
    "dojo/_base/declare",
    "dojo/_base/lang",

    "epi/shell/layout/SimpleContainer"
],
function (
    declare,
    lang,

    SimpleContainer
) {

    return declare([SimpleContainer], {
        countryDropdown: null,
        regionDropdown: null,

        addChild: function (child) {
            // Summar: Add a widget to the container

            this.inherited(arguments);

            if (child.name.indexOf("country") >= 0) {
                // If it's the country drop down list
                this.countryDropdown = child;

                // Connect to change event to update the region drop down list
                this.own(this.countryDropdown.on("change", lang.hitch(this, this._updateRegionDropdown)));
            } else if (child.name.indexOf("region") >= 0) {
                // If it's the region drop down list
                this.regionDropdown = child;

                // Update the region drop down
                this._updateRegionDropdown(this.countryDropdown.value);
            }
        },

        _updateRegionDropdown: function (country) {
            // Summary: Update the region drop down list according to the selected country

            // Clear the current value
            this.regionDropdown.set("value", null);

            // Set the filter
            this.regionDropdown.set("filter", function (region) {
                // Oops, the region code is prefixed with country code, for the simplicity
                return region.value.indexOf(country) === 0;
            });
        }
    });
});