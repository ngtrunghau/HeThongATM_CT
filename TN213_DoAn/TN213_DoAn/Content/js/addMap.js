var mapObject = L.map("map", { center: [10.029055, 105.775648], zoom: 17 });
//hoặc: var mapObject = L.map('map').setView([10.029055, 105.775648], 17);
//Bản đồ nền dạng Raster
L.tileLayer(
    "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    {
        attribution: ''
    }
).addTo(mapObject);

var layerPoint = L.layerGroup().addTo(mapObject);
$.ajax(
    {
        url: '/ATM/getDB',
        dataType: "json",
        type: 'get',
        success: res => {
            //console.log(res);
            res.map(e => {
                var coors = e.geometry.match(/[0-9]+\.*[0-9]*/ig);
                var objectCoords = coors;
                L.marker([objectCoords[1], objectCoords[0]]).bindPopup(e.name).addTo(layerPoint);
            });
        }
    }
);