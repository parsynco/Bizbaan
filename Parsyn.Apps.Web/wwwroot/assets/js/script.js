"use strict";
(function () {
    const problemSwiper = new Swiper('.problem-swipper',
        {
            slidesPerView: 1,
            centeredSlides: true,
            autoplay: {
                delay: 2500,
                disableOnInteraction: true,
            },
            loop: true,
            navigation: {
                nextEl: ".carousel-opr-btn-right",
                prevEl: ".carousel-opr-btn-left",
            }
        });
    const infinitSwiper = new Swiper('.infinite-swipper', {
        autoplay: true,
        spaceBetween: 10,
        slidesPerView: 'auto',
        loop: true,
        // navigation:{
        // nextEl:".carousel-opr-btn-right",
        // prevEl:".carousel-opr-btn-left",
        // }
    });
    const SingleSlideSlider = new Swiper('.features-swiper', {
        autoplay: true,
        spaceBetween: 10,
        slidesPerView: 'auto',
        loop: true,
        navigation: {
            nextEl: ".single-slide-next",
            prevEl: ".single-slide-prev",
        }
    });
    const ArticleSlider = new Swiper('.article-slider', {
        autoplay: true,
        spaceBetween: 10,
        slidesPerView: 'auto',
        centeredSlides: true,
        loop: true,
        breakpoints: {
            480: {
                slidesPerView: 1,
                spaceBetween: 40,
            },
            640: {
                slidesPerView: 1,
                spaceBetween: 50,
            }, 1080: {
                slidesPerView: 'auto',
                spaceBetween: 10,
            }
        },
        navigation: {
            nextEl: ".article-slide-next",
            prevEl: ".article-slide-prev",
        }
    });
    const CofeatureSlider = new Swiper('.cofeatures-swiper', {
        autoplay: true,
        spaceBetween: 0,
        slidesPerView: 'auto',
        centeredSlides: true,
        loop: true,
        breakpoints: {
            480: {
                slidesPerView: 1,
                spaceBetween: 40,
            },
            640: {
                slidesPerView: 1,
                spaceBetween: 50,
            },
            1080: {
                slidesPerView:'auto',
                spaceBetween: 0,
            }
        },
        navigation: {
            nextEl: ".cofeature-slide-next",
            prevEl: ".cofeature-slide-prev",
        }
    });
    const CofeedbackSlider = new Swiper('.cufeedback-swiper', {
        autoplay: false,
        spaceBetween: 0,
        slidesPerView: 'auto',
        centeredSlides: true,
        loop: true,
        breakpoints: {
            480: {
                slidesPerView: 1,
                spaceBetween: 40,
            },
            640: {
                slidesPerView: 1,
                spaceBetween: 50,
            },
            1080: {
                slidesPerView: 4,
                spaceBetween: 10,
            }
        },
        navigation: {
            nextEl: ".cofeedback-slide-next",
            prevEl: ".cofeedback-slide-prev",
        }
    });


    $(window).on("scroll", function () {
        if ($(window).scrollTop() > 50) {
            $(".header").addClass("active");
        } else {
            //remove the background property so it comes transparent again (defined in your css)
            $(".header").removeClass("active");
        }
    });

    $("#hmbrgr-mnu-btn").on('click', function () {
        $("#ovrflw-mnu").addClass("active");
    });
    $("#closeovrflw-mnu").on('click', function () {
        $("#ovrflw-mnu").removeClass("active");
    });


})();
function Expand(id, el) {
    $(`#${id}`).toggleClass('active');

    $(`#${el}`).toggleClass("fa-chevron-down");
    $(`#${el}`).toggleClass("fa-chevron-left");

}
// $(document).ready(function(){

// 	console.log(swiper);
// });