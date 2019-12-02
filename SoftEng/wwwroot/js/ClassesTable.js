function toggleAddClass() {
    $("#addClassModal .modal-title").html("Add Class");
    $("#addClassModal button[type=submit]").html("Add");
    $("#className").val("");
    $("#locationName").val("");
    $("#classStartDate").date._clearDate(this);
    $("#classEndDate").date._clearDate(this);
    $("#classStartTime").val("");
    $("#classEndTime").val("");
}

function toggleEditClass(classId) {
    $("#addClassModal .modal-title").html("Edit Class");
    $("#addClassModal button[type=submit]").html("Save");
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
        }
    });
}
