﻿const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

 signUpButton.addEventListener('click', () => {
     container.classList.add("right-panel-active");
 });

signInButton.addEventListener('click', () => {
    container.classList.remove("right-panel-active");
});


document.getElementById("togglePassword").addEventListener("click", function () {
    let passwordInput = document.getElementById("password");
    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        this.classList.remove("fa-eye");
        this.classList.add("fa-eye-slash");
    } else {
        passwordInput.type = "password";
        this.classList.remove("fa-eye-slash");
        this.classList.add("fa-eye");
    }
});