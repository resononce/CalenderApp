
function toggleRecurring() {
    $("#recurringDays").toggleClass("hidden");
}

function addTask() {
    var error = "";
    var taskName = $('#taskName').val();
    var startTime = $('#startTime').val().toString();
    var endTime = $('#endTime').val().toString();
    var taskDate = new Date($('#taskDate').val()).toISOString();
    var recurring = $('#recurringCheck').is(":checked");
    var daysRecurring, recurringEndDate;
    if (recurring) {
        daysRecurring = {
            "sun" : $('#sunChkBox').is(':checked'),
            "mon" : $('#monChkBox').is(':checked'),
            "tue" : $('#tueChkBox').is(':checked'),
            "wed" : $('#wedChkBox').is(':checked'),
            "thr" : $('#thrChkBox').is(':checked'),
            "fri" : $('#friChkBox').is(':checked'),
            "sat" : $('#satChkBox').is(':checked')
        }
        recurringEndDate = new Date($('#recurringEndDate').val()).toISOString();
    }
    if (taskName.length === 0)
        error += "Must input task name\n";
    if (startTime.length === 0)
        error += "Must input start Time \n";
    if (endTime.length === 0)
        error += "Must input end Time \n";
    if (taskDate.length === 0)
        error += "Must input date \n";
    if (recurring) {
        var atLeastOneChecked = false;
        for (var key in daysRecurring) {
            if (daysRecurring[key])
                atLeastOneChecked = true;
        }
        if (!atLeastOneChecked)
            error += "Atleast one day must be checked\n";
        if (recurringEndDate.length === 0)
            error += "Must input recurring end date \n";
    }

    if (error != "")
        alert("Error: " + error);
    else {
        $.ajax({
            type: "POST",
            url: fullUrl + "AddNewTask",
            data: {
                taskName: taskName,
                startTimeStr: startTime,
                endTimeStr: endTime,
                taskDateStr: taskDate,
                recurring: recurring,
                daysRecurring: daysRecurring,
                recurringEndDateStr: recurringEndDate
            },
            error: function (result) {
                alert("There is a Problem, Try Again! ");
            },
            success: function (result) {
                if (result.status == true) {
                    alert("success!");
                    window.location.href = fullUrl + "Home/Main";
                }
                else {
                    alert(result.message);
                }
            }
        });
    }

    return false;
}
