const getCookie = (cname) => {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for(let i = 0; i <ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

const updateNav = () => {
    const userRole = getCookie("access_role");
    console.log(userRole);
    const isLoggedIn = getCookie("access_token");
    console.log(isLoggedIn);

    if (isLoggedIn) {
        document.getElementById('nav-login').style.display = 'none';
        document.getElementById('nav-events').style.display = 'block';
        document.getElementById('nav-logout').style.display = 'block';
        if (userRole === 'Manager') {
            document.getElementById('nav-new-event').style.display = 'block';
            document.getElementById('nav-users').style.display = 'block';
            document.getElementById('nav-managers').style.display = 'block';
        } else if (userRole === 'Owner') {
            // TODO:

        }
    } else {
        
    }
}


document.addEventListener("DOMContentLoaded", updateNav());