using System.Linq;
using Way.Domain.Entities;
using Way.Domain.Entities.ValoresPadroes;
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
        }
    }
}
