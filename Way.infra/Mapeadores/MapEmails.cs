using System;
using System.ComponentModel.DataAnnotations.Schema;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapEmails : BaseMapEntidade
    {
        public Guid PessoaID { get; set; }

        [ForeignKey("PessoaID")]
        public MapPessoa Pessoa { get; set; }

        public String Endereco { get; set; }

        public static explicit operator MapEmails (Email value)
        {
            VerificaNotificacoes(value);
            return new MapEmails()
            {
                Id = value.Id,
                Ativo = value.Ativo,
                Endereco = value.Endereco,
                PessoaID = Guid.Empty
            };
        }
    }
}
