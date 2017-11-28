$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#IdDisciplina").val() === "") {
        erro("Disciplina é obrigatorio.");
        return false;
    }

    if ($("#IdLaboratorio").val() === "") {
        erro("laboratório é obrigatorio.");
        return false;
    }

    if ($("#DiaInicial").val() === "" || $("#HoraInicial").val() === "") {
        erro("Dia e hora inicial é obrigatorio.");
        return false;
    }


    if ($("#DiaFinal").val() === ""|| $("#HoraFinal").val() === "") {
        erro("Dia e hora final é obrigatorio.");
        return false;
    }
    
 
    return true;
});

function erro(message) {
    $('#alerts').append(
        '<div class="erro erro-danger">' +
        '<strong>Erro!</strong> <a href="#" class="erro-link">' +
        message +
        '</a>' +
        '</div>');
}

function erro(message) {

    $('#alerts').append(
        '<div class="alert alert-danger">' +
        '<strong>Erro!</strong> <a href="#" class="alert-link">' +
        message +
        '</a><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>' +
        '</div>');
}
