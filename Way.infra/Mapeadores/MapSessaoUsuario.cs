using System;
using System.ComponentModel.DataAnnotations.Schema;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapSessaoUsuario : BaseMapEntidade
    {
        public Guid UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public MapUsuario Usuario { get; set; }

        public DateTimeOffset DataInicioSessao { get; set; }

        public static explicit operator MapSessaoUsuario(SessaoUsuario value)
        {
            VerificaNotificacoes(value);

            Guid IdUsuario = Guid.Empty;
            if (value.Usuario != null)
                IdUsuario = value.Usuario.Id;
            else if (value.UsuarioId != Guid.Empty)
                IdUsuario = value.UsuarioId;
            else
                throw new Exception("Não foi definido nenhum usuário definido para a sessão");

            return new MapSessaoUsuario()
            {
                Id = value.Id,
                Ativo = value.Ativo,
                DataInicioSessao = value.InicioSessao,
                UsuarioID = IdUsuario,
                Usuario = (MapUsuario)value.Usuario
            };
        }
    }
}
