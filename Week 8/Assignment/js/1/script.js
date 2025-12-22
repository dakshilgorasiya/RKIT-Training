// Clock functionality
// H1 tag representing the clock
const clock = document.getElementById("clock");

// Update the clock every second
setInterval(() => {
  // get current time
  let date = new Date();

  // Extract hours, minutes, and seconds
  let hours = date.getHours();
  let minutes = date.getMinutes();
  let seconds = date.getSeconds();

  // Format time to always have two digits
  hours = hours < 10 ? "0" + hours : hours;
  minutes = minutes < 10 ? "0" + minutes : minutes;
  seconds = seconds < 10 ? "0" + seconds : seconds;

  // Update the clock display
  clock.innerHTML = `${hours}:${minutes}:${seconds}`;
}, 1000);

// User ID generation
const MIN_ID = 1000;
const MAX_ID = 10000;
// Event listener of Generate User ID button
document
  .getElementById("generateUserIdBtn")
  .addEventListener("click", function (e) {
    // Input field to display the generated user ID
    const userIdInput = document.getElementById("userIdInput");

    // Generate random user ID between MIN_ID and MAX_ID
    let id = Math.floor(Math.random() * (MAX_ID - MIN_ID) + MIN_ID);

    // Display the generated ID in the input field
    userIdInput.value = id;
  });

// Text formatting functionality
// Event listener of Format Text button
document.getElementById("formatIdBtn").addEventListener("click", function () {
  // Get user input from textarea
  let output = document.getElementById("userInput").value;

  // Trim leading and trailing spaces
  output = output.trim();

  // Split the text into words
  let words = output.split(" ");

  // Capitalize the first letter of each word and make other letters lowercase
  words = words.map((word) => {
    return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
  });

  // Join the words back into a single string with spaces
  output = words.reduce((acc, curr) => {
    return acc + " " + curr;
  }, "");

  // Display the formatted text in the output area
  document.getElementById("formattedOutput").innerHTML = output;
});
