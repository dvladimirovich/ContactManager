function contactsDataSource(options, callback) {

    // define the columns for the table
    var columns = [
        {
            "label": "Full Name",       // column header label
            "property": "FirstName",    // the JSON property you are binding to
            "sortable": true            // is the column sortable (if true returns name from property)
        },
        {
            "label": "Birth date",
            "property": "Birth",
            "sortable": true
        },
        {
            "label": "Email",
            "property": "Email",
            "sortable": true
        },
        {
            "label": "Phone",
            "property": "Phone",
            "sortable": true
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
        url: "/Contact/Contacts",
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

// override the column output via a custom renderer
// allows us to output custom markup for each column
function contactsColumnRenderer(helpers, callback) {
    // determine what column is being rendered
    var column = helpers.columnAttr;

    // get all the data for the entire row
    var rowData = helpers.rowData;
    var customMarkup = '';

    // only override the output for specific columns
    // will default to output the text 
    switch (column) {
        case 'FirstName':
            // combine FirstName and LastName into a single column
            customMarkup = rowData.FirstName + ' ' + rowData.LastName;
            break;
        default:
            // otherwise, just use the existing text value
            customMarkup = helpers.item.text();
            break;
    }

    helpers.item.html(customMarkup);

    callback();
}

// override the row output via a custom renderer.
function contactsRowRenderer(helpers, callback) {
    // get an id and add it to the "tr" DOM element
    var item = helpers.item;
    item.attr('id', 'row-' + helpers.rowData.Id);

    callback();
}

$(function () {
    // initialize the repeater
    var repeater = $('#contactsRepeater');
    // setup our dataSource to handle data retrieval
    // responsible for any paging, sorting, filtering, searching logic
    repeater.repeater({
        dataSource: contactsDataSource,
        list_noItemsHTML: 'no information to see...',
        list_columnRendered: contactsColumnRenderer,
        list_rowRendered: contactsRowRenderer
    });
    repeater.repeater('resize');
});