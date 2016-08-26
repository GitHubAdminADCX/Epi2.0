define([
    "dojo/_base/declare",
    "dijit/_Widget",
    "dijit/_TemplatedMixin",
    'dojo/text!./templates/DojoProperty.html',
],
function (
    declare,
    _Widget,
    _TemplatedMixin,
    template
) {
    return declare("jondjones.CustomProperty.DojoProperty", [
        _Widget,
        _TemplatedMixin], {
            templateString: '<div > \
                        <input type="email" data-dojo-attach-point="email" data-dojo-attach-event="onchange:_onChange" id="txtvalid" /> \</div>',

            postCreate: function () {
                // summary:
                //    Set the value to the textbox after the DOM fragment is created.
                // tags:
                //    protected

                this.set('value', this.value);

                if (this.intermediateChanges) {
                    this.connect(this.email, 'onkeydown', this._onIntermediateChange);
                    this.connect(this.email, 'onkeyup', this._onIntermediateChange);
                }
            },

            focus: function () {
                // summary:
                //    Put focus on this widget.
                // tags:
                //    public

                dijit.focus(this.email);
            },

            isValid: function () {
                // summary:
                //    Indicates whether the current value is valid.
                // tags:
                //    public

                var emailRegex = '[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+';
                if (!this.required) {
                    emailRegex = '(' + emailRegex + ')?';
                }
                var regex = new RegExp('^' + emailRegex + '$');
                if (this.value == "" || this.value == null || this.value == "NaN" || this.value == undefined)
                {
                    return ;
                }
                var check = regex.test(this.value);
                if (check == false) {
                    $("#test").remove();
                    $("#txtvalid").after('<div id="test" style="float:right;margin-right:1250px"> Hi </div>');

                } else {
                    $("#test").remove();
                    return regex.test(this.value);
                }
                
            },

            onChange: function (value) {
                // summary:
                //    Called when the value in the widget changes.
                // tags:
                //    public callback               
            },

            _onIntermediateChange: function (event) {
                // summary:
                //    Handles the textbox key press events event and populates this to the onChange method.
                // tags:
                //    private

                if (this.intermediateChanges) {
                    this._set('value', event.target.value);
                    this.onChange(this.value);

                }
            },

            _onChange: function (event) {
                // summary:
                //    Handles the textbox change event and populates this to the onChange method.
                // tags:
                //    private

                this._set('value', event.target.value);
                this.onChange(this.value);

            },

            
            _setValueAttr: function (value) {
                // summary:
                //    Sets the value of the widget to "value" and updates the value displayed in the textbox.
                // tags:
                //    private

                this._set('value', value);
                this.email.value = this.value || '';

            }
        }
        );
});