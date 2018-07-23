using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Way.Domain;
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

        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        public Guid InstituicaoID { get; set; }

        [ForeignKey("InstituicaoID")]
        public MapPessoa Instituicao { get; set; }

        public static explicit operator MapUsuario (Usuario value)
        {
            VerificaNotificacoes(value);

            MapUsuario ret = new MapUsuario()
            {
                Id = value.Id,
                Ativo = value.Ativo,
                Login = value.Login,
                InstituicaoID = value.Instituicao == null ? value.InstituicaoID : value.Instituicao.Id, 
                Email = value.Email,
                Nome = value.Nome
            };

            ret.Senha = Util.HashSHA256(value.Senha);

            return ret;
        }
    }
}
