using System;
using System.Collections.Generic;
using Way.Domain.Enum;

namespace Way.Domain.Entities
{
    public class Pessoa : BaseEntidade
    {
        public String PrimeiroNome { get; set; }

        public String UltimoNome { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Site { get; set; }

        public List<String> Documentos { get; set; }

        public List<String> Emails { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public List<TipoPessoa> TipoPessoa{ get; set; }

        public List<Guid> Caracterizacoes { get; set; }
    }
}
