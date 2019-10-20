

function toggleRegisterLogin() {
    var checked = $("#registerCheckbox").is(":checked");
    if (checked) {
        $("#userLoginBtn").removeClass("hidden").addClass("hidden");
        $("#registerFields").removeClass("hidden");
    } else {
        $("#registerFields").removeClass("hidden").addClass("hidden");
        $("#userLoginBtn").removeClass("hidden");
    }
}