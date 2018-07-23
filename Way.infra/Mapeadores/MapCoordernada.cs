using System;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapCoordernada : BaseMapEntidade
    {
        public Double Latitude { get; set; }

        public Double Longitude { get; set; }

        public static explicit operator MapCoordernada(Coordenada value)
        {
            if (value == null) return null;
            VerificaNotificacoes(value);

            return new MapCoordernada()
            {
                Ativo = value.Ativo,
                Id = value.Id,
                Latitude = value.Latitude,
                Longitude = value.Longitude
            };
        }
    }
}
