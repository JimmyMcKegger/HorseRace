
// removes the logged in user's access token
// https://www.w3schools.com/js/js_cookies.asp#:~:text=Change%20a%20Cookie%20with%20JavaScript,The%20old%20cookie%20is%20overwritten.
const clearCookie = (name, value) => {
    const d = new Date();
    d.setTime(d.getTime());
    let expires = "expires="+ d.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

clearCookie("access_token", "");