$(function () {
    var applicantId = null;
    console.log("Applicant edit is ready!");

    var params = {
        id: $('#hdnAppId').val()
    };

    let data = jQuery.param(params);

    var ajaxparam = {
        method: "GET",
        url: '/Applicants/GetApplicantById',
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

        applicantId = app.ApplicantId;

        $('#txtSSN').val(app.SSN);

    }


});