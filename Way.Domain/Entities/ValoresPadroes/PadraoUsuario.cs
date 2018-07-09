using System;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class PadraoUsuario
    {
        public static Usuario Admin
        {
            get
            {
                return new Usuario()
                {
                    Ativo = true,
                    InstituicaoID = Guid.Empty,
                    Login = "admin",
                    Email = "lucassalvino1@gmail.com",
                    Senha = Util.HashSHA256("D26m04a03"),
                    Id = new Guid("365D3127-5924-4C83-9ADF-90483E9FD4F9")
                };
            }
        }
    }
}
