window.onload = function() {
  $(".update_deposit").click(function() {
    console.log("1");
    $(".table_one").css({ display: "none" });
    $(".table_two").css({ display: "block" });
  });
};
