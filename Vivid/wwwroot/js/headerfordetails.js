//Header for blog / project details pages

window.onscroll = function() {myotherFunction() };

// for media - blog page
        var headerdetails = document.getElementById("headerdetails"), 
            whitesec = document.getElementById("white-sec"),
            footer2 = document.getElementById("footer2-sec");


        var littlebtn =document.getElementById("littlebtn"),
            headercontant = document.getElementById("header-contant");

        var blacklogo = document.getElementById("black-logo"),
            whitelogo = document.getElementById("white-logo");



          function myotherFunction(){
            if( window.pageYOffset < headerdetails.offsetHeight){
                headerdetails.classList.remove("sticky");
                headerdetails.classList.remove("smlheader");
                headerdetails.classList.remove("darksmlheader");

                littlebtn.classList.add("hide");
                headercontant.classList.remove("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }
            else if (window.pageYOffset <= (footer2.offsetTop - headerdetails.offsetHeight) && window.pageYOffset > headerdetails.offsetHeight ) {
                headerdetails.classList.remove("sticky");
                headerdetails.classList.add("smlheader");
                headerdetails.classList.remove("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.add("hide")
                whitelogo.classList.remove("hide");
            }
            else if(pageYOffset > footer2.offsetTop - headerdetails.offsetHeight){
                headerdetails.classList.remove("sticky");
                headerdetails.classList.remove("smlheader");
                headerdetails.classList.add("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }

        }