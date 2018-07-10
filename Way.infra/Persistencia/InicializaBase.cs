using System.Linq;
using Way.Domain.Entities;
using Way.Domain.Entities.ValoresPadroes;
using Way.Domain.Resources;
using Way.infra.Mapeadores;

namespace Way.infra.Persistencia
{
    public class InicializaBase
    {
        public static void InicializaDadosPadroes(WayContext context)
        {
            Usuario adm = PadraoUsuario.Admin;
            if (!context.Usuarios.Any())
                context.Usuarios.Add((MapUsuario)adm);
            context.SaveChanges();

            #region Caracterizacao
            if (!context.Caracterizacao.Any())
            {
                context.Caracterizacao.Add(new MapCaracterizacao()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.CaracterizacaoFisica,
                    Id = PadraoCaracterizacao.Fisica
                });
                context.Caracterizacao.Add(new MapCaracterizacao()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.CaracterizacaoJuridica,
                    Id = PadraoCaracterizacao.Juridica
                });
                context.Caracterizacao.Add(new MapCaracterizacao()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.CaracterizacaoEmpresa,
                    Id = PadraoCaracterizacao.Empresa
                });
                context.Caracterizacao.Add(new MapCaracterizacao()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.CaracterizacaoAluno,
                    Id = PadraoCaracterizacao.Aluno
                });
                context.Caracterizacao.Add(new MapCaracterizacao()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.CaracterizacaoMotorista,
                    Id = PadraoCaracterizacao.Motorista
                });
                context.Caracterizacao.Add(new MapCaracterizacao()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.CaracterizacaoResponsavel,
                    Id = PadraoCaracterizacao.Responsavel
                });
                context.SaveChanges();
            }
            #endregion

            #region Tipo Documento
            if (!context.TipoDocumento.Any())
            {
                context.TipoDocumento.Add(new MapTipoDocumento()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.TipoDocumentoCPF,
                    Id = PadraoTipoDocumento.CPF
                });

                context.TipoDocumento.Add(new MapTipoDocumento()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.TipoDocumentoCNPJ,
                    Id = PadraoTipoDocumento.CNPJ
                });

                context.TipoDocumento.Add(new MapTipoDocumento()
                {
                    Ativo = true,
                    Descricao = DescricaoTabelasPadroes.TipoDocumentoCNH,
                    Id = PadraoTipoDocumento.CNH
                });

                context.SaveChanges();
            }
            #endregion

            #region Pessoa
            
            #endregion
        }
    }
}
