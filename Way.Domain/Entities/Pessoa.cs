using System;
using System.Collections.Generic;
using Way.Domain.Resources;

namespace Way.Domain.Entities
{
    public class Pessoa : BaseEntidade
    {
        public String PrimeiroNome { get; set; }

        public String UltimoNome { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Site { get; set; }

        public List<Documento> Documentos { get; set; }

        public List<Email> Emails { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public List<Guid> Caracterizacoes { get; set; }

        public override void ExecuteValidation()
        {
            if (Emails != null)
                foreach (Email email in Emails)
                    AddNotifications(email);

            if (Documentos != null)
                foreach (Documento documento in Documentos)
                    AddNotifications(documento);
            else
                AddNotifications(MensagensEntidades.PessoaPrecisaDeAoMenosUmDocumento);

        }

    }
}
