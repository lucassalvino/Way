using System;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;

namespace Way.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        PessoaRespost CadastraPessoa(PessoaRequest Pessoa);

        BaseArgumentos EditaPessoa(Guid IdPessoa, PessoaRequest Pessoa);

        BaseArgumentos InativarPessoa(Guid IdPessoa);

        List<PessoaView> ListarPessoas(FiltroPessoa Filtro);
    }
}
