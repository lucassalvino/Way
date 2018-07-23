using System;
using System.Collections.Generic;
using System.Text;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class PadraoEmail
    {
        public static Email EmailSystemWay
        {
            get
            {
                return new Email
                {
                    Ativo = true,
                    Endereco = "lucassalvino1@gmail.com",
                    Validado = true,
                    Id = new Guid("57E002C6-0607-4FB7-83A3-9936542ABAF0")
                };
            }
        }
    }
}
