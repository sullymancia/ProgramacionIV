$(document).ready(function () {

    console.log("Create role form script");

    var $roleIdInput     =  $("#roleID");
    var $roleNameInput   =  $("#roleName");
    var $roleActiveInput =  $("#roleActive");
    var $roleSubmit      =  $("#submitRole");

    console.log($roleIdInput);
    console.log($roleNameInput);
    console.log($roleActiveInput);
    console.log($roleSubmit);

    //on submit form clicked
        $roleSubmit.click(function (e) {
        e.preventDefault();

        console.log("Submit role was clicked");

        var roleID   = $roleIdInput.val();
        var roleName = $roleNameInput.val();
        var active   = $roleActiveInput.is(':checked') ? 1 : 0;

        console.log('$roleIdInput : ' + roleID );
        console.log('$roleNameInput : ' + roleName );
        console.log('$roleActiveInput : ' + active);

        //posting Role Form
        var urlCreateForm = ' http://localhost:1755/Form/crearRol';
        var ajaxRequestDepartment = $.post(
        urlCreateForm,
        {
            ID: roleID,
            descripcion: roleName,
            activo : active
        },
        function () {
            console.log("Role posted");
        });
    });
});


