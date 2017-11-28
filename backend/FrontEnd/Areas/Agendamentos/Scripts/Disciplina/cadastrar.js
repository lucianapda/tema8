$('form').submit(function (event) {

    if (confirm("Deseja confirmar a ação?") === false) {
        event.preventDefault();
        return;
    }

    if ($("#Descricao").val() === "" ) {
        alert("Descrição é obrigatoria.");
        return false;
    }

    if ($("#Curso").val() === "") {
        alert("Curso é obrigatorio.");
        return false;
    }
   
    return true;
});