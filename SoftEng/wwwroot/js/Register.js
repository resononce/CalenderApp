

function toggleRegisterLogin() {
    $("#userLoginBtn").toggleClass("hidden");
    $("#registerFields").toggleClass("hidden");


    /*
    var checked = $("#registerCheckbox").is(":checked");
    if (checked) {
        $("#userLoginBtn").removeClass("hidden").addClass("hidden");
        $("#registerFields").removeClass("hidden");
    } else {
        $("#registerFields").removeClass("hidden").addClass("hidden");
        $("#userLoginBtn").removeClass("hidden");
    }*/
}

function Register() {
    //check password requirements
    var password = $('#passwordText').val();
    var password2 = $('#passwordTextAgain').val();
    var error = "";
    if (password != password2) {
        error = "Passwords do not match";
    }
    var capital = false, symbol = false, number = false, lower = false;
    for (var i = 0; i < password.length; i++) {
        if (password.charCodeAt(i) >= 48 && password.charCodeAt(i) <= 57) {
            number = true;
        } else if (password.charCodeAt(i) >= 65 && password.charCodeAt(i) <= 90) {
            capital = true;
        } else if (password.charCodeAt(i) >= 97 && password.charCodeAt(i) <= 122) {
            lower = true;
        } else {
            symbol = true;
        }
    }
    if (capital && symbol && number && lower && password.length > 8) {

        //register
        $.ajax({
            type: "POST",
            url: fullUrl + "Home/Register",
            data: {
                username: $('#usernameText').val(),
                password: $('#passwordText').val()
            },
            error: function (result) {
                alert("There is a Problem, Try Again! ");
            },
            success: function (result) {
                if (result.status == true) {
                    window.location.href = fullUrl + "Home/Main";
                }
                else {
                    error = result.message;
                }
            }
        });
    } else {
        error = "Password must have 1 lower case, 1 upper case, 1 symbol, 1 number, and must be 8 or more characters";
    }
    if (error != "") {
        alert(error);
    }
}
function Validate() {
    $.ajax(
        {
            type: "POST",
            url: fullUrl + "Home/Validate",
            data: {
                username: $('#usernameText').val(),
                password: $('#passwordText').val()
            },
            error: function (result) {
                alert("There is a Problem, Try Again! ");
            },
            success: function (result) {
                console.log(result);
                if (result.status == true) {
                    window.location.href = fullUrl + "Home/Main";
                }
                else {
                    alert(result.message);
                }
            }
        });
}
