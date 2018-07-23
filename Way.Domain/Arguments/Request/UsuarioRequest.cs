using System;
using Way.Domain.Entities;

namespace Way.Domain.Arguments.Request
{
    public class UsuarioRequest: BaseArgumentos
    {
        public String Login { get; set; }
        public String Senha { get; set; }
        public String ReSenha { get; set; }
        public String Email { get; set; }
        public String Nome { get; set; }
        public Boolean Ativo { get; set; }
        public Guid IdUsuario { get; set; }

        public static explicit operator Usuario(UsuarioRequest Value)
        {
            return new Usuario()
            {
                Ativo = Value.Ativo,
                Email = Value.Email,
                Senha = Value.Senha,
                Login = Value.Login,
                Nome = Value.Nome,
                Id = Guid.Empty,
                RESenha = Value.ReSenha,
                VerificaSenha = true
            };
        }
    }
}
