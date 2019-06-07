

function validatePassword() {
    //var userName = $('#UserName').val();
    //var passWord = $('#UserPassword').val().trim();
    //var verifyUserPassword = $('#VerifyUserPassword').val().trim();

    var User = createUser();
    if (User.UserName === '') {
        alert('User Name is empty');
        return false;
    }

    else if (User.VerifyUserPassword.trim() !== User.UserPassword.trim()) {
        alert('Passwords do not match');
        return false;
    }
}

function createUser(){
   return {
        UserName: $('#UserName').val(),
        UserPassword: $('#UserPassword').val(),
        VerifyUserPassword: $('#VerifyUserPassword').val()
    };
}

$(document).ready(function () {

    bindButtonControls();

})

function bindButtonControls() {
    $('#btn-login').on('click', function () {
        var User = createUser();
        var ajaxData = {
            'url': '/Home/Login',
            'data': { login: User },
            'type': 'POST',
            'success': function (result) {
                
                $('#login-div-to-replace').html(result);
                bindButtonControls();
            }
        };
        $.ajax(ajaxData);
    });

}

