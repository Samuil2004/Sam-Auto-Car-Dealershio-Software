//document.addEventListener('DOMContentLoaded', function() {
const firstNameError = document.querySelector(".fNameError");
const lastNameError = document.querySelector(".lNameError");
const firstNameInput = document.querySelector(".inputFirstName");
const lastNameInput = document.querySelector(".inputLastName");
const allDTOErrorMessages = document.querySelectorAll(".DTOErrors")
const btnSubmit = document.querySelector('.submitBtn');

function hideDTOErrors() {
    allDTOErrorMessages.forEach(error=>error.classList.add("hidden"))
}
function unhideDTOErrors() {
    allDTOErrorMessages.forEach(error => error.classList.remove("hidden"))
}

//First name live validation
firstNameInput.addEventListener("input", function () {
    hideDTOErrors()
    const firstName = firstNameInput.value.trim();
    const errorMessage = isValidName(firstName);
    firstNameError.textContent = errorMessage;

    if (errorMessage) {
        firstNameError.classList.remove("hidden");
    } else {
        firstNameError.classList.add("hidden");
    }
});

//Last name live validation
lastNameInput.addEventListener("input", function () {
    hideDTOErrors()
    const lastName = lastNameInput.value.trim();
    const errorMessage = isValidName(lastName);
    lastNameError.textContent = errorMessage;

    if (errorMessage) {
        lastNameError.classList.remove("hidden");
    } else {
        lastNameError.classList.add("hidden");
    }
});

function isValidName(name) {
    if (name.length === 0) {
        return "Name is required";
    }

    if (!/^[a-zA-Z]+$/.test(name)) {
        return "Name must contain only letters";
    }

    return "";
}


//Email live validation
const emailError = document.querySelector(".EmailError");
const emailInput = document.querySelector(".inputEmail");
emailInput.addEventListener("input", function () {
    hideDTOErrors()

    const email = emailInput.value.trim();

    const errorMessage = isValidEmail(email);
    emailError.textContent = errorMessage;

    if (errorMessage) {
        emailError.classList.remove("hidden");
    } else {
        emailError.classList.add("hidden"); 
    }
});

function isValidEmail(email) {
    // Check for "@" symbol
    if (email.indexOf('@') === -1) {
        return "Email address must contain '@'zfafasfasfa";
    }

    const parts = email.split('@');
    const usernamePart = parts[0];
    const domainPart = parts[1];


    // Check for username part length (there are not emails with no username aprt)
    if (usernamePart.length === 0) {
        return "Local part of email address is missing";
    }

    // Check for domain part length
    if (domainPart.length === 0) {
        return "Domain part of email address is missing";
    }


    return "";
}

const phoneNumberInput = document.querySelector(".inputPhone");
const phoneNumberError = document.querySelector(".PhoneError");

//phoneNumberInput.addEventListener("input", function () {
//    hideDTOErrors()

//    const phoneNumber = phoneNumberInput.value.trim();
//    const errorMessage = isValidPhoneNumber(phoneNumber);
//    phoneNumberError.textContent = errorMessage;

//    if (errorMessage) {
//        phoneNumberError.classList.remove("hidden");
//    } else {
//        phoneNumberError.classList.add("hidden");
//    }
//})

//function isValidPhoneNumber(phoneNumber) {

//    if (!phoneNumber) {
//        return "Phone number is required";
//    }

//    if (!/^\d{7,}$/.test(phoneNumber)) {
//        return "Phone number must contain at least 7 digits and only digits";
//    }

//    return "";
//}
phoneNumberInput.addEventListener("input", function () {
    hideDTOErrors();

    const phoneNumber = phoneNumberInput.value.trim();
    const errorMessage = isValidPhoneNumber(phoneNumber);
    phoneNumberError.textContent = errorMessage;

    if (errorMessage) {
        phoneNumberError.classList.remove("hidden");
    } else {
        phoneNumberError.classList.add("hidden");
    }
});

function isValidPhoneNumber(phoneNumber) {
    if (!phoneNumber) {
        return "Phone number is required";
    }

    if (!/^\d{7,14}$/.test(phoneNumber)) {
        return "Phone number must contain between 7 and 14 digits and only digits";
    }

    return "";
}


const passwordInput = document.querySelector(".topPassword"); 
const passwordError = document.querySelector(".PasswordError"); 

passwordInput.addEventListener("input", function () {
    passwordError.classList.remove("hidden")

    hideDTOErrors()

})


btnSubmit.addEventListener("click", function () {
    passwordError.classList.add("hidden");

    unhideDTOErrors()
})
