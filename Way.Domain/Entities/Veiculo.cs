using System;
using Way.Domain.Resources;

namespace Way.Domain.Entities
{
    public class Veiculo : BaseEntidade
    {
        public String Marca { get; set; }

        public String Modelo { get; set; }

        public String RENAVAM { get; set; }

        public String Placa { get; set; }

        public int Ano { get; set; }

        public String Cor { get; set; }

        public override void ExecuteValidation()
        {
            if (string.IsNullOrEmpty(Marca))
                AddNotifications(MensagensEntidades.MarcaVeicuiloObrigatorio);
            if (string.IsNullOrEmpty(Modelo))
                AddNotifications(MensagensEntidades.ModeloVeiculoObrigatorio);
            if (string.IsNullOrEmpty(Placa))
                AddNotifications(MensagensEntidades.PlacaVeiculoObrigatoria);
            if (Ano <= 0)
                AddNotifications(MensagensEntidades.AnoFabricacaoVeiculoInvalido);
        }
    }
}
