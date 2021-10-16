var SaveUserInfo = function () {
    var url = "/Home/SaveUserInfo";
    var param = JSON.stringify({
        Title: $(".title").val(),
        Address: $(".address").val(),
        Type: $("#userType").val(),
        Date: $(".date").val(),
        Time: $(".time").val(),
        Remarks: $(".remarks").val()

    });

    $.ajax({
        type: "POST",
        url: url,
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            console.log(data);
            if (data) {
                $(".title").val(""),
                    $(".address").val(""),
                    $("#userType").val("-1"),
                    $(".date").val(""),
                    $(".time").val(""),
                    $(".remarks").val("")
            }
            $("#GridView").load("/Home/UserList")
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    })

}
var SaveUserList = function () {
    var url = "/Home/SaveUserList";


    $.ajax({
        type: "POST",
        url: url,

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            console.log(data);
            if (data) {
                alert("Userlist saved successfully!")
                $("#GridView").load("/Home/UserList")
            }

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    })

}
var DeleteUser = function (id) {
    var url = "/Home/DeleteUser";
    var param = JSON.stringify({
        Id: id,
    });

    $.ajax({
        type: "POST",
        url: url,
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            console.log(data);

            $("#GridView").load("/Home/UserList?searchKey=null")
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    })
}
var GetUserFilteredList = function (searchKey) {
    $("#GridView").load("/Home/UserList?searchKey=" + searchKey)
}
var CloseTooltip = function () {
    console.log("sdfds")
    $(".itemtooltip").addClass("notApear");
    $(".itemtooltip").css("opacity", "0");
}
$(document).ready(function () {

    $(".show-tt").click(function () {

        if ($(".itemtooltip").hasClass("notApear")) {
            $(".itemtooltip").removeClass("notApear");
            $(".itemtooltip").css("opacity", "100");
            setTimeout(function () {
                $(".itemtooltip").addClass("notApear");
                $(".itemtooltip").css("opacity", "0");
            }, 30000);
        }
        else {

            $(".itemtooltip").addClass("isApear");
            $(".itemtooltip").css("opacity", "0");
        }

    })
    var Time = '00:00:01';

    $(".date").datepicker({
        format: "dd-mm-yyyy",
        autoclose: true

    });
    var timepicker = {
        now: Time,
        title: 'Time'
    };
    $('.time').wickedpicker(timepicker);

    $("#GridView").load("/Home/UserList?searchKey=null")
    $(".Search").keyup(function () {
        var SearchKey = $(".Search").val();
        GetUserFilteredList(SearchKey);
    })
    $("#saveInfo").click(function () {
        if ($(".title").val() != "" && $(".date").val() != "" && $(".time").val() != "") {
            SaveUserInfo();
        }
        else {
            alert("Fill up the required fields");
        }

    })

    $("#saveList").click(function () {
        console.log("sdfsdf");
        SaveUserList();
    })


})