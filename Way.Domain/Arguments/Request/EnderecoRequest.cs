using System;
using Way.Domain.Entities;

namespace Way.Domain.Arguments.Request
{
    public class EnderecoRequest : BaseArgumentos
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String IE { get; set; }
        public String Observacao { get; set; }
        public String Descricao { get; set; }
        public String Cep { get; set; }
        public Guid IdEndereco { get; set; }

        public static explicit operator Endereco(EnderecoRequest Value)
        {
            Coordenada Coordenada = new Coordenada()
            {
                Ativo = Value.Ativo,
                Latitude = Value.Latitude,
                Longitude = Value.Longitude,
                Id = Value.IdEndereco
            };

            return new Endereco()
            {
                Coordenada = Coordenada,
                Id = Value.IdEndereco,
                Ativo = Value.Ativo,
                Cep = Value.Cep,
                Descricao = Value.Descricao,
                IE = Value.Descricao,
                Observacao = Value.Observacao
            };
        }
    }
}
