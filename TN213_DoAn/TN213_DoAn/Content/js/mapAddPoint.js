var mapObject = L.map("mapaddpoint", { center: [10.029055, 105.775648], zoom: 17 });
L.tileLayer(
    "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    {
        attribution: ''
    }
).addTo(mapObject);

mapObject.on("click", onMapClick);
var popup = L.popup();
function onMapClick(e) {
	popup
		.setLatLng(e.latlng)
		.setContent(
			"Bạn đã click ở (Kinh độ (lng), Vĩ độ (lat)):<br>" +
			Math.round(e.latlng.lng * 1000000 + Number.EPSILON) / 1000000 + ", " +
			Math.round(e.latlng.lat * 1000000 + Number.EPSILON) / 1000000
		)
		.openOn(mapObject);
	$('#kinhdo').val(Math.round(e.latlng.lng * 1000000 + Number.EPSILON) / 1000000);
	$('#vido').val(Math.round(e.latlng.lat * 1000000 + Number.EPSILON) / 1000000);
}