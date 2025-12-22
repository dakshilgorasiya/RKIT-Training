$(function () {
  // innerText, innerHTML, value
  $("#para").text("dynamic text set by jQuery"); // set text content
  $("#para").html("<strong>bold dynamic text set by jQuery</strong>"); // set HTML content
  $("#inputBox").val("dynamic value set by jQuery"); // set input value

  // attr
  console.log("Before:", $("#link").attr("href")); // get attribute
  $("#link").attr("href", "https://www.example.com"); // set attribute
  console.log("After:", $("#link").attr("href"));

  // append, prepend, after, before
  $("#myList").append("<li>Appended Item</li>"); // add as last child
  $("#myList").prepend("<li>Prepended Item</li>"); // add as first child
  $("#myList").after("<p>This is after the list.</p>"); // add after the element
  $("#myList").before("<p>This is before the list.</p>"); // add before the element

  // remove, empty
  // $("#myList li:last").remove(); // remove element and its children
  // $("#myList").empty(); // remove all children but keep the element

  // css
  $("#link").addClass("text-danger"); // add class
  $("#link").removeClass("text-danger"); // remove class
  $("#link").toggleClass("text-danger"); // toggle class
  $("#link").css("font-size", "20px"); // set CSS property

  console.log($("#link").css("font-size")); // get CSS property
  // to set multiple CSS properties
  $("#link").css({
    "text-decoration": "underline",
    "background-color": "yellow",
  });

  // width, innerWidth, outerWidth, outerWidth(true)
  // console.log("Width:", $("#box").width()); // get width without padding, border, margin
  // console.log("Inner Width:", $("#box").innerWidth()); // get width with padding
  // console.log("Outer Width:", $("#box").outerWidth()); // get width with padding and border
  // console.log("Outer Width (with margin):", $("#box").outerWidth(true)); // get width with padding, border, margin

  // traversal
  // parent, parents, parentsUntil
  console.log($("#link").parent()); // direct parent
  console.log($("#link").parents()); // all ancestors
  console.log($("#link").parentsUntil("body")); // ancestors until body

  // children, children(selector), find
  console.log($("#myList").children()); // direct children
  console.log($("#myList").children("li")); // direct children filtered by selector
  console.log($("#container").find("li")); // all descendants filtered by selector

  // siblings, next, nextAll, nextUntil, prev, prevAll, prevUntil
  console.log("Siblings of #item2:");
  console.log($("#item2").siblings()); // all siblings
  console.log($("#item2").next()); // next sibling
  console.log($("#item2").nextAll()); // all next siblings
  console.log($("#item2").nextUntil("#item5")); // next siblings until #item5
  console.log($("#item4").prev()); // previous sibling
  console.log($("#item4").prevAll()); // all previous siblings
  console.log($("#item4").prevUntil("#item1")); // previous siblings until #item1

  // first, last, eq, filter, not
  console.log("Filtering children of #myList:");
  console.log($("#myList").children().first()); // first child
  console.log($("#myList").children().last()); // last child
  console.log($("#myList").children().eq(2)); // child at index 2
  console.log(
    $("#myList")
      .children()
      .filter(function (index) {
        return index % 2 === 0; // even indexed children
      })
  );
  console.log(
    $("#myList")
      .children()
      .not(function (index) {
        return index % 2 === 0; // odd indexed children
      })
  );
});
