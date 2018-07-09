using Microsoft.EntityFrameworkCore;
using System.Linq;
using Way.Domain.Entities;
using Way.Domain.Entities.ValoresPadroes;
using Way.infra.Mapeadores;
using Way.infra.Persistencia;
using Xunit;

namespace Way.Testes
{
    public class BaseTests
    {
        private WayContext _context = null;

        public WayContext DbContext
        {
            get
            {
                if (_context == null)
                {
                    var optionsBase = new DbContextOptionsBuilder<WayContext>();
                    optionsBase.UseInMemoryDatabase("BaseTestesWay");
                    _context = new WayContext(optionsBase.Options);
                    InicializaBase.InicializaDadosPadroes(_context);
                }
                return _context;
            }
        }

        [Fact]
        public void VerificaDadosDefault()
        {
            #region Usuario
            MapUsuario Usuario = (from user in DbContext.Usuarios
                               where user.Id == PadraoUsuario.Admin.Id
                               select user).FirstOrDefault();

            Usuario UsuarioEsperado = PadraoUsuario.Admin;
            Assert.Equal(UsuarioEsperado.Email, Usuario.Email);
            Assert.Equal(UsuarioEsperado.Id, Usuario.Id);
            Assert.Equal(UsuarioEsperado.Login, Usuario.Login);
            Assert.Equal(UsuarioEsperado.Senha, Usuario.Senha);
            #endregion
        }
    }
}
