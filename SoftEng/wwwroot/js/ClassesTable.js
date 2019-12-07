function toggleAddClass() {
    $("#addClassModal .modal-title").html("Add Class");
    $("#addClassModal button[type=submit]").html("Add");
    $("#className").val("");
    $("#locationName").val("");
    $("#classStartDate").val("");
    $("#classEndDate").val("");
    $("#classStartTime").val("");
    $("#classEndTime").val("");
    $(document).off('click', '#submit_btn');
    $(document).on('click', '#submit_btn', function () {
        addOrUpdateClass("AddNewClass");
    })
}

function toggleEditClass(classId) {
    $("#addClassModal .modal-title").html("Edit Class");
    $("#addClassModal button[type=submit]").html("Save");
    $("#sat").prop('checked', false);
    $("#mon").prop('checked', false);
    $("#tue").prop('checked', false);
    $("#wed").prop('checked', false);
    $("#thr").prop('checked', false);
    $("#fri").prop('checked', false);
    $("#sun").prop('checked', false);
    $.ajax({
        type: "POST",
        url: fullUrl + "EditClass",
        data: {
            id: classId
        },
        error: function (result) {
            alert("There is a Problem, Try Again! " + "ClassId " + classId);
        },
        success: function (result) {
            $("#className").val(result.className);
            $("#classId").val(classId);
            $("#locationName").val(result.classLocation);
            $("#classStartDate").val(result.classStartDate);
            $("#classEndDate").val(result.classEndDate);
            $.each(result.classDays, function (index, value) {
                switch (value) {
                    case "Saturday":
                        $("#sat").prop('checked', true);
                        break;
                    case "Monday":
                        $("#mon").prop('checked', true);
                        break;
                    case "Tuesday":
                        $("#tue").prop('checked', true);
                        break;
                    case "Wednesday":
                        $("#wed").prop('checked', true);
                        break;
                    case "Thursday":
                        $("#thr").prop('checked', true);
                        break;
                    case "Friday":
                        $("#fri").prop('checked', true);
                        break;
                    case "Sunday":
                        $("#sun").prop('checked', true);
                        break;
                }
            });
            $("#classStartTime").val(result.classStartTime);
            $("#classEndTime").val(result.classEndTime);
            $("#classTotalTime").val(result.classTime);
        },
        complete: function () {
            $(document).off('click', '#submit_btn');
            $(document).on('click', '#submit_btn', function () {
                addOrUpdateClass("UpdateClass");
            })
        }
    });
}

function addOrUpdateClass(addOrUpdate) {
    $.ajax({
        type: "POST",
        url: fullUrl + addOrUpdate,
        data: {
            name: $("#className").val(),
            id: $("#classId").val(),
            location: $("#locationName").val(),
            startDateStr: $("#classStartDate").val(),
            endDateStr: $("#classEndDate").val(),
            days: {
                1: $('#sun').is(':checked'),
                2: $('#mon').is(':checked'),
                3: $('#tue').is(':checked'),
                4: $('#wed').is(':checked'),
                5: $('#thr').is(':checked'),
                6: $('#fri').is(':checked'),
                7: $('#sat').is(':checked')
            },
            startTime: $("#classStartTime").val(),
            endTime: $("#classEndTime").val()
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

function deleteClass(classId) {
    $.ajax({
        type: "POST",
        url: fullUrl + "DeleteClass",
        data: {
            id: classId
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
                alert("could not delete class: \n" + result.message);
            }
        }
    });
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

function setDeleteFunction(classId) {
    $('#deleteClassModal').on('click', '#delete_btn', function (e) {
        deleteClass(classId);
    });
}