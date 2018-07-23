using System;
using System.ComponentModel.DataAnnotations;

namespace Way.infra.Mapeadores
{
    public class MapTipoDocumento : BaseMapEntidade
    {
        [MaxLength(20)]
        public String Descricao { get; set; }
    }
}
