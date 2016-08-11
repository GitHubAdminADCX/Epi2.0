define([
    "dojo/_base/connect",
    "dojo/_base/declare",
    "dojo/_base/lang",

    "dijit/registry",

    "dijit/_Widget",
    "dijit/_Container",
    "epi/cms/widget/_HasChildDialogMixin",

    "dijit/form/TextBox",
    "dijit/form/NumberTextBox",
    "dijit/form/CheckBox",
    "dijit/form/Button",
    "dijit/layout/ContentPane",
    "dojox/layout/TableContainer",
    "epi/cms/widget/ContentSelector",
    "epi-cms/widget/FileSelector",
    "epi-cms/widget/UrlSelector",

    "epi/dependency"
], function (
    connect,
    declare,
    lang,
    registry,

    _Widget,
    _Container,
    _HasChildDialogMixin,

    TextBox,
    NumberTextBox,
    CheckBox,
    Button,
    ContentPane,
    TableContainer,
    ContentSelector,
    FileSelector,
    UrlSelector,
    dependency
) {
    return declare("custom.LinksCustomProperty.LinksProperty", [_Widget, _Container, _HasChildDialogMixin], {
        contentPane: null,
        //startPageRef: null,

        postCreate: function () {
            var self = this;
            if (this.value == null) {
                this.value = [];
            }

            //jQuery.ajax({
            //    url: '/sllapi/content/GetStartPageReference',
            //    type: 'GET',
            //    success: function (result) {
            //        self.startPageRef = result;
            //    },
            //    async: false
            //});

            this.contentPane = new ContentPane({
                style: "width: 100%",
                class: "table-container"
            });

            var newBtn = new Button({
                label: "Add Links",
                style: "margin: 0 0 10px 0;",
                iconClass: "epi-iconPlus epi-primary",
                onClick: lang.hitch(this, "_addRow")
            });

            this.contentPane.addChild(newBtn);
            this.contentPane.placeAt(this.containerNode);
        },


        _addRow: function (val) {
            var layouts = registry.findWidgets(this.contentPane.domNode);
            if (layouts.length <= 6) {
                var layout = new TableContainer({
                    cols: 5,
                    showLabels: true,
                    orientation: "vert",
                    customClass: ""
                });

                var urlTextBox = new TextBox({
                    label: "Link",
                    title: "Link",
                    style: "width: 200px",
                    placeholder: "Link",
                    required: false
                });

                var linkTextBox = new TextBox({
                    label: "LinkText",
                    title: "LinkText",
                    style: "width: 200px",
                    placeholder: "LinkText",
                    required: false
                });

                var currentPage = window.location.href.split('///')[1];
                var fileSelector = new FileSelector({
                    title: "Icon",
                    fileBrowserMode: "image",
                    contentLink: currentPage,
                    parentLink: currentPage,
                    resourceFolderId: currentPage
                });
                this.connect(fileSelector, '_showDialog', '_onDialogShow');
                this.connect(fileSelector, '_onHide', '_onDialogHide');

                var removeBtn = new Button({
                    label: "Remove",
                    showLabel: false,
                    iconClass: "epi-iconTrash",
                    onClick: lang.hitch(this, "_removeRow")
                });

                if (val != null) {
                    urlTextBox.set("value", val.link);
                    fileSelector.set("value", val.image);
                    linkTextBox.set("value", val.linkText);
                }
                layout.addChild(urlTextBox);//0
                layout.addChild(linkTextBox);//1
                layout.addChild(fileSelector);//2
                layout.addChild(removeBtn);//3

                this.contentPane.addChild(layout);
            }
        },

        _onDialogShow: function () {
            this.isShowingChildDialog = true;
        },

        _onDialogHide: function () {
            this.isShowingChildDialog = false;
        },

        _removeRow: function (e) {
            var button = registry.getEnclosingWidget(e.srcElement);
            var layout = button.getParent();
            layout.destroyRecursive();
        },

        _getValueAttr: function () {
            var val = [];
            var layouts = registry.findWidgets(this.contentPane.domNode);

            for (var i = 0; i < layouts.length; i++) {
                var widgets = registry.findWidgets(layouts[i].domNode);
                if (widgets.length === 4) {
                    var item = {
                        Link: widgets[0].value || "",
                        LinkText: widgets[1].value || "",
                        Image: objectFileLink = widgets[2].value || ""
                    }
                    val.push(item);
                }
            }
            return val;
        },

        _setValueAttr: function (val) {
            this._set('value', val);
            if (val != null) {
                for (var i = 0; i < val.length; i++) {
                    this._addRow(val[i]);
                }
            }
        }
    });
});
