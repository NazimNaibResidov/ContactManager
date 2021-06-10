$(document).ready(function () {
    $("#example").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "/Home/Index",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [

            { "data": "name", "name": "name", "autoWidth": true },
            { "data": "phone", "name": "phone", "autoWidth": true },
            { "data": "salary", "name": "salary", "autoWidth": true },
            { "data": "married", "name": "married", "autoWidth": true },
            { "data": "dateofBirth", "name": "dateofBirth", "autoWidth": true },
            {
                "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Home/Edit/' + full.ID + '">Edit</a>'; }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.ID + "'); >Delete</a>";
                }
            },
        ]
    });
});

function DeleteData(ID) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(CustomerID);
    } else {
        return false;
    }
}

function Delete(CustomerID) {
    var url = '@Url.Content("~/")' + "DemoGrid/Delete";

    $.post(url, { ID: CustomerID }, function (data) {
        if (data) {
            oTable = $('#example').DataTable();
            oTable.draw();
        } else {
            alert("Something Went Wrong!");
        }
    });
}