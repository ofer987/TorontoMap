(function() {
    $('#create-player-form').submit(function() {
        var name = $(this).find('#name');
        var longitude = $(this).find('#longitude');
        var latitude = $(this).find('#latitude');

        var data = {
            'name': name,
            'longitude': longitude,
            'latitude': latitude
        };

        $.post('/players', data, function() {
            $.ajax('https://maps.googleapis.com/maps/api/js?key=AIzaSyAor0aj6SGbSlOjiso-Zx-44YB4xy3pRL4&callback=renderMap');
        });

        return false;
    });
}());
