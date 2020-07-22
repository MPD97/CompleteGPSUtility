let locationCount = 0;

function locationsOnClick() {
    console.log($(this).text());

    map.flyTo({
        center: [$(this).attr('lon'), $(this).attr('lat')],
        essential: true // this animation is considered essential with respect to prefers-reduced-motion
    });
}
function placeMarkers(json) {

    map.loadImage("https://i.imgur.com/MK4NUzI.png", function (error, image) {
        if (error) throw error;
        try {
            map.addImage("custom-marker", image);
        } catch (e) {}

        $.each(json, function (i, item) {
            map.addLayer({
                id: "markers-" + i,
                type: "symbol",
                source: {
                    type: "geojson",
                    data: {
                        type: 'FeatureCollection',
                        features: [{
                            type: 'Feature',
                            properties: {
                                description: i + "."
                            },
                            geometry: {
                                type: "Point",
                                coordinates: [item.longitude, item.latitude]
                            }
                        }]
                    }
                },
                layout: {
                    "icon-image": "custom-marker",
                    "icon-allow-overlap": false,
                    "icon-ignore-placement": false,
                    'text-field': ['get', 'description'],
                    'text-offset': [0, 1.8],

                    'text-justify': 'center',
                }
            }, i === 0 ? null : "markers-" + i - 1);
        });
        locationCount = json.length;
        map.flyTo({
            center: [json[json.length - 1].longitude, json[json.length - 1].latitude],
            essential: true // this animation is considered essential with respect to prefers-reduced-motion
        });
    });
}
function ClearLayers() {
    for (var i = 0; i < locationCount; i++) {
        var mapLayer = map.getLayer("markers-" + i);
        if (typeof mapLayer !== 'undefined') {
            // Remove map layer & source.
            map.removeLayer("markers-" + i).removeSource("markers-" + i);
        }
    }
}