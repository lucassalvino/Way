using System;
using Way.Domain.Entities;

namespace Way.Domain.Arguments.Request
{
    public class EmailRequest : BaseArgumentos
    {
        public String Endereco { get; set; }
        public Boolean Validado { get; set; }
        public Guid IdEmail { get; set; }

        public static explicit operator Email (EmailRequest Value)
        {
            return new Email()
            {
                Ativo = Value.Ativo,
                Endereco = Value.Endereco,
                Id = Value.IdEmail,
                Validado = Value.Validado
            };
        }
    }
}
