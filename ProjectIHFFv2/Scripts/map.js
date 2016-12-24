

function initMap() {
        
        var directionsService = new google.maps.DirectionsService;
        var directionsDisplay = new google.maps.DirectionsRenderer;
        //Creer een nieuwe map waar Haarlem op te zien is.
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 14,
            center: { lat: 52.3873880, lng: 4.6462190 }
        });
        //Zet in het directionsDisplayobject een  map
        directionsDisplay.setMap(map);
        //Zet op het rechterpanel de routebeschrijving
        directionsDisplay.setPanel(document.getElementById('right-panel'));

    /*Als er geklikt wordt op de button met id=submit ,
    dan wordt de calculateAndDisplayRoute aangeroepen
    */
        document.getElementById('submit').addEventListener('click', function () {
            calculateAndDisplayRoute(directionsService, directionsDisplay);
        });
    }

    function calculateAndDisplayRoute(directionsService, directionsDisplay) {
        //Creer een array van waypoints
        var waypts = [];
        //Haal de geselecteerde waardes op uit het element met #waypoints
        var checkboxArray = document.getElementById('waypoints');
        //Doorloop alle waardes in #waypoints
        for (var i = 0; i < checkboxArray.length; i++) {
            //Als de waarde geselecteerd is, voeg dan de locatie toe en geef aan dat er gestopt wordt
            if (checkboxArray.options[i].selected) {
                waypts.push({
                    location: checkboxArray[i].value,
                    stopover: true
                });
            }
        }

        //Bereken de route
        directionsService.route({
            //Haal startpunt op uit #start
            origin: document.getElementById('start').value,
            //Haal eindpunt op uit #end
            destination: document.getElementById('end').value,
            //Geef aan dat de waypoints in de array waypts staan
            waypoints: waypts,
            optimizeWaypoints: true,
            travelMode: 'WALKING'
        }, function (response, status) {
            if (status === 'OK') {
                directionsDisplay.setDirections(response);
            } else {
                window.alert('Directions request failed due to ' + status);
            }
        });
    }



