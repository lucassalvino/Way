using System;
using Way.Domain.Resources;

namespace Way.Domain.Entities
{
    public class Carne : BaseEntidade
    {
        public Pessoa Pessoa { get; set; }

        public int QuantidadeDeParcelas { get; set; }

        public DateTime DataVencimento { get; set; }

        public override void ExecuteValidation()
        {
            if (DataVencimento == null || DataVencimento == DateTime.MinValue)
                AddNotifications(String.Format(MensagensEntidades.DataDeveSerInformada, MensagensEntidades.DataVencimento));
            ValidIsNull(Pessoa, MensagensEntidades.PessoaResponsavelCarne);
            ValidItsBetween(QuantidadeDeParcelas, 0, int.MaxValue, MensagensEntidades.ParcelasCarnePositivas);
        }
    }
}
