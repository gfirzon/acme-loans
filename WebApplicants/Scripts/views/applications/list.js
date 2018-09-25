$(function () {
    console.log("Applications list is ready!");

    var params = {
    };

    let data = jQuery.param(params);

    var ajaxparam = {
        method: "GET",
        url: '/Applications/GetApplicationList', 
        data: data,
        dataType: 'json',
        success: function (response) {

            createLoansTable(response);
        },
        error: function (xhr) {

        }
    };

    $.ajax(ajaxparam);

    function createLoansTable(list) {

        var template = $('#templateTable').html();
        var r = Mustache.render(template, list);
        $("#tableContainer").html(r);
    }


});