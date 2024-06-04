
    $("#ddlDepartamento").attr("disabled", true);

    $("#ddlEmpresa").change(function () {

        if ($(this).val() != "") {

            $('#ddlDepartamento').empty();
            $('#ddlDepartamento').append($('<option></option>').val("").html("Aguarde ..."));
            $("#ddlDepartamento").attr("disabled", true);

            $.ajax({
                method: 'POST',
                url: 'DepartamentoPorEmpresa',
                cache: true,
                async: true,
                data: { idEmpresa: $(this).val() },
                error: function (erro) {
                    ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
                },
                success: function (content) {                   
                    if (content.value.length > 0) {
                        $("#ddlDepartamento").attr("disabled", false);
                        $('#ddlDepartamento').empty();
                        $('#ddlDepartamento').append($('<option></option>').val("").html("Selecione um departamento"));
                        for (var i = 0; i < content.value.length; i++) {
                            $('#ddlDepartamento').append(
                                $('<option></option>').val(content.value[i].id).html(content.value[i].nome + " - " + content.value[i].sigla)
                            );
                        }
                    }
                    else {
                        $('#ddlDepartamento').empty();
                        $('#ddlDepartamento').append($('<option></option>').val("").html("Nenhum departamento encontrado para esta empresa"));
                    }
                }
            });
        }
        else {
            $('#ddlDepartamento').empty();
            $('#ddlDepartamento').append($('<option></option>').val("").html("Selecione antes uma Empresa..."));
            $("#ddlDepartamento").attr("disabled", true);
        }
    });

