///<reference path="jquery-1.3.2-vsdoc.js>
///<reference path="tablesorter.js>
//the above allows for full jquery intellisense, to see it type '$(' to see for yourself!

//the jquery ready, any scripts here will run as soon as the DOM is ready at page load time
$(document).ready(function() {

    //nav menu tabs
    $("#tabs").tabs({ event: 'mouseover' });

    //intercept the default behavior of the aspnet login link
    $("a:contains('Login')").attr({
        href: "Login.aspx?height=140&width=215&modal=true",
        title: "Login"
    }).addClass('thickbox');
    
    $("a:contains('Not a member?')").attr({
        href: "UserRegistration.aspx?height=470&width=300&modal=true",
        title: "UserRegistration"
    }).addClass('thickbox');
    
//    $("a:contains('My Account')").attr({
//        href: "ViewProfile.aspx?height=400&width=300&modal=true",
//        title: "ViewProfile"
//    }).addClass('thickbox');

    //call tablesorter plugin on all gv's with tablesorter class
    $(".tablesorter").tablesorter();

    // code examples
    $(".popup").click(function(event) {
        alert("Thanks for visiting My Pet Store");
    });

    $("#doStuff").click(function() {
        DoStuff('You did some stuff');
    });




});     //end of doc.ready

//-----------------------------Misc Functions----------------------------------------------
//i often call functions from doc ready events, they'll go here
function DoStuff(v) {
    alert(v);
}


