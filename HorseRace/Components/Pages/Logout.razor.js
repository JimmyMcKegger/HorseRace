function clearCookie(name) {
    const d = new Date();
    d.setTime(d.getTime());
    let expires = "expires="+ d.toUTCString();
    document.cookie = `${name}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
}