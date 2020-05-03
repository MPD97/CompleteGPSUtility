let lastIMEI = undefined;
var interval = undefined;
var progress = 0;

$(document).ready(function () {

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            const json = JSON.parse(xhr.responseText);
            console.log(json);


            var container = $("#devices > .card-body");
            container.empty();

            $.each(json, function (i, item) {
                //<button type="button" class="btn btn-lg btn-block btn-outline-primary">Sign up for free</button>
                var button = $("<button></button>").text(item.name);
                button.addClass("btn btn-lg btn-block btn-outline-primary device");
                button.attr("imei", item.imei);
                container.append(button);
            });

            $(".device").click(devicesOnClick);
        }
    }
    xhr.open('GET', '/api/device', true);
    xhr.send(null);
});

function devicesOnClick() {
    if (typeof interval !== 'undefined') {
        clearInterval(interval);
        progress = 0;
    }
    ClearLayers();
    DownloadLocations($(this).attr("imei"));
    lastIMEI = $(this).attr("imei");
    interval = setInterval(RefreshInterval, 1000);
}
function RefreshInterval() {
    var progressbar = $("#progressbar");
    progress += 10;
    progressbar.attr('aria-valuenow', progress);
    progressbar.css("width", progress + "%");

    if (progress === 100) {
        $(".device").click();
    }
}
function DownloadLocations(imei) {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            const json = JSON.parse(xhr.responseText);
            console.log(json);
            var container = $("#locations > .card-body");
            container.empty();
            $.each(json, function (i, item) {
                //<button type="button" class="btn btn-lg btn-block btn-outline-primary">Sign up for free</button>
                var button = $("<button></button>").text(json.length - 1 - i + ". " + ConvertToDate(item.timeY2K));
                button.addClass("btn btn-lg btn-block btn-outline-primary location");
                button.attr("locationId", item.locationId);
                button.attr("lon", item.longitude);
                button.attr("lat", item.latitude);
                container.append(button);
            });
            $(".location").click(locationsOnClick);
            placeMarkers(json);
        }
    };
    xhr.open('GET', '/api/location?imei=' + imei, true);
    xhr.send(null);
}
function ConvertToDate(y2kSeconds) {
    var y2kFromTimestamp = 946684800;
    var date = new Date(y2kFromTimestamp + y2kSeconds * 1000); // set year 2000
    let options = {
        weekday: "long", day: "numeric", month: "short",
        hour: "2-digit", minute: "2-digit"
    };
    // d.setUTCSeconds(y2kSeconds);
    return date.toLocaleTimeString("pl-pl", options);
}