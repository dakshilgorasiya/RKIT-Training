h1tag = document.querySelector(".box h1"); // Returns the first matching element
h1tag.innerText = "Welcome to RKIT Training"; // Changes the text content

button = document.getElementById("myButton"); // Returns the element with the specified ID
button.style.padding = "10px 20px"; // css styles
button.style.fontSize = "16px";
button.style.cursor = "pointer";
button.style.borderRadius = "5px";

button.addEventListener("click", function () {
  // Event listener for click event
  console.log("Button was clicked!");
});

mainContent = document.getElementById("mainContent");
mainContent.innerText =
  "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

mainContent.innerHTML =
  "<strong>Lorem ipsum dolor sit amet</strong>, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."; // Changes HTML content

optionList = document.getElementsByClassName("optionsList")[0]; // Returns list of elements with the specified class name

newLi = document.createElement("li");
newLi.innerText = "Option 4";
optionList.appendChild(newLi); // Adds new list item to the end of the list

optionList.removeChild(optionList.children[1]); // Removes the second list item (index 1)

googleLink = document.createElement("a"); // Creates a new anchor element
googleLink.setAttribute("href", "https://www.google.com");
googleLink.setAttribute("target", "_blank");
googleLink.innerText = "Go to Google";

document.body.appendChild(googleLink); // Appends the link to the body of the document
