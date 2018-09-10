var PessoaControle = {
    Get: function () {
        Loader.AdicionaLoaderParaElemento($('body'));
        var request = $.ajax({
            type: "GET",
            url: "api/Pessoa",
            data: { "IdSessao": Sessao.ObtemIDSessao() }
        });
        request.done(function (data) {
            Loader.RemoveLoaderDeElemento($('body'));
            var t = $("#pessoaCadastrados").DataTable();
            for (i = 0; i < data.length; i++) {
                var node = t.row.add([
                    'Primeiro nome',
                    'Ultimno nome',
                    'documento',
                    'ativo'
                ]).draw(false).node();
                $(node).attr("id", i);
            }
        });
        request.fail(function (data) {
            Loader.RemoveLoaderDeElemento($('body'));
            AlertMessages.ErrorMessage("Algum erro acaba de acontecer, tente novamente mais tarde ou entre em contato");
        });
    }
};


$(document).ready(function () {

    PessoaControle.Get();

    $("#adiciona-pessoa").on("click", function () {
        Sessao.SetarDadoTemporario("pessoa", false);
        Utilitarios.Redireciona(Utilitarios.HostAtual() + "/pessoa/detalhepessoa");
    });

    $("#edita-pessoa").on("click", function () {
        if (Sessao.GetDadoTemporario("pessoa")) {
            Utilitarios.Redireciona(Utilitarios.HostAtual() + "/pessoa/detalhepessoa");
        } else {
            AlertMessages.InfoMessage("Selecione uma pessoa.");
        }
    });

    $("#pessoaCadastrados").on('click', 'tr', function () {
        var table = $("#pessoaCadastrados").DataTable();
        var nodeId = table.row(this).node().id;

        if (table.rows('.selected').data().length > 0) {
            table.rows('.selected').nodes().to$().removeClass('selected');
        }

        $(this).toggleClass('selected');
        $("#edita-pessoa").removeClass("hide");
        Sessao.SetarDadoTemporario("pessoa", nodeId);
    });
});