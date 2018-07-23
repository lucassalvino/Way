using System;
using System.Collections.Generic;

namespace Way.Domain.Entities.ValoresPadroes
{
    public class PadraoPessoa
    {
        public static Pessoa SystemsWay
        {
            get
            {
                return new Pessoa()
                {
                    Ativo = true,
                    Caracterizacoes = new List<Guid>() { PadraoCaracterizacao.Empresa, PadraoCaracterizacao.Aluno, PadraoCaracterizacao.Responsavel, PadraoCaracterizacao.Motorista },
                    DataCadastro = DateTime.Now,
                    DataNascimento = DateTime.Now,
                    Id = new Guid("4832C50F-280C-4EB0-8CFB-D98E99245CA0"),
                    PrimeiroNome = "Systems Way",
                    UltimoNome = "Tecnologia em roterização",
                    Site = "www.systemsway.com.br",
                    Enderecos = new List<Endereco>() { EnderecoPadrao.EnderecoWay },
                    Emails = new List<Email> { PadraoEmail.EmailSystemWay },
                    Documentos = new List<Documento>() { PadraoDocumento.DocumentoPadraoWay }
                };
            }
        }
    }
}
