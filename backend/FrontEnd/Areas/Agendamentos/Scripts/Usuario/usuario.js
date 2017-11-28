$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#Nome").val() === "") {
        var message = "Nome é obrigatorio.";
        erro(message);
        return false;
    }

    if ($("#Login").val() === "") {
        erro("Login é obrigatorio.");
        return false;
    }

    if ($("#Senha").val() === "" || $("#ConfirmarSenha").val() === "") {
        erro("Senha e confirmar senha é obrigatorio.");
        return false;
    }

    if ($("#Senha").val() !== $("#ConfirmarSenha").val())
    {
        erro("Senhas devem ser iguais.");
        return false;
    }

    return true;
});

function erro(message) {
    $('#alerts').append(
        '<div class="alert alert-danger">' +
        '<strong>Erro!</strong> <a href="#" class="alert-link">' +
        message +
        '</a><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>' +
        '</div>');
}