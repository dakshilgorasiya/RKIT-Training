// API Endpoints
const userAPI = "https://jsonplaceholder.typicode.com/users/1";
const postsAPI = "https://jsonplaceholder.typicode.com/posts?userId=1";

// Function to fetch user data
function fetchUserData() {
  return $.ajax({
    url: userAPI,
    method: "GET",
  });
}

// Function to fetch user posts
function fetchUserPosts() {
  return $.ajax({
    url: postsAPI,
    method: "GET",
  });
}

// Run when document is ready
$(document).ready(function () {
  // Event listener for button click
  $("#loadBtn").on("click", function () {
    // Fetch user data and posts concurrently
    $.when(fetchUserData(), fetchUserPosts())
      .done(function (userData, userPosts) {
        // Extract data from the responses
        const user = userData[0];
        const posts = userPosts[0];

        // Create user info section
        const userDiv = $("<div>").addClass(
          "user-info p-3 m-3 rounded border border-2 border-black"
        );

        userDiv.append($("<h2>").text(user.name));
        userDiv.append($("<p>").text(`Email: ${user.email}`).addClass("mb-1"));
        userDiv.append($("<p>").text(`Phone: ${user.phone}`).addClass("mb-1"));

        // Create user posts section
        const postsDiv = $("<div>")
          .addClass("user-posts")
          .addClass("p-3 m-3 rounded border border-2 border-black");
        postsDiv.append($("<h3>").text("Posts:").addClass("mb-3"));

        const postsContainer = $("<div>").addClass("");

        posts.forEach((post) => {
          const postDiv = $("<div>").addClass(
            "p-2 border border-1 border-secondary m-1 rounded"
          );
          postDiv.append($("<h5>").text(post.title));
          postDiv.append($("<p>").text(post.body));
          postsContainer.append(postDiv);
        });

        postsDiv.append(postsContainer);

        // Append user info and posts to the container
        $("#container").empty().append(userDiv).append(postsDiv);
      })
      // Handle errors
      .fail(function () {
        // Display error message
        const errorDiv = $("<div>")
          .addClass("alert alert-danger")
          .text("Error loading data. Please try again later.");

        // Clear container and show error
        $("#container").empty().append(errorDiv);
      });
  });
});
