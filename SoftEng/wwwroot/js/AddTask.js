
function toggleRecurring() {
    $("#recurringDays").toggleClass("hidden");
}

function addTask() {
    var error = "";
    var data;
    var taskName = $('#taskName').val();
    var startTime = new Date($('#startTime').val());
    alert(startTime);
    var endTime = new Date($('#endTime').val());
    var taskDate = new Date($('#taskDate').val());
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
        recurringEndDate = new Date ($('#recurringEndDate').val());
    }
    if (taskName.length == 0)
        error += "Must input task name\n";
    if (startTime.length == 0)
        error += "Must input start Time \n";
    if (endTime.length == 0)
        error += "Must input end Time \n";
    if (isNaN(taskDate.getFullYear()))
        error += "Must input date \n";
    if (recurring) {
        var atLeastOneChecked = false;
        for (var key in daysRecurring) {
            if (daysRecurring[key])
                atLeastOneChecked = true;
        }
        if (!atLeastOneChecked)
            error += "Atleast one day must be checked\n";
        if (isNaN(recurringEndDate.getFullYear()))
            error += "Must input recurring end date \n";
    }

    if (error != "")
        alert(error);
    else {
        $.ajax({
            type: "POST",
            url: fullUrl + "AddNewTask",
            data: {
                taskName: taskName,
                startTime: startTime.toISOString(),
                endTime: endTime.toISOString(),
                taskDate: taskDate.toISOString(),
                recurring: recurring,
                daysRecurring: daysRecurring,
                recurringEndDate: recurringEndDate.toISOString()
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
