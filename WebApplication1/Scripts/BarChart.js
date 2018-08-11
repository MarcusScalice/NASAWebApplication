// Load the Visualization API and the corechart package.
google.charts.load('current', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded.
google.charts.setOnLoadCallback(drawChart);

// Callback that creates and populates a data table,
// instantiates the pie chart, passes in the data and
// draws it.
function drawChart() {

    // Create the data table.
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Name');
    data.addColumn('number', 'Mass');

    // Set chart options
    var options = {
        'title': "Meteorite's Mass",
        'width': 400,
        'height': 300
    };

    $.ajax({
        url: '@Url.Action("MeteoritesChart", "Charts")',
        datatype: "json",
        type: "get",
        async: false,
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (d) {
            $.each(d, function (index, item) {
                data.addRow([item.Name, item.Mass]);
            });
        },
        error: function (xhr) {
            alert("Error " + xhr);
        }
    });

    // Instantiate and draw our chart, passing in some options.
    var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}