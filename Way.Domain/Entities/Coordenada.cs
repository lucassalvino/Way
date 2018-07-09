using Way.Domain.Resources;

namespace Way.Domain.Entities
{
    public class Coordenada : BaseEntidade
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Elevacao { get; set; }

        public override void ExecuteValidation()
        {
            ValidItsBetween(Latitude, -90, 90, string.Format(MensagensEntidades.Coordenada_Intervalo, MensagensEntidades.Latitude));
            ValidItsBetween(Longitude, -90, 90, string.Format(MensagensEntidades.Coordenada_Intervalo, MensagensEntidades.Longitude));
        }
    }
}
