$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#Descricao").val() === "" ) {
        erro("Descrição é obrigatoria.");
        return false;
    }

    if ($("#Curso").val() === "") {
        erro("Curso é obrigatorio.");
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