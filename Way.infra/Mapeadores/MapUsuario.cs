using System;
using System.ComponentModel.DataAnnotations;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapUsuario : BaseMapEntidade
    {
        [MaxLength(64)]
        [Required]
        public string Login { get; set; }

        [MaxLength(64)]
        [Required]
        public string Senha { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        Guid InstituicaoID { get; set; }

        public static explicit operator MapUsuario (Usuario value)
        {
            VerificaNotificacoes(value);
            return new MapUsuario()
            {
                Id = value.Id,
                Ativo = value.Ativo,
                Login = value.Login,
                Senha = value.Senha,
                InstituicaoID = value.Instituicao == null ? value.InstituicaoID : value.Instituicao.Id, 
                Email = value.Email
            };
        }
    }
}
