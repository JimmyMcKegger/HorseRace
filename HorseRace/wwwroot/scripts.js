/*
if (document.readyState !== 'loading') {
    console.log('document is already ready, just execute code here');
    updateNav();
} else {
    document.addEventListener('DOMContentLoaded', function () {
        console.log('document was not ready, place code here');
        updateNav();
    });
}



// removes the logged in user's access token
// https://www.w3schools.com/js/js_cookies.asp#:~:text=Change%20a%20Cookie%20with%20JavaScript,The%20old%20cookie%20is%20overwritten.


const updateNav = () => {
    const userRole = getCookie("access_role");
    console.log(userRole);
    const isLoggedIn = getCookie("access_token");
    console.log(isLoggedIn);

    if (isLoggedIn) {
        console.log('logged in');
         document.getElementById('nav-login').style.display = 'none';
        document.getElementById('nav-logout').style.display = 'block';
        document.getElementById('nav-events').style.display = 'block';
        document.getElementById('nav-logout').style.display = 'block';
        if (userRole === 'Manager') {
            console.log(userRole);
            document.getElementById('nav-new-event').style.display = 'block';
            document.getElementById('nav-users').style.display = 'block';
            document.getElementById('nav-managers').style.display = 'block';
        } else if (userRole === 'Owner') {
            // TODO:
            console.log(userRole);
        }
    } else {
        document.getElementById('nav-login').style.display = 'block';
        document.getElementById('nav-logout').style.display = 'none';
    }
}*/
