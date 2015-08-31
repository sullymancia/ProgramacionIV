$(document).ready(function () {

    console.log("Create department form script");

    var $departmentIdInput     = $("#departmentID");
    var $departmentNameInput   = $("#departmentName");
    var $departmentActiveInput = $("#departmentActive");
    var $departmentSubmit      = $("#submitDepartment");

    console.log($departmentIdInput);
    console.log($departmentNameInput);
    console.log($departmentActiveInput);
    console.log($departmentSubmit);

    //on submit form clicked
    $departmentSubmit.click(function (e) {
        e.preventDefault();

        console.log("Submit department was clicked");

        var departmentID = $departmentIdInput.val();
        var departmentName = $departmentNameInput.val();
        var active = $departmentActiveInput.is(':checked') ? 1 : 0;

        console.log('$departmentIdInput : ' + departmentID);
        console.log('$departmentNameInput : ' + departmentName);
        console.log('$departmentActiveInput : ' + active);

        //posting department Form
        var urlCreateForm = 'http://localhost:1755/Form/crearDepartamento';
        var ajaxRequestDepartment = $.post(
            urlCreateForm,
            {
                ID: departmentID,
                descripcion: departmentName,
                activo: active
            },
            function () {
                console.log("Department posted");
            });
    });
});