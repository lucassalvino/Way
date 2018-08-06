using System;
using System.Collections.Generic;
using System.Text;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;

namespace Way.Domain.Interfaces.Repositories
{
    public interface IPessoaRepositorio
    {
        void InativarPessoa(Guid IDPessoa);

        PessoaRespost CadastrarPessoa(PessoaRequest pessoa);
    }
}
