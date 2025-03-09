function displayMessage(message, isSuccess, duration) {
    let messageContainer = document.getElementById('message-container');
    if (!messageContainer) {
        messageContainer = document.createElement('div');
        messageContainer.id = 'message-container';
        document.body.appendChild(messageContainer);
    }

    messageContainer.style.position = 'fixed';
    messageContainer.style.top = '20px';
    messageContainer.style.left = '50%';
    messageContainer.style.transform = 'translateX(-50%)';
    messageContainer.style.padding = '15px';
    messageContainer.style.color = '#fff';
    messageContainer.style.fontSize = '16px';
    messageContainer.style.zIndex = '1000';
    messageContainer.style.borderRadius = '5px';
    messageContainer.style.boxShadow = '0 4px 8px rgba(0, 0, 0, 0.2)';
    messageContainer.style.backgroundColor = isSuccess ? 'green' : 'red';
    messageContainer.innerText = message;

    messageContainer.style.display = 'block';
    setTimeout(() => {
        messageContainer.style.display = 'none';
    }, duration);
}


document.addEventListener("DOMContentLoaded", function () {
    document.addEventListener("click", function (event) {
        var dropdowns = document.querySelectorAll(".dropdown-menu.show");
        dropdowns.forEach(function (dropdown) {
            if (!dropdown.parentElement.contains(event.target)) {
                bootstrap.Dropdown.getInstance(dropdown.parentElement.querySelector(".dropdown-toggle"))?.hide();
            }
        });
    });
});

 window.onload = function () {
        console.log("JavaScript ready for Blazor!");
    };

