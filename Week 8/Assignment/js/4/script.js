async function loadUsers() {
  try {
    let response = await fetch("https://jsonplaceholder.typicode.com/users");
    response = await response.json();
    return response;
  } catch (error) {
    if (!navigator.onLine) {
      document.getElementById("outputError").innerText =
        "You are offline. Please check your internet connection.";
      return;
    }
    throw error;
  }
}

outputUl = document.getElementById("outputUl");
let userList;

loadUsers().then((data) => {
  userList = data;
  displayUsers(userList);
});

function displayUsers(users) {
  users.forEach((user) => {
    let li = document.createElement("li");
    li.textContent = user.name;
    outputUl.appendChild(li);
  });
}
