using System;

namespace Way.Domain.Entities
{
    public class Documento : BaseEntidade
    {
        public String ValorDocumento { get; set; }

        public Guid TipoDocumento { get; set; }
    }
}
