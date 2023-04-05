      window.onscroll = function() {myFunction()};

var header = document.getElementById("header_bottom");
var sticky = header.offsetTop;

function myFunction() {
  if (window.pageYOffset > sticky) {
    header.classList.add("sticky");
  } else {
    header.classList.remove("sticky");
  }
}



// ..............................................Banner.......................................................



   wow = new WOW(
      {
        animateClass: 'animated',
        offset:       100,
        callback:     function(box) {
          console.log("WOW: animating <" + box.tagName.toLowerCase() + ">")
        }
      }
    );
    wow.init();
    document.getElementById('moar').onclick = function() {
      var section = document.createElement('section');
      section.className = 'section--purple wow fadeInDown';
      this.parentNode.insertBefore(section, this);
    };



    // ..............................................owl.................................

$(".hover").mouseleave(
  function() {
    $(this).removeClass("hover");
  }
);









// $(document).ready(function(){

//   $('.input').focus(function(){
//     $(this).parent().find(".label-txt").addClass('label-active');
//   });

//   $(".input").focusout(function(){
//     if ($(this).val() == '') {
//       $(this).parent().find(".label-txt").removeClass('label-active');
//     };
//   });

// });