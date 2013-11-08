/*
* jQuery File Upload Plugin JS Example 5.0.2
* https://github.com/blueimp/jQuery-File-Upload
*
* Copyright 2010, Sebastian Tschan
* https://blueimp.net
*
* Licensed under the MIT license:
* http://creativecommons.org/licenses/MIT/
*/

/*jslint nomen: true */
/*global $ */

$(function () {
    'use strict';
    var parameter = window.location.search.replace("?", ""); // will return the GET parameter 
    var parameter = parameter.replace("&", "=");
    var requrl = 'FileTransferHandler.ashx?';
    var values = parameter.split("=");
    for (var i = 0; i < values.length; i++) {
        if (values[i] == 'id') {
            requrl += "&id=";
            requrl += values[i + 1];
        }
    }


    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload({
        url: requrl
    });

    // Load existing files:
    $.ajax({
        url: $('#fileupload').fileupload('option', 'url'),
        dataType: 'json',
        context: $('#fileupload')[0]
    }).done(function (result) {
        $(this).fileupload('option', 'done').call(this, null, { result: result });
    });

    // Open download dialogs via iframes,
    // to prevent aborting current uploads:
    $('#fileupload .files a:not([target^=_blank])').live('click', function (e) {
        e.preventDefault();
        $('<iframe style="display:none;"></iframe>')
            .prop('src', this.href)
            .appendTo('body');
    });

});