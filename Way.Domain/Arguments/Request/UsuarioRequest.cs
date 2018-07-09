using System;

namespace Way.Domain.Arguments.Request
{
    public class UsuarioRequest: BaseArgumentos
    {
        public String Usuario { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
    }
}
