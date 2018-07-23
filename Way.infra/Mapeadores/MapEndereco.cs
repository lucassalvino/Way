using System;
using System.ComponentModel.DataAnnotations.Schema;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapEndereco : BaseMapEntidade
    {
        public String IE { get; set; }
        public String Observacao { get; set; }
        public String Descricao { get; set; }
        public String Cep { get; set; }


        public Guid CoordenadaID { get; set; }
        [ForeignKey("CoordenadaID")]
        public MapCoordernada Coordenada {get; set;}

        public static explicit operator MapEndereco(Endereco Value)
        {
            if (Value.Coordenada != null)
                VerificaNotificacoes(Value.Coordenada);
            return new MapEndereco()
            {
                IE = Value.IE,
                Ativo = Value.Ativo,
                Cep = Value.Cep,
                Coordenada = (MapCoordernada)Value.Coordenada,
                CoordenadaID = Value.CoordenadaID,
                Descricao = Value.Descricao,
                Id = Value.Id,
                Observacao = Value.Observacao
            };
        }
    }
}
