using System;
using Way.Domain.Resources;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class PadraoTipoDocumento
    {
        public static Guid CPF
        {
            get
            {
                return new Guid("439376A6-7362-4459-B7C4-3C55D159450F");
            }
        }

        public static Guid CNPJ
        {
            get
            {
                return new Guid("6EB330AC-987F-4D64-8473-0276663EEEFC");
            }
        }

        public static Guid CNH
        {
            get
            {
                return new Guid("ACCED9F6-29E8-4309-B99C-8A0937A5CB55");
            }
        }
        public static string DescricaoTipoDocumento(Guid TipoDocumento)
        {
            String GuidDf = TipoDocumento.ToString().ToUpper();

            if (GuidDf.Equals(CPF.ToString().ToUpper()))
                return DescricaoTabelasPadroes.TipoDocumentoCPF;

            if (GuidDf.Equals(CNPJ.ToString().ToUpper()))
                return DescricaoTabelasPadroes.TipoDocumentoCNPJ;

            if (GuidDf.Equals(CNH.ToString().ToUpper()))
                return DescricaoTabelasPadroes.TipoDocumentoCNH;

            return String.Empty;
        }
    }
}
