using System;
using Way.Domain.Resources;

namespace Way.Domain.Entities
{
    public class Usuario : BaseEntidade
    {
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public Pessoa Instituicao { get; set; }

        public Guid InstituicaoID { get; set; }

        public override void ExecuteValidation()
        {
            if (string.IsNullOrEmpty(Senha))
                AddNotifications(MensagensEntidades.SenhaObrigatoria);

            if (string.IsNullOrEmpty(Login))
                AddNotifications(MensagensEntidades.LoginObrigatorio);
        }
    }
}
