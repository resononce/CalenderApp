
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
    var recurringEndDate = taskName;
    var daysRecurring = {
        0: $('#sunChkBox').is(':checked'),
        1: $('#monChkBox').is(':checked'),
        2: $('#tueChkBox').is(':checked'),
        3: $('#wedChkBox').is(':checked'),
        4: $('#thrChkBox').is(':checked'),
        5: $('#friChkBox').is(':checked'),
        6: $('#satChkBox').is(':checked')
    }
    if (recurring)
        recurringEndDate = new Date($('#recurringEndDate').val()).toISOString();
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
            error: function (xhr, err) {
                var responseTitle = $(xhr.responseText).filter('title').get(0);
                alert($(responseTitle).text() + "\n" + formatErrorMessage(xhr, err)); 
            },
            success: function (result) {
                if (result.status == true) {
                    alert("success!");
                    window.location.href = fullUrl + "Home/Main";
                }
                else {
                    alert("could not add task: \n" + result.message);
                }
            }
        });
    }

    return false;
}

function formatErrorMessage(jqXHR, exception) {

    if (jqXHR.status === 0) {
        return ('Not connected.\nPlease verify your network connection.');
    } else if (jqXHR.status == 404) {
        return ('The requested page not found. [404]');
    } else if (jqXHR.status == 500) {
        return ('Internal Server Error [500].');
    } else if (exception === 'parsererror') {
        return ('Requested JSON parse failed.');
    } else if (exception === 'timeout') {
        return ('Time out error.');
    } else if (exception === 'abort') {
        return ('Ajax request aborted.');
    } else {
        return ('Uncaught Error.\n' + jqXHR.responseText);
    }
}