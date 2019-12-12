var startDate;
var endDate;
var resetContent;
window.onload = function () {
    resetContent = $(".table-responsive").html();
    startDate = new Date();
    endDate = new Date();
    var day = startDate.getDay() * -1;
    startDate.setTime(startDate.getTime() + day * 86400000);
    endDate.setTime(startDate.getTime() + 6 * 86400000);
    $("#startDate").html(startDate.getMonth() + 1 + "/" + startDate.getDate() + "/" + startDate.getFullYear());
    $("#endDate").html(endDate.getMonth() + 1 + "/" + endDate.getDate() + "/" + endDate.getFullYear());
    this.getEventsByTime();
}

function back() {
    startDate.setTime(startDate.getTime() + -7 * 86400000);
    endDate.setTime(endDate.getTime() + -7 * 86400000);
    $("#startDate").html(startDate.getMonth() + 1 + "/" + startDate.getDate() + "/" + startDate.getFullYear());
    $("#endDate").html(endDate.getMonth() + 1 + "/" + endDate.getDate() + "/" + endDate.getFullYear());
    getEventsByTime();
}

function forward() {
    startDate.setTime(startDate.getTime() + 7 * 86400000);
    endDate.setTime(endDate.getTime() + 7 * 86400000);
    $("#startDate").html(startDate.getMonth() + 1 + "/" + startDate.getDate() + "/" + startDate.getFullYear());
    $("#endDate").html(endDate.getMonth() + 1 + "/" + endDate.getDate() + "/" + endDate.getFullYear());
    getEventsByTime();
}

function resetWeek() {
    $(".table-responsive").html(resetContent);
}

function getEventsByTime() {
    var i = 0;
    while (i <= 23) {
        setDay(i, i, 's', "", "");
        setDay(i, i, 'm', "", "");
        setDay(i, i, 't', "", "");
        setDay(i, i, 'w', "", "");
        setDay(i, i, 'th', "", "");
        setDay(i, i, 'f', "", "");
        setDay(i, i, 'sa', "", "");
        i++;
    }
    requestWeek(startDate.toISOString(), endDate.toISOString());
}

function setDay(value, timeEnd, day, jClass, name) {
    if (value <= 0 && 0 <= timeEnd) {
        $('#12am > #' + day).removeClass();
        $('#12am > #' + day).addClass(jClass);
        $('#12am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 1 && 1 <= timeEnd) {
        $('#1am > #' + day).removeClass();
        $('#1am > #' + day).addClass(jClass);
        $('#1am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 2 && 2 <= timeEnd) {
        $('#2am > #' + day).removeClass();
        $('#2am > #' + day).addClass(jClass);
        $('#2am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 3 && 3 <= timeEnd) {
        $('#3am > #' + day).removeClass();
        $('#3am > #' + day).addClass(jClass);
        $('#3am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 4 && 4 <= timeEnd) {
        $('#4am > #' + day).removeClass();
        $('#4am > #' + day).addClass(jClass);
        $('#4am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 5 && 5 <= timeEnd) {
        $('#5am > #' + day).removeClass();
        $('#5am > #' + day).addClass(jClass);
        $('#5am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 6 && 6 <= timeEnd) {
        $('#6am > #' + day).removeClass();
        $('#6am > #' + day).addClass(jClass);
        $('#6am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 7 && 7 <= timeEnd) {
        $('#7am > #' + day).removeClass();
        $('#7am > #' + day).addClass(jClass);
        $('#7am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 8 && 8 <= timeEnd) {
        $('#8am > #' + day).removeClass();
        $('#8am > #' + day).addClass(jClass);
        $('#8am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 9 && 9 <= timeEnd) {
        $('#9am > #' + day).removeClass();
        $('#9am > #' + day).addClass(jClass);
        $('#9am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 10 && 10 <= timeEnd) {
        $('#10am > #' + day).removeClass();
        $('#10am > #' + day).addClass(jClass);
        $('#10am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 11 && 11 <= timeEnd) {
        $('#11am > #' + day).removeClass();
        $('#11am > #' + day).addClass(jClass);
        $('#11am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 12 && 12 <= timeEnd) {
        $('#12pm > #' + day).removeClass();
        $('#12pm > #' + day).addClass(jClass);
        $('#12pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 13 && 13 <= timeEnd) {
        $('#1pm > #' + day).removeClass();
        $('#1pm > #' + day).addClass(jClass);
        $('#1pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 14 && 14 <= timeEnd) {
        $('#2pm > #' + day).removeClass();
        $('#2pm > #' + day).addClass(jClass);
        $('#2am > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 15 && 15 <= timeEnd) {
        $('#3pm > #' + day).removeClass();
        $('#3pm > #' + day).addClass(jClass);
        $('#3pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 16 && 16 <= timeEnd) {
        $('#4pm > #' + day).removeClass();
        $('#4pm > #' + day).addClass(jClass);
        $('#4pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 17 && 17 <= timeEnd) {
        $('#5pm > #' + day).removeClass();
        $('#5pm > #' + day).addClass(jClass);
        $('#5pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 18 && 18 <= timeEnd) {
        $('#6pm > #' + day).removeClass();
        $('#6pm > #' + day).addClass(jClass);
        $('#6pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 19 && 19 <= timeEnd) {
        $('#7pm > #' + day).removeClass();
        $('#7pm > #' + day).addClass(jClass);
        $('#7pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 20 && 20 <= timeEnd) {
        $('#8pm > #' + day).removeClass();
        $('#8pm > #' + day).addClass(jClass);
        $('#8pm > #' + day).append("<p>" + name + "</p>");
        
    } else if (value <= 21 && 21 <= timeEnd) {
        $('#9pm > #' + day).removeClass();
        $('#9pm > #' + day).addClass(jClass);
        $('#9pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 22 && 22 <= timeEnd) {
        $('#10pm > #' + day).removeClass();
        $('#10pm > #' + day).addClass(jClass);
        $('#10pm > #' + day).append("<p>" + name + "</p>");
    } else if (value <= 23 && 23 <= timeEnd) {
        $('#11pm > #' + day).removeClass();
        $('#11pm > #' + day).addClass(jClass);
        $('#11pm > #' + day).append("<p>" + name + "</p>");
    }
}

function requestWeek(startDate, endDate) {
    $.ajax({
        type: "POST",
        url: fullUrl + "RequestWeekly",
        data: {
            start: startDate,
            end: endDate
        },
        error: function (result) {
            alert("There is a Problem, Try Again! ");
            return null;
        },
        success: function (result) {
            if (result.status == true) {
                resetWeek();
                $.each(result.simpleEvents, function (index, value) {
                    if (value.day == 0) {
                        setDay(value.time, value.timeEnd, 's', ' success', value.name)
                    } else if (value.day == 1) {
                        setDay(value.time, value.timeEnd, 'm', ' success', value.name)
                    } else if (value.day == 2) {
                        setDay(value.time, value.timeEnd, 't', ' success', value.name)
                    } else if (value.day == 3) {
                        setDay(value.time, value.timeEnd, 'w', ' success', value.name)
                    } else if (value.day == 4) {
                        setDay(value.time, value.timeEnd, 'th', ' success', value.name)
                    } else if (value.day == 5) {
                        setDay(value.time, value.timeEnd, 'f', ' success',  value.name)
                    } else if (value.day == 6) {
                        setDay(value.time, value.timeEnd, 'sa', ' success', value.name)
                    }
                });
                return result.simpleEvents;
            }
            else {
                alert("Something went wrong");
                return null;
            }
        }
    });
}