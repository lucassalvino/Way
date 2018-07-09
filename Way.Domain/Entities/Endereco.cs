using System;

namespace Way.Domain.Entities
{
    public class Endereco : BaseEntidade
    {
        public Pessoa Pessoa { get; set; }

        public Coordenada Coordenada { get; set; }

        public String IE { get; set; }

        public String Observacao { get; set; }

        public String Cep { get; set; }

        public override void ExecuteValidation()
        {
            AddNotifications(Pessoa);
            AddNotifications(Coordenada);
        }
    }
}
