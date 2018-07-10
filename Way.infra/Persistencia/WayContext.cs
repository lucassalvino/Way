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
        public DbSet<MapCaracterizacao> Caracterizacao { get; set; }
        public DbSet<MapTipoDocumento> TipoDocumento { get; set; }
        public DbSet<MapUsuario> Usuarios { get; set; }
        public DbSet<MapSessaoUsuario> SessaoUsuario{ get; set; }
        public DbSet<MapEmails> Emails{ get; set; }
        public DbSet<MapDocumento> Documentos { get; set; }
        #endregion
    }
}
/*
 * Abilita migration
 *          dotnet ef migrations add InitialUsuarioClear
 *           dotnet ef database update
 */
