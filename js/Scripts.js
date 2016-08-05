
function isLogin() {
    var loginSession = document.getElementById("LoginRole").innerHTML;


    if (loginSession == 1) {

        document.getElementById("Admin").style.visibility = 'visible';

    } else {
        document.getElementById("Admin").style.visibility = 'hidden';

    }
}
