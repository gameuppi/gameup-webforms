$(document).ready(function () {
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    });

    $('[data-toggle="tooltip"]').tooltip();

    $('[data-toggle="popover"]').popover();

    $('#txtConfirmarSenha').on('keyup', function () {
        if ($('#txtConfirmarSenha').val().length >= 3) {
            if ($('#txtConfirmarSenha').val() != $('#txtSenha').val()) {
                $('#lblConfirmarSenha').html("As senhas não coincidem");
            } else {
                $('#lblConfirmarSenha').html("");
            }
        }
    })
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})