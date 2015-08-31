$(document).ready(function () {
    console.log("Dash board loaded");


    var $WelcomeParagraph = $("#welcome");
    var currentSession;
   

    var url = 'http://localhost:1755/Home/getSession';
    var ajaxRequestForSession = $.post(url , function (session) {

        console.log("Session name : " + session.name);
        console.log("Session ID : " + session.talentoHumano);
        currentSession = session;
        $WelcomeParagraph.append(session.name + " " + session.lastName);

        var urlForRoles = 'http://localhost:1755/Home/getRolesPorUsuario'
        var ajaxRequestForRoles = $.post(urlForRoles, { talento_humano: session.talentoHumano }, function (roles) {
            console.log("----------------------------");
            console.log(roles.roles);
        });


    });

    
    
    
   
});