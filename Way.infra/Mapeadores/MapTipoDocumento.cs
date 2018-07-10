using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Way.infra.Mapeadores
{
    public class MapTipoDocumento : BaseMapEntidade
    {
        [MaxLength(20)]
        public String Descricao { get; set; }
    }
}
