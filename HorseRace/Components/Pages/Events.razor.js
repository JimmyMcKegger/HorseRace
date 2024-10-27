function ShowEditButtons() {
    const buttons = document.getElementsByClassName("btn");
    for (let i = 0; i < buttons.length; i++) {
        buttons[i].classList.remove("d-none");
    }
}