$('#quanHuyen').append("<option value='tatca'>Tất cả</option>");
$('#xaPhuong').append("<option value='tatca'>Tất cả</option>");
$.ajax({
    url: '/QuanHuyen/getDB',
    dataType: 'json',
    type: 'get',
    success: res => {
        //console.log(res);
        res.map(e => {
            $('#quanHuyen').append("<option value='" + e.id + "'>" + e.name + "</option>");
        });
    }
});



$('#quanHuyen').change(e => {
    $('#xaPhuong').children('option:not(:first)').remove();
    var id_QH = $('#quanHuyen').val();
    if (id_QH == 'tatca') {
        $.ajax({
            url: '/XaPhuong/getDB',
            type: 'get',
            dataType: 'json',
            success: res => {
                //console.log(res);
                $('#xaPhuong').append("<option value='tatca'>Tất cả</option>");
                res.map(e => {
                    $('#xaPhuong').append("<option value='" + e.id + "'>" + e.name + "</option>");
                });
            }
        });
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

    } else {
        $.ajax({
            url: '/XaPhuong/getDB',
            type: 'post',
            dataType: 'json',
            data: { 'id': id_QH },
            success: res => {
                //console.log(res);
                res.map(e => {
                    $('#xaPhuong').append("<option value='" + e.id + "'>" + e.name + "</option>");
                });
            }
        });
        layerPoint.clearLayers();
        $.ajax({
            url: '/ATM/getDB_QH',
            type: 'post',
            dataType: 'json',
            data: { 'id': id_QH },
            success: res => {
                //console.log(res);
                res.map(e => {
                    var coors = e.geometry.match(/[0-9]+\.*[0-9]*/ig);
                    var objectCoords = coors;
                    L.marker([objectCoords[1], objectCoords[0]]).bindPopup(e.name).addTo(layerPoint);
                });
            }
        });
    }
});

$('#xaPhuong').change(e => {
    layerPoint.clearLayers();
    var id_XP = $('#xaPhuong').val();
    var id_QH = $('#quanHuyen').val();
    if (id_XP == 'tatca') {
        $.ajax({
            url: '/ATM/getDB_QH',
            type: 'post',
            dataType: 'json',
            data: {'id': id_QH},
            success: res => {
                res.map(e => {
                    var coors = e.geometry.match(/[0-9]+\.*[0-9]*/ig);
                    var objectCoords = coors;
                    L.marker([objectCoords[1], objectCoords[0]]).bindPopup(e.name).addTo(layerPoint);
                });
            }
        })
    } else {
        $.ajax({
            url: '/ATM/getDB_PX',
            type: 'post',
            dataType: 'json',
            data: { 'id': id_XP },
            success: res => {
                res.map(e => {
                    var coors = e.geometry.match(/[0-9]+\.*[0-9]*/ig);
                    var objectCoords = coors;
                    L.marker([objectCoords[1], objectCoords[0]]).bindPopup(e.name).addTo(layerPoint);
                });
            }
        })
    }
});

$.ajax(
    {
        url: '/NganHang/getDB_NH',
        type: 'get',
        dataType: 'json',
        success: res => {
            //console.log(res);
            $('#nganHang').append("<option value='tatca'>Tất cả</option>");
            res.map(e => {
                $('#nganHang').append("<option value='" + e.id + "'>" + e.name + "</option>");
            });
        }
    }
);

$('#nganHang').change(e => {
    layerPoint.clearLayers();
    var id_nh = $('#nganHang').val();
    if (id_nh == "tatca") {
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
        )
    } else {
        $.ajax({
            url: '/ATM/getDB_NH',
            type: 'post',
            dataType: 'json',
            data: { 'id': id_nh },
            success: res => {
                res.map(e => {
                    var coors = e.geometry.match(/[0-9]+\.*[0-9]*/ig);
                    var objectCoords = coors;
                    L.marker([objectCoords[1], objectCoords[0]]).bindPopup(e.name).addTo(layerPoint);
                });
            }
        });
    }
});