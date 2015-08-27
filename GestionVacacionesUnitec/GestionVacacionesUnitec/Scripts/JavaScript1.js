$(document).ready(function () {

    
    $("#btn").on("click", function () {
        var email = $("#email").val();
        var pass = $("#password").val();
        console.log("Email input : " + email);
        console.log("Password input : " + pass);
        
        var jqxhr = $.post("http://localhost:1755/TestForService/crearUser", { email: email, password: pass }, function (data) {
            console.log("Server returned : " + data)
        })
        .done(function (data) {
            alert("Server returned : " + data);
        })
        .fail(function () {
            alert("error");
        })
        .always(function () {
           
        });
    });



});