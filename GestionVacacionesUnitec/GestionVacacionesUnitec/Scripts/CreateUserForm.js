$(document).ready(function () {

    var $talentoHumanoInput      = $("#talentoHumano");
    var $emailInput              = $("#email");
    var $passwordInput           = $("#password");
    var $firstNameInput          = $("#firstName");
    var $middleNameInput         = $("#middleName");
    var $lasNameInput            = $("#lastName");
    var $secondLastNameInput     = $("#secondLastName");
    var $signUpDateInput         = $("#signUpDate");
    var $employmentDateInput     = $("#employmentDate");
    var $activeInput             = $("#active");
    var $submitUserButton        = $("#submitUser");
    var $roleCheckBoxes          = $(".role");
    var $departmentCheckBoxes    = $(".department");
    var serializedDepartmentList = "";
    var departments              = [];
    var currentSessionId;

    console.log("Datepicker checkpoint");
    console.log($signUpDateInput);
    console.log($employmentDateInput);

  /*  $signUpDateInput.datepicker();

    $employmentDateInput.datepicker({
        format: 'dd/mm/yyyy',
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });*/

    //Retrieve session
    /*var url = 'http://localhost:1755/Form/getSession';
    var ajaxRequestForSession = $.post(url, function (session) {

        console.log("Session name : " + session.name);
        console.log("Session ID : " + session.talentoHumano);
        currentSessionId = session.talentoHumano;

    });*/

    //Retrieve active departments
    var url = 'http://localhost:1755/Form/getDepartamentos';
    var ajaxRequestForSession = $.post(url, function (data) {
        serializedDepartmentList = data.serializedData;
        departments = serializedDepartmentList.split('~');
        console.log("departments array : " + departments);
    });

    


    //on submit form clicked
    $submitUserButton.click( function (e) {
        e.preventDefault();
        console.log("Current Session ID : " + currentSessionId);

        // Get values from first form
        var talentoHumano  = $talentoHumanoInput.val();
        var email          = $emailInput.val();
        var password       = $passwordInput.val();
        var firstName      = $firstNameInput.val();
        var middleName     = $middleNameInput.val();
        var lastname       = $lasNameInput.val();
        var secondLastName = $secondLastNameInput.val();
        var signUpDate     = $signUpDateInput.val();
        var employmentDate = $employmentDateInput.val();
        var active         = $activeInput.is(':checked') ? 1 : 0;


        // Get values from second form
        var roles       = "";
        var departments = "";

        var numberOfRoles = 0;
        var numberOfDepartments = 0;

        $roleCheckBoxes.each(function (index) {
            $thisCheckBox = $(this);
            if ($thisCheckBox.is(':checked'))
            {
                if (numberOfRoles != 0)
                    roles += "~";
                roles += $thisCheckBox.attr("name");
                numberOfRoles++;
            }
        });

        // Get values from third form
        $departmentCheckBoxes.each(function (index) {
            $thisCheckBox = $(this);
            if ($thisCheckBox.is(':checked')) {
                if (numberOfDepartments != 0)
                    departments += "~";
                departments += $thisCheckBox.attr("name");
                numberOfDepartments++;
            }
        });

        console.log("--------------------------");

           //posting User Creation Form
           var urlCreateUser = ' http://localhost:1755/Form/crearUser';
           var ajaxRequest = $.post(
               urlCreateUser,
               {
                   talentoH: talentoHumano,
                   correo: email,
                   password: password,
                   nombre1: firstName,
                   nombre2: middleName,
                   apellido1: lastname,
                   apellido2: secondLastName,
                   fechaIngreso: employmentDate,
                   fechaCreacion: signUpDate,
                   activo: active
               },
              function (data) {
                  console.log("Talento Humano : " + talentoHumano);
                  console.log("Email : " + email);
                  console.log("Password : " + password);
                  console.log("First Name : " + firstName);
                  console.log("Middle Name : " + middleName);
                  console.log("Last Name : " + lastname);
                  console.log("Second Last Name : " + secondLastName);
                  console.log("Creation Date : " + employmentDate);
                  console.log("Sign Up Date : " + signUpDate);
                  console.log("Active User : " + active);    
       });
        
        
        //posting Roles Form
           var urlCreateUserRole = ' http://localhost:1755/Form/Usuario_Rol';
           var ajaxRequestRoles = $.post(
           urlCreateUserRole,
           {
               Talento_Humano: talentoHumano,
               descripcion_rol: roles
           },
           function () {
               console.log("Talento Humano Roles : " + talentoHumano);
               console.log("Roles : " + roles);
        });

        //posting Departments Form
           var urlCreateUserDepartment = ' http://localhost:1755/Form/Usuario_Departamento';
           var ajaxRequestDepartment = $.post(
           urlCreateUserDepartment,
           {
               Talento_Humano: talentoHumano,
               descripcion_departamento: departments
           },
           function () {
               console.log("Talento Humano Department : " + talentoHumano);
               console.log("Departments : " + departments);
        });
    });
});





                  
   