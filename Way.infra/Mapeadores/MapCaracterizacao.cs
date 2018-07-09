using System.ComponentModel.DataAnnotations;

namespace Way.infra.Mapeadores
{
    public class MapCaracterizacao : BaseMapEntidade
    {
        [MaxLength(50)]
        [Required]
        public string Descricao { get; set; }
    }
}
