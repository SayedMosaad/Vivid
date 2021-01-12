/*  ---------------------------------------------------
    Theme Name: Staging
    Description: Staging bootstrap tamplate
    Author: Colorib
    Author URI: https://www.colorib.com/
    Version: 1.0
    Created: 
---------------------------------------------------------  */

'use strict';

(function ($) {

    /*-----------.loader   #preloder-------
        Preloader
    --------------------*/
    $(window).on('load', function () {
        $(".loader").delay(1300).fadeOut(); 
        //$(".loader").fadeOut();     
        $("#preloder").delay(2000).fadeOut("slow");
    });

    /*------------------
        Background Set
    --------------------*/
    $('.set-bg').each(function () {
        var bg = $(this).data('setbg');
        $(this).css('background-image', 'url(' + bg + ')');
        
    });

    //Canvas Menu
    // $(".canvas__open").on('click', function () {
    //     $(".offcanvas-menu-wrapper").addClass("active");
    //     $(".offcanvas-menu-overlay").addClass("active");
    // });

    // $(".offcanvas-menu-overlay").on('click', function () {
    //     $(".offcanvas-menu-wrapper").removeClass("active");
    //     $(".offcanvas-menu-overlay").removeClass("active");
    // });


    /*------------------
		Navigation
	--------------------*/
    // $(".mobile-menu").slicknav({
    //     prependTo: '#mobile-menu-wrap',
    //     allowParentLinks: true
    // });

    /*-----------------------
        Hero Slider
    ------------------------*/
    $(".hero__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 1,
        dots: true,
        nav: true,
        navText: ["<i class='fa fa-angle-left'><i/>", "<i class='fa fa-angle-right'><i/>"],
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 1000,   //1500
        autoHeight: false,
        autoplay: true,
        mouseDrag: false,
        onInitialized: function (e) {
            var a = this.items().length;
            $("#snh-1").html("<span>01</span><span>" + "0" + a + "</span>");
            var presentage = Math.round((100 / a));
            $('.slider__progress span').css("width", presentage + "%");
        }
    }).on("changed.owl.carousel", function (e) {
        var b = --e.item.index,
            a = e.item.count;
        $("#snh-1").html("<span> " + "0" + (1 > b ? b + a : b > a ? b - a : b) + "</span><span>" + "0" + a + "</span>");

        var current = e.page.index + 1;
        var presentage = Math.round((100 / e.page.count) * current);
        $('.slider__progress span').css("width", presentage + "%");
    });

    /*--------------------------
        Project Slider
    ----------------------------*/
    $(".project__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 4,
        dots: false,
        nav: true,
        navText: ["<span class='arrow_carrot-left'><span/>", "<span class='arrow_carrot-right'><span/>"],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: false,
        responsive: {
            320: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
    });

    /*-----------------------------
        Testimonial Slider
    -------------------------------*/
    $('.testimonial__carousel').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        fade: true,
        // autoplay:true,
        asNavFor: '.testimonial__client',
        prevArrow: '<button type="button" class="slick-prev"><i class="fa fa-angle-left"><i></i></i></button>',
        nextArrow: '<button type="button" class="slick-next"><i class="fa fa-angle-right"><i></i></i></button>',
      });
      $('.testimonial__client').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        asNavFor: '.testimonial__carousel',
        arrows: false,
        variableWidth: true,
        centerMode: true,
        focusOnSelect: true,
        responsive: [
            {
              breakpoint: 768,
              settings: {
                slidesToShow: 3,
              }
            },
            {
              breakpoint: 575,
              settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                variableWidth: false
              }
            }
          ]
        
      });


        /*---------------------------------
        Make Header Fixed Animate
        ----------------------------------*/
        // When the user scrolls the page, execute myFunction
        window.onscroll = function() {myFunction() };

        // Get the sections
        var header = document.getElementById("myHeader"),
            aboutsec = document.getElementById("about-sec"),
            projectsec = document.getElementById("project-sec"),
            careersec = document.getElementById("career-sec"),
            footersec = document.getElementById("footer-sec");
            
        var littlebtn =document.getElementById("littlebtn"),
            headercontant = document.getElementById("header-contant");

        var blacklogo = document.getElementById("black-logo"),
            whitelogo = document.getElementById("white-logo");

        function myFunction() {
            if( window.pageYOffset < header.offsetHeight){
                header.classList.remove("sticky");
                header.classList.remove("smlheader");
                header.classList.remove("darksmlheader");

                littlebtn.classList.add("hide");
                headercontant.classList.remove("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }
            else if (window.pageYOffset <= aboutsec.offsetTop && window.pageYOffset > header.offsetHeight ) {
                header.classList.add("sticky");
                header.classList.remove("smlheader");
                header.classList.remove("darksmlheader");

                littlebtn.classList.add("hide");
                headercontant.classList.remove("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            } 
            else if( window.pageYOffset <= projectsec.offsetTop && window.pageYOffset > aboutsec.offsetTop){
                header.classList.remove("sticky");
                header.classList.add("smlheader");
                header.classList.remove("darksmlheader")

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.add("hide")
                whitelogo.classList.remove("hide");
            }
            else if( window.pageYOffset <= careersec.offsetTop &&  window.pageYOffset > projectsec.offsetTop){
                header.classList.remove("sticky");
                header.classList.remove("smlheader");
                header.classList.add("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }
            else if(window.pageYOffset <= (footersec.offsetTop - header.offsetHeight) && window.pageYOffset > careersec.offsetTop ){
                header.classList.remove("sticky");
                header.classList.add("smlheader");
                header.classList.remove("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.add("hide")
                whitelogo.classList.remove("hide");
            }  
            else if(pageYOffset > footersec.offsetTop - header.offsetHeight){
                header.classList.remove("sticky");
                header.classList.remove("smlheader");
                header.classList.add("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }
        }
    
            // const allsection = document.querySelectorAll("section"),
            // totalallsection = allsection.length;
            // console.log(allsection);

            // for(let i=0; i<totalallsection; i++){

            //     console.log(allsection[i]);

            //     const datacolorsec = allsection[i].getAttribute("data-color-sec");
            //     console.log(datacolorsec);

            //     // for(let j=0; j<datacolorsec ; j++){
            //     //     const colorvalue = datacolorsec.getAttribute("data-color-sec");
            //     //     console.log("its value "+ colorvalue);
            //     // }
                
            // }
               
           /* function myFunction() {
                const allsection = document.querySelectorAll("section"),
                    totalallsection = allsection.length;
                    console.log(allsection);

                for(let i=0; i<totalallsection; i++){
                    console.log(allsection[i]);
                    const datacolorsec = allsection[i].getAttribute("data-color-sec");
                    console.log(datacolorsec);
                    
                    if(datacolorsec == 'white'){
                        header.classList.remove("sticky");
                        header.classList.add("smlheader");
                        header.classList.remove("darksmlheader");
        
                        littlebtn.classList.remove("hide");
                        headercontant.classList.add("hide");
                    }
                    else if(datacolorsec == 'dark'){
                        header.classList.remove("sticky");
                        header.classList.remove("smlheader");
                        header.classList.add("darksmlheader");
        
                        littlebtn.classList.remove("hide");
                        headercontant.classList.add("hide");
                    }
                }
            }  */



        /*---------------------------------
        Dropmenu list
        ----------------------------------*/
        $(function() {
            $(".projects.menu__projects").click(function() { 
                $(".button-projects.projects__button-projects").toggleClass("openbtn");
                $(".projects__dropdown").toggleClass("openmenu");
            });
        });

        /*---------------------------------
        search form
        ----------------------------------*/
        $(function() {
            $(".Search_button").click(function() {
                $(".search__form").toggleClass("opensearch");
                $(".menuheader").toggleClass("hide");  
            });
        });

        /*------------------------------
        Contact_form
        ------------------------------ */
        $(function() {
            $(".custom-select__head").click(function() {
                $(".custom-select__item").toggleClass("custom-select__item_hide"); 
            });
        });

        $(function() {
            $(".contact_for_form").click(function(){  
                $(".ContactFormSec").toggleClass("close");
            });
        });
        $(function() {
            $(".modal__close").click(function(){  
                $(".ContactFormSec").toggleClass("close");
            });
        });   

        /*---------------------------------
        nav toggle
        ----------------------------------*/
        // $(function() {
        //     $(".nav-toggler.closenavtglr").click(function(){
        //         $(this).toggleClass("open");

        //        $(".bigHeader").toggleClass("close");
        //        $(".bigHeader").toggleClass("open");
               
        //        $(".header").toggleClass("darksmlheader");

        //        //$(".header").toggleClass("smlheader");
        //        // $(".header").removeClass("sticky");

        //         //littlebtn.addClass("hide");
        //        //headercontant.removeClass("hide");
               
        //        //window.pageYOffset = footersec.offsetTop;
        //       //window.pageYOffset = projectsec.offsetTop;
        //       //$('body').offsetTop = window.pageYOffset

        //       //--- for removing Scrollbar from the body itself
        //       $("body").toggleClass("overflow");

        //       window.pageYOffset = 5000;

        //        jQuery('body').css({
        //             'overflow-y': 'hidden'
        //             //'window.pageYOffset' : '2500'
        //             //'height'  : '$( window).pageYOffset'

        //     //         //'height.pageYOffset'  : projectsec.offsetHeight
        //     //         //'height'  : header.offsetHeight
        //     //         //'height'  : '150'
        //     //         //'height'  : $( window).height()
        //     //           'height'  : header.offsetHeight
        //      });
               

        //     //    var littlebtn = document.getElementById("littlebtn");
        //     //    var header = document.getElementById("myHeader");
        //     //    var headercontant = document.getElementById("header-contant");

        //     //     header.classList.remove("sticky");
        //     //     header.classList.remove("smlheader");
        //     //     header.classList.add("darksmlheader");

        //     //     littlebtn.classList.remove("hide");
        //     //     headercontant.classList.add("hide");
                
        //     //     jQuery('.header').css({
        //     //         'background-color': 'black'
        //     //     });
        //     }); 
        // });

    /*---------------------------------
        Logo Carousel
    ----------------------------------*/
    $(".logo__carousel").owlCarousel({
        loop: true,
        margin: 80,
        items: 5,
        dots: false,
        nav: false,
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        responsive: {
            320: {
                items: 2
            },
            576: {
                items: 3
            },
            992: {
                items: 5
            },
        }
    });

    /*------------------
        Counter
    --------------------*/
    $('.count').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 4000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });

})(jQuery);

/*------------------
    Media Filter Card
--------------------*/
const FilterContainer =document.querySelector(".media__filters"),
    filterBtns = FilterContainer.children,
    totalFilterBtn=filterBtns.length,
    MediaCards = document.querySelectorAll(".media__card"),
    totalMediaCards = MediaCards.length;

    for(let i=0; i<totalFilterBtn; i++){
        filterBtns[i].addEventListener("click",function(){
            FilterContainer.querySelector(".filters__button_active").classList.remove("filters__button_active");
            this.classList.add("filters__button_active");
            
            const filterValue = this.getAttribute("data-filter");
            for( let j =0; j<totalMediaCards; j++){
                if(filterValue === MediaCards[j].getAttribute("data-filter-card")){
                    MediaCards[j].classList.remove("hide");
                    MediaCards[j].classList.add("show");
                }
                else{
                    MediaCards[j].classList.remove("show");
                    MediaCards[j].classList.add("hide");
                }
                if(filterValue === "all"){
                    MediaCards[j].classList.remove("hide");
                    MediaCards[j].classList.add("show");

                }
            }
        })
    }

  