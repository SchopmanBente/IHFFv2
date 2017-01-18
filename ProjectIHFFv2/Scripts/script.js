
$(document).ready(function () {
    var betaalstap1 = "Cart/Index"

    var betaalstap2 = "Cart/Betaal"

    var betaalstap3 = "Cart/Afgerond"
    
    $('a').each(function () {
        /*Voor elke a die verwijzing heeft naar de huidige paginalink.
        de klasse current toe */
     
        var string = window.location.href;
        var isSpecial = window.location.href.indexOf("Special") >= 0;

        if ($(this).prop('href') == window.location.href) {

            $(this).toggleClass('current');
            console.log(this)

            $(this).addClass('current');
            console.log($(this).attr('href'));


        }

       

      
    });



});