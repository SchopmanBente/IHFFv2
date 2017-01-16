
$(document).ready(function () {
    var betaalstap1 = "Cart/Index"

    var betaalstap2 = "Cart/Betaal"

    var betaalstap3 = "Cart/Afgerond"
    
    $('a').each(function () {
        /*Voor elke a die verwijzing heeft naar de huidige paginalink.
        de klasse current toe */


        if ($(this).prop('href') == window.location.href) {
            $(this).toggleClass('current');
            console.log(this)


        }

      
    });



});