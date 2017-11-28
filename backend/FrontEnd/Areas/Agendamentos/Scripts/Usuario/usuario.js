$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#Nome").val() === "") {
        alert("Nome é obrigatorio.");
        return false;
    }

    if ($("#Login").val() === "") {
        alert("Login é obrigatorio.");
        return false;
    }

    if ($("#Senha").val() === "" || $("#ConfirmarSenha").val() === "") {
        alert("Senha e confirmar senha é obrigatorio.");
        return false;
    }

    if ($("#Senha").val() !== $("#ConfirmarSenha").val())
    {
        alert("Senhas devem ser iguais.");
        return false;
    }

    return true;
});