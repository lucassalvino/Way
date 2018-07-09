using System;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;

namespace Way.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Realiza o cadastro do Usuario e retorna o ID do cadastro
        /// </summary>
        UsuarioRespost CadastraUsuario(UsuarioRequest Usuario);

        /// <summary>
        /// Realiza edição de um usuario já cadastrado, necessida do Id do usuario
        /// </summary>
        BaseArgumentos EditaUsuario(Guid IdUsuario, UsuarioRequest Usuario);

        /// <summary>
        /// Realiza Inativação do Usuario informado pelo ID
        /// </summary>
        BaseArgumentos Inativar(Guid IdUsuario);

        /// <summary>
        /// Retorna o resultado da aplicação do filtro nos usuarios cadastrados
        /// </summary>
        List<UsuarioView> ListarUsuario(FiltroUsuario Filtro);

        /// <summary>
        /// Realiza autencticação do usuário :( obvio não ???
        /// </summary>
        /// <param name="Request">Dados de login</param>
        /// <returns></returns>
        LoginUsuarioRespost AutenticaUsuario(LoginUsuarioRequest Request);

        /// <summary>
        /// Desativa Sessao
        /// </summary>
        /// <param name="SessaoId"></param>
        void InativarSessao(Guid SessaoId);

        /// <summary>
        /// Desativa a sessão ativa para o usuario com guid Guid
        /// </summary>
        /// <param name="guid">Guid do usuário</param>
        /// <returns></returns>
        void InativaSessoesUsuario(Guid guid);
    }
}
