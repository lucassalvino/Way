using System;
using System.Collections.Generic;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;

namespace Way.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepositorio
    {
        void InativaSessoesUsuario(Guid IdUsuario);

        void InativaSessao(Guid IdSessao);

        bool SessaoAtiva(Guid IdSessao);

        LoginUsuarioRespost AutenticaUsuario(LoginUsuarioRequest Usuario);

        UsuarioRespost CadastraUsuario(UsuarioRequest Usuario);

        UsuarioRespost EditaUsuario(Guid IdUsuario, UsuarioRequest Usuario);

        UsuarioRespost Inativar(Guid IdUsuario);

        List<UsuarioView> ListarUsuario(FiltroUsuario Filtro);
    } 
}
