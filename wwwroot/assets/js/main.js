
$(document).ready(function() {
    $('#owl-product').owlCarousel({
        navigation: true,
        animateOut: 'fadeOut',
        items:1,
        loop:true,
        navigationText : ["prev","next"],
        autoplay:false,
        autoplayTimeout:3000
    });
    $('#owl-project').owlCarousel({
        navigation: true,
        animateOut: 'fadeOut',
        items:2,
        loop:true,
        navigationText : ["prev","next"],
        autoplay:false,
    });
    $('#owl-project-tablet').owlCarousel({

        animateOut: 'fadeOut',
        items:1,
        loop:false,
        autoplayTimeout:3000,
        autoplay:false,
    });
    $('#owl-item-project-tablet').owlCarousel({

        animateOut: 'fadeOut',
        items:1,
        loop:true,
        autoplayTimeout:3000,
        autoplay:false,
    });
    $('#owl-project-mobile').owlCarousel({

        animateOut: 'fadeOut',
        items:1,
        loop:true,
        autoplayTimeout:3000,
        autoplay:true,
    });
    $('#owl-news-mobile').owlCarousel({

        animateOut: 'fadeOut',
        items:1,
        loop:true,
        autoplayTimeout:3000,
        autoplay:true,
    });
    $('#owl-item-project-mobile').owlCarousel({

        animateOut: 'fadeOut',
        items:1,
        loop:true,
        autoplayTimeout:3000,
        autoplay:true,
    });
    $('#owl-project-interested').owlCarousel({

        navigation: true,
        animateOut: 'fadeOut',
        items: 3,
        loop: true,
        navigationText: ["prev", "next"],
        autoplay: false,
        autoplayTimeout: 3000
    });


    $(window).scroll(function() {
        var scrollPos = $(this).scrollTop();
        if (scrollPos > 50) { // thay đổi màu sắc khi cuộn xuống 100px
          $('#myNavbar').addClass('active');
          $('#myNavbar .menu-top a').addClass('active-text');
        } else {
          $('#myNavbar').removeClass('active');
          $('#myNavbar .menu-top a').removeClass('active-text');
        }
    });
    var $hamburger = $(".hamburger");
    var $navBar = $(".menu-toggle");
    // On click
    $hamburger.on("click", function() {
    // Toggle class "is-active"
    $hamburger.toggleClass("is-active");
    $navBar.toggleClass("opened");
    // Do something else, like open/close menu
    });
    $(".line").on("click", function() {
    $hamburger.removeClass("is-active");
    $navBar.removeClass("opened");
    });


    $(".img-small img").click(function() {
        var smallImage = $(this).attr("src");
        $(".img-big img").attr("src", smallImage);
        });
    // Move on Top
    $(window).scroll(function() {
        if ($(this).scrollTop() >= 700) {
        $('.move-on-top-btn').fadeIn();
        }
        else{
        $('.move-on-top-btn').fadeOut();
        }
    });
    //pagination
    $(".pagination-1").paginathing({
        // Limites your pagination number
        // false or number
        limitPagination: false,
        prevNext: true,
        firstLast: true,
        prevText: '&laquo;',
        nextText: '&raquo;',
        firstText: 'First',
        lastText: 'Last',
        perPage: 6,
        containerClass: 'pagination-container',
        ulClass: 'pagination',
        liClass: 'page',
        activeClass: 'active',
        disabledClass: 'disabled',
    });
        

    
});
// cuộn khi kéo xuống
// window.onscroll = function() {myFunction()};
// function myFunction() {
//     var navbar = document.getElementById("myNavbar");
//     if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
//         navbar.classList.add("active");
//     } else {
//         navbar.classList.remove("active");
//     }
// }

// toggle menu mobile
// Look for .hamburger
// var hamburger = document.querySelector(".hamburger");
// var navBar = document.querySelector(".menu-toggle");
// // On click
// hamburger.addEventListener("click", function() {
//   // Toggle class "is-active"
//   hamburger.classList.toggle("is-active");
//   navBar.classList.toggle("opened");
//   // Do something else, like open/close menu
// })
// document.querySelectorAll(".line").forEach(n => n.addEventListener("click", () => {
//     hamburger.classList.remove("is-actice");
//     navBar.classList.remove("opened");
// }
// ));
//change image  
// function changeImage(e) {
//     var expandImg = document.getElementById("expandedImg");
//     expandImg.src = e.src;
// }



