window.onscroll = function() {myFunction()};

var goUp = document.getElementById("go-up");
var sticky = goUp.offsetTop;

function myFunction() {
  if (window.pageYOffset > sticky) {
    goUp.classList.add("sticky");
  } else {
    goUp.classList.remove("sticky");
  }
}