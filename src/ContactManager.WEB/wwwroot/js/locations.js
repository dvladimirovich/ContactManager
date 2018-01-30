function locationsDataSource(options, callback) {

    // define the columns for the table
    var columns = [
        {
            "label": "Id",          // column header label
            "property": "Id",       // the JSON property you are binding to
            "sortable": false       // is the column sortable (if true returns name from property)
        },
        {
            "label": "Country",
            "property": "Country",
            "sortable": true
        },
        {
            "label": "Region",
            "property": "Region",
            "sortable": true
        },
        {
            "label": "City",
            "property": "City",
            "sortable": true
        },
        {
            "label": "Street",
            "property": "Street",
            "sortable": true
        },
        {
            "label": "Postal",
            "property": "Postal",
            "sortable": false
        }
    ];

    // set options
    var pageIndex = options.pageIndex;
    var pageSize = options.pageSize;
    var options = {
        "pageIndex": pageIndex,
        "pageSize": pageSize,
        "sortDirection": options.sortDirection,
        "sortBy": options.sortProperty,
        "filterBy": options.filter.value || '',
        "searchBy": options.search || ''
    };

    // calling API
    $.ajax({
        type: "POST",
        data: JSON.stringify(options),
        url: "/Address/Locations",
        contentType: "application/json",
        dataType: "json"
    }).done(function (data) {
        //data = JSON.parse(data);
        var items = data.Items;
        var totalItems = data.Total;
        var totalPages = Math.ceil(totalItems / pageSize);
        var startIndex = (pageIndex * pageSize) + 1;
        var endIndex = (startIndex + pageSize) - 1;

        if (endIndex > totalItems) {
            endIndex = totalItems;
        }

        // configure dataSource
        var dataSource = {
            "page": pageIndex,
            "pages": totalPages,
            "count": totalItems,
            "start": startIndex,
            "end": endIndex,
            "columns": columns,
            "items": items
        };

        // pass the dataSource back to the repeater
        callback(dataSource);
    }).error(function (er) {
        console.log(er);
    });
}

$(function () {
    // initialize the repeater
    var repeater = $('#locationsRepeater');
    // setup our dataSource to handle data retrieval
    // responsible for any paging, sorting, filtering, searching logic
    repeater.repeater({
        dataSource: locationsDataSource,
        list_noItemsHTML: 'no information to render'
    });
    //repeater.repeater('resize');
});