$(document).ready(function () {
    if (Utilitarios.HeGuidEmpty(Sessao.ObtemIDSessao())) {
        Utilitarios.Redireciona(Utilitarios.HostAtual());
    } else {
        Loader.AdicionaLoaderParaElemento();
        AlertMessages.InfoMessage("Verificando sessão");
        var IdSessao = Sessao.ObtemIDSessao();
        var request = $.ajax({
            type: "GET",
            url: "/api/Login/?idSessao=" + IdSessao
        });
        request.done(function(Data){
            if (!Data.sessaoAtiva) {
                Utilitarios.Redireciona(Utilitarios.HostAtual());
            } else {
                AlertMessages.SucessMessage("Sessão ativa");
            }
        });
        request.fail(function (Data) {
            AlertMessages.WarningMessage("Uma falha acaba de acontecer ao realizar acesso ao servidor. Tente novamente.");
        });
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