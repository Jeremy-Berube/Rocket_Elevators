
$(() => {
    console.log("hello");
    $.ajax({
        url: "/intervention/getbuildings",
        method: "GET",
        dataType: "json",
        error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + error);
        },
        success: function (response) {
            console.log("Response: ", response);

            update("#building", response);
        }
    });
});

// AJAX CALLS TO API
function ajax(type) {
    console.log("ajax")
    var _url
    var _data;
    var _typeId;
    var _elementId;
    var _idValue;
    var _request;

    // SWITCH STATEMENTS TO MAKE AJAX FLEXIBLE
    switch (type) {

        case 'building':
            _url = "/intervention/getBatteries";
            _typeId = '#battery';
            _elementId = $('#' + type);
            _idValue = _elementId.val();
            _data = { id: _idValue }

            $("#battery, #column, #elevator").empty();
            $("#batteryField").show();
            $("#columnField, #elevatorField").hide();
            break;

        case 'battery':
            _url = "/intervention/getColumns";
            _typeId = '#column';
            _elementId = $('#' + type);
            _idValue = _elementId.val();
            _data = { id: _idValue }

            $("#column, #elevator").empty();
            $("#columnField").show();
            $("#elevatorField").hide();
            break;

        case 'column':
            _url = "/intervention/getElevators";
            _typeId = '#elevator';
            _elementId = $('#' + type);
            _idValue = _elementId.val();
            _data = { id: _idValue }

            $("#elevator").empty();
            $("#elevatorField").show();
            break;
    }
    $.ajax({
        url: _url,
        method: "GET",
        dataType: "json",
        data: _data,
        error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + error);
        },
        success: function (response) {
            console.log("Response: ", response);

             update(_typeId, response);
        }
    });
}
// UPDATE HTML FORM FIELDS
function update(_typeId, response) {
    console.log("UPDATE!!!!")

    if (_typeId == "#column" || _typeId == "#elevator") {
        $(_typeId).append('<option selected="None" value>None</option>');
    }
    else {
        $(_typeId).append('<option selected="selected" disabled="disabled" value> --Select-- </option>');
    }
    for (var i = 0; i < response.length; i++) {
        $(_typeId).append('<option value="' + response[i] + '">' + response[i] + '</option>');
    }
}