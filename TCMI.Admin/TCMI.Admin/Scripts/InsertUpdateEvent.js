
$(document).ready(function () {
    $("input[type=text]").addClass("form-control");
    $("select").addClass("form-control");
    $("textarea").addClass("form-control")
    $("input[type=datetime]").addClass("form-control");
    $("span").addClass("text-danger");



    $("#Title").attr("placeholder", "Title");
    $("#Description").attr("placeholder", "Description");
    $("#Venue").attr("placeholder", "Venue");
    $("#DateOfEvent").attr("placeholder", "Date");
    $("#Time").attr("placeholder", "Time");


});