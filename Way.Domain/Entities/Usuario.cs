using System;
using Way.Domain.Resources;

namespace Way.Domain.Entities
{
    public class Usuario : BaseEntidade
    {
        public String Login { get; set; }
        public String Senha { get; set; }
        public String RESenha { get; set; }
        public String Email { get; set; }
        public String Nome { get; set; }
        public Pessoa Instituicao { get; set; }

        public Guid InstituicaoID { get; set; }

        public Boolean VerificaSenha { get; set; }

        protected override void ExecuteValidation()
        {
            if (VerificaSenha)
            {
                if (string.IsNullOrEmpty(Senha))
                    AddNotifications(MensagensEntidades.SenhaObrigatoria);

                if (Senha.Length < 6)
                    AddNotifications(MensagensEntidades.TamanhoSenhaIncorreto);

                if (!Senha.Equals(RESenha))
                    AddNotifications(MensagensEntidades.SenhaDivergente);
            }

            this.ValidEmail(Email, MensagensEntidades.EmailInvalido);

            if (string.IsNullOrEmpty(Login))
                AddNotifications(MensagensEntidades.LoginObrigatorio);
        }
    }
}
