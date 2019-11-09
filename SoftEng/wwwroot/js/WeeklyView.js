
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