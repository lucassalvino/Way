var LoginController = {
    Post: function (data) {
        Loader.AdicionaLoaderParaElemento($(".card"));
        var request = $.ajax({
            type: "POST",
            url: "/api/Login/",
            data: data
        });
        request.done(function (data) {
            Loader.RemoveLoaderDeElemento($(".card"));
            if (typeof data != "undefined") {
                if (!Utilitarios.HeUndefined(data.sessaoId) && !Utilitarios.HeGuidEmpty(data.sessaoId)) {
                    AlertMessages.SucessMessage("Usuário logado com sucesso!!!");
                    Sessao.SetarIDSessao(data.sessaoId);
                    Utilitarios.Redireciona(Utilitarios.HostAtual() + "/home");
                } else {
                    AlertMessages.WarningMessage("Login incorreto.");
                }
            }
        });
        request.fail(function (jqXHR) {
            Loader.RemoveLoaderDeElemento($(".card"));
            if (typeof textStatus == "undefined") {
                AlertMessages.ErrorMessage("Não foi possível acessar nosso servidor. Tente novamente ou entre em contato");
            }
        });
    }
};

$("#BtnLogin").on("click", function () {
    var userName = $("#UserName").val();
    var passwd = $("#UserPasswd").val();
    if (userName == "") {
        AlertMessages.WarningMessage("O nome do usuário é obrigatório!!!");
        return;
    }
    if (passwd == "") {
        AlertMessages.WarningMessage("A senha é obrigatória!!!");
        return;
    }
    var post = {
        "Login":userName,
        "Senha":passwd
    };
    LoginController.Post(post);
});