function toggleRecurring() {
    $("input[name=recurringRadio]").change(function () {
        if ($("#recurringNo").is(':checked')) {
            $("#recurringDays").removeClass("hidden").addClass("hidden");
            $("#selectDay").removeClass("hidden");
        } else if ($("#recurringYes").is(':checked')) {
            $("#selectDay").removeClass("hidden").addClass("hidden");
            $("#recurringDays").removeClass("hidden");
        }
    });
}
