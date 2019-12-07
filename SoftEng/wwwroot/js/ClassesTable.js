function toggleAddClass() {
    $("#addClassModal .modal-title").html("Add Class");
    $("#addClassModal button[type=submit]").html("Add");
    $("#className").val("");
    $("#locationName").val("");
    $("#classStartDate").val("");
    $("#classEndDate").val("");
    $("#classStartTime").val("");
    $("#classEndTime").val("");
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
        }
    });
}

function updateClass() {


}