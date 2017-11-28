$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#IdDisciplina").val() === "") {
        alert("Disciplina é obrigatorio.");
        return false;
    }

    if ($("#IdLaboratorio").val() === "") {
        alert("laboratório é obrigatorio.");
        return false;
    }

    if ($("#DiaInicial").val() === "" || $("#HoraInicial").val() === "") {
        alert("Dia e hora inicial é obrigatorio.");
        return false;
    }

    if ($("#DiaInicial").val() < new Date().toLocaleString()) {
        alert("Dia inicial não pode ser menor que a data atual.");
        return false;
    }

    if ($("#DiaFinal").val() === ""|| $("#HoraFinal").val() === "") {
        alert("Dia e hora final é obrigatorio.");
        return false;
    }

    if ($("#DiaFinal").val() < new Date().toLocaleString()) {
        alert("Dia inicial não pode ser menor que a data atual.");
        return false;
    }

    if ($("#DiaInicial").val() > $("#DiaFinal").val()) {
        alert("Data inicial não pode ser maior que data final.");
        return false;
    }

    if ($("#DiaFinal").val() > $("#DiaFinal").val()) {
        alert("Data final não pode ser maior que data final.");
        return false;
    }

    return true;
});