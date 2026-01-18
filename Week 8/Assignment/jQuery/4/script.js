// Custom validator for strong password
$.validator.addMethod(
  "passwordStrong",
  function (value, element) {
    return (
      !this.optional(element) &&
      new RegExp(
        "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"
      ).test(value)
    );
  },
  "Password is not strong enough."
);

// Form validation rules and messages
$("#registerForm").validate({
  rules: {
    username: {
      required: true,
      minlength: 3,
    },
    email: {
      required: true,
      email: true,
    },
    password: {
      required: true,
      passwordStrong: true,
    },
    confirmPassword: {
      required: true,
      equalTo: "#password",
    },
  },
  messages: {
    username: {
      required: "Please enter your username",
      minlength: "Your username must consist of at least 3 characters",
    },
    email: {
      required: "Please enter your email",
      email: "Please enter a valid email address",
    },
    password: {
      required: "Please provide a password",
    },
    confirmPassword: {
      required: "Please confirm your password",
      equalTo: "Passwords do not match",
    },
  },
  submitHandler: function (form) {
    alert("Form submitted successfully!");
    form.reset();
  },
});
