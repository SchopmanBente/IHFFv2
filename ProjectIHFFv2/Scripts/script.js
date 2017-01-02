
$(document).ready(function () {

    
    $('a').each(function () {
        /*Voor elke a die verwijzing heeft naar de huidige paginalink.
        de klasse current toe */
        if ($(this).prop('href') == window.location.href) {
            $(this).addClass('current');
        }
    });



});