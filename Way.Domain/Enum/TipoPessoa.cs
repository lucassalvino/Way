using System;

namespace Way.Domain.Enum
{
    public class TipoPessoa
    {
        public Guid Id { get; set; }
        public String Descricao { get; set; }

        private TipoPessoa(String Descricao, Guid Id)
        {
            this.Id = Id;
            this.Descricao = Descricao;
        }

        public static TipoPessoa Fisica { get { return new TipoPessoa("Física", new Guid("5c1dbf99-8353-44e7-ae71-299ee5b6d4c4")); } }
        public static TipoPessoa Juridica { get { return new TipoPessoa("Jurídica", new Guid ("ca79e09b-a66f-47b4-bd17-205fbf5fbef8")); } }
        public static TipoPessoa Aluno { get { return new TipoPessoa("Aluno", new Guid("ea48629a-e148-4737-85a0-a586a27da162")); } }
        public static TipoPessoa ResponsavelAluno { get { return new TipoPessoa("Responsável Aluno", new Guid("7fda1146-c9a0-442a-9132-5ca4dcfe096f")); } }
        public static TipoPessoa ResponsavelEscola { get { return new TipoPessoa("Responsável Escola", new Guid("b3be5b17-a881-4f47-a8ff-aaca9ecc77de")); } }
        public static TipoPessoa Motorista { get { return new TipoPessoa("Motorista", new Guid("8e347e41-901c-49f8-9bac-1bc6f6abb81c")); } }
        public static TipoPessoa Escola { get { return new TipoPessoa("Escola",new Guid("a357ad68-b68e-4615-a233-65d6b25ab21b")); } }
        public static TipoPessoa EmpresaTransporte { get { return new TipoPessoa("Empresa Transporte", new Guid("a357ad68-b68e-4615-a233-65d6b25ab21b")); } }
    }
}
