using System;
using Way.Domain.Entities;

namespace Way.Domain.Arguments.Request
{
    public class DocumentosRequest : BaseArgumentos
    {
        public String ValorDocumento { get; set; }
        public Guid TipoDoDocumento { get; set; }
        public Guid IdDocumento { get; set; }

        public static explicit operator Documento (DocumentosRequest Value)
        {
            return new Documento()
            {
                Ativo = Value.Ativo,
                Id = Value.IdDocumento,
                TipoDocumento = Value.TipoDoDocumento,
                ValorDocumento = Value.ValorDocumento
            };
        }
    }
}
