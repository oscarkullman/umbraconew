function goToNasaPage() {
    window.location.href = "/nasa-api";
}

function submitContactForm() {
    var name = document.getElementById("name-input").value;
    var mail = document.getElementById("mail-input").value;
    var message = document.getElementById("message-input").value;

    if (name != "" && mail != "" && message != "") {
        alert("Ditt meddelande har skickats!");
    } else {
        return false;
    }
}