let map;

async function initMap() {
    // The location of Uluru
    // Request needed libraries.
    //@ts-ignore
    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerView } = await google.maps.importLibrary("marker");

    // The map, centered at Uluru
    map = new Map(document.getElementById("map"), {
        zoom: 13,
        center: POINTS[0],
        mapId: "DEMO_MAP_ID",
    });
    console.log(POINTS)
    POINTS.forEach(point => {

        const marker = new AdvancedMarkerView({
            map: map,
            position: point,
            title: "stop",
        });
    });
    // The marker, positioned at Uluru
}

initMap();