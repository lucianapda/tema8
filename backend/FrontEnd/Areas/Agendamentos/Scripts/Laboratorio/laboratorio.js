$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#Descricao").val() === "") {
        alert("Descrição é obrigatoria.");
        return false;
    }

    if ($("#Bloco").val() === "") {
        alert("Bloco é obrigatorio.");
        return false;
    }

    if ($("#NumeroSala").val() === "0") {
        alert("Número da Sala é obrigatoria.");
        return false;
    }

    if ($("#QtdMaquinas").val() === "0") {
        alert("Quantidade máquinas é obrigatorio.");
        return false;
    }

    return true;
});