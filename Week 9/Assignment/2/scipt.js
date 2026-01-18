$(function () {
  // Handle form submission
  $("#myForm").on("submit", function (e) {

    // Prevent default form submission behavior
    e.preventDefault();

    // Serialize form data into an array of objects
    const formData = $(this).serializeArray();

    // Combine fields with the same name into arrays
    formData.forEach((field) => {
      // Destructure name and value from the field
      const { name, value } = field;

      // Check for existing field with the same name
      const existingField = formData.find(
        (f) => f.name === name && f !== field,
      );

      // If found, combine values into an array
      if (existingField) {
        if (Array.isArray(existingField.value)) {
          existingField.value.push(value);
          formData.splice(formData.indexOf(field), 1);
        } else {
          existingField.value = [existingField.value, value];
          formData.splice(formData.indexOf(field), 1);
        }
      }
    });

    // Display the serialized form data as a formatted JSON string
    $("#result").text(JSON.stringify(formData, null, 1));
  });
});
