$(function () {
  $("#box").click(function () {
    $(this).fadeOut(2000, function () {
      alert("Box is gone");
      $(this).fadeIn();
    });
  });
});
