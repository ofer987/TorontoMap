var Map = (function() {
    var apiKey = "AIzaSyAor0aj6SGbSlOjiso-Zx-44YB4xy3pRL4";
    var Map = function() {
        this.playerPositions = {};
    };

    Map.getApiKey = function() {
        return apiKey;
    };

    Map.prototype.render = function() {
        var element = document.getElementById('map');

        this.map = new google.maps.Map(element, {
            center: new google.maps.LatLng(45, -45),
            zoom: 100
        });

        this.renderMarkers(this.playerPositions);
    };

    Map.prototype.renderMarkers = function(positions) {
        for (var key in positions) {
            if (positions.hasOwnProperty(key)) {
                var position = positions[key];

                new google.maps.Marker({
                    position: position,
                    map: this.map
                });
            }
        }
    };

    Map.prototype.addPosition = function(playerName, latitude, longitude) {
        var position = { lat: latitude, lng: longitude };

        this.playerPositions[playerName] = position;
    };

    return Map;
})();
