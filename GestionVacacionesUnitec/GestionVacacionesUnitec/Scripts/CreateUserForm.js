$(document).ready(function () {

    $talentoHumanoInput  = $("#talentoHumano");
    $emailInput          = $("#email");
    $passwordInput       = $("#password");
    $firstNameInput      = $("#firstName");
    $middleNameInput     = $("#middleName");
    $lasNameInput        = $("#lastName");
    $secondLastNameInput = $("#secondLastName");
    $signUpDateInput     = $("#signUpDate");
    $employmentDateInput = $("#employmentDate");
    $activeInput         = $("#active");
    $submitUserButton    = $("#submitUser");


    //on submit form clicked
    $submitUserButton.on('click', function (e) {
        e.preventDefault();

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

        console.log("--------------------------");


           var url = ' http://localhost:1755/TestForService/crearUser';
           var ajaxRequest = $.post(
               url,
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
                   activo : active
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
    });

});


//Roles
/*
$roleCheckbox        = $(".roleCheckbox:checked");
var roles = {};
roleCheckbox.each( function(index){
var $thisCheckbox = $(this);
var role          = $thisCheckbox.val()
roles.push(role);
console.log("Role : " + role + " | index : " + );
});
*/
