using System;
using System.ComponentModel.DataAnnotations;
using Way.Domain.Entities;

namespace Way.infra.Mapeadores
{
    public class BaseMapEntidade
    {
        [Key]
        public Guid Id { get; set; }

        public Boolean Ativo { get; set; }

        public static explicit operator BaseMapEntidade (BaseEntidade value)
        {
            if (value == null)
                throw new Exception("O valor é nulo. Falha ao gerar ao gerar cast");

            if (value.GetType() != typeof(BaseMapEntidade))
                throw new Exception("Não é garantia de cast. Por favor verifique se a operação está correta");

            return new BaseMapEntidade()
            {
                Ativo = value.Ativo,
                Id = value.Id
            };
        }

        public static void VerificaNotificacoes( BaseEntidade value)
        {
            if (value == null)
                throw new Exception("A entidade é nula");

            if (!value.ItsValid) {
                throw new Exception($"O objeto do tipo [{value.GetType().ToString()}] possui [{value.GetNumberOfNotifications}] notificações. O mapeamento do mesmo para a unidade de banco não será realizado");
            }
            return;
        }
    }
}
