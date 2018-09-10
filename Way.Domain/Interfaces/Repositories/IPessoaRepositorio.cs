using System;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;

namespace Way.Domain.Interfaces.Repositories
{
    public interface IPessoaRepositorio
    {
        BaseArgumentos InativarPessoa(Guid IDPessoa);

        PessoaRespost CadastrarPessoa(PessoaRequest pessoa);

        List<PessoaView> ListarPessoas(FiltroPessoa filtro);

        PessoaRespost EditaPessoa(Guid IdPessoa, PessoaRequest Pessoa);
    }
}
