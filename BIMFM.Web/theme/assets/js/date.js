/*
Template Name: Color Admin - Responsive Admin Dashboard Template build with Twitter Bootstrap 3.3.7 & Bootstrap 4.0.0-Alpha 6
Version: 3.0.0
Author: Sean Ngu
Website: http://www.seantheme.com/color-admin-v3.0/admin/html/
*/

// IE8 browser support
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function(elt /*, from*/) {
        var len = this.length >>> 0;
        var from = Number(arguments[1]) || 0;
        from = (from < 0) ? Math.ceil(from) : Math.floor(from);
        if (from < 0)
            from += len;

        for (; from < len; from++) {
            if (from in this && this[from] === elt)
                return from;
        }
        return -1;
    };
}
if(typeof String.prototype.trim !== 'function') {
    String.prototype.trim = function() {
        return this.replace(/^\s+|\s+$/g, '');
    }
}


var handleDatepicker = function() {
    $('#datepicker-disabled-past1').datepicker({
        todayHighlight: true
    });
    $('#datepicker-disabled-past2').datepicker({
        todayHighlight: true
    });
    $('#datepicker-disabled-past3').datepicker({
        todayHighlight: true
    });
    $('#datepicker-disabled-past4').datepicker({
        todayHighlight: true
    });
    $('#datepicker-disabled-past5').datepicker({
        todayHighlight: true
    });
    $('#datepicker-disabled-past6').datepicker({
        todayHighlight: true
    });

};


var FormPlugins = function () {
    "use strict";
    return {
        //main function
        init: function () {
            handleDatepicker();
        }
    };
}();