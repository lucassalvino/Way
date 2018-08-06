using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Way.Domain.Entities;

namespace Way.Domain.Arguments.Request
{
    public class PessoaRequest : BaseArgumentos
    {
        public Guid IdPessoa { get; set; }
        public List<Guid> Caracterizacoes { get; set; }
        public DateTime DataNascimento { get; set; }
        public String PrimeiroNome { get; set; }
        public String UltimoNome { get; set; }
        public String Site { get; set; }
        public List<EnderecoRequest> Enderecos { get; set; }
        public List<DocumentosRequest> Documentos { get; set; }
        public List<EmailRequest> Emails { get; set; }

        public static explicit operator Pessoa(PessoaRequest value)
        {
            return new Pessoa()
            {
                Ativo = value.Ativo,
                Id = value.IdPessoa,
                Caracterizacoes = value.Caracterizacoes,
                DataNascimento = value.DataNascimento,
                PrimeiroNome = value.PrimeiroNome,
                UltimoNome = value.UltimoNome,
                Site = value.Site,
                Enderecos = value.Enderecos.Select(x=>(Endereco)x).ToList(),
                Documentos = value.Documentos.Select(x=>(Documento)x).ToList(),
                Emails = value.Emails.Select(x=>(Email)x).ToList()
            };
        }
    }
}