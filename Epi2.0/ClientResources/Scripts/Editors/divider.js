/*
Dojo widget for editing a list of strings. Also see property type PropertyStringList in /Models/Properties.
*/

define([
    "dojo/_base/array",
    "dojo/_base/connect",
    "dojo/_base/declare",
    "dojo/_base/lang",

    "dijit/_CssStateMixin",
    "dijit/_Widget",
    "dijit/_TemplatedMixin",
    "dijit/_WidgetsInTemplateMixin",

    "dijit/form/Textarea",

    "epi/epi",
    "epi/shell/widget/_ValueRequiredMixin"
],
function (
    array,
    connect,
    declare,
    lang,

    _CssStateMixin,
    _Widget,
    _TemplatedMixin,
    _WidgetsInTemplateMixin,

    Textarea,
    epi,
    _ValueRequiredMixin
) {

    return declare("custom.editors.divider", [_Widget, _TemplatedMixin, _WidgetsInTemplateMixin, _CssStateMixin, _ValueRequiredMixin], {


        templateString: "<div>\
                            <div data-dojo-attach-point=\"contentName\"></div>\
                        </div>",

        contextChanged: function (context, callerData) {
            this.inherited(arguments);

            // the context changed, probably because we navigated or published something
            html.set(this.contentName, context.name);
        }
    });
});