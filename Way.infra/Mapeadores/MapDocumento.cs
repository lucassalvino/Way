using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class MapDocumento : BaseMapEntidade
    {
        [MaxLength(30)]
        public String Documento { get; set; }

        public Guid TipoDocumentoID { get; set; }

        [ForeignKey("TipoDocumentoID")]
        public MapTipoDocumento TipoDocumento { get; set; }

        public Guid PessoaID { get; set; }

        [ForeignKey("PessoaID")]
        public MapPessoa Pessoa { get; set; }

        public static explicit operator MapDocumento(Documento value)
        {
            VerificaNotificacoes(value);
            return new MapDocumento() {
                Ativo = value.Ativo,
                Documento = value.ValorDocumento,
                Id = value.Id,
                PessoaID = value.Pessoa,
                TipoDocumentoID = value.TipoDocumento
            };
        }
    }
}
