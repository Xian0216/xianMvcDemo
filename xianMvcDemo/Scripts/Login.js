$(document).ready(function () {
    var panelOne = $('.form-panel.two').height(),
        panelTwo = $('.form-panel.two')[0].scrollHeight;

    $('.form-panel.two').not('.form-panel.two.active').on('click', function (e) {
        e.preventDefault();

        $('.form-toggle').addClass('visible');
        $('.form-panel.one').addClass('hidden');
        $('.form-panel.two').addClass('active');
        $('.form').animate({
            'height': panelTwo
        }, 200);
    });

    $('.form-toggle').on('click', function (e) {
        e.preventDefault();
        $(this).removeClass('visible');
        $('.form-panel.one').removeClass('hidden');
        $('.form-panel.two').removeClass('active');
        $('.form').animate({
            'height': panelOne
        }, 200);
    });
});

function Login(account, password, rememberMe) {

    $.ajax({
        url: "/Member/Login",
        method: "POST",
        data: {
            Account: account,
            Password: password,
            RememberMe: rememberMe
        },
        success: function (data) {
            if (data.IsSuccess) {
                window.location.href = '/Home/Index';
            } else {
                alert(data.ErrorMessage);
            }
        },
        
        error: function () {
            alert("Can't Post To Server");
        }
    });
}

function Register(account, password, repeatPassword) {

    if (password != repeatPassword)
    {
        alert('"Password" does NOT match the "confirmed password"');
    }

    $.ajax({
        url: "/Member/Register",
        method: "POST",
        data: {
            Account: account,
            Password: password
        },
        success: function (data) {
            if (data.IsSuccess) {
                alert('Register Success');
            } else {
                alert(data.ErrorMessage);
            }
        },

        error: function () {
            alert("Can't Post To Server");
        }
    });
}