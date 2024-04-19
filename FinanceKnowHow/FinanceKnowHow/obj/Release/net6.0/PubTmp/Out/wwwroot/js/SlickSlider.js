﻿//Slick Slider
$(document).ready(function () {
    $(".slick-slider").slick({
        // normal options...
        infinite: false,

        // the magic
        responsive: [{

            breakpoint: 1024,
            settings: {
                slidesToShow: 3,
                infinite: true
            }

        }, {
            breakpoint: 600,
            settings: {
                slidesToShow: 5,
                dots: true
            }
        }, {
            breakpoint: 300,
            settings: "unslick" // destroys slick
        }]
    });
})