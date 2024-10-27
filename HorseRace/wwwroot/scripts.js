function ShowOwnerProfile(role, userId) {
    switch (role.trim().toLowerCase()) {
        case 'owner':
            const ownerCard = document.getElementById(userId);
            ownerCard.classList.remove("d-none");
            break;
        case 'manager':
            const [...allCards] = document.getElementsByClassName("card");
            allCards.forEach((card) => {card.classList.remove("d-none");});
            break;
        default:
            break;
    }
}