$(document).ready(function () {
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    });

    $('[data-toggle="tooltip"]').tooltip();

    $('[data-toggle="popover"]').popover();

});