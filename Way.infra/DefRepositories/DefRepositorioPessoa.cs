using System;
using System.Collections.Generic;
using System.Text;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;
using Way.Domain.Entities;
using Way.Domain.Interfaces.Repositories;
using Way.Domain.Resources;
using Way.infra.ManagerTables;
using Way.infra.Mapeadores;
using Way.infra.Persistencia;
using Way.infra.Utilitarios;

namespace Way.infra.DefRepositories
{
    public class DefRepositorioPessoa : BaseManagerTable<MapPessoa>, IPessoaRepositorio
    {
        public DefRepositorioPessoa(WayContext context) : base(context)
        {
            RealizaSet = true;
        }

        public PessoaRespost CadastrarPessoa(PessoaRequest pessoa)
        {
            if (pessoa.IdPessoa != Guid.Empty)
                return EditaPessoa(pessoa.IdPessoa, pessoa);

            DadosSessao StatusSessao = DefRepositorioUsuario.StatusSessao(pessoa.IdSessao, this.DBContext);

            if (StatusSessao == null) return new PessoaRespost() { IdSessao = Guid.Empty };

            Pessoa pessoaAdiciona = (Pessoa)pessoa;

            PessoaRespost Retorno = new PessoaRespost() { IdSessao = pessoa.IdSessao };
            if (pessoaAdiciona.ItsValid)
            {
                 
            }
            else
            {
                Retorno.ErrorMessage = String.Format(MensagensEntidades.ErroAoRealizarOperacao, Operacaoes.CadastroPessoa);
                Retorno.Alertas = pessoaAdiciona.Notifications;
                Retorno.DefineErro();
            }
            return Retorno;
        }

        public PessoaRespost EditaPessoa(Guid IdPessoa, PessoaRequest Pessoa)
        {
            throw new NotImplementedException();
        }

        public BaseArgumentos InativarPessoa(Guid IDPessoa)
        {
            throw new NotImplementedException();
        }

        public List<PessoaView> ListarPessoas(FiltroPessoa filtro)
        {
            throw new NotImplementedException();
        }
    }
}
