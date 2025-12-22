let clickCount = 0;

$("#incrementBtn").click(function () {
  clickCount++;
  $("#countOutput").text(`Counter: ${clickCount}`);

  $("#console").prepend(`<p class="log">Increment count: ${clickCount}</p>`);

  if (clickCount == 10) {
    $("#resetBtn").trigger("click");
  }
});

$("#resetBtn").click(function () {
  clickCount = 0;
  $("#countOutput").text(`Counter: ${clickCount}`);

  $("#console").prepend(`<p class="log">Reset count: ${clickCount}</p>`);
});
