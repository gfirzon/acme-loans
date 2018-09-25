$(function () {
    var applicationId = null;
    console.log("Applications edit is ready!");

    var params = {
        id: $('#hdnAppId').val()
    };

    let data = jQuery.param(params);

    var ajaxparam = {
        method: "GET",
        url: '/Applications/GetApplicationById',
        data: data,
        dataType: 'json',
        success: function (response) {

            populateFields(response);
        },
        error: function (xhr) {

        }
    };

    $.ajax(ajaxparam);

    function populateFields(app) {

        applicationId = app.ApplicationId;

        $('#txtAmount').val(app.Amount);
        
    }


});