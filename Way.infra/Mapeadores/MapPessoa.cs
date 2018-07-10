using System;

namespace Way.infra.Mapeadores
{
    public class MapPessoa : BaseMapEntidade
    {
        public String PrimeiroNome { get; set; }

        public String UltimoNome { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Site { get; set; }
    }
}
