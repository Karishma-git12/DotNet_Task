var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: "Student/GetAll",
            type: "GET",
            "dataType": "json"
        },
        "columns": [
            {
                "data": "imageUrl",
                "render": function (data, type, row) {
                    if (!data) {
                        return '<img src="path/to/placeholder/image.jpg" style="width:50px;height:50px;"/>';
                    }
                    return '<img src="' + data + '" alt="Student Image" style="width:50px;height:50px;"/>';
                },
                "width": "20%"
            },
            { "data": "name", "width": "20%" },
            { "data": "age", "width": "20%" },
            { "data": "studentClassName", "width": "20%" },
            { "data": "rollNumber", "width": "20%" },
        ]
    })
}