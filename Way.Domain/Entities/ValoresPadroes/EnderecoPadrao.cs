using System;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class EnderecoPadrao
    {
        public static Endereco EnderecoWay
        {
            get
            {
                return new Endereco()
                {
                    Ativo = true,
                    Cep = "75380261",
                    Descricao = "Rua Aliança do norte",
                    Observacao = "Qd. 53, Lt. 16",
                    Id = new Guid("8EE9836F-10AF-44C3-81FA-177E6C5BA84C"),
                    IE = "ISENTO",
                    Coordenada = new Coordenada()
                    {
                        Ativo = true,
                        Latitude = -16.630793,
                        Longitude = -49.390084,
                        Id = new Guid("26F004B6-481A-4E9D-A3E0-A1B3301527AA")
                    }
                };
            }
        }
    }
}
