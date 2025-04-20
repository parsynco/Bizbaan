
function InitVideo() {
    const videoElement = document.querySelector('youtube-video');
    if (videoElement) {
        // must wait for DOM to be ready and for component to be accessible

        // wait for loading
        videoElement.load().then(() => {
            // pause video after two seconds
            const timer = setTimeout(function () {
                videoElement.pause();
                clearTimeout(timer);
            }, 2000);
        });

    }
}
var app;
var inEditMode = false;
var MAP;
function ActiveMap({ mode = false }) {

    //alert(mode);
    inEditMode = mode.mode;
    var myAPIKey = "c9373ff3b73344a1a9286c06746bc93f";
    MAP = new maplibregl.Map({
        container: 'biz-map',
        center: [-99.759930, 42.058873],
        zoom: 2.5,
        style: `https://maps.geoapify.com/v1/styles/osm-bright/style.json?apiKey=${myAPIKey}`,
    });
    MAP.addControl(new maplibregl.NavigationControl());

    MAP.on('load', () => {
        MAP.setPaintProperty('highway-motorway', 'line-width', { "base": 1.2, "stops": [[6.5, 0], [7, 1.25], [20, 45]] });
    });

}

function AddMarker(cords) {
    var myAPIKey = "c9373ff3b73344a1a9286c06746bc93f";
    MAP = new maplibregl.Map({
        container: 'biz-map',
        center: [cords.lng, cords.lat],
        zoom: 7,
        style: `https://maps.geoapify.com/v1/styles/osm-bright/style.json?apiKey=${myAPIKey}`,
    });
    MAP.addControl(new maplibregl.NavigationControl());

    MAP.on('load', () => {
        MAP.setPaintProperty('highway-motorway', 'line-width', { "base": 1.2, "stops": [[6.5, 0], [7, 1.25], [20, 45]] });
    });
    var bicon = document.createElement('div');
    bicon.classList.add("business-icon-over-map");
    var bm = new maplibregl.Marker(bicon, {
        anchor: 'bottom',
        offset: [0, 6]
    }).setLngLat([cords.lng, cords.lat]).addTo(MAP);
    bm.setOffset([0, 1])

}



function SetAddressOnMap(latlng) {
    console.error("Lat and Lng received : ", latlng);

}



