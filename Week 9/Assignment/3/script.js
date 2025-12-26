// To show loader overlay
function showLoader() {
  $("#loadingOverlay").removeClass("d-none");
}

// To hide loader overlay
function hideLoader() {
  $("#loadingOverlay").addClass("d-none");
}

// URL of server API
const API_URL = "https://jsonplaceholder.typicode.com/todos";

// In-memory array to store todos
let todos = [];

// Fetch initial todo data from server
async function fetchData() {
  try {
    // Show loader while fetching data
    showLoader();

    // Fetch data from API
    const data = await $.ajax({
      url: API_URL,
      method: "GET",
    });

    // Store only the first 10 todos
    todos.push(...data.slice(0, 10));
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  } finally {
    // Hide loader after fetching data
    hideLoader();
  }
}

// Toggle todo completion status
async function todoToggle(e) {
  // Prevent default checkbox behavior
  e.preventDefault();

  try {
    // Show loader while updating todo
    showLoader();

    // Send PATCH request to update todo status
    const response = await $.ajax({
      url: `${API_URL}/${e.target.value}`,
      method: "PATCH",
      data: JSON.stringify({
        completed: e.target.checked,
      }),
      contentType: "application/json; charset=UTF-8",
    });

    // Update local todo array
    const todo = todos.find((todo) => todo.id === parseInt(e.target.value));

    // Update the completed status
    if (todo) {
      todo.completed = response.completed;
    }

    // Remove all todos from display
    $("#todoContainer").empty();

    // Re-display updated todos
    displayTodos(todos);
  } catch (error) {
    console.error("Error showing loader:", error);
    throw error;
  } finally {
    // Hide loader after updating todo
    hideLoader();
  }
}

// Delete a todo item
async function deleteTodo(e) {
  // Confirm deletion with the user
  if (confirm("Are you sure you want to delete this todo?")) {
    e.preventDefault();
  } else {
    return;
  }

  try {
    // Show loader while deleting todo
    showLoader();

    // Send DELETE request to API
    const response = await $.ajax({
      url: `${API_URL}/${e.target.value}`,
      method: "DELETE",
    });

    // Update local todo array by removing deleted todo
    todos = todos.filter((todo) => todo.id !== parseInt(e.target.value));

    // Clear current todo display
    $("#todoContainer").empty();

    // Re-display updated todos
    displayTodos(todos);
  } catch (error) {
    console.error("Error deleting todo:", error);
    throw error;
  } finally {
    // Hide loader after deleting todo
    hideLoader();
  }
}

// Add a new todo item
async function addTodo(e) {
  // Get the title from input field
  const todoTitle = $("#todoInput").val().trim();

  // Proceed only if title is not empty
  if (todoTitle) {
    try {
      // Show loader while adding todo
      showLoader();

      // Send POST request to add new todo
      const response = await $.ajax({
        url: API_URL,
        method: "POST",
        data: JSON.stringify({
          title: todoTitle,
          completed: false,
          userId: 1,
        }),
        contentType: "application/json; charset=UTF-8",
      });

      // Create new todo object
      const newTodo = {
        userId: response.userId || 1,
        id: response.id || todos.length + 1,
        title: response.title || todoTitle,
        completed: response.completed || false,
      };

      // Add new todo to local array
      todos.push(newTodo);

      // Clear input field
      $("#todoInput").val("");

      // Clear current todo display
      $("#todoContainer").empty();

      // Re-display updated todos
      displayTodos(todos);
    } catch (error) {
      console.error("Error adding todo:", error);
      throw error;
    } finally {
      // Hide loader after adding todo
      hideLoader();
    }
  }
}

// Display todos in the table
function displayTodos(todos) {
  // Iterate over each todo and create table rows
  todos.forEach((todo) => {
    // Create table row
    const row = $("<tr></tr>");

    // Create delete button cell, button, and event handler
    const deleteCell = $("<td></td>");
    const deleteBtn = $("<button></button>")
      .text("Delete")
      .addClass("btn btn-danger btn-sm")
      .on("click", deleteTodo)
      .val(todo.id);
    deleteCell.append(deleteBtn);
    row.append(deleteCell);

    // Create checkbox cell, checkbox, and event handler
    const checkboxCell = $("<td></td>");
    const checkbox = $("<input type='checkbox' />")
      .prop("checked", todo.completed)
      .on("change", todoToggle)
      .addClass("form-check-input mx-1")
      .val(todo.id);
    checkboxCell.append(checkbox);
    row.append(checkboxCell);

    // Create title cell
    const titleCell = $("<td></td>").text(todo.title);
    row.append(titleCell);

    // Append the row to the todo container
    $("#todoContainer").append(row);
  });
}

// Initialize the app on document ready
$(document).ready(async function () {
  // Bind add todo button click event
  $("#addTodoBtn").on("click", addTodo);

  // Fetch initial todo data
  await fetchData();

  // Display the fetched todos
  displayTodos(todos);
});
