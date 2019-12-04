var startDate;
var endDate;
window.onload = function () {
    startDate = new Date();
    endDate = new Date();
    var day = startDate.getDay() * -1;
    startDate.setTime(startDate.getTime() + day * 86400000);
    endDate.setTime(startDate.getTime() + 6 * 86400000);
    $("#startDate").html(startDate.getMonth() + 1 + "/" + startDate.getDate() + "/" + startDate.getFullYear());
    $("#endDate").html(endDate.getMonth() + 1 + "/" + endDate.getDate() + "/" + endDate.getFullYear());
}

function back() {
    startDate.setTime(startDate.getTime() + -7 * 86400000);
    endDate.setTime(endDate.getTime() + -7 * 86400000);
    $("#startDate").html(startDate.getMonth() + 1 + "/" + startDate.getDate() + "/" + startDate.getFullYear());
    $("#endDate").html(endDate.getMonth() + 1 + "/" + endDate.getDate() + "/" + endDate.getFullYear());
}

function forward() {
    debugger;
    startDate.setTime(startDate.getTime() + 7 * 86400000);
    endDate.setTime(endDate.getTime() + 7 * 86400000);
    $("#startDate").html(startDate.getMonth() + 1 + "/" + startDate.getDate() + "/" + startDate.getFullYear());
    $("#endDate").html(endDate.getMonth() + 1 + "/" + endDate.getDate() + "/" + endDate.getFullYear());
}

function requestWeek() {
    var startDate = new Date();
    var endDate = new Date();
    $.ajax({
        type: "POST",
        url: fullUrl + "RequestWeekly",
        data: {
            start: startDate,
            end: endDate
        },
        error: function (result) {
            alert("There is a Problem, Try Again! ");
        },
        success: function (result) {
            if (result.status == true) {
                alert("success!");
            }
            else {
                alert(result.message);
            }
        }
    });
}