function toggleRecurring() {
    $("input[name=recurringRadio]").change(function () {
        if ($("#recurringNo").is(':checked')) {
            console.log("No");
            $("#recurringDays").removeClass("hidden").addClass("hidden");
            $("#selectDay").removeClass("hidden");
        } else if ($("#recurringYes").is(':checked')) {
            console.log("Yes");
            $("#selectDay").removeClass("hidden").addClass("hidden");
            $("#recurringDays").removeClass("hidden");
        }
    });
}
