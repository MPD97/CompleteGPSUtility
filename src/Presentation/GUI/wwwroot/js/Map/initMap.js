var map;
var selectedStyle = "osm-bright";
$(document).ready(function () {


    console.log("OSM-Server URL: " + osmServer);

    var q = (location.search || '').substr(1).split('&');
    var preference =
        q.indexOf('vector') >= 0 ? 'vector' :
            (q.indexOf('raster') >= 0 ? 'raster' :
                (mapboxgl.supported() ? 'vector' : 'raster'));
    if (preference == 'vector') {
        mapboxgl.setRTLTextPlugin(osmServer + '/mapbox-gl-rtl-text.js');
        map = new mapboxgl.Map({
            container: 'map',
            style: osmServer + '/styles/' + selectedStyle + '/style.json',
            center: [21.0521, 52.2167],
            zoom: 10.5,
            hash: true
        });
        map.addControl(new mapboxgl.NavigationControl());
    } else {
        map = L.mapbox.map('map', osmServer + '/styles/' + selectedStyle + '.json', { zoomControl: false });
        new L.Control.Zoom({ position: 'topright' }).addTo(map);
        setTimeout(function () {
            new L.Hash(map);
            console.log('This function timeout');
        }, 0);
    }
    //map.on('load', function () {
    //    map.loadImage(
    //        '/images/mobile-cell-tower5-tr.png',
    //        function (error, image) {
    //            if (error) throw error;
    //            map.addImage('BTS-Icon', image);
    //        }
    //    );
    //    map.loadImage(
    //        '/images/marker-red-tr-v2.png',
    //        function (error, image) {
    //            if (error) throw error;
    //            map.addImage('Location-red-marker', image);
    //        }
    //    );
    //    $('#util-location').click();
    //});
});