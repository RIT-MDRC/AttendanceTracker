// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

Date.prototype.addHours = function (h) {
    var date = new Date();
    date.setTime(this.getTime() + (h * 60 * 60 * 1000));
    return date;
}

function GetSelectedRow(dt) {
    let selectedRows = dt.rows({ selected: true }).data();
    if (selectedRows > 1) {
        alert("Error: More than one row was selected. Please select one at a time.")
        return;
    }
    return selectedRows[0];
}
function decodeHtml(html) {
    return $('<div>').html(html).text();
}

function copyElementText(element) {
    var emailText = element.val();

    navigator.clipboard.writeText(emailText);
}