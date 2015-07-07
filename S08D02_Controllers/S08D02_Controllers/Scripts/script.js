$(document).ready(function () {
    
    $("#operationForm").submit(function () {
        e.preventDefault();
        var data = $(this).serialize();

        $.ajax({
            url: "/Home/OperationAPI",
            data: data
        }).success(function (response) {
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });

    });

});