using System;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapPessoa : BaseMapEntidade
    {
        public String PrimeiroNome { get; set; }

        public String UltimoNome { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Site { get; set; }

        public static explicit operator MapPessoa(Pessoa value)
        {
            VerificaNotificacoes(value);

            return new MapPessoa()
            {
                Ativo = value.Ativo,
                DataCadastro = value.DataCadastro,
                DataNascimento = value.DataNascimento,
                Id = value.Id,
                PrimeiroNome = value.PrimeiroNome,
                Site = value.Site,
                UltimoNome = value.UltimoNome
            };
        }
    }
}
