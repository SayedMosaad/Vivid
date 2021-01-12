
//Header for blog / media / project /career  pages

window.onscroll = function() {myotherFunction() };

        var mediaheader = document.getElementById("mediaheader"), 
            whitesec = document.getElementById("white-sec"),
            footer2 = document.getElementById("footer2-sec");


        var littlebtn =document.getElementById("littlebtn"),
            headercontant = document.getElementById("header-contant");

        var blacklogo = document.getElementById("black-logo"),
            whitelogo = document.getElementById("white-logo");


          function myotherFunction(){
            if( window.pageYOffset < mediaheader.offsetHeight){  // && window.pageYOffset > whitesec.offsetHeight
                mediaheader.classList.remove("sticky");
                mediaheader.classList.remove("smlheader");
                mediaheader.classList.remove("darksmlheader");

                littlebtn.classList.add("hide");
                headercontant.classList.remove("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }
            else if (window.pageYOffset <= (footer2.offsetTop - mediaheader.offsetHeight) && window.pageYOffset > mediaheader.offsetHeight ) {
                mediaheader.classList.remove("sticky");
                mediaheader.classList.add("smlheader");
                mediaheader.classList.remove("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.add("hide")
                whitelogo.classList.remove("hide");
            }
            else if(pageYOffset > footer2.offsetTop - mediaheader.offsetHeight){
                mediaheader.classList.remove("sticky");
                mediaheader.classList.remove("smlheader");
                mediaheader.classList.add("darksmlheader");

                littlebtn.classList.remove("hide");
                headercontant.classList.add("hide");

                blacklogo.classList.remove("hide")
                whitelogo.classList.add("hide");
            }

        }