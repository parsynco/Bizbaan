"use strict";
var problemSwiper;
$(function () {

    $(window).on("scroll", function () {
        if ($(window).scrollTop() > 30) {
            $(".header").addClass("active");
            $(".header-img").addClass("active");
        } else {
            $(".header").removeClass("active");
            $(".header-img").removeClass("active");
        }
    });
    problemSwiper = new Swiper('.top-slider-holder',
        {
            on: {
                slideChange: function () {
                    const index_currentSlide = this.realIndex;
                    const currentSlide = this.slides[index_currentSlide];
                    $("#CATID").val($(currentSlide).attr("data-itemid"));
                    console.error("Current Slide : ", $(currentSlide).attr("data-itemid"));
                },
            },
            spaceBetween: 20,
            slidesPerView: 1,
            centeredSlides: true,
            loop: false,
            navigation: {
                nextEl: ".r2-ms-iconright",
                prevEl: ".r2-ms-iconleft",
            }

        });
    $(".filter-by-region").eq(0).trigger('click');
    if ($(".region-swiper").length > 0) {
        var regionSwiper = new Swiper('.region-swiper',
            {
                slidesPerView: 3,
                centeredSlides: false,
                loop: true,
                //navigation: {
                //    nextEl: ".region-swiper .slide-right",
                //    prevEl: ".region-swiper .slide-left",
                //}
            });
    }
    if ($(".ads-image-slider").length > 0) {
        var regionSwiper = new Swiper('.ads-image-slider',
            {
                autoplay: false,
                slidesPerView: 1,
                centeredSlides: true,
                loop: true,
                navigation: {
                    nextEl: ".ads-img-right",
                    prevEl: ".ads-img-left",
                }
            });
    }
    if ($(".row-business-image-slider").length > 0) {
        var regionSwiper = new Swiper('.row-business-image-slider',
            {
                autoplay: false,
                slidesPerView: 1,
                centeredSlides: true,
                loop: true,
                navigation: {
                    nextEl: ".ads-img-right",
                    prevEl: ".ads-img-left",
                }
            });
    }
    if ($("#Mile").length > 0) {
        const $slider = document.getElementById('Mile');

        // set properties
        $slider.rtl = true;
        /*$('#Mile').rangeslider();*/
    }
    $("#showModal").on('click', function () {
        $("#mdl-category").addClass("active");
    });
    $("#closeModel").on('click', function () {
        $("#mdl-category").removeClass("active");
    });

});
$(document).ready(function () {
    AOS.init({ disable: 'mobile' });
});
function SetCategoryAndCloseModal(catid, title) {
    $("#CATID").val(catid);
    ignoreTitleToSearch = true;
    $("#ADTITLED").val(title);
    $("#mdl-category").removeClass("active");
}
function Toggle(id, l) {
    $(".expandable-panel").removeClass("active");
    $("#" + id + " .expandable-panel." + l).toggleClass("active");
    $("#" + id + " .nested-" + l).toggleClass("fa-chevron-left");
    $("#" + id + " .nested-" + l).toggleClass("fa-chevron-down");
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
/**OPEN- CLOSE Modal*/
function ToggleModal(id) {
    $("#" + id).toggleClass("active");
}
/***************** */
async function SearchAd() {
    grecaptcha.ready(function () {
        grecaptcha.execute('6LeGQOAqAAAAAIRbkRcc2DHs5h9R7KxegkDb5w4F', { action: 'submit' }).then(function (token) {
            var cat = $("#CATID").val();
            var adtitle = $("#ADTITLE").val();
            var region = $("#REGION").val();
            var mile = $("#MILE").val();
            if (cat == "") {
                const index_currentSlide = problemSwiper.realIndex;
                const currentSlide = problemSwiper.slides[index_currentSlide];
                cat = $(currentSlide).attr("data-itemid");
            }
            var model = {
                CatId: parseInt(cat),
                Title: (ignoreTitleToSearch ? "" : adtitle),
                Region: region,
                Mile: region != "" ? mile : 1
            };

            $.ajax({
                type: "POST",
                data: JSON.stringify(model),
                url: "/Search",
                contentType: "application/json"
            }).done(function (res) {
                var data = JSON.parse(res.data);
                if (data != undefined) {
                    var html = "";
                    data.forEach(item => {
                        html += `
                        <a href="/${item.Seo.Url}" class="row6-mainsection">
                            <div class="r5-box1">
                                <img src="${item.Logo}" />
                            </div>
                            <div class="r5-box2">
                               
                                <h6 class="box-subtitle-fa ">
                                    ${item.Title}
                                </h6>
                                <h6 class="box-subtitle1 ">
                                    ${item.Category.Title}
                                </h6>
                                <h5 class="box-subtitle2 ">
                                    ${item.CityName}, ${item.ProivinceName}
                                </h5>
                            </div>
                             <h4 class="box-title">
                                    ${item.TitleEn}
                                </h4>
                        </a>
                        `;
                    });
                    $("#searchResult").html(html);
                }
            });
        });
    });



}
var ignoreTitleToSearch = false;
function DisableTitleIgnoring() {
    ignoreTitleToSearch = false;
}
async function searchAdDesktop() {

    grecaptcha.ready(function () {
        grecaptcha.execute('6LeGQOAqAAAAAIRbkRcc2DHs5h9R7KxegkDb5w4F', { action: 'submit' }).then(function (token) {
            var cat = $("#CATIDD").val();
            var adtitle = $("#ADTITLED").val();
            var region = $("#REGIOND").val();
            var mile = $("#MILE").val();
            if (cat == "") {
                cat = $("#firstItemToSelect").attr("data-itemid");
            }
            var model = {
                CatId: parseInt(cat),
                Title: (ignoreTitleToSearch ? "" : adtitle),
                Region: region,
                Mile: region != "" ? mile : 1
            };

            $.ajax({
                type: "POST",
                data: JSON.stringify(model),
                url: "/Search",
                contentType: "application/json"
            }).done(function (res) {
                var data = JSON.parse(res.data);
                if (data != undefined) {
                    var html = "";
                    data.forEach(item => {
                        html += `
                        <a href="/${item.Seo.Url}" class="result-item">
                            <div class="result-item-img-holder">
                                <img src="${item.Logo}" alt="${item.Title}" title="${item.Title}" />
                            </div>
                            <div class="result-item-description-holder">
                                
                                <h4 class="result-item-title-fa">${item.Title}</h4>
                                <div class="result-item-subtitle">${item.Category.Title}</div>
                                <div class="result-item-subtitle1">${item.CityName}, ${item.ProivinceName}</div>
                            </div>
                            <h4 class="result-item-title">${item.TitleEn}</h4>
                        </a>
                        `;
                    });
                    if (data.length < 4) {
                        for (var i = 0; i < (4 - data.length); i++) {
                            html += `<a href="javascript:void(0)" class="result-item empty">نتیجه جستجو</a>`;
                        }
                    }
                    $("#desktop-search-result").html(html);
                    $(".fluid-search-options-section").addClass("active");

                }
            });
        });
    });

}
async function CloseFilterResult() {
    $("#desktop-search-result").html('');
    $(".fluid-search-options-section").removeClass("active");
}
async function Subscribe() {

    grecaptcha.ready(function () {
        grecaptcha.execute('6LeGQOAqAAAAAIRbkRcc2DHs5h9R7KxegkDb5w4F', { action: 'submit' }).then(function (token) {
            var cat = $("#subscribe").val();
            $.ajax({
                type: "POST",
                data: JSON.stringify({ email: cat }),
                url: "/Subscribe",
                contentType: "application/json"
            }).done(function (res) {
                if (res != undefined) {

                    if (res.status != 0) {
                        Err(res.msg);
                        return;
                    }
                    Ok(res.msg);
                    $("#subscribe").val("");
                }
            });
        });
    });

}
async function SetCategoryOnDesktop(id, title,color,element) {
    $("#CATIDD").val(id);
    ignoreTitleToSearch = true;
    $("#ADTITLED").val(title);
    const allBackgroundElements = document.querySelectorAll('.has-background');
    allBackgroundElements.forEach(el => {
        el.style.backgroundColor = 'transparent';
    });

    console.warn("ELEMENT : ", $("#" + element));

    $("#" + element).css('background-color', color );
 
}
function ToggleSidebar() {
    $(".absolute-slider").toggleClass("active");
}

function GetGeoLocation() {
    var lat = 0;
    var lng = 0;
    if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                lat = position.coords.latitude;
                lng = position.coords.longitude;
                getLocToZip();
                console.log(`Latitude: ${lat}, longitude: ${lng}`);
            },
            (error) => {
                getGeoByApi();
            }
        );
    } else {
        console.error("Geolocation is not supported by this browser.");
        getGeoByApi();
    }

    const getGeoByApi = function () {
        fetch('https://api.geoapify.com/v1/ipinfo?apiKey=f6185d2bf4704ba19f56cceac1ea3c64')
            .then(response => response.json())
            .then(data => {
                // You can now access the location data in the "data" object
                lat = data.location.latitude;
                lng = data.location.longitude;
                ; getLocToZip();
                console.log(lat, lng);
            })
    }
    const getLocToZip = function () {
        fetch(`https://api.geoapify.com/v1/postcode/search?lat=${lat}&lon=${lng}&geometry=original&apiKey=f6185d2bf4704ba19f56cceac1ea3c64`)
            .then(response => response.json())
            .then(result => {
                var zc = result.features[0].properties.postcode;
                $("#REGIOND").val(zc);
                $("#REGION").val(zc);
                console.warn("ZPPPPP : ", zc);
                console.warn("OBJJJJECT : ", result);
            })
            .catch(error => console.log('error', error));
    }

}

function Err(msg) {
    Swal.fire({
        icon: "error",
        title: "Error",
        text: msg
    });
}
function Ok(msg) {
    Swal.fire({
        icon: "success",
        title: "Success",
        text: msg
    });
}