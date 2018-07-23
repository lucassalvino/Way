var UsuarioManager = {
    IdUsuario : "00000000-0000-0000-0000-000000000000"
};

$(document).ready(function () {

    if (Sessao.GetDadoTemporario("usuario") != "false") {
        Loader.AdicionaLoaderParaElemento($('#wrapper'));
        var IdUsuario = Sessao.GetDadoTemporario("usuario");
        var request = $.ajax({
            type: "GET",
            url: "/api/Usuario",
            data:
                {
                    "IdEntidade": IdUsuario,
                    "IdSessao": Sessao.ObtemIDSessao()
                }
        });
        request.done(function (data) {
            if (data.error) {
                for (i = 0; i < data.alertas.length; i++)
                    AlertMessages.WarningMessage(data.alertas[i])
            } else {
                UsuarioManager.IdUsuario = data[0].idEntidade;
                $("#senha-usuario").val(UsuarioManager.IdUsuario);
                $("#resenha-usuario").val(UsuarioManager.IdUsuario);
                $("#email-usuario").val(data[0].email);
                $("#nome-usuario").val(data[0].usuario);
                $("#login-usuario").val(data[0].login);
                $("#usuario-ativo").prop('checked', data[0].ativo);
            }
            Loader.RemoveLoaderDeElemento($('#wrapper'));
        });
        request.fail(function (data) {
            AlertMessages.ErrorMessage("Ocorreu um erro ao para se comunicar com o servidor");
            Loader.RemoveLoaderDeElemento($('#wrapper'));
        });
    }

    $("#cancelar").on("click", function () {
        Utilitarios.Redireciona(Utilitarios.HostAtual() + "/usuario");
    });

    $("#salva-usuario").on("click", function () {
        Loader.AdicionaLoaderParaElemento($("#wrapper"));
        var nome = $("#nome-usuario").val();
        var login = $("#login-usuario").val();
        var email = $("#email-usuario").val();
        var senha = $("#senha-usuario").val();
        var resenha = $("#resenha-usuario").val();
        var ativo = $("#usuario-ativo").is(":checked");

        if (senha != resenha) {
            AlertMessages.WarningMessage("A senha não é igual a sua confirmação!!!");
            Loader.RemoveLoaderDeElemento($("#wrapper"));
            return;
        }

        var request = $.ajax({
            type: "POST",
            url: "/api/Usuario",
            data: {
                "IdUsuario": UsuarioManager.IdUsuario,
                "Login": login,
                "Senha": senha,
                "ReSenha": resenha,
                "Email": email,
                "Nome": nome,
                "IdSessao": Sessao.ObtemIDSessao(),
                "Ativo": ativo
            }
        });

        request.done(function (data) {
            try {
                if (data.error) {
                    for (i = 0; i < data.alertas.length; i++)
                        AlertMessages.WarningMessage(data.alertas[i])
                } else {
                    AlertMessages.SucessMessage(data.menssagem);
                    UsuarioManager.IdUsuario = data.idCadasto;
                    $("#senha-usuario").val(data.idCadasto);
                    $("#resenha-usuario").val(data.idCadasto);
                }
                Loader.RemoveLoaderDeElemento($("#wrapper"));
            }
            catch (err) {
                console.error(err);
                AlertMessages.ErrorMessage("Um erro acaba de acontecer no script da página");
            }
        });
        
        request.fail(function (data) {
            AlertMessages.ErrorMessage("Ocorreu um erro ao para se comunicar com o servidor");
            Loader.RemoveLoaderDeElemento($("#wrapper"));
        });
    });
});