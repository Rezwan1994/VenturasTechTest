$(document).ready(function () {
    if (window.innerWidth < 500) {
        $("#mySidebar").width("0px")
    }
    else {
        $("#mySidebar").width("250px")
        $("#main").width(window.innerWidth - 290)
    }

    //document.getElementById("main").style.marginRight = "250px";
    //$("#main").width(window.innerWidth - 250);
})
function ExpandCloseNav() {
    if ($(".openbtn").hasClass("open")) {
        $(".openbtn").removeClass("open");
        document.getElementById("mySidebar").style.width = "250px";
        $("#main").width(window.innerWidth - 290);
        //document.getElementById("main").style.marginRight = "250px";
        //$("#main").width(window.innerWidth - $("#mySidebar").width());
    }
    else {
        $(".openbtn").addClass("open");

        document.getElementById("mySidebar").style.width = "0";
        $("#main").width(window.innerWidth - 80);
        //document.getElementById("main").style.marginRight = "0";
        //$("#main").width(window.innerWidth - $("#mySidebar").width());

    }

}