$(document).ready(function () {
    console.log("Dash board loaded");

    var url = 'http://localhost:1755/Home/getSession'
    var ajaxRequest = $.post(url , function (session) {

        console.log("Session name : " + session.name);
        
    });
});