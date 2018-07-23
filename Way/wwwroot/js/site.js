﻿var Utilitarios = {
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
    },
    AtualizarUrlPagina: function (novaUrl) {
        window.history.replaceState({ path: novaUrl }, '', novaUrl);
    }
};

var Sessao = {
    ObtemIDSessao: function () {
        return (sessionStorage['IDSessao'] || '00000000-0000-0000-0000-000000000000');
    },
    SetarIDSessao: function (IdSessao) {
        sessionStorage['IDSessao'] = IdSessao;
    },
    DesabilitaSessao: function () {
        sessionStorage['IDSessao'] = '00000000-0000-0000-0000-000000000000';
    },
    SetarDadoTemporario: function (chave, dado) {
        if (chave)
            sessionStorage[chave] = dado;
    },
    GetDadoTemporario: function (chave) {
        if (chave)
            return sessionStorage[chave];
        return null;
    }
    
};