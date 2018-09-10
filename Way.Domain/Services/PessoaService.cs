using System;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;
using Way.Domain.Interfaces.Repositories;
using Way.Domain.Interfaces.Services;

namespace Way.Domain.Services
{
    public class PessoaService: BaseService , IPessoaService
    {
        private IPessoaRepositorio _pessoaRepositorio;

        public PessoaService (IPessoaRepositorio PessoaRepositorio)
        {
            if (PessoaRepositorio == null)
                throw new Exception("Definição de repositório é obrigatório");
            _pessoaRepositorio = PessoaRepositorio;
        }

        public PessoaRespost CadastraPessoa(PessoaRequest Pessoa)
        {
            return _pessoaRepositorio.CadastrarPessoa(Pessoa);
        }

        public BaseArgumentos EditaPessoa(Guid IdPessoa, PessoaRequest Pessoa)
        {
            return _pessoaRepositorio.EditaPessoa(IdPessoa, Pessoa);
        }

        public BaseArgumentos InativarPessoa(Guid IdPessoa)
        {
            return _pessoaRepositorio.InativarPessoa(IdPessoa);
        }

        public List<PessoaView> ListarPessoas(FiltroPessoa Filtro)
        {
            return _pessoaRepositorio.ListarPessoas(Filtro);
        }
    }
}
