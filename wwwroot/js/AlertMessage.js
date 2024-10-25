function AlertMessage(url, id,redirectUrl) {
    if ($('#' + id).valid()) {
        swal({
            title: "Want to add data?",
            text: "Add Information!!!",
            buttons: true,
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Add",
            dangerMode: false
        }).then((willadd) => {
            if (willadd) {
                var formData = new FormData(document.getElementById(id));
                $.ajax({
                    url: url,
                    type: "POST",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        if (data.success) {
                            swal({
                                title: "Success!",
                                text: data.message,
                                icon: "success" 
                            }).then(() => {
                                window.location.href = redirectUrl;
                            })
                        } else {
                            swal({
                                title: "Error!",
                                text: data.message,
                                icon: "error",
                                button: "OK"
                            });
                        }
                    }
                });
            }
        });
    } 
}
