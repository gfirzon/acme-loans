$(function () {
    console.log("Applicants list is ready!");

    var params = {
    };

    let data = jQuery.param(params);

    var ajaxparam = {
        method: "GET",
        url: '/Applicants/GetApplicantList',
        data: data,
        dataType: 'json',
        success: function (response) {

            createEmployeesTable(response);
        },
        error: function (xhr) {

        }
    };

    $.ajax(ajaxparam);

    function createEmployeesTable(list) {

        var template = $('#templateTable').html();
        var r = Mustache.render(template, list); //mergedl template with data
        $("#tableContainer").html(r);
    }


});