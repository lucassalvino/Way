using System;
 
namespace Way.Domain.Entities
{
    public class SessaoUsuario : BaseEntidade
    {
        public Usuario Usuario { get; set; }

        public DateTime InicioSessao { get; set; }

        public Guid UsuarioId { get; set; }

        public override void ExecuteValidation()
        {
            if (Usuario == null && (UsuarioId == null || UsuarioId == Guid.Empty))
                AddNotifications("Não é possível criar uma sessão sem um usuário");

            if (InicioSessao == DateTime.MinValue)
                AddNotifications("Uma falha aconteceu ao setar a data do inicio da sessão");
        }
    }
}
