var UsuarioControle = {
    Get: function () {
        Loader.AdicionaLoaderParaElemento($('body'));
        var request = $.ajax({
            type: "GET",
            url: "api/Usuario",
            data: { "IdSessao": Sessao.ObtemIDSessao()}
        });

        request.done(function (data) {
            Loader.RemoveLoaderDeElemento($('body'));
            var t = $("#usuariosCadastrados").DataTable();
            for (i = 0; i < data.length; i++) {
                var node = t.row.add([
                    data[i].usuario,
                    data[i].login,
                    data[i].email,
                    data[i].ativo ? 'sim' : 'não'
                ]).draw(false).node();
                $(node).attr("id", data[i].idEntidade);
            }
        });

        request.fail(function (data) {
            Loader.RemoveLoaderDeElemento($('body'));
            Utilitarios.HeGuidEmpty(data);
        });
    }
};

$(document).ready(function () {
    UsuarioControle.Get();

    $("#adiciona-usuario").on("click", function () {
        Sessao.SetarDadoTemporario("usuario", false);
        Utilitarios.Redireciona(Utilitarios.HostAtual() + "/usuario/detalheusuario");
    });

    $("#edita-usuario").on("click", function () {
        if (Sessao.GetDadoTemporario("usuario")) {
            Utilitarios.Redireciona(Utilitarios.HostAtual() + "/usuario/detalheusuario");
        } else {
            AlertMessages.InfoMessage("Selecione um usuário.");
        }
    });

    $("#usuariosCadastrados").on('click', 'tr', function () {
        var table = $("#usuariosCadastrados").DataTable();
        var nodeId = table.row(this).node().id;

        if (table.rows('.selected').data().length > 0) {
            table.rows('.selected').nodes().to$().removeClass('selected');
        }

        $(this).toggleClass('selected');
        $("#edita-usuario").removeClass("hide");
        Sessao.SetarDadoTemporario("usuario", nodeId);
    });
});