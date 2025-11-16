// Example: Display alert on button click
document.addEventListener("DOMContentLoaded", () => {
    const btn = document.getElementById("btnSubmit");

    if (btn) {
        btn.addEventListener("click", () => {
            console.log("Submit button clicked!");
        });
    }
});
