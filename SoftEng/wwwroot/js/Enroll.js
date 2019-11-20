var changeClass = function () {
    var classId = $("#selectClass").val();
    $.ajax({
        type: "POST",
        url: fullUrl + "GetClassById",
        data: {
            id: classId
        },
        error: function (result) {
            alert("There is a Problem, Try Again! ");
        },
        success: function (result) {
            //put result on page
            $("#location").html(result.location);
            var startDate = new Date(result.startDate);
            var endDate = new Date(result.endDate);
            $("#dateRange").html(startDate.getMonth().toString() + "/" + startDate.getDate().toString() + "/" + "20" + startDate.getYear() % 100 + "-" + endDate.getMonth().toString() + "/" + endDate.getDate().toString() + "/" + "20" + endDate.getYear() % 100);
            //$("#dateRange").html(result.startDate.getDate().toString() + "-" + result.endDate.getDate().toString());
            var daysOfWeek = "";
            for (var i = 0; i < result.classDay.length; i++) {
                if (daysOfWeek == "") {
                    daysOfWeek = daysOfWeek + result.classDay[i].day.day1;
                } else {
                    daysOfWeek = daysOfWeek + ", " + result.classDay[i].day.day1;
                }
            }
            $("#daysOfWeek").html(daysOfWeek);
            $("#timeSpan").html(result.time.toString());
        }
    });
};