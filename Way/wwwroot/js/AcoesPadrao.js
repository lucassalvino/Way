$(document).ready(function () {
    if (Utilitarios.HeGuidEmpty(Sessao.ObtemIDSessao())) {
        Utilitarios.Redireciona(Utilitarios.HostAtual());
    } else {
        Loader.AdicionaLoaderParaElemento($('#wrapper'));
        //AlertMessages.InfoMessage("Verificando sessão");
        var IdSessao = Sessao.ObtemIDSessao();
        var request = $.ajax({
            type: "GET",
            url: "/api/Login/?idSessao=" + IdSessao
        });
        request.done(function(Data){
            if (!Data.sessaoAtiva) {
                Sessao.DesabilitaSessao();
                Utilitarios.Redireciona(Utilitarios.HostAtual());
            } else {
                AlertMessages.SucessMessage("Sessão ativa");
                Loader.RemoveLoaderDeElemento($('#wrapper'));
            }
        });
        request.fail(function (Data) {
            AlertMessages.WarningMessage("Uma falha acaba de acontecer ao realizar acesso ao servidor. Tente novamente.");
        });
    }

    $("table").DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ elementos por página",
            "zeroRecords": "Nenhum resultado",
            "info": "Página _PAGE_ de _PAGES_",
            "infoEmpty": "Nenhum elemento a ser exebido",
            "infoFiltered": "(filtrado de _MAX_ elementos)",
            "search": "Procurar",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            }
        },
        "select": {
            "style": 'single'
        }
    });

    $("#logout").on("click", function (evt) {
        Loader.AdicionaLoaderParaElemento($("#wrapper"));
        var idSessao = Sessao.ObtemIDSessao();
        var request = $.ajax({
            type: "PUT",
            url: "/api/Login/",
            data: { "IdSessao": idSessao }
        });

        request.done(function () {
            Sessao.DesabilitaSessao();
            AlertMessages.SucessMessage("Logou realizado com sucesso!");
            Utilitarios.Redireciona(Utilitarios.HostAtual());
        });

        request.fail(function (Erro) {
            AlertMessages.WarningMessage("Uma falha acaba de acontecer ao realizar acesso ao servidor. Tente novamente");
        });
    });
});