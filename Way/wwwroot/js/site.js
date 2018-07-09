var Utilitarios = {
    HostAtual: function () {
        return (window.location.protocol + "//" + window.location.host);
    },
    Redireciona: function (url) {
        window.location = url;
    },
    HeGuidEmpty: function (value) {
        return (value == "00000000-0000-0000-0000-000000000000");
    },
    HeUndefined: function (value) {
        return (typeof value == "undefined");
    }
};

var Sessao = {
    ObtemIDSessao: function () {
        return (localStorage['IDSessao'] || '00000000-0000-0000-0000-000000000000');
    },
    SetarIDSessao: function (IdSessao) {
        localStorage['IDSessao'] = IdSessao;
    },
    DesabilitaSessao: function () {
        localStorage['IDSessao'] = '00000000-0000-0000-0000-000000000000';
    }
};