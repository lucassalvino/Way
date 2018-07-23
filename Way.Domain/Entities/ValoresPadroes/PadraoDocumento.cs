using System;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class PadraoDocumento
    {
        public static Documento DocumentoPadraoWay
        {
            get
            {
                return new Documento()
                {
                    Ativo = true,
                    Id = new Guid("E33299B3-587A-4EEF-B543-D45F05736D9B"),
                    TipoDocumento = PadraoTipoDocumento.CPF,
                    ValorDocumento = "05744321160"
                };
            }
        }
    }
}
