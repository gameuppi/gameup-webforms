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

    $('#dtInicio').on('change', function () {
        var agora = new Date();
        var escolhida = new Date(this.value);

        if (escolhida < agora) {
            this.value = [agora.getFullYear(), agora.getMonth() + 1, agora.getDate()].map(v => v < 10 ? '0' + v : v).join('-');
        }
    })
});