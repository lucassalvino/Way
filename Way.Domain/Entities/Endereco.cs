using System;

namespace Way.Domain.Entities
{
    public class Endereco : BaseEntidade
    {
        public Coordenada Coordenada { get; set; }

        public Guid CoordenadaID { get; set; }

        public String IE { get; set; }

        public String Observacao { get; set; }

        public String Descricao { get; set; }

        public String Cep { get; set; }

        protected override void ExecuteValidation()
        {
            AddNotifications(Coordenada);
        }
    }
}
