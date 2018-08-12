using System;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;
using Way.Domain.Interfaces.Repositories;
using Way.Domain.Interfaces.Services;

namespace Way.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            if(usuarioRepositorio == null)
                throw new Exception("Definição do repositório é obrigatório");
            _usuarioRepositorio = usuarioRepositorio;
        }

        public LoginUsuarioRespost AutenticaUsuario(LoginUsuarioRequest Request)
        {
            return _usuarioRepositorio.AutenticaUsuario(Request);
        }

        public UsuarioRespost CadastraUsuario(UsuarioRequest Usuario)
        {
            return _usuarioRepositorio.CadastraUsuario(Usuario);
        }

        public void InativaSessoesUsuario(Guid guid)
        {
            _usuarioRepositorio.InativaSessoesUsuario(guid);
        }

        public BaseArgumentos EditaUsuario(Guid IdUsuario, UsuarioRequest Usuario)
        {
            return _usuarioRepositorio.EditaUsuario(IdUsuario, Usuario);
        }

        public BaseArgumentos Inativar(Guid IdUsuario)
        {
            return _usuarioRepositorio.Inativar(IdUsuario);
        }

        public List<UsuarioView> ListarUsuario(FiltroUsuario Filtro)
        {
            return _usuarioRepositorio.ListarUsuario(Filtro);
        }

        public void InativarSessao(Guid SessaoId)
        {
            _usuarioRepositorio.InativaSessao(SessaoId);
        }

        public bool SessaoAtiva(Guid SessaoId)
        {
            return _usuarioRepositorio.SessaoAtiva(SessaoId);
        }
    }
}
