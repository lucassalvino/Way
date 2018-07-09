using System;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;

namespace Way.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepositorio
    {
        void InativaSessoesUsuario(Guid IdUsuario);

        void InativaSessao(Guid IdSessao);

        bool SessaoAtiva(Guid IdSessao);

        LoginUsuarioRespost AutenticaUsuario(LoginUsuarioRequest Usuario);

        UsuarioRespost CadastraUsuario(UsuarioRequest Usuario);

        BaseArgumentos EditaUsuario(Guid IdUsuario, UsuarioRequest Usuario);

        BaseArgumentos Inativar(Guid IdUsuario);

        List<UsuarioView> ListarUsuario(FiltroUsuario Filtro);
    } 
}
