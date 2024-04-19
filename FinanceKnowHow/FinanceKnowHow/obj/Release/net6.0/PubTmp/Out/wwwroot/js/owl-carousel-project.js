
//Owl Carousel
$(document).ready(function () {
    $('.owl-one').owlCarousel({
        startPosition: 3,
        loop: true,
        rewind: true,
        margin: 10,
        responsiveClass: true,
        center: false,
        dots: false,
        dotsEach: false,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1000: {
                items: 4,
            }
        }
    });
    $('.owl-two').owlCarousel({
        startPosition: 3,
        loop: true,
        rewind: true,
        margin: 10,
        responsiveClass: true,
        center: false,
        nav: true,
        dots: false,
        dotsEach: false,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        navText: [
            "<i class='fa fa-angle-left'></i>",
            "<i class='fa fa-angle-right'></i>"
        ],
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 2,
            },
            1024: {
                items: 3,
            },

            1200: {
                items: 4,
            }
        }
    });
    $('.owl-three').owlCarousel({
        startPosition: 1,
        loop: true,
        rewind: true,
        margin: 10,
        responsiveClass: true,
        center: true,
        dots: true,
        dotsEach: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1000: {
                items: 3,
            }
        }
    });
    $('.owl-four').owlCarousel({
        startPosition: 1,
        loop: true,
        rewind: true,
        margin: 10,
        responsiveClass: true,
        center: true,
        dots: false,
        dotsEach: false,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 3,
            },
            1000: {
                items: 5,
            }
        }
    });
    $('.owl-five').owlCarousel({
        startPosition: 1,
        loop: true,
        rewind: true,
        margin: 10,
        responsiveClass: true,
        center: true,
        dots: true,
        dotsEach: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2,
            },
            1000: {
                items: 3,
            }
        }
    });
});