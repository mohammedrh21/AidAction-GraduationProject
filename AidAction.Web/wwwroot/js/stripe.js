function redirectToCheckout(clientSecret) {
    var stripe = Stripe('pk_test_51RFVMIKsLMfau8ltkragoNdh1beurXKYSTZ3U4f01sNBradxOAFyra4DsO0H33u7FRXjdXnCerBaI8XLyqAgjzsl00hjN2ONPr');  // Use your publishable key here

    stripe.redirectToCheckout({
        sessionId: clientSecret  // This should be the client secret returned from your server
    }).then(function (result) {
        if (result.error) {
            console.error(result.error.message);
        }
    });
}

let selectedButton = null;

function selectAmount(amount, button) {
    const input = document.getElementById("customAmount");

    if (selectedButton === button) {
        button.classList.remove("active");
        selectedButton = null;
        input.value = "";
    } else {
        const buttons = document.querySelectorAll(".donation-amounts button");
        buttons.forEach((btn) => btn.classList.remove("active"));

        button.classList.add("active");
        selectedButton = button;
        input.value = amount;
    }

    updateSummary();
}

function updateSummary() {
    const amount =
        parseFloat(document.getElementById("customAmount").value) || 0;
    document.getElementById("summaryAmount").textContent =
        `$${amount.toFixed(2)}`;
    document.getElementById("totalAmount").textContent =
        `$${(amount + 2).toFixed(2)}`;

    if (!selectedButton) return;

    const inputAmount = parseFloat(
        document.getElementById("customAmount").value
    );
    const selectedAmount = parseFloat(selectedButton.textContent);

    if (inputAmount !== selectedAmount) {
        selectedButton.classList.remove("active");
        selectedButton = null;
    }
}






