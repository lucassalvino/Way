using Microsoft.EntityFrameworkCore;
using Way.infra.Mapeadores;

namespace Way.infra.Persistencia
{
    public class WayContext : DbContext
    {
        public WayContext(DbContextOptions<WayContext> options) : base(options){
        }

        public void Configure()
        {
            InicializaBase.InicializaDadosPadroes(this);
        }

        #region DBSets
        public DbSet<MapUsuario> Usuarios { get; set; }
        public DbSet<MapSessaoUsuario> SessaoUsuario{ get; set; }
        #endregion
    }
}
/*
 * Abilita migration
 *          dotnet ef migrations add InitialUsuarioClear
 *           dotnet ef database update
 */
